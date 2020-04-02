Imports System
Imports MuseumPOS.BPVB

Public Class SwipeBluePay
    Private sSaleAmount As String
    Public Property SaleAmount() As String
        Get
            Return sSaleAmount
        End Get
        Set(ByVal value As String)
            sSaleAmount = value
        End Set
    End Property
    Private Sub SwipeBluePay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ("%B4111111111111111^TEST/BLUEPAY^2511101100001100000000667000000?;4111111111111111=251110110000667?")
        Label1.Text = ""
    End Sub


    Private Sub btnRunCard_Click(sender As Object, e As EventArgs) Handles btnRunCard.Click

        Dim accountID As String = "Merchant's Account ID Here"
        Dim secretKey As String = "Merchant's Secret Key Here"
        Dim mode As String = "TEST"

        Dim payment As BluePay = New BluePay(
            accountID,
            secretKey,
            mode
        )

        payment.setCustomerInformation(
            firstName:="Bob",
    lastName:="Tester",
    address1:="123 Test St.",
    address2:="Apt #500",
    city:="Testville",
    state:="IL",
    zipCode:="54321",
    country:="USA",
    phone:="123-123-12345",
    email:="test@bluepay.com"
        )

        ' Set payment information for a swiped credit card transaction
        ' payment.swipe("%B4111111111111111^TEST/BLUEPAY^2511101100001100000000667000000?;4111111111111111=251110110000667?")
        payment.swipe(TextBox1.Text.Trim)
        payment.sale(amount:=sSaleAmount)

        payment.process()

        If payment.isSuccessfulTransaction() Then
            'Console.Write("Transaction Status: " + payment.getStatus() + Environment.NewLine)
            'Console.Write("Transaction Message: " + payment.getMessage() + Environment.NewLine)
            'Console.Write("Transaction ID: " + payment.getTransID() + Environment.NewLine)
            'Console.Write("AVS Result: " + payment.getAVS() + Environment.NewLine)
            'Console.Write("CVV2 Result: " + payment.getCVV2() + Environment.NewLine)
            'Console.Write("Masked Payment Account: " + payment.getMaskedPaymentAccount() + Environment.NewLine)
            'Console.Write("Card Type: " + payment.getCardType() + Environment.NewLine)
            Label1.Text = ("Authorization Code: " + payment.getAuthCode())
        Else
            Label1.Text = ("Transaction Error: " + payment.getMessage())
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class