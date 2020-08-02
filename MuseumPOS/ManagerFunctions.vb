Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class ManagerFunctions
    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click

        Dim fInventoryItem As New InventoryItem
        fInventoryItem.ShowDialog()
        fInventoryItem = Nothing

    End Sub

    Private Sub btnCreateTables_Click(sender As Object, e As EventArgs) Handles btnCreateTables.Click
        Dim sConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"
        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand, SQLstring As String

        SQLstring = "CREATE TABLE [dbo].[Attendance] ("
        SQLstring += "[Id]          Int           Not NULL,"
        SqlString += " [Worker]      Int           NULL,"
        SqlString += " [TimeIN]      SMALLDATETIME NULL,"
        SqlString += " [TimeOUT]     SMALLDATETIME NULL,"
        SqlString += " [TimeEncoded] NCHAR(100)   NULL,"
        SqlString += " PRIMARY KEY CLUSTERED ([Id] ASC)"
        SqlString += ")"

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

        Dim sConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"
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
End Class