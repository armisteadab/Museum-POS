Imports System
Imports MuseumPOS.BPVB

Public Class SwipeBluePay
    Private sSaleAmount As String
    Private bSuccess As Boolean
    Private sAuthorizationCode As String
    Private sCardType As String
    Private sLast4 As String
    Private sTransactionID As String
    Private bRefunding As Boolean

    Public Property TransactionID() As String
        Get
            Return sTransactionID
        End Get
        Set(ByVal value As String)
            sTransactionID = value
            Me.Text = "REFUND"
            bRefunding = True
        End Set
    End Property

    Public Property Last4() As String
        Get
            Return sLast4
        End Get
        Set(ByVal value As String)
            sLast4 = value
        End Set
    End Property

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

    Public Property CardType() As String
        Get
            Return sCardType
        End Get
        Set(ByVal value As String)
            sCardType = value
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


        Label1.Text = ""
        Exit Sub

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

        If Not bRefunding Then
            payment.process()
        Else
            payment.refund(sTransactionID)
        End If

        btnRunCard.Enabled = False ' you did it- don't need to do it again
        btnExit.Enabled = False


        'Set cursor to hourglass
        '        Me.Cursor = Cursors.WaitCursor
        Cursor = System.Windows.Forms.Cursors.AppStarting

        If payment.isSuccessfulTransaction() Then
            'Console.Write("Transaction Status: " + payment.getStatus() + Environment.NewLine)
            'Console.Write("Transaction Message: " + payment.getMessage() + Environment.NewLine)
            sTransactionID = payment.getTransID()
            'Console.Write("AVS Result: " + payment.getAVS() + Environment.NewLine)
            'Console.Write("CVV2 Result: " + payment.getCVV2() + Environment.NewLine)
            Debug.Print("Masked Payment Account: " + payment.getMaskedPaymentAccount())

            sCardType = payment.getCardType().Trim
            sLast4 = payment.getMaskedPaymentAccount()
            sLast4 = sLast4.Replace("x", "")
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