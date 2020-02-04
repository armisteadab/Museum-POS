Public Class Quantity
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub

    Private Sub numQuantityAdjust_KeyUp(sender As Object, e As KeyEventArgs) Handles numQuantityAdjust.KeyUp
        If (e.KeyValue = Keys.Enter) Then
            Me.Close()
        End If
    End Sub

    Private Sub numQuantityAdjust_ValueChanged(sender As Object, e As EventArgs) Handles numQuantityAdjust.ValueChanged

    End Sub
End Class