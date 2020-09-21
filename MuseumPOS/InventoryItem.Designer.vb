<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryItem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUPC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.cboVendor = New System.Windows.Forms.ComboBox()
        Me.numPrice = New System.Windows.Forms.NumericUpDown()
        Me.numUnitCost = New System.Windows.Forms.NumericUpDown()
        Me.numOnHandQuantity = New System.Windows.Forms.NumericUpDown()
        Me.numItemNumber = New System.Windows.Forms.NumericUpDown()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.InvName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvVendor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvOnHandQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UPC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UniqueID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblChanged = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnAllowUPCChange = New System.Windows.Forms.Button()
        Me.btnCancelChanges = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnActualDelete = New System.Windows.Forms.Button()
        Me.btnListSetup = New System.Windows.Forms.Button()
        Me.lblUniqueID = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.nTaxRate = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUnitCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOnHandQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numItemNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nTaxRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "UPC"
        '
        'txtUPC
        '
        Me.txtUPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUPC.Location = New System.Drawing.Point(98, 44)
        Me.txtUPC.MaxLength = 12
        Me.txtUPC.Name = "txtUPC"
        Me.txtUPC.ReadOnly = True
        Me.txtUPC.Size = New System.Drawing.Size(308, 34)
        Me.txtUPC.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Item Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 29)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Notes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 29)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 29)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Department"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 29)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Vendor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(31, 309)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 29)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Price"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(30, 351)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 29)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Unit Cost"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(30, 392)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(201, 29)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "On Hand Quantity"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(30, 434)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 29)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Item Number"
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(172, 93)
        Me.txtItemName.MaxLength = 20
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(415, 34)
        Me.txtItemName.TabIndex = 11
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(109, 142)
        Me.txtNotes.MaxLength = 50
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(478, 28)
        Me.txtNotes.TabIndex = 12
        '
        'cboType
        '
        Me.cboType.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(109, 182)
        Me.cboType.MaxDropDownItems = 80
        Me.cboType.MaxLength = 20
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(210, 37)
        Me.cboType.TabIndex = 13
        '
        'cboDepartment
        '
        Me.cboDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(176, 225)
        Me.cboDepartment.MaxLength = 20
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(230, 37)
        Me.cboDepartment.TabIndex = 14
        '
        'cboVendor
        '
        Me.cboVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(129, 268)
        Me.cboVendor.MaxLength = 20
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(228, 37)
        Me.cboVendor.TabIndex = 15
        '
        'numPrice
        '
        Me.numPrice.DecimalPlaces = 2
        Me.numPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPrice.Location = New System.Drawing.Point(109, 311)
        Me.numPrice.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numPrice.Name = "numPrice"
        Me.numPrice.Size = New System.Drawing.Size(120, 34)
        Me.numPrice.TabIndex = 16
        '
        'numUnitCost
        '
        Me.numUnitCost.DecimalPlaces = 2
        Me.numUnitCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numUnitCost.Location = New System.Drawing.Point(146, 351)
        Me.numUnitCost.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numUnitCost.Name = "numUnitCost"
        Me.numUnitCost.Size = New System.Drawing.Size(120, 34)
        Me.numUnitCost.TabIndex = 17
        '
        'numOnHandQuantity
        '
        Me.numOnHandQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numOnHandQuantity.Location = New System.Drawing.Point(242, 390)
        Me.numOnHandQuantity.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numOnHandQuantity.Minimum = New Decimal(New Integer() {45, 0, 0, -2147483648})
        Me.numOnHandQuantity.Name = "numOnHandQuantity"
        Me.numOnHandQuantity.Size = New System.Drawing.Size(120, 34)
        Me.numOnHandQuantity.TabIndex = 18
        '
        'numItemNumber
        '
        Me.numItemNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numItemNumber.Location = New System.Drawing.Point(199, 432)
        Me.numItemNumber.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numItemNumber.Name = "numItemNumber"
        Me.numItemNumber.Size = New System.Drawing.Size(120, 34)
        Me.numItemNumber.TabIndex = 19
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(214, 551)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(192, 70)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvName, Me.InvType, Me.InvDepartment, Me.InvVendor, Me.InvPrice, Me.InvCost, Me.InvOnHandQuantity, Me.ID, Me.UPC, Me.UniqueID})
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(655, 70)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(665, 551)
        Me.DataGridView1.TabIndex = 23
        '
        'InvName
        '
        Me.InvName.HeaderText = "Item Name"
        Me.InvName.MinimumWidth = 6
        Me.InvName.Name = "InvName"
        Me.InvName.Width = 225
        '
        'InvType
        '
        Me.InvType.HeaderText = "Type"
        Me.InvType.MinimumWidth = 6
        Me.InvType.Name = "InvType"
        Me.InvType.Width = 125
        '
        'InvDepartment
        '
        Me.InvDepartment.HeaderText = "Dept"
        Me.InvDepartment.MinimumWidth = 6
        Me.InvDepartment.Name = "InvDepartment"
        Me.InvDepartment.ReadOnly = True
        Me.InvDepartment.Width = 125
        '
        'InvVendor
        '
        Me.InvVendor.HeaderText = "Vendor"
        Me.InvVendor.MinimumWidth = 6
        Me.InvVendor.Name = "InvVendor"
        Me.InvVendor.ReadOnly = True
        Me.InvVendor.Width = 125
        '
        'InvPrice
        '
        Me.InvPrice.HeaderText = "Price"
        Me.InvPrice.MinimumWidth = 6
        Me.InvPrice.Name = "InvPrice"
        Me.InvPrice.ReadOnly = True
        Me.InvPrice.Width = 125
        '
        'InvCost
        '
        Me.InvCost.HeaderText = "Cost/Unit"
        Me.InvCost.MinimumWidth = 6
        Me.InvCost.Name = "InvCost"
        Me.InvCost.ReadOnly = True
        Me.InvCost.Width = 125
        '
        'InvOnHandQuantity
        '
        Me.InvOnHandQuantity.HeaderText = "Qty"
        Me.InvOnHandQuantity.MinimumWidth = 6
        Me.InvOnHandQuantity.Name = "InvOnHandQuantity"
        Me.InvOnHandQuantity.ReadOnly = True
        Me.InvOnHandQuantity.Width = 125
        '
        'ID
        '
        Me.ID.HeaderText = "Item #"
        Me.ID.MinimumWidth = 6
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 125
        '
        'UPC
        '
        Me.UPC.HeaderText = "UPC"
        Me.UPC.MinimumWidth = 6
        Me.UPC.Name = "UPC"
        Me.UPC.Width = 125
        '
        'UniqueID
        '
        Me.UniqueID.HeaderText = "."
        Me.UniqueID.MinimumWidth = 6
        Me.UniqueID.Name = "UniqueID"
        Me.UniqueID.Width = 125
        '
        'lblChanged
        '
        Me.lblChanged.AutoSize = True
        Me.lblChanged.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChanged.ForeColor = System.Drawing.Color.Coral
        Me.lblChanged.Location = New System.Drawing.Point(545, 44)
        Me.lblChanged.Name = "lblChanged"
        Me.lblChanged.Size = New System.Drawing.Size(95, 24)
        Me.lblChanged.TabIndex = 24
        Me.lblChanged.Text = "Changed"
        Me.lblChanged.Visible = False
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(37, 551)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(169, 70)
        Me.btnNew.TabIndex = 25
        Me.btnNew.Text = "Add New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnAllowUPCChange
        '
        Me.btnAllowUPCChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllowUPCChange.Location = New System.Drawing.Point(412, 44)
        Me.btnAllowUPCChange.Name = "btnAllowUPCChange"
        Me.btnAllowUPCChange.Size = New System.Drawing.Size(89, 36)
        Me.btnAllowUPCChange.TabIndex = 26
        Me.btnAllowUPCChange.Text = "Allow UPC Change"
        Me.btnAllowUPCChange.UseVisualStyleBackColor = True
        '
        'btnCancelChanges
        '
        Me.btnCancelChanges.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelChanges.Location = New System.Drawing.Point(412, 551)
        Me.btnCancelChanges.Name = "btnCancelChanges"
        Me.btnCancelChanges.Size = New System.Drawing.Size(190, 70)
        Me.btnCancelChanges.TabIndex = 27
        Me.btnCancelChanges.Text = "Cancel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Changes"
        Me.btnCancelChanges.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(487, 238)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(131, 44)
        Me.btnDelete.TabIndex = 28
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnActualDelete
        '
        Me.btnActualDelete.BackColor = System.Drawing.Color.Red
        Me.btnActualDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualDelete.Location = New System.Drawing.Point(487, 294)
        Me.btnActualDelete.Name = "btnActualDelete"
        Me.btnActualDelete.Size = New System.Drawing.Size(131, 44)
        Me.btnActualDelete.TabIndex = 29
        Me.btnActualDelete.Text = "Delete?"
        Me.btnActualDelete.UseVisualStyleBackColor = False
        '
        'btnListSetup
        '
        Me.btnListSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListSetup.Location = New System.Drawing.Point(505, 382)
        Me.btnListSetup.Name = "btnListSetup"
        Me.btnListSetup.Size = New System.Drawing.Size(113, 39)
        Me.btnListSetup.TabIndex = 30
        Me.btnListSetup.Text = "Setup"
        Me.btnListSetup.UseVisualStyleBackColor = True
        '
        'lblUniqueID
        '
        Me.lblUniqueID.AutoSize = True
        Me.lblUniqueID.Location = New System.Drawing.Point(32, 12)
        Me.lblUniqueID.Name = "lblUniqueID"
        Me.lblUniqueID.Size = New System.Drawing.Size(16, 17)
        Me.lblUniqueID.TabIndex = 31
        Me.lblUniqueID.Text = "0"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1180, 23)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(130, 40)
        Me.btnSearch.TabIndex = 32
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(655, 23)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(510, 41)
        Me.txtSearch.TabIndex = 33
        '
        'nTaxRate
        '
        Me.nTaxRate.DecimalPlaces = 2
        Me.nTaxRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nTaxRate.Location = New System.Drawing.Point(201, 484)
        Me.nTaxRate.Name = "nTaxRate"
        Me.nTaxRate.Size = New System.Drawing.Size(120, 34)
        Me.nTaxRate.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(32, 486)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(137, 29)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Tax Rate %"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label12.Location = New System.Drawing.Point(237, 392)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 29)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "n/a"
        '
        'InventoryItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1493, 689)
        Me.Controls.Add(Me.nTaxRate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lblUniqueID)
        Me.Controls.Add(Me.btnListSetup)
        Me.Controls.Add(Me.btnActualDelete)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancelChanges)
        Me.Controls.Add(Me.btnAllowUPCChange)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.lblChanged)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.numItemNumber)
        Me.Controls.Add(Me.numOnHandQuantity)
        Me.Controls.Add(Me.numUnitCost)
        Me.Controls.Add(Me.numPrice)
        Me.Controls.Add(Me.cboVendor)
        Me.Controls.Add(Me.cboDepartment)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUPC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "InventoryItem"
        Me.Text = "Inventory Item"
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUnitCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOnHandQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numItemNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nTaxRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtUPC As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents cboType As ComboBox
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents cboVendor As ComboBox
    Friend WithEvents numPrice As NumericUpDown
    Friend WithEvents numUnitCost As NumericUpDown
    Friend WithEvents numOnHandQuantity As NumericUpDown
    Friend WithEvents numItemNumber As NumericUpDown
    Friend WithEvents btnSave As Button
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents InvName As DataGridViewTextBoxColumn
    Friend WithEvents InvType As DataGridViewTextBoxColumn
    Friend WithEvents InvDepartment As DataGridViewTextBoxColumn
    Friend WithEvents InvVendor As DataGridViewTextBoxColumn
    Friend WithEvents InvPrice As DataGridViewTextBoxColumn
    Friend WithEvents InvCost As DataGridViewTextBoxColumn
    Friend WithEvents InvOnHandQuantity As DataGridViewTextBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents UPC As DataGridViewTextBoxColumn
    Friend WithEvents lblChanged As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnAllowUPCChange As Button
    Friend WithEvents btnCancelChanges As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnActualDelete As Button
    Friend WithEvents btnListSetup As Button
    Friend WithEvents UniqueID As DataGridViewTextBoxColumn
    Friend WithEvents lblUniqueID As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents nTaxRate As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
End Class
