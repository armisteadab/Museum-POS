<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class POSMain
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtEntry = New System.Windows.Forms.TextBox()
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnAdult = New System.Windows.Forms.Button()
        Me.btnChild = New System.Windows.Forms.Button()
        Me.btnAAAMilAdult = New System.Windows.Forms.Button()
        Me.btnAdultGroup = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUPC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTaxRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CardType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDELETE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnChildGroup = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
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
        Me.TaxRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblReceiptTotal = New System.Windows.Forms.Label()
        Me.btnPreviousReceipt = New System.Windows.Forms.Button()
        Me.btnNextReceipt = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.btnManagerMode = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGo2LatestReceipt = New System.Windows.Forms.Button()
        Me.btnReportMenu = New System.Windows.Forms.Button()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.txtReceiptNumber = New System.Windows.Forms.TextBox()
        Me.btnZOut = New System.Windows.Forms.Button()
        Me.btnAttend = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEntry
        '
        Me.txtEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntry.Location = New System.Drawing.Point(427, 12)
        Me.txtEntry.MaxLength = 12
        Me.txtEntry.Name = "txtEntry"
        Me.txtEntry.Size = New System.Drawing.Size(463, 34)
        Me.txtEntry.TabIndex = 0
        '
        'btnInventory
        '
        Me.btnInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventory.Location = New System.Drawing.Point(1597, 6)
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.Size = New System.Drawing.Size(131, 39)
        Me.btnInventory.TabIndex = 2
        Me.btnInventory.Text = "Inventory"
        Me.btnInventory.UseVisualStyleBackColor = True
        '
        'btnAdult
        '
        Me.btnAdult.Font = New System.Drawing.Font("Constantia", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdult.Location = New System.Drawing.Point(12, 58)
        Me.btnAdult.Name = "btnAdult"
        Me.btnAdult.Size = New System.Drawing.Size(193, 162)
        Me.btnAdult.TabIndex = 3
        Me.btnAdult.Text = "ADULT"
        Me.btnAdult.UseVisualStyleBackColor = True
        '
        'btnChild
        '
        Me.btnChild.Font = New System.Drawing.Font("Constantia", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChild.Location = New System.Drawing.Point(211, 58)
        Me.btnChild.Name = "btnChild"
        Me.btnChild.Size = New System.Drawing.Size(186, 162)
        Me.btnChild.TabIndex = 4
        Me.btnChild.Text = "CHILD"
        Me.btnChild.UseVisualStyleBackColor = True
        '
        'btnAAAMilAdult
        '
        Me.btnAAAMilAdult.Font = New System.Drawing.Font("Constantia", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAAAMilAdult.Location = New System.Drawing.Point(12, 226)
        Me.btnAAAMilAdult.Name = "btnAAAMilAdult"
        Me.btnAAAMilAdult.Size = New System.Drawing.Size(193, 146)
        Me.btnAAAMilAdult.TabIndex = 5
        Me.btnAAAMilAdult.Text = "ADULT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AAA/MIL"
        Me.btnAAAMilAdult.UseVisualStyleBackColor = True
        '
        'btnAdultGroup
        '
        Me.btnAdultGroup.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdultGroup.Location = New System.Drawing.Point(12, 378)
        Me.btnAdultGroup.Name = "btnAdultGroup"
        Me.btnAdultGroup.Size = New System.Drawing.Size(193, 153)
        Me.btnAdultGroup.TabIndex = 6
        Me.btnAdultGroup.Text = "ADULT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GROUP"
        Me.btnAdultGroup.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colQTY, Me.colPrice, Me.colUPC, Me.colTaxRate, Me.PayType, Me.CardType, Me.colDELETE})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(424, 56)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1409, 725)
        Me.DataGridView1.TabIndex = 7
        '
        'colItem
        '
        Me.colItem.HeaderText = "Item"
        Me.colItem.MinimumWidth = 6
        Me.colItem.Name = "colItem"
        Me.colItem.ReadOnly = True
        Me.colItem.Width = 400
        '
        'colQTY
        '
        Me.colQTY.HeaderText = "QTY"
        Me.colQTY.MinimumWidth = 6
        Me.colQTY.Name = "colQTY"
        Me.colQTY.ReadOnly = True
        Me.colQTY.Width = 125
        '
        'colPrice
        '
        Me.colPrice.HeaderText = "Price"
        Me.colPrice.MinimumWidth = 6
        Me.colPrice.Name = "colPrice"
        Me.colPrice.ReadOnly = True
        Me.colPrice.Width = 125
        '
        'colUPC
        '
        Me.colUPC.HeaderText = "UPC"
        Me.colUPC.MinimumWidth = 6
        Me.colUPC.Name = "colUPC"
        Me.colUPC.ReadOnly = True
        Me.colUPC.Width = 125
        '
        'colTaxRate
        '
        Me.colTaxRate.HeaderText = "Tax%"
        Me.colTaxRate.MinimumWidth = 6
        Me.colTaxRate.Name = "colTaxRate"
        Me.colTaxRate.ReadOnly = True
        Me.colTaxRate.Width = 125
        '
        'PayType
        '
        Me.PayType.HeaderText = "PayType"
        Me.PayType.MinimumWidth = 6
        Me.PayType.Name = "PayType"
        Me.PayType.ReadOnly = True
        Me.PayType.Visible = False
        Me.PayType.Width = 125
        '
        'CardType
        '
        Me.CardType.HeaderText = "CardType"
        Me.CardType.MinimumWidth = 6
        Me.CardType.Name = "CardType"
        Me.CardType.ReadOnly = True
        Me.CardType.Visible = False
        Me.CardType.Width = 125
        '
        'colDELETE
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.NullValue = "delete"
        Me.colDELETE.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDELETE.HeaderText = ""
        Me.colDELETE.MinimumWidth = 6
        Me.colDELETE.Name = "colDELETE"
        Me.colDELETE.ReadOnly = True
        Me.colDELETE.Width = 125
        '
        'btnChildGroup
        '
        Me.btnChildGroup.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChildGroup.Location = New System.Drawing.Point(211, 378)
        Me.btnChildGroup.Name = "btnChildGroup"
        Me.btnChildGroup.Size = New System.Drawing.Size(186, 153)
        Me.btnChildGroup.TabIndex = 8
        Me.btnChildGroup.Text = "CHILD" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GROUP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnChildGroup.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(424, 836)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(220, 87)
        Me.Button9.TabIndex = 12
        Me.Button9.Text = "CARD"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(651, 836)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(167, 87)
        Me.Button10.TabIndex = 13
        Me.Button10.Text = "CASH"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(825, 836)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(141, 87)
        Me.Button11.TabIndex = 14
        Me.Button11.Text = "CHECK" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(limited use)"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Constantia", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(1625, 836)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(151, 87)
        Me.Button12.TabIndex = 15
        Me.Button12.Text = "CLEAR ALL"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Font = New System.Drawing.Font("Constantia", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.Location = New System.Drawing.Point(1292, 836)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(211, 87)
        Me.btnDone.TabIndex = 16
        Me.btnDone.Text = "SAVE AND" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PRINT"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(895, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 29)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Receipt #:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvName, Me.InvType, Me.InvDepartment, Me.InvVendor, Me.InvPrice, Me.InvCost, Me.InvOnHandQuantity, Me.ID, Me.UPC, Me.UniqueID, Me.TaxRate})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView2.Location = New System.Drawing.Point(504, 137)
        Me.DataGridView2.Name = "DataGridView2"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(1039, 551)
        Me.DataGridView2.TabIndex = 24
        Me.DataGridView2.Visible = False
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
        'TaxRate
        '
        Me.TaxRate.HeaderText = "Tax%"
        Me.TaxRate.MinimumWidth = 6
        Me.TaxRate.Name = "TaxRate"
        Me.TaxRate.Width = 125
        '
        'lblReceiptTotal
        '
        Me.lblReceiptTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReceiptTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptTotal.Location = New System.Drawing.Point(1224, 784)
        Me.lblReceiptTotal.Name = "lblReceiptTotal"
        Me.lblReceiptTotal.Size = New System.Drawing.Size(139, 37)
        Me.lblReceiptTotal.TabIndex = 25
        Me.lblReceiptTotal.Text = "0.00"
        Me.lblReceiptTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnPreviousReceipt
        '
        Me.btnPreviousReceipt.Location = New System.Drawing.Point(1129, 10)
        Me.btnPreviousReceipt.Name = "btnPreviousReceipt"
        Me.btnPreviousReceipt.Size = New System.Drawing.Size(89, 34)
        Me.btnPreviousReceipt.TabIndex = 26
        Me.btnPreviousReceipt.Text = "<<Prev"
        Me.btnPreviousReceipt.UseVisualStyleBackColor = True
        '
        'btnNextReceipt
        '
        Me.btnNextReceipt.Location = New System.Drawing.Point(1220, 10)
        Me.btnNextReceipt.Name = "btnNextReceipt"
        Me.btnNextReceipt.Size = New System.Drawing.Size(89, 34)
        Me.btnNextReceipt.TabIndex = 32
        Me.btnNextReceipt.Text = "Next >>"
        Me.btnNextReceipt.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM5"
        '
        'btnManagerMode
        '
        Me.btnManagerMode.Location = New System.Drawing.Point(1434, 7)
        Me.btnManagerMode.Name = "btnManagerMode"
        Me.btnManagerMode.Size = New System.Drawing.Size(157, 39)
        Me.btnManagerMode.TabIndex = 33
        Me.btnManagerMode.Text = "Manager Mode OFF"
        Me.btnManagerMode.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportViewer1.LocalReport.DisplayName = "Receipt"
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Me.ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\Receipt.rdl"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 537)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.ServerReport.ReportServerUrl = New System.Uri("", System.UriKind.Relative)
        Me.ReportViewer1.Size = New System.Drawing.Size(396, 246)
        Me.ReportViewer1.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1120, 788)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 29)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "TOTAL:"
        '
        'btnGo2LatestReceipt
        '
        Me.btnGo2LatestReceipt.Location = New System.Drawing.Point(1315, 10)
        Me.btnGo2LatestReceipt.Name = "btnGo2LatestReceipt"
        Me.btnGo2LatestReceipt.Size = New System.Drawing.Size(89, 34)
        Me.btnGo2LatestReceipt.TabIndex = 36
        Me.btnGo2LatestReceipt.Text = "Last>>"
        Me.btnGo2LatestReceipt.UseVisualStyleBackColor = True
        '
        'btnReportMenu
        '
        Me.btnReportMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.btnReportMenu.Location = New System.Drawing.Point(1734, 6)
        Me.btnReportMenu.Name = "btnReportMenu"
        Me.btnReportMenu.Size = New System.Drawing.Size(110, 39)
        Me.btnReportMenu.TabIndex = 37
        Me.btnReportMenu.Text = "Reports"
        Me.btnReportMenu.UseVisualStyleBackColor = True
        '
        'btnReturn
        '
        Me.btnReturn.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.Location = New System.Drawing.Point(1085, 836)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(199, 87)
        Me.btnReturn.TabIndex = 38
        Me.btnReturn.Text = "RETURN"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'txtReceiptNumber
        '
        Me.txtReceiptNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiptNumber.Location = New System.Drawing.Point(1023, 14)
        Me.txtReceiptNumber.Name = "txtReceiptNumber"
        Me.txtReceiptNumber.Size = New System.Drawing.Size(85, 34)
        Me.txtReceiptNumber.TabIndex = 39
        Me.txtReceiptNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnZOut
        '
        Me.btnZOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZOut.Location = New System.Drawing.Point(1795, 836)
        Me.btnZOut.Name = "btnZOut"
        Me.btnZOut.Size = New System.Drawing.Size(117, 50)
        Me.btnZOut.TabIndex = 40
        Me.btnZOut.Text = "Z Out"
        Me.btnZOut.UseVisualStyleBackColor = True
        '
        'btnAttend
        '
        Me.btnAttend.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttend.Location = New System.Drawing.Point(1850, 7)
        Me.btnAttend.Name = "btnAttend"
        Me.btnAttend.Size = New System.Drawing.Size(142, 38)
        Me.btnAttend.TabIndex = 41
        Me.btnAttend.Text = "Attendance"
        Me.btnAttend.UseVisualStyleBackColor = True
        '
        'POSMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 935)
        Me.Controls.Add(Me.btnAttend)
        Me.Controls.Add(Me.btnZOut)
        Me.Controls.Add(Me.txtReceiptNumber)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.btnReportMenu)
        Me.Controls.Add(Me.btnGo2LatestReceipt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnManagerMode)
        Me.Controls.Add(Me.btnNextReceipt)
        Me.Controls.Add(Me.btnPreviousReceipt)
        Me.Controls.Add(Me.lblReceiptTotal)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.btnChildGroup)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnAdultGroup)
        Me.Controls.Add(Me.btnAAAMilAdult)
        Me.Controls.Add(Me.btnChild)
        Me.Controls.Add(Me.btnAdult)
        Me.Controls.Add(Me.btnInventory)
        Me.Controls.Add(Me.txtEntry)
        Me.Name = "POSMain"
        Me.Text = "Roads and Rails Museum Point-of-Sale"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEntry As TextBox
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnAdult As Button
    Friend WithEvents btnChild As Button
    Friend WithEvents btnAAAMilAdult As Button
    Friend WithEvents btnAdultGroup As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnChildGroup As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents btnDone As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents lblReceiptTotal As Label
    Friend WithEvents InvName As DataGridViewTextBoxColumn
    Friend WithEvents InvType As DataGridViewTextBoxColumn
    Friend WithEvents InvDepartment As DataGridViewTextBoxColumn
    Friend WithEvents InvVendor As DataGridViewTextBoxColumn
    Friend WithEvents InvPrice As DataGridViewTextBoxColumn
    Friend WithEvents InvCost As DataGridViewTextBoxColumn
    Friend WithEvents InvOnHandQuantity As DataGridViewTextBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents UPC As DataGridViewTextBoxColumn
    Friend WithEvents UniqueID As DataGridViewTextBoxColumn
    Friend WithEvents TaxRate As DataGridViewTextBoxColumn
    Friend WithEvents btnPreviousReceipt As Button
    Friend WithEvents btnNextReceipt As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents btnManagerMode As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGo2LatestReceipt As Button
    Friend WithEvents btnReportMenu As Button
    Friend WithEvents btnReturn As Button
    Friend WithEvents txtReceiptNumber As TextBox
    Friend WithEvents btnZOut As Button
    Friend WithEvents colItem As DataGridViewTextBoxColumn
    Friend WithEvents colQTY As DataGridViewTextBoxColumn
    Friend WithEvents colPrice As DataGridViewTextBoxColumn
    Friend WithEvents colUPC As DataGridViewTextBoxColumn
    Friend WithEvents colTaxRate As DataGridViewTextBoxColumn
    Friend WithEvents PayType As DataGridViewTextBoxColumn
    Friend WithEvents CardType As DataGridViewTextBoxColumn
    Friend WithEvents colDELETE As DataGridViewTextBoxColumn
    Friend WithEvents btnAttend As Button
End Class
