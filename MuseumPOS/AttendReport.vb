Imports System.Data.SqlClient
Imports IngenicoPOS
Imports Ingenico
Imports System.IO
Imports Microsoft.Reporting
Imports MuseumPOS.My
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing

Public Class AttendReport
    ' run Date Range report
    Private Sub btnRunReport_Click(sender As Object, e As EventArgs) Handles btnRunReport.Click
        AttendShow("RANGE")
    End Sub


    Private Sub AttendShow(ByVal sReportType As String)
        Dim AttendDataSource As New WinForms.ReportDataSource
        Dim dataset As New DataSet("Attendance")
        Dim sReportTitle As String

        GetAttendDataSet(dataset, sReportType)

        AttendDataSource.Name = "Attendance"
        AttendDataSource.Value = dataset.Tables("Attendance")

        ReportViewer1.ProcessingMode = WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(AttendDataSource)
        ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\Attendance.rdl"

        Dim rParam As New WinForms.ReportParameter
        rParam.Values.Clear()
        rParam.Name = "ReportTitleText"

        sReportTitle = ""
        If sReportType = "RANGE" Then
            sReportTitle = "From " & DateTimePicker_Start.Value.ToShortDateString.Trim & " To " & DateTimePicker_End.Value.ToShortDateString.Trim
        End If

        If sReportType = "SINGLE" Then
            sReportTitle = DateTimePickerSingle.Value.ToShortDateString.Trim
        End If

        rParam.Values.Add(sReportTitle)
        ReportViewer1.LocalReport.SetParameters(rParam)

        ReportViewer1.RefreshReport()

    End Sub

    Private Sub GetAttendDataSet(ByRef parDataSet As DataSet, ByVal sReportType As String)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSQL = "SELECT Worker, TimeIN, TimeOUt FROM Attendance"

        If sReportType = "RANGE" Then
            sSQL += " WHERE TimeIN BETWEEN " + QTrim(Me.DateTimePicker_Start.Value.ToShortDateString + " 12:00AM") + " AND " + QTrim(Me.DateTimePicker_End.Value.ToShortDateString + " 12:00PM")
        End If

        If sReportType = "SINGLE" Then
            sSQL += " WHERE TimeIN BETWEEN " + QTrim(Me.DateTimePickerSingle.Value.ToShortDateString + " 12:00AM") + " AND " + QTrim(Me.DateTimePickerSingle.Value.ToShortDateString + " 12:00PM")
        End If
        '        sSQL += " AND "

        sSQL += " ORDER BY TimeIN"
        Debug.Print(sSQL)

        Using connection As New SqlConnection(sConnectionString)

            Dim command As New SqlCommand(sSQL, connection)

            Dim AttendAdapter As New SqlDataAdapter(command)

            AttendAdapter.Fill(parDataSet, "Attendance")

        End Using

    End Sub

    Private Sub ReportAttend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ReportAttend_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.ReportViewer1.Height = (Me.Height - ReportViewer1.Top) - 40
        Me.ReportViewer1.Width = (Me.Width - ReportViewer1.Left) - 20
    End Sub

    Private Sub btnSingleDateRunReport_Click(sender As Object, e As EventArgs) Handles btnSingleDateRunReport.Click
        AttendShow("SINGLE")

    End Sub
End Class