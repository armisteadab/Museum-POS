<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SwipeBluePay
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
        Me.btnRunCard = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TextBoxFirstName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxLastName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxAddr1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxAddr2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxCity = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxZIP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboCountry = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxPhone = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.btnManualEntry = New System.Windows.Forms.Button()
        Me.TimerCloseAfterSuccess = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'btnRunCard
        '
        Me.btnRunCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunCard.Location = New System.Drawing.Point(937, 12)
        Me.btnRunCard.Name = "btnRunCard"
        Me.btnRunCard.Size = New System.Drawing.Size(189, 73)
        Me.btnRunCard.TabIndex = 0
        Me.btnRunCard.Text = "Run Card"
        Me.btnRunCard.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(25, 53)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(893, 22)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label1.Location = New System.Drawing.Point(38, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1020, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(987, 442)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(156, 100)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TextBoxFirstName
        '
        Me.TextBoxFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFirstName.Location = New System.Drawing.Point(208, 152)
        Me.TextBoxFirstName.Name = "TextBoxFirstName"
        Me.TextBoxFirstName.Size = New System.Drawing.Size(377, 41)
        Me.TextBoxFirstName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 36)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "First Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 36)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Last Name:"
        '
        'TextBoxLastName
        '
        Me.TextBoxLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLastName.Location = New System.Drawing.Point(208, 199)
        Me.TextBoxLastName.Name = "TextBoxLastName"
        Me.TextBoxLastName.Size = New System.Drawing.Size(377, 41)
        Me.TextBoxLastName.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 36)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Address 1:"
        '
        'TextBoxAddr1
        '
        Me.TextBoxAddr1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAddr1.Location = New System.Drawing.Point(220, 248)
        Me.TextBoxAddr1.Name = "TextBoxAddr1"
        Me.TextBoxAddr1.Size = New System.Drawing.Size(377, 41)
        Me.TextBoxAddr1.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 298)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 36)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Address 2:"
        '
        'TextBoxAddr2
        '
        Me.TextBoxAddr2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAddr2.Location = New System.Drawing.Point(220, 295)
        Me.TextBoxAddr2.Name = "TextBoxAddr2"
        Me.TextBoxAddr2.Size = New System.Drawing.Size(377, 41)
        Me.TextBoxAddr2.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 345)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 36)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "City:"
        '
        'TextBoxCity
        '
        Me.TextBoxCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCity.Location = New System.Drawing.Point(145, 342)
        Me.TextBoxCity.Name = "TextBoxCity"
        Me.TextBoxCity.Size = New System.Drawing.Size(377, 41)
        Me.TextBoxCity.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(538, 340)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 36)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "State:"
        '
        'cboState
        '
        Me.cboState.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(635, 340)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(190, 46)
        Me.cboState.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(25, 393)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 36)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Zip:"
        '
        'TextBoxZIP
        '
        Me.TextBoxZIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxZIP.Location = New System.Drawing.Point(145, 390)
        Me.TextBoxZIP.Name = "TextBoxZIP"
        Me.TextBoxZIP.Size = New System.Drawing.Size(377, 41)
        Me.TextBoxZIP.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(538, 395)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 36)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Country:"
        '
        'cboCountry
        '
        Me.cboCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCountry.FormattingEnabled = True
        Me.cboCountry.Location = New System.Drawing.Point(667, 395)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(121, 44)
        Me.cboCountry.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 445)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 36)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Phone:"
        '
        'TextBoxPhone
        '
        Me.TextBoxPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPhone.Location = New System.Drawing.Point(153, 442)
        Me.TextBoxPhone.Name = "TextBoxPhone"
        Me.TextBoxPhone.Size = New System.Drawing.Size(377, 41)
        Me.TextBoxPhone.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(25, 506)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 36)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Email:"
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxEmail.Location = New System.Drawing.Point(153, 503)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(609, 41)
        Me.TextBoxEmail.TabIndex = 23
        '
        'btnManualEntry
        '
        Me.btnManualEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualEntry.Location = New System.Drawing.Point(957, 180)
        Me.btnManualEntry.Name = "btnManualEntry"
        Me.btnManualEntry.Size = New System.Drawing.Size(169, 109)
        Me.btnManualEntry.TabIndex = 25
        Me.btnManualEntry.Text = "Manual Entry"
        Me.btnManualEntry.UseVisualStyleBackColor = True
        '
        'TimerCloseAfterSuccess
        '
        Me.TimerCloseAfterSuccess.Interval = 1000
        '
        'SwipeBluePay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 554)
        Me.Controls.Add(Me.btnManualEntry)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBoxPhone)
        Me.Controls.Add(Me.cboCountry)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBoxZIP)
        Me.Controls.Add(Me.cboState)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxCity)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxAddr2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxAddr1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxLastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxFirstName)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnRunCard)
        Me.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SwipeBluePay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Swipe Card"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRunCard As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents TextBoxFirstName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxLastName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxAddr1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxAddr2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxCity As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboState As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBoxZIP As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboCountry As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBoxPhone As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents btnManualEntry As Button
    Friend WithEvents TimerCloseAfterSuccess As Timer
End Class
