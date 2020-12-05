Imports System.Data.SqlClient
Imports IngenicoPOS
Imports Ingenico
Imports System.IO
Imports Microsoft.Reporting
Imports MuseumPOS.My
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing
Imports System.Xml
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Threading
Imports Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel

Public Class POSMain
    Dim nReceiptNumber As Integer
    Private nReceiptCurrent As Integer
    Private nReceiptLatest As Integer ' highest #
    Private bSearchReady As Boolean
    Private nSumPriceItems As Double, LatestReturnNumber As Integer
    Private bReceiptMarkedPaid As Boolean, bManagerMode As Boolean
    Const sReceiptPath As String = "C:\Users\armis\Documents\receipt.txt"
    Private btxtReceiptNumber_EnterKeyPressed As Boolean
    Private sInitial_txtReceiptNumber As String, nManagerWarningCounter As Integer
    Private sUPCButton(0 To 8) As String
    Private sItemNameButton(0 To 8) As String
    Private sItemPriceButton(0 To 8) As String
    Private sItemTaxButton(0 To 8) As String



    Private Sub ShowTicketsSoldToday()
        lblTicketSum.Text = Format(GetSumTicketsByDate(Today.ToShortDateString), "###0.00")
    End Sub
    Private Sub POSMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblChange.Text = ""
        LoadButtonSetup()
        CashTillSetupForToday()
        ShowTicketsSoldToday()
        NewReceiptID()
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub NewReceiptID()
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        'Release\
        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

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
            On Error Resume Next

            reader.Read()
            nReceiptCurrent = 0 + reader.Item("MaxID")

        End If

        nReceiptCurrent += 1
        nReceiptLatest = (nReceiptCurrent)
        Me.ReceiptNumber = (nReceiptCurrent)
        reader.Close()

        sqlConnect.Close()

    End Sub

    Public Property ManagerMode() As Boolean
        Get
            Return bManagerMode
        End Get
        Set(ByVal value As Boolean)
            bManagerMode = (value)
            If bManagerMode Then
                btnManagerMode.Text = "Manager Mode is ON"
            Else
                btnManagerMode.Text = "Manager Mode is OFF"
            End If
            btnManagerFunctions.Visible = bManagerMode
        End Set
    End Property
    Public Property ReceiptNumber() As Integer
        Get
            Return nReceiptNumber
        End Get
        Set(ByVal value As Integer)
            txtReceiptNumber.Text = value.ToString.Trim
            nReceiptNumber = (value)
            ReceiptShow(nReceiptNumber)
        End Set
    End Property

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If nSumPriceItems = 0 Then Exit Sub

        Dim fSwipe As New SwipeBluePay

        fSwipe.SaleAmount = (Me.lblReceiptTotal.Text.Trim)
        fSwipe.ShowDialog()
        If fSwipe.CardWorked Then
            LoadRowToGrid(fSwipe.TransactionID, fSwipe.CardType + Space(1) + fSwipe.Last4 + Space(1) + "Auth:" + fSwipe.AuthorizationCode, "-" + Me.lblReceiptTotal.Text.Trim, "0", "1", "CARD", fSwipe.CardType.Trim.ToUpper)
            GridTotals()
        End If

        fSwipe = Nothing

    End Sub
    Private Function RefundCC(ByVal sTotal As String, ByVal sTransID As String) As Boolean

        Dim fSwipe As New SwipeBluePay
        Dim bRefunded As Boolean

        fSwipe.SaleAmount = sTotal
        fSwipe.TransactionID = sTransID
        fSwipe.ShowDialog()
        bRefunded = (fSwipe.CardWorked)

        fSwipe = Nothing
        Return bRefunded

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        nManagerWarningCounter = 0
        lblChange.Text = ""
        Timer1.Enabled = False

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

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSearchLikeValue = AddLikeSymbol(txtEntry.Text)
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@InvName", sSearchLikeValue)
        cmd.CommandType = CommandType.Text

        sSQL = "EXEC InventoryItemSearchByName @InvName"

        cmd.CommandText = sSQL
        cmd.Connection = sqlConnect

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

        If DataGridView2.Rows.Count = 1 And txtEntry.TextLength = 12 Then
            PickFIRSTFromSearch()
            DataGridView2.Visible = False
        ElseIf DataGridView2.Rows.Count > 0 Then
            DataGridView2.Visible = True
            DataGridView2.Focus()
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
        PickFromSearch(e.RowIndex)
    End Sub

    Private Sub PickFromSearch(ByVal parIndex As Integer)

        Dim sInvUPC$, sNameItem$, sPrice$, sTaxRate$

        sInvUPC = ("" & DataGridView2.Item(8, parIndex).Value)
        sNameItem = ("" & DataGridView2.Item(0, parIndex).Value)
        sPrice = ("" & DataGridView2.Item(4, parIndex).Value)
        sTaxRate = ("" & DataGridView2.Item(10, parIndex).Value)

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

    End Sub

    Private Sub numQuantityAdjust_Leave(sender As Object, e As EventArgs)

        '        numQuantityAdjust.Visible = False

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim nQuantity As Integer, nPriceModify As Double, nPriceModify_Absolute As Double
        Dim nTaxAdjust As Double, sPriceModify As String
        If e.RowIndex < 0 Then Exit Sub

        Dim sPayType As String, sInvUPC As String, nRow As Integer

        If nReceiptCurrent <> nReceiptLatest Then
            If Not Me.ManagerMode Then
                BigMsgBox("Manager Access Needed")
                Exit Sub
            End If
        End If

        Select Case e.ColumnIndex

            Case 1

                Dim fQuantity As New Quantity
                nQuantity = ("" & DataGridView1.Item(1, e.RowIndex).Value)
                fQuantity.numQuantityAdjust.Value = nQuantity
                fQuantity.ShowDialog()
                nQuantity = fQuantity.numQuantityAdjust.Value ' get value
                fQuantity = Nothing
                DataGridView1.Item(1, e.RowIndex).Value = (nQuantity)

            Case 2

                Dim fPriceModify As New PriceModify
                nPriceModify = ("" & DataGridView1.Item(2, e.RowIndex).Value)
                fPriceModify.OriginalPrice = nPriceModify
                fPriceModify.ShowDialog()
                nPriceModify = fPriceModify.numPriceModify.Value ' get value
                fPriceModify = Nothing
                DataGridView1.Item(2, e.RowIndex).Value = Format(nPriceModify, "###0.00")

            Case 4

                Dim fTaxAdjust As New TaxAdjust
                nTaxAdjust = ("" & DataGridView1.Item(4, e.RowIndex).Value)
                fTaxAdjust.numTaxRate.Value = (nTaxAdjust)
                fTaxAdjust.ShowDialog()
                nTaxAdjust = fTaxAdjust.numTaxRate.Value ' get value
                fTaxAdjust = Nothing
                DataGridView1.Item(4, e.RowIndex).Value = Format(nTaxAdjust, "###0.00")

            Case 7
                ' deletion - is it a payment?
                nPriceModify = ("" & DataGridView1.Item(2, e.RowIndex).Value)
                If nPriceModify < 0 Then ' a payment?
                    sPayType = DataGridView1.Item(0, e.RowIndex).Value

                    If sPayType.Trim = "CASH" Then
                        ' open the cash drawer
                        nPriceModify_Absolute = Math.Abs(nPriceModify) ' remove the negative
                        sPriceModify = String.Format("{0,-10:C}", nPriceModify_Absolute)
                        BigMsgBox("CASH REFUND " & sPriceModify & " Minus Change")
                        Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)
                    Else
                        nRow = Me.DataGridView1.CurrentRow.Index
                        sInvUPC = ("" & DataGridView1.Item(3, nRow).Value)
                        ' we need to run a refund thru the card service
                        If RefundCC(nPriceModify.ToString, sInvUPC) Then
                            Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)
                        End If
                    End If
                Else ' not a payment
                    Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)
                End If
        End Select
        GridTotals()

    End Sub

    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyCode = Keys.Delete Then
            Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)
            GridTotals()
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

    Private Sub btnAdult_Click(sender As Object, e As EventArgs) Handles btnQuick1.Click
        Me.DataGridView1.Rows.Add(sItemNameButton(1), "1", sItemPriceButton(1), sUPCButton(1), sItemTaxButton(1))

    End Sub

    Private Sub btnChild_Click(sender As Object, e As EventArgs) Handles btnQuick2.Click

        Me.DataGridView1.Rows.Add(sItemNameButton(2), "1", sItemPriceButton(2), sUPCButton(2), sItemTaxButton(2))

    End Sub

    Private Sub btnAAAMilAdult_Click(sender As Object, e As EventArgs) Handles btnQuick3.Click
        Me.DataGridView1.Rows.Add(sItemNameButton(3), "1", sItemPriceButton(3), sUPCButton(3), sItemTaxButton(3))
        'Me.DataGridView1.Rows.Add("AAA/MIL Adult", "1", "9.00", "333333333333", "0")
    End Sub

    Private Sub btnAdultGroup_Click(sender As Object, e As EventArgs) Handles btnQuick5.Click

        Me.DataGridView1.Rows.Add(sItemNameButton(5), "1", sItemPriceButton(5), sUPCButton(5), sItemTaxButton(5))

    End Sub

    Private Sub btnChildGroup_Click(sender As Object, e As EventArgs) Handles btnQuick6.Click
        Me.DataGridView1.Rows.Add(sItemNameButton(6), "1", sItemPriceButton(6), sUPCButton(6), sItemTaxButton(6))

    End Sub

    Private Sub GridTotals()
        Dim sQuantity As String, sPrice As String, nQuantity As Integer, nPrice As Double
        Dim nRowsToSum As Integer, nRow As Integer
        Dim nTotal As Double, nTaxRate As Double, nItemTotal As Double

        If DataGridView1.Rows.Count < 1 Then
            lblReceiptTotal.Text = "0.00"
            '           btnDone.Enabled = False
            nSumPriceItems = 0
            Exit Sub
        End If

        If IsDBNull(DataGridView1.Item(2, nRow).Value) Then Exit Sub

        nTotal = 0
        nRowsToSum = (DataGridView1.Rows.Count - 1)
        For nRow = 0 To nRowsToSum
            nTaxRate = CDbl("0" & DataGridView1.Item(4, nRow).Value)
            nTaxRate = nTaxRate / 100
            sPrice = ("" & DataGridView1.Item(2, nRow).Value)
            sQuantity = ("" & DataGridView1.Item(1, nRow).Value)
            nPrice = Val(sPrice)
            nQuantity = Int(Val(sQuantity))
            nItemTotal = (nPrice * nQuantity)
            nItemTotal += (nItemTotal * nTaxRate)
            nTotal += (nItemTotal)
        Next

        nSumPriceItems = (Format(nTotal, "####0.00").Trim)
        lblReceiptTotal.Text = (Format(nTotal, "####0.00"))

    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        GridTotals()
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        GridTotals()
    End Sub

    Private Sub POSMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        DataGridView1.Width = (Me.Width - DataGridView1.Left) - 25
        ReportViewer1.Height = (Me.Height - ReportViewer1.Top) - 35
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Dim bTimerEntryFocus_EnableState As Boolean

        bTimerEntryFocus_EnableState = (TimerEntryFocus.Enabled)
        TimerEntryFocus.Enabled = False
        FireReceipt(False)
        ShowTicketsSoldToday()
        TimerEntryFocus.Enabled = bTimerEntryFocus_EnableState
    End Sub
    Private Sub FireReceipt(ByVal bIsReturn As Boolean)
        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String
        Dim nCashIn As Double, nCashOut As Double

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If nReceiptCurrent <> nReceiptLatest Then
            If Not Me.ManagerMode Then
                BigMsgBox("Manager Access Needed")
                Exit Sub
            End If
        End If

        If nSumPriceItems > 0 Then
            If Not bIsReturn Then
                BigMsgBox("Full Payment Required")
                Exit Sub
            End If
        Else ' there are rows and they end up at zero (payment made)
            If bIsReturn Then
                BigMsgBox("Manually Return Payment First")
                Exit Sub
            End If
        End If

        If DataGridView1.Rows.Count < 1 Then
            BigMsgBox("Nothing to Print")
            Exit Sub
        End If

        If nSumPriceItems < 0 Then ' there are rows and they DO NOT end up at zero (change required)
            If bIsReturn Then
                BigMsgBox("Return to Customer: " & lblReceiptTotal.Text.Replace("-", ""))
            Else
                lblChange.Text = "Change: " & lblReceiptTotal.Text.Replace("-", "")
            End If
            nCashOut = CDbl(lblReceiptTotal.Text.Trim)
            nCashOut = nCashOut * -1
        End If

        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand

        Dim sInvUPC$, sNameItem$, sPrice$, sTaxRate$
        Dim nRow As Integer, sQuantity As String
        Dim nTaxRate As Double, nPrice As Double, nTaxedAmount As Double
        Dim sPayType As String = "", sCardType As String = ""
        Dim nRowFinal As Integer, nQuantity As Integer

        nRowFinal = DataGridView1.Rows.Count - 1

        If nRowFinal < 0 Then Exit Sub

        ' put the items/payments into receipt, organized by receipt #

        DeleteOldReceipt(Me.ReceiptNumber)  ' clear old data if this is an edit

        LatestReturnNumber = GetLatestReturnNumber()

        For nRow = 0 To nRowFinal
            sInvUPC = ("" & DataGridView1.Item(3, nRow).Value)
            sNameItem = ("" & DataGridView1.Item(0, nRow).Value)
            sPrice = ("" & DataGridView1.Item(2, nRow).Value)
            sQuantity = ("" & DataGridView1.Item(1, nRow).Value)
            sTaxRate = ("" & DataGridView1.Item(4, nRow).Value)
            sPayType = ("" & DataGridView1.Item(5, nRow).Value)
            sCardType = ("" & DataGridView1.Item(6, nRow).Value)

            If sTaxRate.ToString.Trim = "" Then
                sTaxRate = "0"
            End If
            'convert some values to numerics for taxed amount calc
            nTaxRate = CDbl(sTaxRate)
            nPrice = CDbl(sPrice)
            nTaxRate = nTaxRate / 100
            nTaxedAmount = (nPrice * nTaxRate)
            nTaxRate = nTaxRate * 100  'convert it right back for reciept insertion
            nQuantity = CInt(sQuantity)

            sqlConnect1.Open()

            If Not bIsReturn Then

                sqlString = "EXEC InsertReceipt @sInvUPC, @Price, @Paid, @nTaxedAmount, @ReceiptNumber, @Quantity"
                sqlString += ", @TaxRate, @Descript, @sNameItem, @Now, @NowDT, @sPayType, @sCardType"

                commandSQL1 = New SqlCommand(sqlString, sqlConnect1)

                commandSQL1.Parameters.AddWithValue("@sInvUPC", sInvUPC)
                commandSQL1.Parameters.AddWithValue("@Price", nPrice)
                commandSQL1.Parameters.AddWithValue("@Paid", nPrice)
                commandSQL1.Parameters.AddWithValue("@nTaxedAmount", nTaxedAmount)
                commandSQL1.Parameters.AddWithValue("@ReceiptNumber", Me.ReceiptNumber)
                commandSQL1.Parameters.AddWithValue("@Quantity", nQuantity)
                commandSQL1.Parameters.AddWithValue("@TaxRate", nTaxRate)
                commandSQL1.Parameters.AddWithValue("@Descript", sNameItem)
                commandSQL1.Parameters.AddWithValue("@sNameItem", sNameItem)
                commandSQL1.Parameters.AddWithValue("@Now", Now)
                commandSQL1.Parameters.AddWithValue("@NowDT", Now)
                commandSQL1.Parameters.AddWithValue("@sPayType", sPayType)
                commandSQL1.Parameters.AddWithValue("@sCardType", sCardType)

                If sPayType.Trim.ToUpper = "CASH" Then
                    nCashIn = (nPrice * -1)
                End If

            Else

                sqlString = "EXEC InsertReturn @sInvUPC, @Price, @Paid, @nTaxedAmount, @ReturnID, @ReceiptNumber, @Quantity"
                sqlString += ", @TaxRate, @Descript, @sNameItem, @Now, @NowDT, @sPayType, @sCardType"

                commandSQL1 = New SqlCommand(sqlString, sqlConnect1)

                commandSQL1.Parameters.AddWithValue("@sInvUPC", sInvUPC)
                commandSQL1.Parameters.AddWithValue("@Price", nPrice)
                commandSQL1.Parameters.AddWithValue("@Paid", nPrice)
                commandSQL1.Parameters.AddWithValue("@nTaxedAmount", nTaxedAmount)
                commandSQL1.Parameters.AddWithValue("@ReturnID", Me.ReceiptNumber)
                commandSQL1.Parameters.AddWithValue("@ReceiptNumber", LatestReturnNumber)
                commandSQL1.Parameters.AddWithValue("@Quantity", nQuantity)
                commandSQL1.Parameters.AddWithValue("@TaxRate", nTaxRate)
                commandSQL1.Parameters.AddWithValue("@Descript", sNameItem)
                commandSQL1.Parameters.AddWithValue("@sNameItem", sNameItem)
                commandSQL1.Parameters.AddWithValue("@Now", Now)
                commandSQL1.Parameters.AddWithValue("@NowDT", Now)
                commandSQL1.Parameters.AddWithValue("@sPayType", sPayType)
                commandSQL1.Parameters.AddWithValue("@sCardType", sCardType)

            End If

            Try

                commandSQL1.CommandType = CommandType.Text
                commandSQL1.ExecuteNonQuery()
                commandSQL1.Dispose()
                sqlConnect1.Close()

            Catch ex As ArgumentException
                BigMsgBox("" & ex.Message)

            Finally

            End Try

            If Not bIsReturn Then
                ' remove sold items from inventory
                sqlString = "EXEC UpdateQuantity " & QTrim(sInvUPC) & ", " & sQuantity
            Else
                'return item to inventory
                sqlString = "UPDATE InventoryItems Set OnHandQuantity = (OnHandQuantity + " & sQuantity & ")"
                sqlString += " WHERE InvType <> 'NonInventory'"
                sqlString += " AND InvUPC = " & QTrim(sInvUPC)
            End If


            Try
                sqlConnect1.Open()
                commandSQL1 = New SqlCommand(sqlString, sqlConnect1)
                commandSQL1.ExecuteNonQuery()
                commandSQL1.Dispose()
                sqlConnect1.Close()

            Catch ex As ArgumentException
                BigMsgBox("" & ex.Message)

            Finally

            End Try

        Next nRow

        DataGridView1.Rows.Clear()

        If Not bIsReturn Then
            If Me.ReceiptNumber = nReceiptLatest Then
                Me.ReceiptNumber = (Me.ReceiptNumber + 1)
                nReceiptLatest = (Me.ReceiptNumber) ' increment the latest to agree with table
                nReceiptCurrent = nReceiptLatest
            Else
                Me.ReceiptNumber = (nReceiptLatest) ' done changing old receipt- go to latest
            End If

            Dim sReceiptPrint As String
            sReceiptPrint = (Me.ReceiptNumber - 1)

            ReceiptShow(sReceiptPrint)
            While ReportViewer1.CurrentStatus.InCancelableOperation
                Application.DoEvents()
            End While

            ReportViewer1.PrintDialog()
            ReceiptShow(nReceiptLatest.ToString.Trim)
            CashDrawerSync(nCashIn, nCashOut)
            If Not (lblChange.Text.Trim = "") Then
                BigMsgBox(lblChange.Text)
                Timer1.Enabled = True ' clear message within a few seconds
            End If
            ReturnShow(LatestReturnNumber)
        End If

    End Sub

    Private Sub DeleteOldReceipt(ByVal nReceiptDelete As Integer)
        Dim commandSQL1 As SqlCommand
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"
        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()
        Dim sqlConnect1 As New SqlConnection(sConnectionString)


        sqlString = "DELETE FROM Receipt WHERE ReceiptID = " & nReceiptDelete

        Try

            sqlConnect1.Open()
            commandSQL1 = New SqlCommand(sqlString, sqlConnect1)
            'commandSQL1.CommandType = CommandType.Text
            commandSQL1.ExecuteNonQuery()
            commandSQL1.Dispose()
            sqlConnect1.Close()

        Catch ex As ArgumentException
            BigMsgBox("" & ex.Message)

        Finally

        End Try
        Debug.Print(sqlString)


    End Sub

    'CASH
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim nCashAmount As Double
        If nSumPriceItems > 0 Then ' a sum to deal with?

            Dim fCashPay As New CashPay

            fCashPay.CashAmount = (nSumPriceItems)
            fCashPay.ShowDialog()
            nCashAmount = (fCashPay.CashAmount)
            If nCashAmount <> 0 Then
                nCashAmount = (nCashAmount * -1)
                LoadRowToGrid("CASH", "CASH", Format(nCashAmount, "###0.00"), "0", "1", "CASH", "")
            End If
            fCashPay = Nothing

        Else ' possible cash refund
            Dim fCashPay As New CashPay
            ' don't bother to send the sum to the cash payment form
            fCashPay.ShowDialog()
            nCashAmount = (fCashPay.CashAmount)
            If nCashAmount <> 0 Then
                nCashAmount = (nCashAmount * -1)
                LoadRowToGrid("CASH", "CASH", Format(nCashAmount, "###0.00"), "0", "1", "CASH", "")
            End If
            fCashPay = Nothing

        End If

    End Sub

    Private Sub LoadRowToGrid(ByVal sInvUPC As String, ByVal sNameItem As String,
                              ByVal sPrice As String, ByVal sTaxRate As String, ByVal sQuantity As String,
                              Optional ByVal sPayType As String = "", Optional ByVal sCardType As String = "")

        If sPayType = "" Then
            Me.DataGridView1.Rows.Add(sNameItem.Trim, sQuantity.ToString, sPrice, sInvUPC.Trim, sTaxRate)
        Else
            Me.DataGridView1.Rows.Add(sNameItem.Trim, sQuantity.ToString, sPrice, sInvUPC.Trim, sTaxRate, sPayType, sCardType)
        End If

        nSumPriceItems = 0
        GridTotals()

    End Sub

    Private Sub LoadSavedReceipt(ByVal nReceiptToLoad As Integer)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String, sSearchLikeValue$

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSearchLikeValue = QLike(txtEntry.Text)
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        sSQL = "SELECT a.UPC, a.ReceiptID ,a.Description, b.InvName, a.Price, a.paid, b.InvUPC, a.TaxPaid, a.Quantity, a.TaxRate, a.PayType, a.CardType FROM Receipt a"
        sSQL += " LEFT JOIN InventoryItems b ON a.UPC = b.InvUPC WHERE a.ReceiptID = " & nReceiptToLoad

        cmd.CommandText = sSQL
        cmd.Connection = sqlConnect
        ' Create a SqlParameter for each parameter in the stored procedure.

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State
        Dim nPriceDisplayGrid As Double, sPriceDisplayGrid As String
        Dim nTaxRate As Double, sItemName As String

        Me.DataGridView1.Rows.Clear()

        Try
            If sqlConnect.State = ConnectionState.Closed Then
                sqlConnect.Open()
            End If
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    ' Process SprocResults datareader here.
                    nPriceDisplayGrid = reader.Item("Price")
                    sPriceDisplayGrid = Strings.FormatNumber(reader.Item("Price"), 2)

                    If Not IsDBNull(reader.Item("TaxRate")) Then
                        nTaxRate = reader.Item("TaxRate")
                    Else
                        nTaxRate = 0
                    End If

                    If Not IsDBNull(reader.Item("InvName")) Then
                        sItemName = reader.Item("InvName")
                        If String.IsNullOrEmpty(sItemName) Then
                            sItemName = reader.Item("Description")
                        End If
                    Else
                        If Not IsDBNull(reader.Item("Description")) Then
                            sItemName = reader.Item("Description")
                        Else
                            sItemName = ""
                        End If
                    End If
                    LoadRowToGrid(reader.Item("UPC"), sItemName, sPriceDisplayGrid, nTaxRate.ToString, reader.Item("Quantity").ToString, reader.Item("PayType").ToString, reader.Item("CardType").ToString)
                End While

                nSumPriceItems = (nSumPriceItems * -1)
                If nSumPriceItems <> 0 Then ' some change to show
                    LoadRowToGrid("", "CHANGE", Format(nSumPriceItems, "###0.00"), "", "1")
                End If


            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

    End Sub

    Private Sub btnPreviousReceipt_Click(sender As Object, e As EventArgs) Handles btnPreviousReceipt.Click

        If nReceiptLatest = 1 Then
            Exit Sub
        End If
        If Me.ReceiptNumber = 1 Then
            Exit Sub
        End If

        If nReceiptCurrent < (nReceiptLatest - 3) And ManagerMode = False Then
            nManagerWarningCounter += 1
            If nManagerWarningCounter > 3 Then BigMsgBox("Manager Access Needed for Receipts Further than 4 Back")
            Timer1.Enabled = True
            Exit Sub ' no more than 4 back without manager function
        End If

        If nReceiptLatest = nReceiptCurrent And DataGridView1.Rows.Count > 0 Then
            BigMsgBox("You need to resolve this open receipt before going to other receipts")
            Exit Sub
        End If
        nReceiptCurrent += -1
        Me.ReceiptNumber = nReceiptCurrent
        LoadSavedReceipt(nReceiptCurrent)
    End Sub

    Private Sub btnManagerMode_Click(sender As Object, e As EventArgs) Handles btnManagerMode.Click

        If Me.ManagerMode Then ' on? then just turn if off
            Me.ManagerMode = False
            Exit Sub
        End If

        Me.ManagerMode = False ' false until password checked
        Dim fManagerPassword As New ManagerPassword
        With fManagerPassword
            .ShowDialog()
            If .CorrectPassword Then
                Me.ManagerMode = True
            End If
        End With
        fManagerPassword = Nothing

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim oFile = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\armis\Documents\receipt.txt", True)
        oFile.WriteLine("dljlfasddkja444444444444444")
        oFile.Close()

        'C:\Users\armis\Documents
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub btnNextReceipt_Click(sender As Object, e As EventArgs) Handles btnNextReceipt.Click
        If nReceiptLatest = nReceiptCurrent Then ' no going into future
            Exit Sub
        End If

        nReceiptCurrent += 1
        Me.ReceiptNumber = nReceiptCurrent
        LoadSavedReceipt(nReceiptCurrent)

    End Sub

    Private Sub ReceiptShow(ByVal sReceiptToShow As String)
        Dim receiptDataSource As New WinForms.ReportDataSource
        Dim dataset As New DataSet("Receipt")

        GetReceiptDataSet(sReceiptToShow, dataset)

        receiptDataSource.Name = "Receipt"
        receiptDataSource.Value = dataset.Tables("Receipt")

        ReportViewer1.ProcessingMode = WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(receiptDataSource)
        ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\Receipt.rdl"

        Dim rParam As New WinForms.ReportParameter
        rParam.Values.Clear()
        rParam.Name = "rID"
        rParam.Values.Add(sReceiptToShow)
        Dim rParam2 As New WinForms.ReportParameter
        rParam2.Name = "title"
        rParam2.Values.Add("Receipt")

        ReportViewer1.LocalReport.SetParameters(rParam)
        ReportViewer1.LocalReport.SetParameters(rParam2)
        ReportViewer1.PrinterSettings.PrinterName = "CITIZEN CT-S310"

        ReportViewer1.RefreshReport()

    End Sub

    Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            PickFromSearch(DataGridView2.CurrentRow.Index)
        End If

        If e.KeyCode = Keys.Escape Then ' abandon this operation
            DataGridView2.Visible = False ' selection not made, clear the area
            txtEntry.Enabled = True

        End If

    End Sub

    'clear all button
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If nReceiptCurrent <> nReceiptLatest Then
            BigMsgBox("You Can Only Clear Latest Unpaid Receipt")
            Exit Sub
        End If

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
            If sTaxRate.ToString.Trim = "" Then
                sTaxRate = "0"
            End If
            'convert some values to numerics for taxed amount calc
            nTaxRate = CDbl(sTaxRate)
            nPrice = CDbl(sPrice)
            nTaxRate = nTaxRate / 100
            nTaxedAmount = (nPrice * nTaxRate)

            If nPrice < 0 Then
                BigMsgBox("Cannot Clear Receipt with Payments")
                Exit Sub
            End If


        Next nRow

        DataGridView1.Rows.Clear()

    End Sub

    Private Sub btnGo2LatestReceipt_Click(sender As Object, e As EventArgs) Handles btnGo2LatestReceipt.Click
        If nReceiptLatest = nReceiptCurrent Then ' already there
            Exit Sub
        End If

        nReceiptCurrent = nReceiptLatest
        Me.ReceiptNumber = nReceiptCurrent
        LoadSavedReceipt(nReceiptCurrent)

    End Sub

    Private Sub btnReportMenu_Click(sender As Object, e As EventArgs) Handles btnReportMenu.Click
        Dim fReportsMenu As New ReportsMenu
        fReportsMenu.ShowDialog()
        fReportsMenu = Nothing
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        If Not Me.ManagerMode Then
            BigMsgBox("Manager Access Needed")
            Exit Sub
        End If

        FireReceipt(True)


    End Sub

    Private Sub GetReceiptDataSet(ByVal parReceiptID As String,
                               ByRef parDataSet As DataSet)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSQL = "SELECT a.UPC, a.ReceiptID, a.Description, b.InvName, a.Price, a.Paid, b.InvUPC, a.TaxPaid, a.Quantity, a.TaxRate,"
        sSQL += " a.ReceiptDate, a.ReceiptDateTime FROM Receipt AS a LEFT OUTER JOIN"
        sSQL += " InventoryItems AS b ON a.UPC = b.InvUPC"
        sSQL += " WHERE (a.ReceiptID = @rID)"


        Using connection As New SqlConnection(sConnectionString)

            Dim command As New SqlCommand(sSQL, connection)

            Dim parameter As New SqlParameter("rID",
                parReceiptID)
            command.Parameters.Add(parameter)

            Dim ReceiptAdapter As New SqlDataAdapter(command)

            ReceiptAdapter.Fill(parDataSet, "Receipt")

        End Using

    End Sub


    Private Sub GetReturnDataSet(ByVal parReceiptID As String,
                               ByRef parDataSet As DataSet)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSQL = "SELECT a.UPC, a.ReceiptID, a.Description, b.InvName, a.Price, a.Paid, b.InvUPC, a.TaxPaid, a.Quantity, a.TaxRate"
        sSQL += " FROM Returns AS a LEFT OUTER JOIN"
        sSQL += " InventoryItems AS b ON a.UPC = b.InvUPC"
        '        sSQL += " WHERE (a.ReceiptID = " + parReceiptID + ")"
        sSQL += " WHERE (a.ReturnID = @rID)"


        Using connection As New SqlConnection(sConnectionString)

            Dim command As New SqlCommand(sSQL, connection)

            Dim parameter As New SqlParameter("rID",
                parReceiptID)
            command.Parameters.Add(parameter)

            Dim ReceiptAdapter As New SqlDataAdapter(command)

            ReceiptAdapter.Fill(parDataSet, "Receipt")

        End Using

    End Sub

    Private Sub txtReceiptNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles txtReceiptNumber.KeyUp
        Dim nTextBoxValue As Integer

        If e.KeyCode <> Keys.Enter Then
            Exit Sub
        End If

        btxtReceiptNumber_EnterKeyPressed = True ' indicate this so that we can undo changes if we lose focus w/out enter key pressed
        nTextBoxValue = Val(txtReceiptNumber.Text)
        If nTextBoxValue < (nReceiptLatest - 3) And ManagerMode = False Then
            BigMsgBox("Manager Access Needed for Receipts Further than 4 Back")
            txtReceiptNumber.Text = (sInitial_txtReceiptNumber) ' restore original value
            Exit Sub ' no more than 4 back without manager function
        End If

        If nTextBoxValue < 1 Then
            Exit Sub
        End If

        If nTextBoxValue > nReceiptLatest Then ' no going into future
            txtReceiptNumber.Text = (sInitial_txtReceiptNumber) ' restore original value
            Exit Sub
        End If

        If nReceiptLatest = nReceiptCurrent And DataGridView1.Rows.Count > 0 Then
            BigMsgBox("You need to resolve this open receipt before going to other receipts")
            Exit Sub
        End If

        nReceiptCurrent = Int(Val(txtReceiptNumber.Text))
        Me.ReceiptNumber = nReceiptCurrent
        LoadSavedReceipt(nReceiptCurrent)

    End Sub

    Private Sub txtReceiptNumber_Enter(sender As Object, e As EventArgs) Handles txtReceiptNumber.Enter
        sInitial_txtReceiptNumber = ("" & txtReceiptNumber.Text)
    End Sub

    Private Sub txtReceiptNumber_Leave(sender As Object, e As EventArgs) Handles txtReceiptNumber.Leave
        If Not btxtReceiptNumber_EnterKeyPressed Then ' leaving w possible changes, but no enter key pressed
            txtReceiptNumber.Text = ("" & sInitial_txtReceiptNumber)
        End If
        btxtReceiptNumber_EnterKeyPressed = False ' set back to default value
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnAttend_Click(sender As Object, e As EventArgs) Handles btnAttend.Click
        Dim fAttend As New Attendance
        fAttend.ShowDialog()
        fAttend = Nothing

    End Sub

    Private Sub btnManagerFunctions_Click(sender As Object, e As EventArgs) Handles btnManagerFunctions.Click
        Dim fMgrFunc As New ManagerFunctions
        fMgrFunc.ShowDialog()
        fMgrFunc = Nothing

    End Sub

    Private Sub txtReceiptNumber_TextChanged(sender As Object, e As EventArgs) Handles txtReceiptNumber.TextChanged

    End Sub

    Private Sub btnDrawer_Click(sender As Object, e As EventArgs) Handles btnDrawer.Click
        Printer.CashDrawer()
    End Sub

    Private Sub lblTicketSum_Click(sender As Object, e As EventArgs) Handles lblTicketSum.Click
        ShowTicketsSoldToday()
    End Sub

    Private Function GetLatestReturnNumber() As Integer
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnCurrent As Integer, nReturnLatest As Integer

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT Max(ReturnID) as MaxID, Count(ReturnID) as CountID from Returns"
        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            On Error Resume Next

            reader.Read()
            nReturnCurrent = 0 + reader.Item("MaxID")

        End If

        nReturnCurrent += 1
        nReturnLatest = (nReturnCurrent)
        reader.Close()

        sqlConnect.Close()

        Return (nReturnCurrent)
    End Function

    Private Sub btnQuick4_Click(sender As Object, e As EventArgs) Handles btnQuick4.Click
        Me.DataGridView1.Rows.Add(sItemNameButton(4), "1", sItemPriceButton(4), sUPCButton(4), sItemTaxButton(4))

    End Sub

    Private Sub TimerEntryFocus_Tick(sender As Object, e As EventArgs) Handles TimerEntryFocus.Tick
        If Timer1.Enabled Then
            Exit Sub ' don't interfere with other timer
        End If


        If Not DataGridView2.Visible Then ' allow user to use keys to select item from search list
            txtEntry.Focus()
        End If

    End Sub

    Private Sub ReturnShow(ByVal sReturnToShow As String)
        Dim ReturnDataSource As New WinForms.ReportDataSource
        Dim dataset As New DataSet("Receipt")

        GetReturnDataSet(sReturnToShow, dataset)

        ReturnDataSource.Name = "Receipt"
        ReturnDataSource.Value = dataset.Tables("Receipt")

        ReportViewer1.ProcessingMode = WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(ReturnDataSource)
        ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\Receipt.rdl"

        Dim rParam As New WinForms.ReportParameter
        rParam.Values.Clear()
        rParam.Name = "title"
        rParam.Values.Add("RETURN")
        ReportViewer1.LocalReport.SetParameters(rParam)

        ReportViewer1.RefreshReport()

    End Sub

    Private Sub CashDrawerSync(ByVal dblCashIn As Double, ByVal dblCashOut As Double)
        Dim sConnectionString As String, SQLString As String
        Dim dblCashAmount As Double

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand

        dblCashAmount = (dblCashIn - dblCashOut)

        SQLString = "EXEC UpdateCashTill " + Format(dblCashAmount, "#####0.00") + ", " + QTrim(Today.ToShortDateString.Trim)

        Try

            sqlConnect1.Open()
            commandSQL1 = New SqlCommand(SQLString, sqlConnect1)
            'commandSQL1.CommandType = CommandType.Text
            commandSQL1.ExecuteNonQuery()
            commandSQL1.Dispose()
            sqlConnect1.Close()

        Catch ex As ArgumentException
            BigMsgBox("" & ex.Message)

        Finally

        End Try

    End Sub

    '    load customer configurable buttons
    Public Sub LoadButtonSetup()
        Dim sqlConnect As New SqlConnection(), dPrice As Double
        Dim sConnectionString As String, sqlString As String, nButton As Long
        'Release\
        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        btnQuick1.Visible = False
        btnQuick2.Visible = False
        btnQuick3.Visible = False
        btnQuick4.Visible = False
        btnQuick5.Visible = False
        btnQuick6.Visible = False

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "EXEC GetButtons"
        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        '        On Error Resume Next
        Using reader
            While reader.Read
                nButton = 0 + reader.Item("ButtonNumber")
                sUPCButton(nButton) = "" + reader.Item("ButtonUPC")
                sItemNameButton(nButton) = "" + reader.Item("InvName")
                If sItemNameButton(nButton).Trim <> "" Then
                    dPrice = 0 + reader.Item("InvPrice")
                    sItemPriceButton(nButton) = Format(dPrice, "###0.00")
                    sItemTaxButton(nButton) = "" + reader.Item("TaxRate").ToString
                End If

                Select Case nButton
                    Case 1
                        btnQuick1.Text = reader.Item("ButtonText")
                        btnQuick1.Visible = (btnQuick1.Text.Trim <> "")
                    Case 2
                        btnQuick2.Text = reader.Item("ButtonText")
                        btnQuick2.Visible = (btnQuick2.Text.Trim <> "")
                    Case 3
                        btnQuick3.Text = reader.Item("ButtonText")
                        btnQuick3.Visible = (btnQuick3.Text.Trim <> "")
                    Case 4
                        btnQuick4.Text = reader.Item("ButtonText")
                        btnQuick4.Visible = (btnQuick4.Text.Trim <> "")
                    Case 5
                        btnQuick5.Text = reader.Item("ButtonText")
                        btnQuick5.Visible = (btnQuick5.Text.Trim <> "")
                    Case 6
                        btnQuick6.Text = reader.Item("ButtonText")  'btnQuick6
                        btnQuick6.Visible = (btnQuick6.Text.Trim <> "")
                End Select
            End While
        End Using


        reader.Close()

        sqlConnect.Close()

    End Sub

End Class