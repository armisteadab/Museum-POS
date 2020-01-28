
Imports System.Data.SqlClient
Imports System.Data.SqlDbType

Public Class ListsSetup
    Private ChangedValue As Boolean
    'button1 = btnSave
    Dim sConnectionString As String

    Private Sub ListsSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnActualDelete.Visible = False
        LoadGrid()
    End Sub

    Private Sub LoadGrid()

        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT ListOrder, ListValue, ListType, Id FROM ListSetup"
        cmd.Connection = sqlConnect
        ' Create a SqlParameter for each parameter in the stored procedure.

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State
        Me.DataGridView1.Rows.Clear()

        Try
            If sqlConnect.State = ConnectionState.Closed Then
                sqlConnect.Open()
            End If
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    ' Process SprocResults datareader here.
                    Me.DataGridView1.Rows.Add(reader.Item("ListValue"), reader.Item("ListType"), reader.Item("ListOrder"),
                                              reader.Item("Id"))
                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

        If DataGridView1.Rows.Count > 0 Then
            Scatter()
        End If


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellClick
        Scatter()
    End Sub

    Private Sub Scatter()

        Dim sqlConnect As New SqlConnection()
        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand, sSQL As String, sID_Validation As String
        Dim nID As Integer

        Try
            nID = (DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value)

        Catch ex As ArgumentException
            MsgBox(ex.Message)
        End Try

        sID_Validation = ("" & nID.ToString.Trim)
        If sID_Validation.Length < 1 Then Exit Sub

        cmd.CommandType = CommandType.Text
        sSQL = "SELECT ListOrder, ListValue, ListType, Id FROM ListSetup"
        sSQL += " WHERE Id = " & nID

        cmd.CommandText = sSQL
        cmd.Connection = sqlConnect
        ' Create a SqlParameter for each parameter in the stored procedure.

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        Try
            If sqlConnect.State = ConnectionState.Closed Then
                sqlConnect.Open()
            End If
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    ' Process SprocResults datareader here.
                    With Me

                        .txtListType.Text = reader.Item("ListType").ToString.Trim
                        .txtListValue.Text = reader.Item("ListValue").ToString.Trim
                        .numListOrder.Value = reader.Item("ListOrder")
                        .lblID.Text = reader.Item("Id").ToString.Trim
                        .Changed = False   ' we haven't really changed data, just new record

                    End With

                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

    End Sub

    Public Property Changed() As Boolean
        Get
            Return ChangedValue
        End Get
        Set(ByVal value As Boolean)
            ChangedValue = value
            lblChanged.Visible = ChangedValue
            DataGridView1.Enabled = Not ChangedValue
            btnNew.Enabled = Not ChangedValue
            btnSave.Enabled = ChangedValue
            btnCancelChanges.Enabled = ChangedValue
        End Set
    End Property

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearValues()

    End Sub

    Private Sub ClearValues()

        With Me

            .txtListType.Text = ""
            .txtListValue.Text = ""
            .numListOrder.Value = 0
            .lblID.Text = "0"
            '          .Changed = True   ' we haven't really changed data, just new record

        End With

    End Sub

    Private Sub btnCancelChanges_Click(sender As Object, e As EventArgs) Handles btnCancelChanges.Click
        Scatter()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' delete current row/record
        btnDelete.Visible = False ' hide this button
        btnActualDelete.Visible = True ' make ACTUAL delete button visible (instead of 'are you sure Y/N?')
    End Sub

    Private Sub btnActualDelete_Click(sender As Object, e As EventArgs) Handles btnActualDelete.Click
        btnActualDelete.Visible = False
        btnDelete.Visible = True


        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not (lblID.Text = "0") Then
            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            Dim commandSQL As SqlCommand
            sqlString = "DELETE FROM ListSetup WHERE Id = '" & Me.lblID.Text.Trim & "'"
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            commandSQL.ExecuteNonQuery()
            sqlConnect.Close()

        End If

        LoadGrid()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not (lblID.Text = "0") Then
            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            Dim commandSQL As SqlCommand
            sqlString = "SELECT Id from ListSetup WHERE Id = '" & Me.lblID.Text.Trim & "'"
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            Dim reader = commandSQL.ExecuteReader()
            AlreadyInTable = reader.HasRows
            reader.Close()
            sqlConnect.Close()

        End If

        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand

        If Not AlreadyInTable Then
            sqlString = "INSERT INTO ListSetup(ListOrder, ListValue, ListType) "
            sqlString += " VALUES ("
            sqlString = sqlString & (numListOrder.Value.ToString) & "," & QTrim(txtListValue.Text) & "," & QTrim(txtListType.Text) & ")"
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

        Else 'update instead
            'InvType, InvCost, InvPrice, Department,  OnHandQuantity, Vendor, InvNotes, Id) values ("
            sqlString = "UPDATE ListSetup SET ListOrder = " & QTrim(numListOrder.Value.ToString) & ","
            sqlString += " ListType = " & QTrim(txtListType.Text) & ","
            sqlString += " ListValue = " & QTrim(txtListValue.Text)
            sqlString += " WHERE Id =" & lblID.Text.Trim

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

        LoadGrid()
        Scatter()
        Me.Changed = False

    End Sub

    Private Sub txtListValue_TextChanged(sender As Object, e As EventArgs) Handles txtListValue.TextChanged
        Me.Changed = True
    End Sub

    Private Sub txtListType_TextChanged(sender As Object, e As EventArgs) Handles txtListType.TextChanged
        Me.Changed = True

    End Sub

    Private Sub numListOrder_ValueChanged(sender As Object, e As EventArgs) Handles numListOrder.ValueChanged
        Me.Changed = True

    End Sub
End Class