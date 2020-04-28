<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportReceipt
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.DateTimePicker_Start = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker_End = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.DisplayName = "ReportReceipt"
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Me.ReportViewer1.LocalReport.ReportPath = "C:\Users\armis\source\repos\MuseumPOS\Museum POS\Report MuseumPOS\ReportReceipt.r" &
    "dl"
        Me.ReportViewer1.Location = New System.Drawing.Point(460, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(687, 517)
        Me.ReportViewer1.TabIndex = 0
        '
        'btnRunReport
        '
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(94, 484)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(238, 45)
        Me.btnRunReport.TabIndex = 1
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'DateTimePicker_Start
        '
        Me.DateTimePicker_Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_Start.Location = New System.Drawing.Point(21, 47)
        Me.DateTimePicker_Start.Name = "DateTimePicker_Start"
        Me.DateTimePicker_Start.Size = New System.Drawing.Size(376, 38)
        Me.DateTimePicker_Start.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Start:"
        '
        'DateTimePicker_End
        '
        Me.DateTimePicker_End.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_End.Location = New System.Drawing.Point(21, 140)
        Me.DateTimePicker_End.Name = "DateTimePicker_End"
        Me.DateTimePicker_End.Size = New System.Drawing.Size(376, 38)
        Me.DateTimePicker_End.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 32)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "End:"
        '
        'ReportReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1159, 541)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker_End)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker_Start)
        Me.Controls.Add(Me.btnRunReport)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReportReceipt"
        Me.Text = "Receipt Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnRunReport As Button
    Friend WithEvents DateTimePicker_Start As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker_End As DateTimePicker
    Friend WithEvents Label2 As Label
End Class
