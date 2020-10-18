Imports System.Data.SqlClient
Imports System.Data.SqlDbType

Public Class InventoryItem
    Private ChangedValue As Boolean
    'button1 = btnSave
    Dim sConnectionString As String
    Private bRadioButtonChanged As Boolean

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not (txtUPC.Text.Trim = "") Then
            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            Dim commandSQL As SqlCommand
            sqlString = "SELECT InvUPC from InventoryItems WHERE InvUPC = '" & Me.txtUPC.Text.Trim & "'"
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            Dim reader = commandSQL.ExecuteReader()
            AlreadyInTable = reader.HasRows
            reader.Close()
            sqlConnect.Close()
        Else
            txtUPC.Text = "00" + numItemNumber.Value.ToString.Trim
        End If

        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand

        If Not AlreadyInTable Then
            sqlString = "INSERT INTO InventoryItems(Id, InvUPC, InvName, InvNotes, InvType, InvCost, OnHandQuantity, Vendor, InvPrice, Department, TaxRate) "
            sqlString += " VALUES ("
            sqlString = sqlString & (numItemNumber.Value.ToString) & "," & QTrim(txtUPC.Text) & "," & QTrim(txtItemName.Text) & ","
            sqlString = sqlString & QTrim(txtNotes.Text) & "," & QTrim(cboType.Text) & "," & numUnitCost.Value.ToString & ","
            sqlString = sqlString & numOnHandQuantity.Value & "," & QTrim(cboVendor.Text) & "," & numPrice.Value.ToString
            sqlString = sqlString & "," & QTrim(cboDepartment.Text) & ", " & nTaxRate.Value.ToString.Trim & ")"
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
            sqlString += " TaxRate = " & nTaxRate.Value.ToString & ", "
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

        If Me.RadioButtonChanged Then
            SaveQuickButtons()
            POSMain.LoadButtonSetup()
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

    Private Sub LoadGrid(Optional ByVal parSQL$ = "")

        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        If parSQL$ = "" Then
            cmd.CommandText = "SELECT Id, InvUPC, InvName, InvType, Vendor, Department, TaxRate, InvPrice, InvCost, OnHandQuantity, InvNotes, UniqueID, TaxRate FROM InventoryItems"
        Else
            cmd.CommandText = parSQL
        End If

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
                                              reader.Item("OnHandQuantity"), reader.Item("Id"), reader.Item("InvUPC"), reader.Item("UniqueID"), reader.Item("TaxRate"))
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

        If DataGridView1.Rows.Count < 1 Then
            Me.Close()
            Exit Sub
        End If

        Dim sqlConnect As New SqlConnection()
        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand, sSQL As String, sInvUPC As String, sUPC_Validation As String

        sInvUPC = ("" & DataGridView1.Item(8, DataGridView1.CurrentRow.Index).Value)
        lblUniqueID.Text = ("" & DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value)

        sUPC_Validation = ("" & sInvUPC.Trim)
        If Val(lblUniqueID.Text) < 1 Then Exit Sub

        cmd.CommandType = CommandType.Text
        sSQL = "SELECT Id, InvUPC, InvName, InvType, Vendor, Department, InvPrice, InvCost, OnHandQuantity, InvNotes, UniqueID, TaxRate FROM InventoryItems"
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
                    If cboType.Text.ToUpper.Trim <> "NONINVENTORY" Then
                        Me.numOnHandQuantity.Visible = True
                        Me.numOnHandQuantity.Value = reader.Item("OnHandQuantity")
                    Else
                        Me.numOnHandQuantity.Visible = False
                    End If

                    Me.numItemNumber.Value = reader.Item("Id")
                        Me.txtUPC.Text = reader.Item("InvUPC").ToString.Trim
                    Me.txtNotes.Text = reader.Item("InvNotes").ToString.Trim
                    If Not IsDBNull(reader.Item("TaxRate")) Then
                        Me.nTaxRate.Value = reader.Item("TaxRate")
                    Else
                        Me.nTaxRate.Value = 0
                    End If

                    ScatterQuickButtons()
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

    Public Property RadioButtonChanged() As Boolean
        Get
            Return bRadioButtonChanged
        End Get
        Set(ByVal value As Boolean)
            bRadioButtonChanged = value
        End Set
    End Property
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
            If ChangedValue = False Then ' turn off but never on from here
                Me.RadioButtonChanged = False
            End If
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
        numItemNumber.Value = GetMaxItemNumber() + 1
        txtUPC.ReadOnly = False ' allow new UPC
        txtUPC.Focus()
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
        Me.nTaxRate.Value = 6.0   ' 6% default tax rate

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
        nTaxRate.Enabled = Not bLockField
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

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not (lblUniqueID.Text = "0") Then
            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            Dim commandSQL As SqlCommand
            sqlString = "DELETE FROM InventoryItems WHERE UniqueID = " & lblUniqueID.Text
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            commandSQL.ExecuteNonQuery()
            sqlConnect.Close()
            BigMsgBox("Record Deleted")

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
        ' reload list values
        LoadALLComboBoxes()

    End Sub

    Private Sub LoadALLComboBoxes()
        LoadComboBox("INVTYPE", cboType)
        LoadComboBox("VENDOR", cboVendor)
        LoadComboBox("DEPT", cboDepartment)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim sEntry As String, bIsNumeric As Boolean

        sEntry = txtSearch.Text.Trim
        bIsNumeric = IsNumeric(sEntry)

        RunSearch()

    End Sub

    Private Sub RunSearch()

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String, sSearchLikeValue$

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString
        sSearchLikeValue = QLike(txtSearch.Text)
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        sSQL = "SELECT Id, InvUPC, InvName, InvType, Vendor, Department, InvPrice, InvCost, OnHandQuantity, TaxRate, InvNotes, UniqueID FROM InventoryItems"

        sSQL += " WHERE InvName LIKE " & sSearchLikeValue
        sSQL += " OR InvUPC LIKE " & sSearchLikeValue
        If sSearchLikeValue.Length < 12 Then
            sSQL += " OR Id LIKE " & sSearchLikeValue
        End If

        LoadGrid(sSQL) ' run LoadGrid() but with SQL parameter
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyUp
        Dim sEntry As String

        If e.KeyCode <> Keys.Enter Then Exit Sub
        sEntry = txtSearch.Text.Trim

        RunSearch()
    End Sub

    Private Sub nTaxRate_ValueChanged(sender As Object, e As EventArgs) Handles nTaxRate.ValueChanged
        Me.Changed = True

    End Sub

    Private Sub numItemNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles numItemNumber.KeyUp
        Me.Changed = True
    End Sub

    Private Sub SaveQuickButtons()

        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()
        Dim nRadioButtonValue As Long

        If RadioButton1.Checked Then nRadioButtonValue = 1
        If RadioButton2.Checked Then nRadioButtonValue = 2
        If RadioButton3.Checked Then nRadioButtonValue = 3
        If RadioButton4.Checked Then nRadioButtonValue = 4
        If RadioButton5.Checked Then nRadioButtonValue = 5
        If RadioButton6.Checked Then nRadioButtonValue = 6
        If RadioButtonNONE.Checked Then nRadioButtonValue = 0

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not (txtUPC.Text.Trim = "") Then
            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            Dim commandSQL As SqlCommand
            sqlString = "SELECT ButtonNumber FROM Buttons WHERE ButtonNumber = " & nRadioButtonValue.ToString.Trim
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            Dim reader = commandSQL.ExecuteReader()
            AlreadyInTable = reader.HasRows
            reader.Close()
            sqlConnect.Close()
        End If

        Dim sqlConnect1 As New SqlConnection(sConnectionString)
        Dim commandSQL1 As SqlCommand

        If Not AlreadyInTable Then
            If RadioButtonNONE.Checked Then
                sqlString = "DELETE FROM Buttons WHERE ButtonUPC = " & QTrim(txtUPC.Text)
            Else
                sqlString = "INSERT INTO Buttons(ButtonUPC, ButtonText, ButtonNumber) VALUES ("
                sqlString = sqlString & QTrim(txtUPC.Text) & "," & QTrim(txtNotes.Text) & "," & nRadioButtonValue & ")"
            End If

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
            sqlString = "UPDATE Buttons SET ButtonText = " & QTrim(Me.txtNotes.Text.Trim) & ","
            sqlString += " ButtonUPC = " & QTrim(txtUPC.Text.Trim)
            sqlString += " WHERE ButtonNumber = " & nRadioButtonValue.ToString.Trim

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

    End Sub


    Private Sub ScatterQuickButtons()

        RadioButtonNONE.Checked = True

        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        If Not (txtUPC.Text.Trim = "") Then
            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            Dim commandSQL As SqlCommand
            sqlString = "SELECT ButtonNumber FROM buttons WHERE ButtonUPC = '" & Me.txtUPC.Text.Trim & "'"
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            Dim reader = commandSQL.ExecuteReader()
            If reader.HasRows Then
                reader.Read()

                Select Case reader.Item("ButtonNumber")
                    Case 1
                        RadioButton1.Checked = True
                    Case 2
                        RadioButton2.Checked = True
                    Case 3
                        RadioButton3.Checked = True
                    Case 4
                        RadioButton4.Checked = True
                    Case 5
                        RadioButton5.Checked = True
                    Case 6
                        RadioButton6.Checked = True
                End Select
            End If

            reader.Close()
                sqlConnect.Close()
            End If


    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Me.Changed = True
        Me.RadioButtonChanged = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.Changed = True
        Me.RadioButtonChanged = True
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Me.Changed = True
        Me.RadioButtonChanged = True

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Me.Changed = True
        Me.RadioButtonChanged = True

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        Me.Changed = True
        Me.RadioButtonChanged = True

    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        Me.Changed = True
        Me.RadioButtonChanged = True

    End Sub

    Private Sub RadioButtonNONE_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNONE.CheckedChanged
        Me.Changed = True
        Me.RadioButtonChanged = True

    End Sub
End Class
