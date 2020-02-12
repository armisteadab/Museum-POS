Imports System.Data.SqlClient
Imports IngenicoPOS
Public Class POSMain
    Dim nReceiptNumber As Integer
    Private nReceiptCurrent As Integer
    Private bSearchReady As Boolean

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        Dim fInventoryItem As New InventoryItem
        fInventoryItem.ShowDialog()
        fInventoryItem = Nothing

    End Sub

    Private Sub POSMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewReceiptID()
    End Sub

    Private Sub NewReceiptID()
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT Max(ReceiptID) as MaxID, Count(ReceiptID) as CountID from Receipt"
        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

            If reader.HasRows Then
            reader.Read()
            nReceiptCurrent = 0 + reader.Item("MaxID")
        End If

        nReceiptCurrent += 1
        Me.ReceiptNumber = (nReceiptCurrent)
        reader.Close()

        sqlConnect.Close()

    End Sub

    Public Property ReceiptNumber() As Integer
        Get
            Return nReceiptNumber
        End Get
        Set(ByVal value As Integer)
            lblReceiptNumber.Text = value.ToString.Trim
            nReceiptNumber = (value)

        End Set
    End Property

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim oPos As New POS(1)
        oPos.CashierID = "1"
        oPos.CurrencyISO = 840
        oPos.Language = "English"
        oPos.Connect()

        If Not oPos.IsConnected Then
            Exit Sub
        End If

        If oPos.Sale(199).Success Then
            MsgBox("success")
        End If

        oPos.Disonnect()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Not DataGridView2.Visible Then ' allow user to use keys to select item from search list
            txtEntry.Focus()
        Else
            txtEntry.Enabled = False
        End If

    End Sub

    Private Sub DoSearch()
        Dim sEntry As String, bIsNumeric As Boolean

        sEntry = txtEntry.Text.Trim
        bIsNumeric = IsNumeric(sEntry)

        If sEntry.Length >= 2 Then
            ' something to search for
            RunSearch(bIsNumeric)
        Else
            DataGridView2.Visible = False
        End If

    End Sub
    Private Sub RunSearch(ByVal bIsNumeric As Boolean)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String, sSearchLikeValue$

        If txtEntry.Text.Trim.Length = 0 Then Exit Sub

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSearchLikeValue = QLike(txtEntry.Text)
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        sSQL = "SELECT Id, InvUPC, InvName, InvType, Vendor, Department, InvPrice, InvCost, OnHandQuantity, InvNotes, UniqueID, TaxRate FROM InventoryItems"

        If Not bIsNumeric Then
            sSQL += " WHERE InvName LIKE " & sSearchLikeValue
        Else
            sSQL += " WHERE InvUPC LIKE " & sSearchLikeValue
            If sSearchLikeValue.Length < 12 Then
                sSQL += " OR Id LIKE " & sSearchLikeValue
            End If
        End If


        cmd.CommandText = sSQL
        cmd.Connection = sqlConnect
        ' Create a SqlParameter for each parameter in the stored procedure.

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State
        Dim nPriceDisplayGrid As Double, sPriceDisplayGrid As String
        Dim nTaxRate As Double

        Me.DataGridView2.Rows.Clear()

        Try
            If sqlConnect.State = ConnectionState.Closed Then
                sqlConnect.Open()
            End If
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    ' Process SprocResults datareader here.
                    nPriceDisplayGrid = reader.Item("InvPrice")
                    sPriceDisplayGrid = Strings.FormatNumber(reader.Item("InvPrice"), 2)

                    If Not IsDBNull(reader.Item("TaxRate")) Then
                        nTaxRate = reader.Item("TaxRate")
                    Else
                        nTaxRate = 0
                    End If
                    Me.DataGridView2.Rows.Add(reader.Item("InvName"), reader.Item("InvType"), reader.Item("Department"),
                                              reader.Item("Vendor"), sPriceDisplayGrid, reader.Item("InvCost"),
                                              reader.Item("OnHandQuantity"), reader.Item("Id"), reader.Item("InvUPC"), reader.Item("UniqueID"), nTaxRate)
                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

        If DataGridView2.Rows.Count > 1 Then
            DataGridView2.Visible = True
            DataGridView2.Focus()
            '       Me.DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.Rows.Count - 1))
        ElseIf DataGridView2.Rows.Count = 1 Then
            PickFIRSTFromSearch()
            DataGridView2.Visible = False
        End If


    End Sub

    Private Sub txtEntry_TextChanged(sender As Object, e As EventArgs) Handles txtEntry.TextChanged
        DataGridView2.Visible = False
        bSearchReady = True ' new search now possible
        If txtEntry.TextLength > 11 And IsNumeric(txtEntry.Text) Then ' complete UPC
            DoSearch()
        End If

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        PickFromSearch()
    End Sub

    Private Sub PickFromSearch()

        Dim sInvUPC$, sNameItem$, sPrice$, sTaxRate$

        sInvUPC = ("" & DataGridView2.Item(8, DataGridView2.CurrentRow.Index).Value)
        sNameItem = ("" & DataGridView2.Item(0, DataGridView2.CurrentRow.Index).Value)
        sPrice = ("" & DataGridView2.Item(4, DataGridView2.CurrentRow.Index).Value)
        sTaxRate = ("" & DataGridView2.Item(10, DataGridView2.CurrentRow.Index).Value)

        Me.DataGridView1.Rows.Add(sNameItem.Trim, "1", sPrice, sInvUPC.Trim, sTaxRate)
        DataGridView2.Visible = False ' selection made, clear the area
        txtEntry.Text = ""  ' clear
        txtEntry.Enabled = True


    End Sub

    Private Sub PickFIRSTFromSearch()

        Dim sInvUPC$, sNameItem$, sPrice$, sTaxRate$

        sInvUPC = ("" & DataGridView2.Item(8, 0).Value)
        sNameItem = ("" & DataGridView2.Item(0, 0).Value)
        sPrice = ("" & DataGridView2.Item(4, 0).Value)
        sTaxRate = ("" & DataGridView2.Item(10, 0).Value)

        Me.DataGridView1.Rows.Add(sNameItem.Trim, "1", sPrice, sInvUPC.Trim, sTaxRate)
        DataGridView2.Visible = False ' selection made, clear the area
        txtEntry.Text = ""  ' clear
        txtEntry.Enabled = True


    End Sub

    Private Sub DataGridView2_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView2.KeyUp
        If e.KeyCode = Keys.Enter Then
            PickFromSearch()
        End If

        If e.KeyCode = Keys.Escape Then ' abandon this operation
            DataGridView2.Visible = False ' selection not made, clear the area
            txtEntry.Enabled = True

        End If
    End Sub

    Private Sub numQuantityAdjust_Leave(sender As Object, e As EventArgs)

        '        numQuantityAdjust.Visible = False

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim nQuantity As Integer, nPriceModify As Double
        Dim nTaxAdjust As Double
        If e.RowIndex < 0 Then Exit Sub

        Select Case e.ColumnIndex

            Case 1

                Dim fQuantity As New Quantity
                nQuantity = ("" & DataGridView1.Item(1, e.RowIndex).Value)
                fQuantity.numQuantityAdjust.Value = nQuantity
                fQuantity.ShowDialog()
                nQuantity = fQuantity.numQuantityAdjust.Value ' get value
                fQuantity = Nothing
                DataGridView1.Item(1, e.RowIndex).Value = (nQuantity)
                GridTotals()

            Case 2

                Dim fPriceModify As New PriceModify
                nPriceModify = ("" & DataGridView1.Item(2, e.RowIndex).Value)
                fPriceModify.OriginalPrice = nPriceModify
                fPriceModify.ShowDialog()
                nPriceModify = fPriceModify.numPriceModify.Value ' get value
                fPriceModify = Nothing
                DataGridView1.Item(2, e.RowIndex).Value = Format(nPriceModify, "###0.00")
                GridTotals()

            Case 4

                Dim fTaxAdjust As New TaxAdjust
                nTaxAdjust = ("" & DataGridView1.Item(4, e.RowIndex).Value)
                fTaxAdjust.numTaxRate.Value = (nTaxAdjust)
                fTaxAdjust.ShowDialog()
                nTaxAdjust = fTaxAdjust.numTaxRate.Value ' get value
                fTaxAdjust = Nothing
                DataGridView1.Item(4, e.RowIndex).Value = Format(nTaxAdjust, "###0.00")
                GridTotals()

            Case 5
                Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)
        End Select

    End Sub

    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyCode = Keys.Delete Then
            Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)
        End If
    End Sub

    Private Sub txtEntry_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEntry.KeyUp
        If e.KeyCode = Keys.Enter Then
            DoSearch()
        End If
    End Sub

    Private Sub DataGridView2_MouseLeave(sender As Object, e As EventArgs) Handles DataGridView2.MouseLeave
        DataGridView2.Visible = False ' selection not made, clear the area
        txtEntry.Enabled = True
    End Sub

    Private Sub btnAdult_Click(sender As Object, e As EventArgs) Handles btnAdult.Click

        txtEntry.Text = StrDup(12, "1")  '"111111111111"
        RunSearch(True)

    End Sub

    Private Sub btnChild_Click(sender As Object, e As EventArgs) Handles btnChild.Click

        txtEntry.Text = StrDup(12, "2")  '""
        RunSearch(True)

    End Sub

    Private Sub btnAAAMilAdult_Click(sender As Object, e As EventArgs) Handles btnAAAMilAdult.Click

        txtEntry.Text = StrDup(12, "3")  '""
        RunSearch(True)
    End Sub

    Private Sub btnAdultGroup_Click(sender As Object, e As EventArgs) Handles btnAdultGroup.Click
        txtEntry.Text = StrDup(12, "4")  '""
        RunSearch(True)

    End Sub

    Private Sub btnChildGroup_Click(sender As Object, e As EventArgs) Handles btnChildGroup.Click
        txtEntry.Text = StrDup(12, "5")  '""
        RunSearch(True)

    End Sub

    Private Sub GridTotals()
        Dim sQuantity As String, sPrice As String, nQuantity As Integer, nPrice As Double
        Dim nRowsToSum As Integer, nRow As Integer
        Dim nTotal As Double, nTaxRate As Double, nItemTotal As Double

        If DataGridView1.Rows.Count < 1 Then
            lblReceiptTotal.Text = "0.00"
            btnDone.Enabled = False
            Exit Sub
        End If

        If IsDBNull(DataGridView1.Item(2, nRow).Value) Then Exit Sub

        nTotal = 0
        nRowsToSum = (DataGridView1.Rows.Count - 1)
        For nRow = 0 To nRowsToSum
            nTaxRate = (DataGridView1.Item(4, nRow).Value)
            nTaxRate = nTaxRate / 100
            sPrice = ("" & DataGridView1.Item(2, nRow).Value)
            sQuantity = ("" & DataGridView1.Item(1, nRow).Value)
            nPrice = Val(sPrice)
            nQuantity = Int(Val(sQuantity))
            nItemTotal = (nPrice * nQuantity)
            nItemTotal += (nItemTotal * nTaxRate)
            nTotal += (nItemTotal)
        Next


        lblReceiptTotal.Text = (Format(nTotal, "####0.00"))

        If nTotal = 0 Then ' there are rows and they end up at zero (payment made)
            btnDone.Enabled = True
        End If
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        GridTotals()
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        GridTotals()
    End Sub

    Private Sub POSMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        DataGridView1.Width = (Me.Width - DataGridView1.Left) - 25
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand

        Dim sInvUPC$, sNameItem$, sPrice$, sTaxRate$
        Dim nRow As Integer, sQuantity As String
        Dim nTaxRate As Double, nPrice As Double, nTaxedAmount As Double
        Dim nRowFinal As Integer

        nRowFinal = DataGridView1.Rows.Count - 1

        If nRowFinal < 0 Then Exit Sub

        For nRow = 0 To nRowFinal
            sInvUPC = ("" & DataGridView1.Item(3, nRow).Value)
            sNameItem = ("" & DataGridView1.Item(0, nRow).Value)
            sPrice = ("" & DataGridView1.Item(2, nRow).Value)
            sQuantity = ("" & DataGridView1.Item(1, nRow).Value)
            sTaxRate = ("" & DataGridView1.Item(4, nRow).Value)

            'convert some values to numerics for taxed amount calc
            nTaxRate = CDbl(sTaxRate)
            nPrice = CDbl(sPrice)
            nTaxRate = nTaxRate / 100
            nTaxedAmount = (nPrice * nTaxRate)

            sqlString = "INSERT INTO Receipt(UPC, Price, Paid, TaxPaid, ReceiptID, Quantity) "
            sqlString += " VALUES ("
            sqlString = sqlString & QTrim(sInvUPC) & "," & (sPrice) & "," & (sPrice) & "," & nTaxedAmount.ToString & ","
            sqlString = sqlString & Me.ReceiptNumber & "," & sQuantity
            sqlString = sqlString & ")"

            Try

                sqlConnect1.Open()
                commandSQL1 = New SqlCommand(sqlString, sqlConnect1)
                'commandSQL1.CommandType = CommandType.Text
                commandSQL1.ExecuteNonQuery()
                commandSQL1.Dispose()
                sqlConnect1.Close()

            Catch ex As ArgumentException
                MsgBox("" & ex.Message)

            Finally

            End Try
            Debug.Print(sqlString)
        Next nRow

        Me.ReceiptNumber = (Me.ReceiptNumber + 1)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        btnDone.Enabled = True
    End Sub
End Class