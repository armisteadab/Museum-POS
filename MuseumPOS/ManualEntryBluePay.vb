Imports System.Windows.Forms
Imports System
Imports MuseumPOS.BPVB

Public Class ManualEntryBluePay
    Private sManualCC As String
    Private sManualCVV2 As String
    Private sManualCExp As String
    Public Property ManualCExp() As String
        Get
            Return sManualCExp
        End Get
        Set(ByVal value As String)
            sManualCExp = value
        End Set
    End Property

    Public Property ManualCVV2() As String
        Get
            Return sManualCVV2
        End Get
        Set(ByVal value As String)
            sManualCVV2 = value
        End Set
    End Property



    Public Property ManualCC() As String
        Get
            Return sManualCC
        End Get
        Set(ByVal value As String)
            sManualCC = value
        End Set
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click


        Me.ManualCC = txtCC.Text.Trim
        Me.ManualCExp = txtExpDate.Text.Trim
        Me.ManualCVV2 = txtCVV2.Text.Trim

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
