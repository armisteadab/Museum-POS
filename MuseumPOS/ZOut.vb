Imports System.Data.SqlClient
Imports IngenicoPOS
Imports Ingenico
Imports System.IO
Imports Microsoft.Reporting
Imports MuseumPOS.My
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing

Public Class ZOut

    Private Sub ZOutShow()
        Dim receiptDataSource As New WinForms.ReportDataSource
        Dim dataset As New DataSet("Receipt")
        Dim sReportTitle As String, sSumCash As String, sSumChecks As String, sSumCards As String, sTotalSales As String
        Dim sReportDateString As String

        GetZOutDataSet(dataset)
        receiptDataSource.Name = "Receipt" 'dataset.Tables.Item(0).TableName '
        receiptDataSource.Value = dataset.Tables.Item(0) 'dataset.Tables("Receipt")

        ReportViewer1.ProcessingMode = WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(receiptDataSource)
        ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\ZOut.rdl"

        Dim rParam As New WinForms.ReportParameter
        rParam.Values.Clear()
        rParam.Name = "rDateTime"

        sReportDateString = Date.Today.ToShortDateString

        rParam.Values.Add(sReportDateString)
        ReportViewer1.LocalReport.SetParameters(rParam)

        rParam.Values.Clear()
        rParam.Name = "ReportTitleText"

        sReportTitle = "End of Day: "

        sReportTitle += Date.Today.ToShortDateString.Trim

        rParam.Values.Add(sReportTitle)
        ReportViewer1.LocalReport.SetParameters(rParam)

        ' sum cash
        Dim rParam2 As New WinForms.ReportParameter
        rParam2.Values.Clear()
        rParam2.Name = "SumCash"
        sSumCash = Format(GetSumByDatePayType("CASH", sReportDateString), "####0.00")

        rParam2.Values.Add(sSumCash)
        ReportViewer1.LocalReport.SetParameters(rParam2)

        ' sum credit cards
        Dim rParam3 As New WinForms.ReportParameter
        rParam3.Values.Clear()
        rParam3.Name = "SumCards"

        sSumCards = Format(GetSumByDatePayType("CARD", sReportDateString), "####0.00")

        rParam3.Values.Add(sSumCards)
        ReportViewer1.LocalReport.SetParameters(rParam3)

        ' sum checks
        Dim rParam4 As New WinForms.ReportParameter
        rParam4.Values.Clear()
        rParam4.Name = "SumChecks"

        sSumChecks = Format(GetSumByDatePayType("CHECK", sReportDateString), "####0.00")
        rParam4.Values.Add(sSumChecks)
        ReportViewer1.LocalReport.SetParameters(rParam4)


        ' sum total sales
        Dim rParam5 As New WinForms.ReportParameter
        rParam5.Values.Clear()
        rParam5.Name = "TotalSales"

        sTotalSales = Format(GetSumByDatePayType("", Date.Today.ToShortDateString), "####0.00")

        rParam5.Values.Add(sTotalSales)
        ReportViewer1.LocalReport.SetParameters(rParam5)

        ReportViewer1.RefreshReport()

    End Sub

    Private Sub GetZOutDataSet(ByRef parDataSet As DataSet)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSQL = "SELECT CardType, ABS(SUM(Paid)) as TotalCards FROM Receipt"
        sSQL += " WHERE ReceiptDate = " + QTrim(Date.Today.ToShortDateString)
        sSQL += " AND PayType = 'CARD' GROUP BY CardType"
        Debug.Print(sSQL)

        Using connection As New SqlConnection(sConnectionString)

            Dim command As New SqlCommand(sSQL, connection)

            Dim parameter As New SqlParameter("rDateTime", Date.Today.ToShortDateString)
            command.Parameters.Add(parameter)

            Dim ReceiptAdapter As New SqlDataAdapter(command)

            ReceiptAdapter.Fill(parDataSet, "Receipt")

        End Using

    End Sub

    Private Sub ZOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ZOut_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ReConnectUPCsInReceipts(True)
        ZOutShow()
        lblZDone.Visible = True
        Timer1.Enabled = False
    End Sub
End Class