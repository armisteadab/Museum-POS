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
        Me.nPercentDiscount = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPriceModified = New System.Windows.Forms.Label()
        CType(Me.numPriceModify, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nPercentDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'nPercentDiscount
        '
        Me.nPercentDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nPercentDiscount.Location = New System.Drawing.Point(395, 167)
        Me.nPercentDiscount.Name = "nPercentDiscount"
        Me.nPercentDiscount.Size = New System.Drawing.Size(120, 61)
        Me.nPercentDiscount.TabIndex = 29
        Me.nPercentDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(109, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 55)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Discount %:"
        '
        'lblPriceModified
        '
        Me.lblPriceModified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPriceModified.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPriceModified.Location = New System.Drawing.Point(534, 167)
        Me.lblPriceModified.Name = "lblPriceModified"
        Me.lblPriceModified.Size = New System.Drawing.Size(212, 61)
        Me.lblPriceModified.TabIndex = 31
        Me.lblPriceModified.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PriceModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 256)
        Me.Controls.Add(Me.lblPriceModified)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nPercentDiscount)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.numPriceModify)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PriceModify"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PriceModify"
        CType(Me.numPriceModify, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nPercentDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents numPriceModify As NumericUpDown
    Friend WithEvents btnDone As Button
    Friend WithEvents nPercentDiscount As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPriceModified As Label
End Class
