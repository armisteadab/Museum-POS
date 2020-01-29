<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListsSetup
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtListValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numListOrder = New System.Windows.Forms.NumericUpDown()
        Me.btnActualDelete = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancelChanges = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.lblChanged = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numListOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Value, Me.ListType, Me.ListOrder, Me.Id})
        Me.DataGridView1.Location = New System.Drawing.Point(609, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(664, 524)
        Me.DataGridView1.TabIndex = 0
        '
        'Value
        '
        Me.Value.HeaderText = "ListValue"
        Me.Value.MinimumWidth = 6
        Me.Value.Name = "Value"
        Me.Value.ReadOnly = True
        Me.Value.Width = 125
        '
        'ListType
        '
        Me.ListType.HeaderText = "Type"
        Me.ListType.MinimumWidth = 6
        Me.ListType.Name = "ListType"
        Me.ListType.ReadOnly = True
        Me.ListType.Width = 125
        '
        'ListOrder
        '
        Me.ListOrder.HeaderText = "Order"
        Me.ListOrder.MinimumWidth = 6
        Me.ListOrder.Name = "ListOrder"
        Me.ListOrder.ReadOnly = True
        Me.ListOrder.Width = 125
        '
        'Id
        '
        Me.Id.HeaderText = "ID"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 125
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Value"
        '
        'txtListValue
        '
        Me.txtListValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtListValue.Location = New System.Drawing.Point(238, 48)
        Me.txtListValue.Name = "txtListValue"
        Me.txtListValue.Size = New System.Drawing.Size(229, 41)
        Me.txtListValue.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 36)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 36)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Order"
        '
        'numListOrder
        '
        Me.numListOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numListOrder.Location = New System.Drawing.Point(238, 198)
        Me.numListOrder.Name = "numListOrder"
        Me.numListOrder.Size = New System.Drawing.Size(120, 41)
        Me.numListOrder.TabIndex = 8
        '
        'btnActualDelete
        '
        Me.btnActualDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualDelete.Location = New System.Drawing.Point(462, 342)
        Me.btnActualDelete.Name = "btnActualDelete"
        Me.btnActualDelete.Size = New System.Drawing.Size(131, 44)
        Me.btnActualDelete.TabIndex = 35
        Me.btnActualDelete.Text = "Delete?"
        Me.btnActualDelete.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(462, 286)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(131, 44)
        Me.btnDelete.TabIndex = 34
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCancelChanges
        '
        Me.btnCancelChanges.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelChanges.Location = New System.Drawing.Point(403, 449)
        Me.btnCancelChanges.Name = "btnCancelChanges"
        Me.btnCancelChanges.Size = New System.Drawing.Size(190, 70)
        Me.btnCancelChanges.TabIndex = 33
        Me.btnCancelChanges.Text = "Cancel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Changes"
        Me.btnCancelChanges.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(28, 449)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(169, 70)
        Me.btnNew.TabIndex = 32
        Me.btnNew.Text = "Add New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'lblChanged
        '
        Me.lblChanged.AutoSize = True
        Me.lblChanged.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChanged.ForeColor = System.Drawing.Color.Coral
        Me.lblChanged.Location = New System.Drawing.Point(488, 12)
        Me.lblChanged.Name = "lblChanged"
        Me.lblChanged.Size = New System.Drawing.Size(95, 24)
        Me.lblChanged.TabIndex = 31
        Me.lblChanged.Text = "Changed"
        Me.lblChanged.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(205, 449)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(192, 70)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 277)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 36)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "ID"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(241, 277)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(85, 38)
        Me.lblID.TabIndex = 37
        Me.lblID.Text = "0000"
        '
        'cboType
        '
        Me.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"DEPT", "INVTYPE", "VENDOR"})
        Me.cboType.Location = New System.Drawing.Point(238, 127)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(229, 44)
        Me.cboType.TabIndex = 3
        '
        'ListsSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1285, 548)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnActualDelete)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancelChanges)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.lblChanged)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.numListOrder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtListValue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "ListsSetup"
        Me.Text = "ListsSetup"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numListOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtListValue As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents numListOrder As NumericUpDown
    Friend WithEvents btnActualDelete As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnCancelChanges As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents lblChanged As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Value As DataGridViewTextBoxColumn
    Friend WithEvents ListType As DataGridViewTextBoxColumn
    Friend WithEvents ListOrder As DataGridViewTextBoxColumn
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents lblID As Label
    Friend WithEvents cboType As ComboBox
End Class
