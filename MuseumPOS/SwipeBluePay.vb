Imports System
Imports MuseumPOS.BPVB

Public Class SwipeBluePay
    Private sSaleAmount As String, nSaleAmount As Double
    Private bSuccess As Boolean
    Private sAuthorizationCode As String
    Private sCardType As String
    Private sLast4 As String
    Private sTransactionID As String
    Private bRefunding As Boolean
    Private sManualCC As String
    Private sManualCCExp As String
    Private sManualCVV2 As String
    Dim accountID As String = BluePay_AccountID
    Dim secretKey As String = BluePay_SecretKey
    Dim mode As String = BluePay_Mode '"TEST"

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
            nSaleAmount = CDbl(sSaleAmount)

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

        If mode = "TEST" Then
            TextBox1.Text = ("%B4111111111111111^TEST/BLUEPAY^2511101100001100000000667000000?;4111111111111111=251110110000667?")
        End If

        'load testing info


        Label1.Text = ""

    End Sub


    Private Sub btnRunCard_Click(sender As Object, e As EventArgs) Handles btnRunCard.Click

        Dim sRefundAmount As String

        Dim payment As BluePay = New BluePay(
            accountID,
            secretKey,
            mode
        )


        If Not TextBox1.Text.Trim = "" Then

            ' Set payment information for a swiped credit card transaction
            payment.swipe(TextBox1.Text)
            '        payment.sale(amount sSaleAmount)
        Else
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
            payment.setCCInformation(sManualCC, sManualCCExp, sManualCVV2)
        End If

        payment.sale(sSaleAmount)

        If Not bRefunding Then
            payment.process()
        Else
            nSaleAmount = nSaleAmount * -1
            sRefundAmount = nSaleAmount.ToString
            payment.refund(sTransactionID, sRefundAmount)
            payment.process()
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
            SaveCCAuthInfo(sAuthorizationCode, sTransactionID)
            TimerCloseAfterSuccess.Enabled = True ' enable close timer
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

    Private Sub btnManualEntry_Click(sender As Object, e As EventArgs) Handles btnManualEntry.Click

        Dim fManualEntry As New ManualEntryBluePay
        fManualEntry.ShowDialog()

        With fManualEntry
            sManualCC = .ManualCC
            sManualCCExp = .ManualCExp
            sManualCVV2 = .ManualCVV2
        End With

        fManualEntry = Nothing
    End Sub

    Private Sub TimerCloseAfterSuccess_Tick(sender As Object, e As EventArgs) Handles TimerCloseAfterSuccess.Tick
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub


End Class