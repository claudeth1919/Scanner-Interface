Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Namespace SQLServerScripting

    Public Class SQLScript
        Private _scriptBatchContents As Collections.Queue
        Private _filename As String
        Private _filePathName As String

        Public Sub New(ByVal fileName As String)
            Try
                'gets the filename
                Dim file As New FileInfo(fileName)
                Me._filename = file.Name
                Me._filePathName = file.FullName
                GetFileContents(Me._filePathName)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public ReadOnly Property ScriptBatchContents() As Queue
            Get
                Return Me._scriptBatchContents
            End Get
        End Property

        Public ReadOnly Property FileName() As String
            Get
                Return Me._filename
            End Get
        End Property

        Private Sub GetFileContents(ByVal fileName As String)
            Try
                If Me._scriptBatchContents Is Nothing Then
                    Me._scriptBatchContents = New Collections.Queue
                End If

                Dim fileReader As New StreamReader(fileName)
                Dim currentScript As New StringBuilder
                Dim currentLine As String
                Dim rexLn As New Regex("--", RegexOptions.Singleline)
                Dim rexGo As New Regex("^go$", RegexOptions.IgnoreCase)
                Dim insertionFlag As Boolean = False

                currentLine = fileReader.ReadLine

                While (Not currentLine Is Nothing)
                    If Not rexLn.Match(currentLine).Success Then
                        If rexGo.Match(currentLine).Success Then
                            _scriptBatchContents.Enqueue(currentScript.ToString)
                            insertionFlag = True
                            currentScript = New StringBuilder
                        Else
                            currentScript.Append(currentLine)
                            currentScript.Append(vbCrLf)
                        End If
                    End If
                    currentLine = fileReader.ReadLine
                End While

                If Not insertionFlag Then
                    _scriptBatchContents.Enqueue(currentScript.ToString)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class
End Namespace