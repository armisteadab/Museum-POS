Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Drawing.Text

Public Class CashDrawer
    Dim AlreadyInTable As Boolean = False, recordID As String
    Private Function RecordThere() As Boolean
        Dim sqlString As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"
        Dim bReturn As Boolean

        sqlConnect.ConnectionString = sConnectionString
        sqlConnect.Open()

        sqlString = "EXEC IsThereCashTillSetupForToday " & QTrim(Today.ToShortDateString.Trim)

        Dim commandSQL As New SqlCommand(sqlString, sqlConnect)

        Dim reader = commandSQL.ExecuteReader()
        AlreadyInTable = reader.HasRows
        bReturn = (AlreadyInTable)

        If AlreadyInTable Then
            reader.Read()
            NumericUpDown1.Value = (0 + reader.Item("CashOut"))
            reader.Close()
        End If

        reader.Close()
        sqlConnect.Close()
        RecordThere = (bReturn)
    End Function

    Private Sub CashDrawer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BigMsgBox(IIf(RecordThere(), "yes", "no"))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlString As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not RecordThere() Then
            CreateNewEntry()
        End If

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
        BigMsgBox(IIf(RecordThere(), "Record Created", "Record Creation FAIL"))

    End Sub

    Private Sub CreateNewEntry()
        Dim sqlString As String
        Dim sqlConnect As New SqlConnection(), commandSQL As SqlCommand
        Dim sConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        ' get yesterday's values
        sqlString = "EXEC InsertCashTillSetupForToday " + QTrim(Date.Today.AddDays(-1).ToShortDateString.Trim) + ", " +
                        QTrim(Today.ToShortDateString.Trim)

        Try

            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            commandSQL = New SqlCommand(sqlString, sqlConnect)
            commandSQL.ExecuteNonQuery()
            commandSQL.Dispose()

            sqlString = "EXEC GetCurrentCashTill " & QTrim(Today.ToShortDateString.Trim)

            commandSQL = New SqlCommand(sqlString, sqlConnect)

            Dim reader = commandSQL.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                NumericUpDown1.Value = (0 + reader.Item("CashIn"))
                reader.Close()
            Else
                reader.Close()
                sqlString = "INSERT INTO CASH (CashDate, CashIn, CashOut) VALUES (" + QTrim(Date.Today.ToShortDateString.Trim) + ", " +
            "0,0)"

                commandSQL = New SqlCommand(sqlString, sqlConnect)
                commandSQL.ExecuteNonQuery()
                commandSQL.Dispose()

            End If

            sqlConnect.Close()

        Catch ex As ArgumentException
            BigMsgBox("" & ex.Message)

        Finally

        End Try

    End Sub
End Class