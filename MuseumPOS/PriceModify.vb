Imports Ingenico.Connect.Sdk.Domain.Payment.Definitions

Public Class PriceModify
    Dim nOriginalPrice As Double
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub

    Private Sub numPriceModify_ValueChanged(sender As Object, e As EventArgs) Handles numPriceModify.ValueChanged

    End Sub

    Private Sub numPriceModify_KeyUp(sender As Object, e As KeyEventArgs) Handles numPriceModify.KeyUp
        If (e.KeyValue = Keys.Enter) Then
            Me.Close()
        End If
    End Sub

    Private Sub PriceModify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        numPriceModify.Select(0, numPriceModify.Text.Length)
    End Sub

    Private Sub nPercentDiscount_ValueChanged(sender As Object, e As EventArgs) Handles nPercentDiscount.ValueChanged
        Dim nDiscountValue As Double, nFinalDiscountedPrice As Double
        nDiscountValue = (nOriginalPrice)
        nDiscountValue = ((nDiscountValue / 100) * (Me.nPercentDiscount.Value))

        nFinalDiscountedPrice = (nOriginalPrice - nDiscountValue)
        Me.lblPriceModified.Text = nDiscountValue
        numPriceModify.Value = nFinalDiscountedPrice

    End Sub

    Public Property OriginalPrice() As Double
        Get
            Return nOriginalPrice
        End Get
        Set(ByVal value As Double)
            nOriginalPrice = Math.Abs(value)
            numPriceModify.Value = nOriginalPrice
        End Set
    End Property
End Class