Imports System.Data.SqlClient
Imports IngenicoPOS
Imports Ingenico
Imports System.IO
Imports Microsoft.Reporting
Imports MuseumPOS.My
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing
Imports System.Xml
Module Module1
    Public Function QTrim(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "'" & sPar.Trim & "'"
    End Function

    Public Function QLike(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "'%" & sPar.Trim & "%'"
    End Function

    Public Sub BigMsgBox(ByVal sMessage As String)
        Dim fMessage As New Dialog1

        fMessage.TextBox1.Text = "" & sMessage
        fMessage.ShowDialog()
        fMessage = Nothing

    End Sub

    Public Sub SaveCCAuthInfo(ByVal sAuthorizationCode As String, ByVal sTransactionID As String)
        Dim commandSQL1 As SqlCommand
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"
        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()
        Dim sqlConnect1 As New SqlConnection(sConnectionString)

        sqlString = "INSERT INTO CCAuth(AuthCode, TransactionID, AuthDateTime) VALUES ("
        sqlString += QTrim(sAuthorizationCode) + "," + QTrim(sTransactionID) + ", CURRENT_TIMESTAMP)"

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

    Public Function GetTransactionCodeByCCAuthCode(ByVal sAuthorizationCode As String) As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String, sReturnValue As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT AuthCode, TransactionID FROM CCAuth WHERE AuthCode = " + QTrim(sAuthorizationCode)
        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        sReturnValue = ""
        If reader.HasRows Then
            On Error Resume Next

            reader.Read()
            sReturnValue = 0 + reader.Item("AuthCode")
        End If

        reader.Close()

        sqlConnect.Close()
        Return sReturnValue
    End Function

    Public Function GetSumByDatePayType(ByVal sPayType As String, ByVal sDate As String) As Double
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnSum As Double

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT SUM(Paid) as SumReturn FROM Receipt WHERE ReceiptDate = "
        sqlString += QTrim(sDate)
        sqlString += " And PayType = "
        sqlString += QTrim(sPayType)
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
            nReturnSum = (reader.Item("SumReturn"))
        End If

        reader.Close()

        sqlConnect.Close()

        Return (nReturnSum)
    End Function


End Module
