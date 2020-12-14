Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Drawing.Text

Public Class CashDrawer
    Dim AlreadyInTable As Boolean = False, recordID As String
    Private Sub LoadCashAmount()
        Dim sqlString As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        sqlConnect.Open()

        sqlString = "EXEC IsThereCashTillSetupForToday " & QTrim(Today.ToShortDateString.Trim)

        Dim commandSQL As New SqlCommand(sqlString, sqlConnect)

        Dim reader = commandSQL.ExecuteReader()
        AlreadyInTable = reader.HasRows

        If AlreadyInTable Then
            reader.Read()
            NumericUpDown1.Value = CDbl("0" + reader.Item("CashOut").ToString.Trim)
            reader.Close()
        End If

        reader.Close()
        sqlConnect.Close()
    End Sub

    Private Sub CashDrawer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCashAmount()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlString As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        sqlConnect.Open()

        sqlString = "UPDATE CASH SET CashIn = " & NumericUpDown1.Value.ToString.Trim
        sqlString += ", CashOut = " & NumericUpDown1.Value.ToString.Trim
        sqlString += " WHERE CashDate = " & QTrim(Today.ToShortDateString.Trim)
        Dim commandSQL As New SqlCommand(sqlString, sqlConnect)
        Try

            commandSQL = New SqlCommand(sqlString, sqlConnect)
            commandSQL.ExecuteNonQuery()
            commandSQL.Dispose()
            sqlConnect.Close()

        Catch ex As ArgumentException
            MsgBox("" & ex.Message)

        Finally

        End Try

        Me.Close()

    End Sub

End Class