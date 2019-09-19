Namespace Util
    Public Class File

        Public Shared Function getShortFileName(ByVal fileNameWithPath As String) As String
            Dim SlashIndex As Integer = fileNameWithPath.LastIndexOf("\")
            Dim DotIndex As Integer = fileNameWithPath.LastIndexOf(".")
            Dim shortName As String

            If SlashIndex > -1 Then
                If DotIndex > SlashIndex Then
                    shortName = fileNameWithPath.Substring(SlashIndex + 1, DotIndex - SlashIndex - 1)
                Else
                    shortName = fileNameWithPath.Substring(SlashIndex + 1, fileNameWithPath.Length - SlashIndex - 1)
                End If
            End If

            Return shortName
        End Function

    End Class
End Namespace