Public Class PriceModify
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
End Class