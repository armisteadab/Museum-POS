<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManagerFunctions
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
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnCreateTables = New System.Windows.Forms.Button()
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
        Me.btnCreateTables.Location = New System.Drawing.Point(12, 300)
        Me.btnCreateTables.Name = "btnCreateTables"
        Me.btnCreateTables.Size = New System.Drawing.Size(131, 43)
        Me.btnCreateTables.TabIndex = 4
        Me.btnCreateTables.Text = "Create Latest Tables"
        Me.btnCreateTables.UseVisualStyleBackColor = True
        '
        'ManagerFunctions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnCreateTables)
        Me.Controls.Add(Me.btnInventory)
        Me.Name = "ManagerFunctions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manager's Functions"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnInventory As Button
    Friend WithEvents btnCreateTables As Button
End Class
