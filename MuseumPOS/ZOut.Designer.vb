<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZOut
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblZDone = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.DisplayName = "ReportReceipt"
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Me.ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\ReportReceipt.rdl"
        Me.ReportViewer1.Location = New System.Drawing.Point(460, 22)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(687, 517)
        Me.ReportViewer1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(408, 46)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "End of Day Process..."
        '
        'lblZDone
        '
        Me.lblZDone.AutoSize = True
        Me.lblZDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZDone.ForeColor = System.Drawing.Color.Red
        Me.lblZDone.Location = New System.Drawing.Point(88, 95)
        Me.lblZDone.Name = "lblZDone"
        Me.lblZDone.Size = New System.Drawing.Size(270, 91)
        Me.lblZDone.TabIndex = 10
        Me.lblZDone.Text = "DONE"
        Me.lblZDone.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'ZOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 560)
        Me.Controls.Add(Me.lblZDone)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ZOut"
        Me.Text = "ZOut"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label1 As Label
    Friend WithEvents lblZDone As Label
    Friend WithEvents Timer1 As Timer
End Class
