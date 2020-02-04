<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PriceModify
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
        Me.numPriceModify = New System.Windows.Forms.NumericUpDown()
        Me.btnDone = New System.Windows.Forms.Button()
        CType(Me.numPriceModify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'numPriceModify
        '
        Me.numPriceModify.DecimalPlaces = 2
        Me.numPriceModify.Font = New System.Drawing.Font("Microsoft Sans Serif", 66.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPriceModify.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numPriceModify.Location = New System.Drawing.Point(13, 13)
        Me.numPriceModify.Name = "numPriceModify"
        Me.numPriceModify.Size = New System.Drawing.Size(680, 132)
        Me.numPriceModify.TabIndex = 0
        Me.numPriceModify.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDone
        '
        Me.btnDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.Location = New System.Drawing.Point(699, 13)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(193, 132)
        Me.btnDone.TabIndex = 28
        Me.btnDone.Text = "DONE"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'PriceModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 171)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.numPriceModify)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PriceModify"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PriceModify"
        CType(Me.numPriceModify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents numPriceModify As NumericUpDown
    Friend WithEvents btnDone As Button
End Class
