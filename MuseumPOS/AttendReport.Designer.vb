<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttendReport
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSingleDateRunReport = New System.Windows.Forms.Button()
        Me.DateTimePickerSingle = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.DateTimePicker_End = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker_Start = New System.Windows.Forms.DateTimePicker()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSingleDateRunReport)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerSingle)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 337)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(442, 134)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "One Date"
        '
        'btnSingleDateRunReport
        '
        Me.btnSingleDateRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSingleDateRunReport.Location = New System.Drawing.Point(17, 74)
        Me.btnSingleDateRunReport.Name = "btnSingleDateRunReport"
        Me.btnSingleDateRunReport.Size = New System.Drawing.Size(238, 45)
        Me.btnSingleDateRunReport.TabIndex = 1
        Me.btnSingleDateRunReport.Text = "Run Report"
        Me.btnSingleDateRunReport.UseVisualStyleBackColor = True
        '
        'DateTimePickerSingle
        '
        Me.DateTimePickerSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerSingle.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerSingle.Location = New System.Drawing.Point(17, 30)
        Me.DateTimePickerSingle.Name = "DateTimePickerSingle"
        Me.DateTimePickerSingle.Size = New System.Drawing.Size(376, 38)
        Me.DateTimePickerSingle.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnRunReport)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker_End)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker_Start)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(442, 304)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Range"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Start:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 32)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "End:"
        '
        'btnRunReport
        '
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(17, 211)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(238, 45)
        Me.btnRunReport.TabIndex = 1
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'DateTimePicker_End
        '
        Me.DateTimePicker_End.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_End.Location = New System.Drawing.Point(17, 156)
        Me.DateTimePicker_End.Name = "DateTimePicker_End"
        Me.DateTimePicker_End.Size = New System.Drawing.Size(376, 38)
        Me.DateTimePicker_End.TabIndex = 4
        '
        'DateTimePicker_Start
        '
        Me.DateTimePicker_Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_Start.Location = New System.Drawing.Point(17, 63)
        Me.DateTimePicker_Start.Name = "DateTimePicker_Start"
        Me.DateTimePicker_Start.Size = New System.Drawing.Size(376, 38)
        Me.DateTimePicker_Start.TabIndex = 2
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.DisplayName = "ReportReceipt"
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Me.ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\ReportReceipt.rdl"
        Me.ReportViewer1.Location = New System.Drawing.Point(478, 27)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(687, 517)
        Me.ReportViewer1.TabIndex = 8
        '
        'AttendReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 564)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "AttendReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendance Report"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnSingleDateRunReport As Button
    Friend WithEvents DateTimePickerSingle As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnRunReport As Button
    Friend WithEvents DateTimePicker_End As DateTimePicker
    Friend WithEvents DateTimePicker_Start As DateTimePicker
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
