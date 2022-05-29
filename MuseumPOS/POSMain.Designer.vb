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
        Me.btnManagerFunctions = New System.Windows.Forms.Button()
        Me.btnQuick1 = New System.Windows.Forms.Button()
        Me.btnQuick2 = New System.Windows.Forms.Button()
        Me.btnQuick3 = New System.Windows.Forms.Button()
        Me.btnQuick5 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUPC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTaxRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CardType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDELETE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuick6 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
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
        Me.btnAttend = New System.Windows.Forms.Button()
        Me.lblTicketSum = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.btnDrawer = New System.Windows.Forms.Button()
        Me.btnQuick4 = New System.Windows.Forms.Button()
        Me.TimerEntryFocus = New System.Windows.Forms.Timer(Me.components)
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
        'btnManagerFunctions
        '
        Me.btnManagerFunctions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManagerFunctions.Location = New System.Drawing.Point(1878, 6)
        Me.btnManagerFunctions.Name = "btnManagerFunctions"
        Me.btnManagerFunctions.Size = New System.Drawing.Size(131, 37)
        Me.btnManagerFunctions.TabIndex = 2
        Me.btnManagerFunctions.Text = "Manager"
        Me.btnManagerFunctions.UseVisualStyleBackColor = True
        Me.btnManagerFunctions.Visible = False
        '
        'btnQuick1
        '
        Me.btnQuick1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnQuick1.Font = New System.Drawing.Font("Constantia", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuick1.ForeColor = System.Drawing.Color.Yellow
        Me.btnQuick1.Location = New System.Drawing.Point(12, 58)
        Me.btnQuick1.Name = "btnQuick1"
        Me.btnQuick1.Size = New System.Drawing.Size(193, 162)
        Me.btnQuick1.TabIndex = 3
        Me.btnQuick1.Text = "ADULT"
        Me.btnQuick1.UseVisualStyleBackColor = False
        '
        'btnQuick2
        '
        Me.btnQuick2.BackColor = System.Drawing.Color.Aqua
        Me.btnQuick2.Font = New System.Drawing.Font("Constantia", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuick2.Location = New System.Drawing.Point(211, 58)
        Me.btnQuick2.Name = "btnQuick2"
        Me.btnQuick2.Size = New System.Drawing.Size(186, 162)
        Me.btnQuick2.TabIndex = 4
        Me.btnQuick2.Text = "CHILD"
        Me.btnQuick2.UseVisualStyleBackColor = False
        '
        'btnQuick3
        '
        Me.btnQuick3.BackColor = System.Drawing.Color.Green
        Me.btnQuick3.Font = New System.Drawing.Font("Constantia", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuick3.ForeColor = System.Drawing.Color.Coral
        Me.btnQuick3.Location = New System.Drawing.Point(12, 226)
        Me.btnQuick3.Name = "btnQuick3"
        Me.btnQuick3.Size = New System.Drawing.Size(193, 146)
        Me.btnQuick3.TabIndex = 5
        Me.btnQuick3.Text = "ADULT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AAA/MIL"
        Me.btnQuick3.UseVisualStyleBackColor = False
        '
        'btnQuick5
        '
        Me.btnQuick5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnQuick5.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuick5.Location = New System.Drawing.Point(12, 378)
        Me.btnQuick5.Name = "btnQuick5"
        Me.btnQuick5.Size = New System.Drawing.Size(193, 153)
        Me.btnQuick5.TabIndex = 6
        Me.btnQuick5.Text = "ADULT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GROUP"
        Me.btnQuick5.UseVisualStyleBackColor = False
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
        'btnQuick6
        '
        Me.btnQuick6.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuick6.Location = New System.Drawing.Point(211, 378)
        Me.btnQuick6.Name = "btnQuick6"
        Me.btnQuick6.Size = New System.Drawing.Size(186, 153)
        Me.btnQuick6.TabIndex = 8
        Me.btnQuick6.Text = "CHILD" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GROUP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnQuick6.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button9.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(424, 836)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(220, 87)
        Me.Button9.TabIndex = 12
        Me.Button9.Text = "CARD"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button10.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(651, 836)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(167, 87)
        Me.Button10.TabIndex = 13
        Me.Button10.Text = "CASH"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Constantia", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(1670, 836)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(163, 87)
        Me.Button12.TabIndex = 15
        Me.Button12.Text = "CLEAR ALL"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDone.Font = New System.Drawing.Font("Constantia", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.ForeColor = System.Drawing.Color.Coral
        Me.btnDone.Location = New System.Drawing.Point(1292, 836)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(211, 87)
        Me.btnDone.TabIndex = 16
        Me.btnDone.Text = "SAVE AND" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PRINT"
        Me.btnDone.UseVisualStyleBackColor = False
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
        Me.Timer1.Interval = 15000
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
        Me.btnManagerMode.Size = New System.Drawing.Size(174, 39)
        Me.btnManagerMode.TabIndex = 33
        Me.btnManagerMode.Text = "Manager Mode is OFF"
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
        Me.btnReportMenu.Location = New System.Drawing.Point(1614, 6)
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
        Me.btnReturn.Visible = False
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
        'btnAttend
        '
        Me.btnAttend.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttend.Location = New System.Drawing.Point(1730, 6)
        Me.btnAttend.Name = "btnAttend"
        Me.btnAttend.Size = New System.Drawing.Size(142, 38)
        Me.btnAttend.TabIndex = 41
        Me.btnAttend.Text = "Attendance"
        Me.btnAttend.UseVisualStyleBackColor = True
        '
        'lblTicketSum
        '
        Me.lblTicketSum.AutoSize = True
        Me.lblTicketSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTicketSum.Location = New System.Drawing.Point(282, 10)
        Me.lblTicketSum.Name = "lblTicketSum"
        Me.lblTicketSum.Size = New System.Drawing.Size(71, 32)
        Me.lblTicketSum.TabIndex = 42
        Me.lblTicketSum.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(264, 25)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Value of Tickets Sold Today:"
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.Location = New System.Drawing.Point(461, 789)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(545, 32)
        Me.lblChange.TabIndex = 44
        Me.lblChange.Text = "Message Regarding Change for Customer"
        '
        'btnDrawer
        '
        Me.btnDrawer.BackColor = System.Drawing.Color.Aqua
        Me.btnDrawer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDrawer.Location = New System.Drawing.Point(1522, 836)
        Me.btnDrawer.Name = "btnDrawer"
        Me.btnDrawer.Size = New System.Drawing.Size(127, 87)
        Me.btnDrawer.TabIndex = 45
        Me.btnDrawer.Text = "Open Drawer"
        Me.btnDrawer.UseVisualStyleBackColor = False
        '
        'btnQuick4
        '
        Me.btnQuick4.BackColor = System.Drawing.Color.Gold
        Me.btnQuick4.Font = New System.Drawing.Font("Constantia", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuick4.ForeColor = System.Drawing.Color.Brown
        Me.btnQuick4.Location = New System.Drawing.Point(211, 226)
        Me.btnQuick4.Name = "btnQuick4"
        Me.btnQuick4.Size = New System.Drawing.Size(186, 146)
        Me.btnQuick4.TabIndex = 46
        Me.btnQuick4.Text = "button 4 text"
        Me.btnQuick4.UseVisualStyleBackColor = False
        Me.btnQuick4.Visible = False
        '
        'TimerEntryFocus
        '
        Me.TimerEntryFocus.Enabled = True
        Me.TimerEntryFocus.Interval = 8000
        '
        'POSMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 935)
        Me.Controls.Add(Me.btnQuick4)
        Me.Controls.Add(Me.btnDrawer)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTicketSum)
        Me.Controls.Add(Me.btnAttend)
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
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.btnQuick6)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnQuick5)
        Me.Controls.Add(Me.btnQuick3)
        Me.Controls.Add(Me.btnQuick2)
        Me.Controls.Add(Me.btnQuick1)
        Me.Controls.Add(Me.btnManagerFunctions)
        Me.Controls.Add(Me.txtEntry)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "POSMain"
        Me.Text = "Roads and Rails Museum Point-of-Sale"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEntry As TextBox
    Friend WithEvents btnManagerFunctions As Button
    Friend WithEvents btnQuick1 As Button
    Friend WithEvents btnQuick2 As Button
    Friend WithEvents btnQuick3 As Button
    Friend WithEvents btnQuick5 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnQuick6 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
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
    Friend WithEvents colItem As DataGridViewTextBoxColumn
    Friend WithEvents colQTY As DataGridViewTextBoxColumn
    Friend WithEvents colPrice As DataGridViewTextBoxColumn
    Friend WithEvents colUPC As DataGridViewTextBoxColumn
    Friend WithEvents colTaxRate As DataGridViewTextBoxColumn
    Friend WithEvents PayType As DataGridViewTextBoxColumn
    Friend WithEvents CardType As DataGridViewTextBoxColumn
    Friend WithEvents colDELETE As DataGridViewTextBoxColumn
    Friend WithEvents btnAttend As Button
    Friend WithEvents lblTicketSum As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents btnDrawer As Button
    Friend WithEvents btnQuick4 As Button
    Friend WithEvents TimerEntryFocus As Timer
End Class
