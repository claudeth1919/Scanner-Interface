Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Namespace SQLServerScripting

    Public Class SQLScriptRunner

#Region " < DATA MEMBERS > "

        Private _serverName As String     '.. Server where the DB resides
        Private _user As String
        Private _pwd As String
        Private _dataBase As String        '.. database name (catalog is the name used when building the connection string)
        Private _connectionString As String
        Private _fileList As SortedList   '.. scripts will run according to their order in the list
        Private _scriptsToExecute As SortedList

#End Region


#Region " < CONSTRUCTORS > "

        Public Sub New(ByVal ServerName As String, ByVal DataBaseName As String, ByVal user As String, ByVal pwd As String, ByVal fileList As SortedList)
            Me._serverName = ServerName
            Me._user = user
            Me._pwd = pwd
            Me._dataBase = DataBaseName
            Me._connectionString = Me.CreateConnectionString
            Me._fileList = fileList
            Me.GetScriptsFromFileList()

        End Sub

#End Region


#Region " < PUBLIC METHODS > "

        Public Sub Run()
            Try
                For Each item As DictionaryEntry In Me._scriptsToExecute
                    Try
                        Dim currentScript As SQLScript
                        currentScript = CType(item.Value, SQLScript)
                        ExecuteScript(currentScript)
                        'WriteScript(item.Key, currentScript)

                    Catch ex As SqlClient.SqlException
                        ' This line must record the failure for a later notification to user
                        Throw ex
                    End Try
                Next
            Catch ex As Exception
                Throw ex

            End Try
        End Sub

#End Region


#Region " < PRIVATE METHODS > "

        Private Sub GetScriptsFromFileList()
            Try
                If Me._scriptsToExecute Is Nothing Then
                    _scriptsToExecute = New SortedList
                End If
                For Each item As DictionaryEntry In Me._fileList
                    Try
                        Dim currentscript As New SQLScript(item.Value)
                        _scriptsToExecute.Add(currentscript.FileName, currentscript)
                    Catch ex As Exception
                    End Try
                Next
            Catch ex As Exception
            End Try
        End Sub

        Private Function CreateConnectionString() As String
            Return "Data Source=" & Me._serverName & ";user=" & Me._user & ";pwd=" & Me._pwd & ";Initial Catalog=" & Me._dataBase
        End Function

        Private Sub WriteScript(ByVal ScriptName As String, ByVal script As SQLScript)
            Try
                Dim ienum As IEnumerator = script.ScriptBatchContents.GetEnumerator
                Dim strBldr As StringBuilder
                Dim testPath As String = System.AppDomain.CurrentDomain.BaseDirectory & ScriptName & ".txt"

                While ienum.MoveNext
                    strBldr = ienum.Current
                    Dim wr As New StreamWriter(testPath, True)
                    wr.Write(strBldr.ToString)
                    wr.Close()
                End While

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Function ExecuteScript(ByVal script As SQLScript) As Object
            Dim dbConn As New SqlClient.SqlConnection
            Dim dbComm As New SqlClient.SqlCommand
            Dim scriptBatchContentsText As String

            While script.ScriptBatchContents.Count > 0
                scriptBatchContentsText = script.ScriptBatchContents.Dequeue
                Try
                    dbConn.ConnectionString = Me._connectionString

                    dbComm.Connection = dbConn
                    dbComm.CommandType = CommandType.Text
                    dbComm.CommandText = scriptBatchContentsText

                    dbConn.Open()
                    dbComm.ExecuteNonQuery()
                Catch ex As Exception
                    Throw ex
                Finally
                    dbConn.Close()
                End Try
            End While
        End Function

#End Region


    End Class
End Namespace


