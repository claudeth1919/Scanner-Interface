Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Namespace Util
    Public Class SQLScript
        Private _scriptList As Collections.Queue

        Public Sub New(ByVal fileName As String)
            Try
                GetFileContents(fileName)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public ReadOnly Property GetFileContent() As Collections.Queue
            Get
                Return _scriptList
            End Get
        End Property

        Private Sub GetFileContents(ByVal fileName As String)
            Try
                _scriptList = New Queue
                Dim fileReader As New StreamReader(fileName)
                Dim currentScript As New StringBuilder
                Dim currentLine As String
                Dim rexLn As New Regex("--", RegexOptions.Singleline)
                Dim rexGo As New Regex("^go$", RegexOptions.IgnoreCase)

                currentLine = fileReader.ReadLine

                While (Not currentLine Is Nothing)
                    If Not rexLn.Match(currentLine).Success Then
                        If rexGo.Match(currentLine).Success Then
                            _scriptList.Enqueue(currentScript.ToString)
                            currentScript = New StringBuilder
                        Else
                            currentScript.Append(currentLine)
                            currentScript.Append(vbCrLf)
                        End If
                    End If
                    currentLine = fileReader.ReadLine
                End While
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace