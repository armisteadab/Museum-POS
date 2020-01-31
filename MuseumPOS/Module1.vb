Module Module1
    Public Function QTrim(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "'" & sPar.Trim & "'"
    End Function

    Public Function QLike(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "'" & sPar.Trim & "%'"
    End Function

End Module
