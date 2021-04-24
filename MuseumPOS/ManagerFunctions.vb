Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class ManagerFunctions
    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click

        Dim fInventoryItem As New InventoryItem
        fInventoryItem.ShowDialog()
        fInventoryItem = Nothing
    End Sub

    Private Sub btnCreateTables_Click(sender As Object, e As EventArgs) Handles btnCreateTables.Click
        Dim sConnectionString As String = APPConnectionString
        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand, SQLstring As String

        SQLstring = "SELECT * INTO ReceiptsReporting FROM Receipt  "

        BigMsgBox(SqlString)
        Try

            sqlConnect1.Open()
            commandSQL1 = New SqlCommand(SqlString, sqlConnect1)
            commandSQL1.ExecuteNonQuery()
            commandSQL1.Dispose()
            sqlConnect1.Close()

        Catch ex As ArgumentException
            MsgBox("" & ex.Message)

        Finally

        End Try


        BigMsgBox("Done")

    End Sub

    Private Sub btnReceiptDelete_Click(sender As Object, e As EventArgs) Handles btnReceiptDelete.Click

        Dim sConnectionString As String = APPConnectionString
        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand, SQLstring As String

        SQLstring = "DELETE FROM Receipt WHERE ReceiptID = " + nReceiptDelete.Value.ToString.Trim

        Try

            sqlConnect1.Open()
            commandSQL1 = New SqlCommand(SQLstring, sqlConnect1)
            commandSQL1.ExecuteNonQuery()
            commandSQL1.Dispose()
            sqlConnect1.Close()

            lblReceiptDeleted.Visible = True
            Timer1.Enabled = True
        Catch ex As ArgumentException
            MsgBox("" & ex.Message)

        Finally

        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblReceiptDeleted.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub btnCashDrawer_Click(sender As Object, e As EventArgs) Handles btnCashDrawer.Click
        Dim fCash As New CashDrawer
        fCash.ShowDialog()
        fCash = Nothing

    End Sub

    Private Sub btnPostReconnect_Click(sender As Object, e As EventArgs) Handles btnPostReconnect.Click
        lblReconnectInProcess.Visible = True
        ReConnectUPCsInReceipts()
        lblReconnectInProcess.Visible = False
    End Sub

    Private Sub btnCreditCardTest_Click(sender As Object, e As EventArgs) Handles btnCreditCardTest.Click
        BluePay_AccountID = "100868017209"  '"DEMO-ROADSANDRAILS"
        BluePay_SecretKey = "P7KKNNCTELSV12VWSNQ8OAZAXX/IKI4X"
        BluePay_Mode = "TEST"
        BigMsgBox("BluePay Test Server ON")
        POSMain.Text += " BluePay Test Server ON"
    End Sub
End Class