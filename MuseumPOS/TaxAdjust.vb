Public Class TaxAdjust
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub

    Private Sub numTaxRate_KeyUp(sender As Object, e As KeyEventArgs) Handles numTaxRate.KeyUp
        If (e.KeyValue = Keys.Enter) Then
            Me.Close()
        End If

    End Sub
End Class