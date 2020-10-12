<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ManagerFunctions
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
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnCreateTables = New System.Windows.Forms.Button()
        Me.btnReceiptDelete = New System.Windows.Forms.Button()
        Me.nReceiptDelete = New System.Windows.Forms.NumericUpDown()
        Me.lblReceiptDeleted = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnCashDrawer = New System.Windows.Forms.Button()
        CType(Me.nReceiptDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnInventory
        '
        Me.btnInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventory.Location = New System.Drawing.Point(12, 21)
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.Size = New System.Drawing.Size(131, 39)
        Me.btnInventory.TabIndex = 3
        Me.btnInventory.Text = "Inventory"
        Me.btnInventory.UseVisualStyleBackColor = True
        '
        'btnCreateTables
        '
        Me.btnCreateTables.Location = New System.Drawing.Point(12, 138)
        Me.btnCreateTables.Name = "btnCreateTables"
        Me.btnCreateTables.Size = New System.Drawing.Size(131, 43)
        Me.btnCreateTables.TabIndex = 4
        Me.btnCreateTables.Text = "Create Latest Tables"
        Me.btnCreateTables.UseVisualStyleBackColor = True
        '
        'btnReceiptDelete
        '
        Me.btnReceiptDelete.Location = New System.Drawing.Point(12, 198)
        Me.btnReceiptDelete.Name = "btnReceiptDelete"
        Me.btnReceiptDelete.Size = New System.Drawing.Size(131, 45)
        Me.btnReceiptDelete.TabIndex = 5
        Me.btnReceiptDelete.Text = "Receipt Delete"
        Me.btnReceiptDelete.UseVisualStyleBackColor = True
        '
        'nReceiptDelete
        '
        Me.nReceiptDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nReceiptDelete.Location = New System.Drawing.Point(171, 200)
        Me.nReceiptDelete.Name = "nReceiptDelete"
        Me.nReceiptDelete.Size = New System.Drawing.Size(120, 34)
        Me.nReceiptDelete.TabIndex = 6
        '
        'lblReceiptDeleted
        '
        Me.lblReceiptDeleted.AutoSize = True
        Me.lblReceiptDeleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptDeleted.Location = New System.Drawing.Point(321, 198)
        Me.lblReceiptDeleted.Name = "lblReceiptDeleted"
        Me.lblReceiptDeleted.Size = New System.Drawing.Size(349, 32)
        Me.lblReceiptDeleted.TabIndex = 7
        Me.lblReceiptDeleted.Text = "Receipt Has Been Deleted"
        Me.lblReceiptDeleted.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'btnCashDrawer
        '
        Me.btnCashDrawer.Location = New System.Drawing.Point(12, 75)
        Me.btnCashDrawer.Name = "btnCashDrawer"
        Me.btnCashDrawer.Size = New System.Drawing.Size(152, 40)
        Me.btnCashDrawer.TabIndex = 8
        Me.btnCashDrawer.Text = "Cash Drawer Setup"
        Me.btnCashDrawer.UseVisualStyleBackColor = True
        '
        'ManagerFunctions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnCashDrawer)
        Me.Controls.Add(Me.lblReceiptDeleted)
        Me.Controls.Add(Me.nReceiptDelete)
        Me.Controls.Add(Me.btnReceiptDelete)
        Me.Controls.Add(Me.btnCreateTables)
        Me.Controls.Add(Me.btnInventory)
        Me.Name = "ManagerFunctions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manager's Functions"
        CType(Me.nReceiptDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnInventory As Button
    Friend WithEvents btnCreateTables As Button
    Friend WithEvents btnReceiptDelete As Button
    Friend WithEvents nReceiptDelete As NumericUpDown
    Friend WithEvents lblReceiptDeleted As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnCashDrawer As Button
End Class
