Imports System.Drawing.Text
Imports NetBarcode
Imports System.Data.SqlClient
Imports IngenicoPOS
Imports Ingenico
Imports System.IO
Imports Microsoft.Reporting
Imports MuseumPOS.My
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing
Imports System.Xml
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Threading
Imports Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel

Public Class InventoryLabelPrint
    Public sUPC As String, nTypeOfLabel As Integer
    Private Sub InventoryLabelPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub CreateBarcode()

        Dim sBC_Formatted$

        sBC_Formatted = "000000000000" + sUPC.Trim
        sBC_Formatted = Strings.Right(sBC_Formatted, 12)

        Dim x As New Barcode(sBC_Formatted, True)

        x.SaveImageFile("c:\release\barcode1.jpeg")

        ReportViewer1.Clear()
        ReportViewer1.ResetPageSettings()
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()

        PriceTagShow()

    End Sub

    Public Property UPC() As String
        Get
            Return sUPC
        End Get
        Set(ByVal value As String)
            sUPC = value
            CreateBarcode()
        End Set
    End Property


    Private Sub PriceTagShow()
        Dim PriceTagDataSource As New WinForms.ReportDataSource
        Dim dataset As New DataSet("ItemLabel")

        GetPriceTagDataSet(dataset)

        PriceTagDataSource.Name = "ItemLabel"
        PriceTagDataSource.Value = dataset.Tables("ItemLabel")

        ReportViewer1.ProcessingMode = WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(PriceTagDataSource)
        Select Case nTypeOfLabel
            Case 2
                ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\NoBarcodeLabel.rdl"
            Case 3
                ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\BigLabel.rdl"
            Case Else
                ReportViewer1.LocalReport.ReportPath = "c:\release\Report MuseumPOS\ItemLabel.rdl"
        End Select
        ReportViewer1.LocalReport.EnableExternalImages = True
        Dim rParam As New WinForms.ReportParameter
        rParam.Values.Clear()
        rParam.Name = "BarCodeImage"
        rParam.Values.Add("c:\release\barcode1.jpeg")
        ReportViewer1.LocalReport.SetParameters(rParam)

        If nTypeOfLabel = 3 Then
            ReportViewer1.PrinterSettings.PrinterName = "HP7D48B1 (HP Office Jet Pro 8720)"
        Else
            ReportViewer1.PrinterSettings.PrinterName = "ZDesigner LP 2824 Plus (ZPL)"
        end if

        ReportViewer1.RefreshReport()

    End Sub

    Private Sub GetPriceTagDataSet(ByRef parDataSet As DataSet)

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Release\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        sSQL = "SELECT InvUPC, InvPrice, InvName FROM InventoryItems WHERE InvUPC = " + QTrim(sUPC)

        Using connection As New SqlConnection(sConnectionString)

            Dim command As New SqlCommand(sSQL, connection)

            Dim PriceTagAdapter As New SqlDataAdapter(command)

            PriceTagAdapter.Fill(parDataSet, "ItemLabel")

        End Using

    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ChangeTypeOfLabel()
    End Sub

    Private Sub ChangeTypeOfLabel()
        nTypeOfLabel = 1 ' default
        If RadioButton1.Checked = True Then
            nTypeOfLabel = 1
        End If
        If RadioButton2.Checked = True Then
            nTypeOfLabel = 2
        End If
        If RadioButton3.Checked = True Then
            nTypeOfLabel = 3
        End If
        PriceTagShow()
    End Sub

    Private Sub btnTagInfo2Clipboard_Click(sender As Object, e As EventArgs) Handles btnTagInfo2Clipboard.Click
        Clipboard.SetText("" + GetItemPriceNameByUPC(sUPC))
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ChangeTypeOfLabel()
    End Sub
End Class
