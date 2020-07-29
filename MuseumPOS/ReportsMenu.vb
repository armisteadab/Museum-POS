Imports System.Windows.Forms

Public Class ReportsMenu

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnTodayReceipts_Click(sender As Object, e As EventArgs) Handles btnTodayReceipts.Click
        Dim fReport As New ReportReceipt
        fReport.ShowDialog()
        fReport = Nothing
    End Sub

    Private Sub btnZOut_Click(sender As Object, e As EventArgs) Handles btnZOut.Click

        Dim fZout As New ZOut
        fZout.ShowDialog()
        fZout = Nothing

    End Sub

    Private Sub btnAttendReport_Click(sender As Object, e As EventArgs) Handles btnAttendReport.Click
        Dim fAttend As New AttendReport
        fAttend.ShowDialog()
        fAttend = Nothing

    End Sub
End Class
