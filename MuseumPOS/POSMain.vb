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

        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection(), sConnectionString$
        Dim nReceiptCount As New Integer

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString
        sqlConnect.Open()

        Dim commandSQL As SqlCommand
        Dim bAnyRecordsAtAll As Boolean

        commandSQL = New SqlCommand()
        commandSQL.CommandType = CommandType.Text
        commandSQL.CommandText = "SELECT Count(ReceiptID) as CountID from Receipt"
        commandSQL.Connection = sqlConnect

        Dim reader = commandSQL.ExecuteReader()
        Try
            If reader.HasRows Then
                ' nReceiptCount = 0 + reader.Item("CountID")
                bAnyRecordsAtAll = (nReceiptCount > 0)
            End If
        Catch ex As ArgumentException

        End Try

        If bAnyRecordsAtAll Then
            sqlString = "SELECT Max(ReceiptID) as MaxID, Count(ReceiptID) as CountID from Receipt"
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            Try
                If reader.HasRows Then
                    nReceiptCurrent = 0 + reader.Item("MaxID")
                    bAnyRecordsAtAll = True
                End If
            Catch ex As ArgumentException

            End Try
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
        oPos.Connect()

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

        If sEntry.Length >= 4 Then
            ' something to search for
            RunSearch(bIsNumeric)
        Else
            DataGridView2.Visible = False
        End If

    End Sub
    Private Sub RunSearch(ByVal bIsNumeric As Boolean)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String, sSearchLikeValue$

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString
        sSearchLikeValue = QLike(txtEntry.Text)
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        sSQL = "SELECT Id, InvUPC, InvName, InvType, Vendor, Department, InvPrice, InvCost, OnHandQuantity, InvNotes, UniqueID FROM InventoryItems"

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

                    Me.DataGridView2.Rows.Add(reader.Item("InvName"), reader.Item("InvType"), reader.Item("Department"),
                                              reader.Item("Vendor"), sPriceDisplayGrid, reader.Item("InvCost"),
                                              reader.Item("OnHandQuantity"), reader.Item("Id"), reader.Item("InvUPC"), reader.Item("UniqueID"))
                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

        If DataGridView2.Rows.Count > 0 Then
            DataGridView2.Visible = True
            DataGridView2.Focus()
            '       Me.DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.Rows.Count - 1))
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

        Dim sInvUPC$, sNameItem$, sPrice$

        sInvUPC = ("" & DataGridView2.Item(8, DataGridView2.CurrentRow.Index).Value)
        sNameItem = ("" & DataGridView2.Item(0, DataGridView2.CurrentRow.Index).Value)
        sPrice = ("" & DataGridView2.Item(4, DataGridView2.CurrentRow.Index).Value)

        Me.DataGridView1.Rows.Add(sNameItem.Trim, "1", sPrice, sInvUPC.Trim)
        DataGridView2.Visible = False ' selection made, clear the area
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub numQuantityAdjust_Leave(sender As Object, e As EventArgs)

        '        numQuantityAdjust.Visible = False

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim nQuantity As Integer
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex <> 1 Then Exit Sub

        Dim fQuantity As New Quantity
        nQuantity = ("" & DataGridView1.Item(1, e.RowIndex).Value)
        fQuantity.numQuantityAdjust.Value = nQuantity
        fQuantity.ShowDialog()
        nQuantity = fQuantity.numQuantityAdjust.Value ' get value
        fQuantity = Nothing
        DataGridView1.Item(1, e.RowIndex).Value = (nQuantity)

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
End Class