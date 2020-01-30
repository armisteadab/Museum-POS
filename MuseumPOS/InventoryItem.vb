Imports System.Data.SqlClient
Imports System.Data.SqlDbType


Public Class InventoryItem
    Private ChangedValue As Boolean
    'button1 = btnSave
    Dim sConnectionString As String

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not (txtUPC.Text = "") Then
            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            Dim commandSQL As SqlCommand
            sqlString = "SELECT InvUPC from InventoryItems WHERE InvUPC = '" & Me.txtUPC.Text.Trim & "'"
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            Dim reader = commandSQL.ExecuteReader()
            AlreadyInTable = reader.HasRows
            reader.Close()
            sqlConnect.Close()

        End If

        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand

        If Not AlreadyInTable Then
            sqlString = "INSERT INTO InventoryItems(Id, InvUPC, InvName, InvNotes, InvType, InvCost, OnHandQuantity, Vendor, InvPrice, Department) "
            sqlString += " VALUES ("
            sqlString = sqlString & (numItemNumber.Value.ToString) & "," & QTrim(txtUPC.Text) & "," & QTrim(txtItemName.Text) & ","
            sqlString = sqlString & QTrim(txtNotes.Text) & "," & QTrim(cboType.Text) & "," & numUnitCost.Value.ToString & ","
            sqlString = sqlString & numOnHandQuantity.Value & "," & QTrim(cboVendor.Text) & "," & numPrice.Value.ToString
            sqlString = sqlString & "," & QTrim(cboDepartment.Text) & ")"
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
            Debug.Print(sqlString)

        Else 'update instead
            'InvType, InvCost, InvPrice, Department,  OnHandQuantity, Vendor, InvNotes, Id) values ("
            sqlString = "UPDATE InventoryItems SET InvName = " & QTrim(txtItemName.Text) & ","
            sqlString += " InvType = " & QTrim(cboType.Text) & ","
            sqlString += " InvCost = " & numUnitCost.Value.ToString & ","
            sqlString += " OnHandQuantity = " & numOnHandQuantity.Value & ","
            sqlString += " Vendor = " & QTrim(cboVendor.Text) & ","
            sqlString += " InvPrice = " & numPrice.Value.ToString & ","
            sqlString += " Department = " & QTrim(cboDepartment.Text) & ","
            sqlString += " InvNotes = " & QTrim(txtNotes.Text) & ", "
            sqlString += "Id =" & numItemNumber.Value
            sqlString += " WHERE UniqueID = " & (lblUniqueID.Text)

            Debug.Print(sqlString)

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

    Private Sub txtUPC_TextChanged(sender As Object, e As EventArgs) Handles txtUPC.TextChanged
        Me.Changed = True

    End Sub

    Private Sub InventoryItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnActualDelete.Visible = False
        LoadALLComboBoxes()
        LoadGrid()
    End Sub

    Private Sub LoadGrid()

        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT Id, InvUPC, InvName, InvType, Vendor, Department, InvPrice, InvCost, OnHandQuantity, InvNotes, UniqueID FROM InventoryItems"
        cmd.Connection = sqlConnect
        ' Create a SqlParameter for each parameter in the stored procedure.

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State
        Dim nPriceDisplayGrid As Double, sPriceDisplayGrid As String

        Me.DataGridView1.Rows.Clear()

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

                    Me.DataGridView1.Rows.Add(reader.Item("InvName"), reader.Item("InvType"), reader.Item("Department"),
                                              reader.Item("Vendor"), sPriceDisplayGrid, reader.Item("InvCost"),
                                              reader.Item("OnHandQuantity"), reader.Item("Id"), reader.Item("InvUPC"), reader.Item("UniqueID"))
                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

        If DataGridView1.Rows.Count > 0 Then
            Scatter()
            '       Me.DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.Rows.Count - 1))
        End If


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellClick
        Scatter()
    End Sub

    Private Sub Scatter()

        Dim sqlConnect As New SqlConnection()
        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand, sSQL As String, sInvUPC As String, sUPC_Validation As String

        sInvUPC = ("" & DataGridView1.Item(8, DataGridView1.CurrentRow.Index).Value)
        lblUniqueID.Text = ("" & DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value)

        sUPC_Validation = ("" & sInvUPC.Trim)
        If Val(lblUniqueID.Text) < 1 Then Exit Sub

        cmd.CommandType = CommandType.Text
        sSQL = "SELECT Id, InvUPC, InvName, InvType, Vendor, Department, InvPrice, InvCost, OnHandQuantity, InvNotes, UniqueID FROM InventoryItems"
        sSQL += " WHERE UniqueID = " & (lblUniqueID.Text.Trim)

        cmd.CommandText = sSQL
        cmd.Connection = sqlConnect
        ' Create a SqlParameter for each parameter in the stored procedure.

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State
        Dim nPriceDisplayGrid As Double, sPriceDisplayGrid As String

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


                    Me.txtItemName.Text = reader.Item("InvName").ToString.Trim
                    Me.cboType.Text = reader.Item("InvType").ToString.Trim
                    Me.cboDepartment.Text = reader.Item("Department").ToString.Trim
                    Me.cboVendor.Text = reader.Item("Vendor").ToString.Trim
                    Me.numPrice.Value = nPriceDisplayGrid
                    Me.numUnitCost.Value = reader.Item("InvCost")
                    Me.numOnHandQuantity.Value = reader.Item("OnHandQuantity")
                    Me.numItemNumber.Value = reader.Item("Id")
                    Me.txtUPC.Text = reader.Item("InvUPC").ToString.Trim
                    Me.txtNotes.Text = reader.Item("InvNotes").ToString.Trim
                    Me.Changed = False   ' we haven't really changed data, just display/scatter

                    Me.lblUniqueID.Text = reader.Item("UniqueID")
                    txtUPC.ReadOnly = True ' not allow new UPC

                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        Me.Changed = True
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

    Private Sub txtNotes_TextChanged(sender As Object, e As EventArgs) Handles txtNotes.TextChanged
        Me.Changed = True
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        Me.Changed = True

    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        Me.Changed = True

    End Sub

    Private Sub cboVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVendor.SelectedIndexChanged
        Me.Changed = True

    End Sub

    Private Sub numPrice_ValueChanged(sender As Object, e As EventArgs) Handles numPrice.ValueChanged
        Me.Changed = True

    End Sub

    Private Sub numUnitCost_ValueChanged(sender As Object, e As EventArgs) Handles numUnitCost.ValueChanged
        Me.Changed = True

    End Sub

    Private Sub numOnHandQuantity_ValueChanged(sender As Object, e As EventArgs) Handles numOnHandQuantity.ValueChanged
        Me.Changed = True

    End Sub

    Private Sub numItemNumber_ValueChanged(sender As Object, e As EventArgs) Handles numItemNumber.ValueChanged
        Me.Changed = True

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearValues()
        txtUPC.ReadOnly = False ' allow new UPC
    End Sub

    Private Sub ClearValues()

        Me.txtItemName.Text = ""  '"InvName")
        Me.cboType.Text = ""  '"InvType")
        Me.cboDepartment.Text = ""  '"Department")
        Me.cboVendor.Text = ""  '"Vendor")
        Me.numPrice.Value = 0
        Me.numUnitCost.Value = 0  '"InvCost")
        Me.numOnHandQuantity.Value = 0  '"OnHandQuantity")
        Me.numItemNumber.Value = 0  '"Id")
        Me.txtUPC.Text = ""  '"InvUPC")
        Me.txtNotes.Text = ""  '"InvNotes")
        Me.lblUniqueID.Text = "0"
        Me.Changed = False   ' we haven't really changed data, just new record

    End Sub

    Private Sub LockEditFields(ByVal bLockField As Boolean)

        Me.txtItemName.Enabled = Not bLockField
        Me.cboType.Enabled = Not bLockField
        Me.cboDepartment.Enabled = Not bLockField
        Me.cboVendor.Enabled = Not bLockField
        Me.numPrice.Enabled = Not bLockField
        Me.numUnitCost.Enabled = Not bLockField
        Me.numOnHandQuantity.Enabled = Not bLockField
        Me.numItemNumber.Enabled = Not bLockField
        Me.txtUPC.Enabled = Not bLockField
        Me.txtNotes.Enabled = Not bLockField
        DataGridView1.Enabled = Not bLockField

    End Sub
    Private Sub btnAllowUPCChange_Click(sender As Object, e As EventArgs) Handles btnAllowUPCChange.Click
        Me.txtUPC.ReadOnly = Not (Me.txtUPC.ReadOnly) ' switch it
    End Sub

    Private Sub numPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles numPrice.KeyPress
        Me.Changed = True
    End Sub

    Private Sub numUnitCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles numUnitCost.KeyPress
        Me.Changed = True

    End Sub

    Private Sub numOnHandQuantity_Validated(sender As Object, e As EventArgs) Handles numOnHandQuantity.Validated
        Me.Changed = True
    End Sub

    Private Sub numItemNumber_Validated(sender As Object, e As EventArgs) Handles numItemNumber.Validated
        Me.Changed = True
    End Sub

    Private Sub numPrice_Validated(sender As Object, e As EventArgs) Handles numPrice.Validated
        Me.Changed = True
    End Sub

    Private Sub cboVendor_TextUpdate(sender As Object, e As EventArgs) Handles cboVendor.TextUpdate
        Me.Changed = True
    End Sub

    Private Sub cboDepartment_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartment.TextUpdate
        Me.Changed = True

    End Sub

    Private Sub cboType_TextUpdate(sender As Object, e As EventArgs) Handles cboType.TextUpdate
        Me.Changed = True
    End Sub

    Private Sub btnCancelChanges_Click(sender As Object, e As EventArgs) Handles btnCancelChanges.Click
        btnDelete.Visible = True ' hide this button
        btnActualDelete.Visible = False ' make ACTUAL delete button visible (instead of 'are you sure Y/N?')
        LockEditFields(False)
        Scatter()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' delete current row/record
        btnDelete.Visible = False ' hide this button
        btnActualDelete.Visible = True ' make ACTUAL delete button visible (instead of 'are you sure Y/N?')
        Me.Changed = True
        btnNew.Enabled = False
        btnSave.Enabled = False
        LockEditFields(True)
    End Sub

    Private Sub btnActualDelete_Click(sender As Object, e As EventArgs) Handles btnActualDelete.Click
        btnActualDelete.Visible = False
        btnDelete.Visible = True


        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not (lblUniqueID.Text = "0") Then
            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            Dim commandSQL As SqlCommand
            sqlString = "DELETE FROM InventoryItems WHERE UniqueID = " & lblUniqueID.Text
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            commandSQL.ExecuteNonQuery()
            sqlConnect.Close()

        End If

        LockEditFields(False)
        LoadGrid()

    End Sub

    Private Sub lblChanged_Click(sender As Object, e As EventArgs) Handles lblChanged.Click

    End Sub

    Private Sub btnListSetup_Click(sender As Object, e As EventArgs) Handles btnListSetup.Click
        Dim sListsSetup As New ListsSetup
        sListsSetup.ShowDialog()
        sListsSetup = Nothing
    End Sub

    Private Sub LoadALLComboBoxes()
        LoadComboBox("INVTYPE", cboType)
        LoadComboBox("VENDOR", cboVendor)
        LoadComboBox("DEPT", cboDepartment)
    End Sub
    Private Sub LoadComboBox(ByVal sComboType$, parObject As ComboBox)

        Dim sqlConnect As New SqlConnection(), sSQL$

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        sSQL = "SELECT ListOrder, ListValue, ListType, Id FROM ListSetup"
        sSQL += " WHERE ListType = " & QTrim(sComboType)
        sSQL += " ORDER BY ListOrder, Id"

        cmd.CommandText = sSQL
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
                    parObject.Items.Add(reader.Item("ListValue").ToString.Trim)

                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

    End Sub

End Class
