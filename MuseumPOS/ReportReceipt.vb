Imports System.Data.SqlClient
Imports IngenicoPOS
Imports Ingenico
Imports System.IO
Imports Microsoft.Reporting
Imports MuseumPOS.My
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing
Imports System.Drawing.Text

Public Class ReportReceipt
    ' run Date Range report
    Private Sub btnRunReport_Click(sender As Object, e As EventArgs) Handles btnRunReport.Click
        RunReport(False) ' false = not summarized
    End Sub

    Private Sub RunReport(ByVal bSummary As Boolean)

        If DateTimePicker_Start.Value.ToShortDateString.Trim = DateTimePicker_End.Value.ToShortDateString.Trim Then
            ReceiptShow("SINGLE", bSummary)
        Else
            ReceiptShow("RANGE", bSummary)
        End If

    End Sub


    Private Sub ReceiptShow(ByVal sReportType As String, ByVal bSummary As Boolean)
        Dim receiptDataSource As New WinForms.ReportDataSource
        Dim dataset As New DataSet("Receipt")
        Dim sReportTitle As String

        GetReceiptDataSet(dataset, sReportType, bSummary)

        receiptDataSource.Name = "Receipt"
        receiptDataSource.Value = dataset.Tables("Receipt")

        ReportViewer1.ProcessingMode = WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(receiptDataSource)
        If Not bSummary Then
            ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\ReportReceipt.rdl"
        Else
            ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\SalesSummary.rdl"
        End If

        Dim rParam As New WinForms.ReportParameter
        rParam.Values.Clear()
        rParam.Name = "ReportTitleText"

        sReportTitle = ""
        If sReportType = "RANGE" Then
            sReportTitle = "From " & DateTimePicker_Start.Value.ToShortDateString.Trim & " To " & DateTimePicker_End.Value.ToShortDateString.Trim
        End If

        If sReportType = "SINGLE" Then
            sReportTitle = DateTimePicker_Start.Value.ToShortDateString.Trim
        End If

        If Not cboDept.Text.Trim = "" Then
            sReportTitle += " Department: " + QTrim(cboDept.Text.Trim)
        End If

        If Not cboVendor.Text.Trim = "" Then
            sReportTitle += " Vendor: " + QTrim(cboVendor.Text.Trim)
        End If

        If Not cboType.Text.Trim = "" Then
            sReportTitle += " Type: " + QTrim(cboType.Text.Trim)
        End If

        rParam.Values.Add(sReportTitle)
        ReportViewer1.LocalReport.SetParameters(rParam)

        ReportViewer1.RefreshReport()

    End Sub

    Private Sub GetReceiptDataSet(ByRef parDataSet As DataSet, ByVal sReportType As String, ByVal bSummary As Boolean)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        If Not bSummary Then
            sSQL = "SELECT a.UPC, a.ReceiptID, a.Description, b.InvName, a.Price, a.Paid, b.InvUPC, a.TaxPaid, a.ReceiptDateTime, a.Quantity, a.TaxRate, a.ReceiptDateTime"
            sSQL += " FROM Receipt AS a INNER JOIN"
            sSQL += " InventoryItems AS b ON a.UPC = b.InvUPC"
        Else
            sSQL = "SELECT a.Description, b.InvName, SUM(a.Paid) AS Paid, b.InvUPC, SUM(a.TaxPaid) AS TaxPaid, SUM(Quantity) AS Quantity"
            sSQL += " FROM Receipt AS a INNER JOIN"
            sSQL += " InventoryItems AS b ON a.UPC = b.InvUPC"
        End If


        If sReportType = "RANGE" Then
            sSQL += " WHERE a.ReceiptDate BETWEEN " + QTrim(Me.DateTimePicker_Start.Value.ToShortDateString) + " AND " + QTrim(Me.DateTimePicker_End.Value.ToShortDateString)
        End If

        If sReportType = "SINGLE" Then
            sSQL += " WHERE a.ReceiptDate = " + QTrim(DateTimePicker_Start.Value.ToShortDateString)
        End If

        If Not cboDept.Text.Trim = "" Then
            sSQL += " AND b.Department = " + QTrim(cboDept.Text.Trim)
        End If

        If Not cboVendor.Text.Trim = "" Then
            sSQL += " AND b.Vendor = " + QTrim(cboVendor.Text.Trim)
        End If

        If Not cboType.Text.Trim = "" Then
            sSQL += " AND b.InvType = " + QTrim(cboType.Text.Trim)
        End If

        If Not bSummary Then
            sSQL += " ORDER BY a.ReceiptDateTime"
        Else
            sSQL += " GROUP BY a.Description, b.InvName, b.InvUPC"
        End If

        Debug.Print(sSQL)

            Using connection As New SqlConnection(sConnectionString)

            Dim command As New SqlCommand(sSQL, connection)

            Dim ReceiptAdapter As New SqlDataAdapter(command)

            ReceiptAdapter.Fill(parDataSet, "Receipt")

        End Using

    End Sub

    Private Sub ReportReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        LoadComboBox("INVTYPE", cboType)
        LoadComboBox("VENDOR", cboVendor)
        LoadComboBox("DEPT", cboDept)

    End Sub

    Private Sub ReportReceipt_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.ReportViewer1.Height = (Me.Height - ReportViewer1.Top) - 40
        Me.ReportViewer1.Width = (Me.Width - ReportViewer1.Left) - 20
    End Sub

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
        RunReport(True) ' false = not summarized

    End Sub
End Class