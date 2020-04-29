Imports System.Data.SqlClient
Imports IngenicoPOS
Imports Ingenico
Imports System.IO
Imports Microsoft.Reporting
Imports MuseumPOS.My
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing

Public Class ReportReceipt
    ' run Date Range report
    Private Sub btnRunReport_Click(sender As Object, e As EventArgs) Handles btnRunReport.Click
        ReceiptShow("RANGE")
    End Sub


    Private Sub ReceiptShow(ByVal sReportType As String)
        Dim receiptDataSource As New WinForms.ReportDataSource
        Dim dataset As New DataSet("Receipt")
        Dim sReportTitle As String

        GetReceiptDataSet(dataset, sReportType)

        receiptDataSource.Name = "Receipt"
        receiptDataSource.Value = dataset.Tables("Receipt")

        ReportViewer1.ProcessingMode = WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(receiptDataSource)
        ReportViewer1.LocalReport.ReportPath = "C:\Users\armis\source\repos\MuseumPOS\Museum POS\Report MuseumPOS\ReportReceipt.rdl"

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

    Private Sub GetReceiptDataSet(ByRef parDataSet As DataSet, ByVal sReportType As String)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSQL = "SELECT a.UPC, a.ReceiptID, a.Description, b.InvName, a.Price, a.Paid, b.InvUPC, a.TaxPaid, a.Quantity, a.TaxRate, a.ReceiptDateTime"
        sSQL += " FROM Receipt AS a INNER JOIN"
        sSQL += " InventoryItems AS b ON a.UPC = b.InvUPC"

        If sReportType = "RANGE" Then
            sSQL += " WHERE a.ReceiptDate BETWEEN " + QTrim(Me.DateTimePicker_Start.Value.ToShortDateString) + " AND " + QTrim(Me.DateTimePicker_End.Value.ToShortDateString)
        End If

        If sReportType = "SINGLE" Then
            sSQL += " WHERE a.ReceiptDate = " + QTrim(DateTimePickerSingle.Value.ToShortDateString)
        End If
        '        sSQL += " AND "

        sSQL += " ORDER BY a.ReceiptDateTime"
        Debug.Print(sSQL)

        Using connection As New SqlConnection(sConnectionString)

            Dim command As New SqlCommand(sSQL, connection)

            '            Dim parameter As New SqlParameter("rDateTime",
            '            Me.DateTimePicker_Start.Value.ToShortDateString)
            '            command.Parameters.Add(parameter)

            Dim ReceiptAdapter As New SqlDataAdapter(command)

            ReceiptAdapter.Fill(parDataSet, "Receipt")

        End Using

    End Sub

    Private Sub ReportReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ReportReceipt_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.ReportViewer1.Height = (Me.Height - ReportViewer1.Top) - 40
        Me.ReportViewer1.Width = (Me.Width - ReportViewer1.Left) - 20
    End Sub

    Private Sub btnSingleDateRunReport_Click(sender As Object, e As EventArgs) Handles btnSingleDateRunReport.Click
        ReceiptShow("SINGLE")

    End Sub
End Class