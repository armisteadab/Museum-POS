Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Drawing.Text

Public Class Attendance
    Dim AlreadyInTable As Boolean = False, recordID As String
    Private Sub RecordThere()
        Dim sqlString As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        '    [Id] Int Not NULL PRIMARY KEY, 
        '    [Worker] Int NULL, 
        '    [TimeIN] SMALLDATETIME NULL, 
        '    [TimeOUT] SMALLDATETIME NULL, 
        '    [TimeEncoded] NCHAR(100) NULL


        sqlConnect.ConnectionString = sConnectionString
        sqlConnect.Open()
        '        sqlString = "SELECT Id, Worker, TimeIN, TimeOUT, TimeENCODED from Attendance WHERE Worker = " & TextBox1.Text.Trim & " AND "
        '       sqlString += "TimeOUT is null"

        sqlString = "EXEC AttendanceAlreadyThere " & TextBox1.Text.Trim
        Dim commandSQL As New SqlCommand(sqlString, sqlConnect)

        Dim reader = commandSQL.ExecuteReader()
        AlreadyInTable = reader.HasRows
        If AlreadyInTable Then
            reader.Read()
            recordID = 0 + reader.Item("Id")
        End If

        reader.Close()
        sqlConnect.Close()

    End Sub
    Private Sub Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LOGit()
    End Sub

    Private Sub LOGit()

        Dim sqlString As String
        Dim sqlConnect As New SqlConnection(), NEWID As Integer
        Dim sTimeNOW$
        Dim sConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If (TextBox1.Text.Trim = "") Then
            Exit Sub
        End If

        sqlConnect.ConnectionString = sConnectionString
        sqlConnect.Open()
        sqlString = "EXEC AttendanceMaxID"
        Dim commandSQL As New SqlCommand(sqlString, sqlConnect)

        Dim reader = commandSQL.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            NEWID = 0 + reader.Item("MaxID")

        Else
            NEWID = 1
        End If

        reader.Close()
        sqlConnect.Close()

        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand
        sTimeNOW = Now.ToString.Trim
        If Not AlreadyInTable Then ' checking in

            sqlString = "INSERT INTO Attendance(Id, Worker, TimeIN, TimeENCODED) "
            sqlString += " VALUES ("
            sqlString += (NEWID.ToString) + "," + (TextBox1.Text) + ","
            sqlString += QTrim(sTimeNOW) + ",'##################'"
            sqlString += ")"
            Try

                sqlConnect1.Open()
                commandSQL1 = New SqlCommand(sqlString, sqlConnect1)
                commandSQL1.ExecuteNonQuery()
                commandSQL1.Dispose()
                sqlConnect1.Close()

            Catch ex As ArgumentException
                MsgBox("" & ex.Message)

            Finally

            End Try

        Else 'update instead
            'InvType, InvCost, InvPrice, Department,  OnHandQuantity, Vendor, InvNotes, Id) values ("
            sqlString = "UPDATE Attendance SET TimeOUT = " & QTrim(sTimeNOW)
            sqlString += " WHERE Id = " + recordID

            Try

                sqlConnect1.Open()
                commandSQL1 = New SqlCommand(sqlString, sqlConnect1)
                commandSQL1.ExecuteNonQuery()
                commandSQL1.Dispose()
                sqlConnect1.Close()

            Catch ex As ArgumentException
                MsgBox("" & ex.Message)

            Finally

            End Try
        End If

        Me.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = 13 Then
            RecordThere()

            If AlreadyInTable Then
                Button1.Text += " OUT"
            Else
                Button1.Text += " IN"
            End If
            Button1.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RecordThere()

        If AlreadyInTable Then
            Button1.Text += " OUT"
        Else
            Button1.Text += " IN"
        End If
        Button1.Visible = True


    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
    End Sub
End Class