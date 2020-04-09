Imports System
Imports MuseumPOS.BPVB

Public Class SwipeBluePay
    Private sSaleAmount As String
    Private bSuccess As Boolean
    Private sAuthorizationCode As String
    Public Property SaleAmount() As String
        Get
            Return sSaleAmount
        End Get
        Set(ByVal value As String)
            sSaleAmount = value
        End Set
    End Property

    Public Property AuthorizationCode() As String
        Get
            Return sAuthorizationCode
        End Get
        Set(ByVal value As String)
            sAuthorizationCode = value
        End Set
    End Property

    Public Property CardWorked() As Boolean
        Get
            Return bSuccess
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Private Sub SwipeBluePay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ("%B4111111111111111^TEST/BLUEPAY^2511101100001100000000667000000?;4111111111111111=251110110000667?")

        'load testing info

        TextBoxFirstName.Text = "Bob"
        TextBoxLastName.Text = "Tester"
        TextBoxAddr1.Text = "123 Test St."
        TextBoxAddr2.Text = "Apt #500"
        TextBoxCity.Text = "Testville"
        cboState.Text = "IL"
        TextBoxZIP.Text = "54321"
        cboCountry.Text = "USA"
        TextBoxPhone.Text = "123-123-12345"
        TextBoxEmail.Text = "test@bluepay.com"


        Label1.Text = ""
    End Sub


    Private Sub btnRunCard_Click(sender As Object, e As EventArgs) Handles btnRunCard.Click

        '        Dim accountID As String = "100868017210"  ' 100868017209
        Dim accountID As String = "100868017209"
        'Dim accountID As String = "DEMO-ROADSANDRAILS"
        Dim secretKey As String = "P7KKNNCTELSV12VWSNQ8OAZAXX/IKI4X"
        'Dim secretKey As String = "100868017210"
        Dim mode As String = "TEST"

        Dim payment As BluePay = New BluePay(
            accountID,
            secretKey,
            mode
        )

        payment.setCustomerInformation(
             TextBoxFirstName.Text.Trim,
     TextBoxLastName.Text.Trim,
     TextBoxAddr1.Text.Trim,
     TextBoxAddr2.Text.Trim,
     TextBoxCity.Text.Trim,
     cboState.Text.Trim,
     TextBoxZIP.Text.Trim,
     cboCountry.Text.Trim,
     TextBoxPhone.Text.Trim,
     TextBoxEmail.Text.Trim
        )

        ' Set payment information for a swiped credit card transaction
        ' payment.swipe("%B4111111111111111^TEST/BLUEPAY^2511101100001100000000667000000?;4111111111111111=251110110000667?")
        payment.swipe(TextBox1.Text)
        '        payment.sale(amount sSaleAmount)
        payment.sale(sSaleAmount)

        payment.process()

        btnRunCard.Enabled = False ' you did it- don't need to do it again
        btnExit.Enabled = False


        'Set cursor to hourglass
        '        Me.Cursor = Cursors.WaitCursor
        Cursor = System.Windows.Forms.Cursors.AppStarting

        If payment.isSuccessfulTransaction() Then
            'Console.Write("Transaction Status: " + payment.getStatus() + Environment.NewLine)
            'Console.Write("Transaction Message: " + payment.getMessage() + Environment.NewLine)
            'Console.Write("Transaction ID: " + payment.getTransID() + Environment.NewLine)
            'Console.Write("AVS Result: " + payment.getAVS() + Environment.NewLine)
            'Console.Write("CVV2 Result: " + payment.getCVV2() + Environment.NewLine)
            'Console.Write("Masked Payment Account: " + payment.getMaskedPaymentAccount() + Environment.NewLine)
            Debug.Print("Card Type: " + payment.getCardType() + Environment.NewLine)
            sAuthorizationCode = payment.getAuthCode().Trim
            Label1.Text = ("Authorization Code: " + sAuthorizationCode)
            bSuccess = True ' tell the main form

        Else
            Label1.Text = ("Transaction Error: " + payment.getMessage())
            btnRunCard.Enabled = True
        End If

        'Set cursor to default
        Cursor = System.Windows.Forms.Cursors.Default
        btnExit.Enabled = True

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class