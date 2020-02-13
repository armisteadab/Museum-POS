Public Class CashPay
    Private nCashAmount As Double
    Private Sub CashPay_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Property CashAmount() As Double
        Get
            Return nCashAmount
        End Get
        Set(ByVal value As Double)
            nCashAmount = value
            NumericUpDown1.Value = (nCashAmount)
        End Set
    End Property

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.CashAmount = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.CashAmount = 0
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.CashAmount += 10
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Me.CashAmount += 20
    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        Me.CashAmount += 50
    End Sub

    Private Sub Button100_Click(sender As Object, e As EventArgs) Handles Button100.Click
        Me.CashAmount += 100
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.CashAmount = Me.NumericUpDown1.Value
        Me.Close()
    End Sub

    Private Sub NumericUpDown1_KeyUp(sender As Object, e As KeyEventArgs) Handles NumericUpDown1.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.CashAmount = Me.NumericUpDown1.Value
            Me.Close()
        End If
    End Sub
End Class