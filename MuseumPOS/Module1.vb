Module Module1
    Public Function QTrim(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "'" & sPar.Trim & "'"
    End Function

    Public Function QLike(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "'%" & sPar.Trim & "%'"
    End Function

    Public Sub BigMsgBox(ByVal sMessage As String)
        Dim fMessage As New Dialog1

        fMessage.TextBox1.Text = "" & sMessage
        fMessage.ShowDialog()
        fMessage = Nothing

    End Sub

End Module
