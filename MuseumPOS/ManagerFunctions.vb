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

        SQLstring = "CREATE TABLE [dbo].[Buttons] ("
        SQLstring += "[ButtonNumber] Int  NOT NULL, "
        SQLstring += "[ButtonText]   VARCHAR (50) NULL, "
        SQLstring += "[ButtonUPC]    VARCHAR (50) NULL, "
        SQLstring += "[ButtonColor] VARCHAR(50) NULL, "
        SQLstring += "PRIMARY KEY CLUSTERED ([ButtonNumber] ASC));"

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
End Class