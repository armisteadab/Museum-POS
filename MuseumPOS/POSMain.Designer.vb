<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POSMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtEntry = New System.Windows.Forms.TextBox()
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnAdult = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUPC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblReceiptNumber = New System.Windows.Forms.Label()
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
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEntry
        '
        Me.txtEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntry.Location = New System.Drawing.Point(427, 12)
        Me.txtEntry.Name = "txtEntry"
        Me.txtEntry.Size = New System.Drawing.Size(463, 34)
        Me.txtEntry.TabIndex = 0
        '
        'btnInventory
        '
        Me.btnInventory.Location = New System.Drawing.Point(1259, 12)
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.Size = New System.Drawing.Size(86, 39)
        Me.btnInventory.TabIndex = 2
        Me.btnInventory.Text = "Inventory"
        Me.btnInventory.UseVisualStyleBackColor = True
        '
        'btnAdult
        '
        Me.btnAdult.Font = New System.Drawing.Font("Constantia", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdult.Location = New System.Drawing.Point(12, 58)
        Me.btnAdult.Name = "btnAdult"
        Me.btnAdult.Size = New System.Drawing.Size(193, 162)
        Me.btnAdult.TabIndex = 3
        Me.btnAdult.Text = "ADULT"
        Me.btnAdult.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Constantia", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(211, 58)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(186, 162)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "CHILD"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Constantia", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(12, 226)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(193, 146)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "ADULT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AAA/MIL"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Constantia", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(12, 378)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(193, 153)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "ADULT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GROUP"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colQTY, Me.colPrice, Me.colUPC})
        Me.DataGridView1.Location = New System.Drawing.Point(424, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1237, 640)
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
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Constantia", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(211, 378)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(186, 153)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "CHILD" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GROUP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(315, 726)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(220, 87)
        Me.Button9.TabIndex = 12
        Me.Button9.Text = "CARD"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Constantia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(542, 726)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(167, 87)
        Me.Button10.TabIndex = 13
        Me.Button10.Text = "CASH"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(716, 726)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(166, 87)
        Me.Button11.TabIndex = 14
        Me.Button11.Text = "CHECK" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(limited use)"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Constantia", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(1036, 726)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(151, 87)
        Me.Button12.TabIndex = 15
        Me.Button12.Text = "CANCEL"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Constantia", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1199, 726)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 87)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "SAVE AND" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PRINT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(933, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Receipt #:"
        '
        'lblReceiptNumber
        '
        Me.lblReceiptNumber.AutoSize = True
        Me.lblReceiptNumber.Location = New System.Drawing.Point(1011, 13)
        Me.lblReceiptNumber.Name = "lblReceiptNumber"
        Me.lblReceiptNumber.Size = New System.Drawing.Size(42, 17)
        Me.lblReceiptNumber.TabIndex = 18
        Me.lblReceiptNumber.Text = "None"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvName, Me.InvType, Me.InvDepartment, Me.InvVendor, Me.InvPrice, Me.InvCost, Me.InvOnHandQuantity, Me.ID, Me.UPC, Me.UniqueID})
        Me.DataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView2.Location = New System.Drawing.Point(504, 137)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(665, 551)
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
        'POSMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1673, 825)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.lblReceiptNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnAdult)
        Me.Controls.Add(Me.btnInventory)
        Me.Controls.Add(Me.txtEntry)
        Me.Name = "POSMain"
        Me.Text = "POSMain"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEntry As TextBox
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnAdult As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button5 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblReceiptNumber As Label
    Friend WithEvents colItem As DataGridViewTextBoxColumn
    Friend WithEvents colQTY As DataGridViewTextBoxColumn
    Friend WithEvents colPrice As DataGridViewTextBoxColumn
    Friend WithEvents colUPC As DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DataGridView2 As DataGridView
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
End Class
