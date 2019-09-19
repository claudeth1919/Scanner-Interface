Imports System.IO

Namespace Util
    Public Class SQLScriptRunner

#Region " < DATA MEMBERS > "

        Private _dataSource As String     '.. Server where the DB resides
        Private _user As String
        Private _pwd As String
        Private _catalog As String        '.. database name (catalog is the name used when building the connection string)
        Private _fileList As SortedList   '.. scripts will run according to their order in the list

#End Region

#Region " < CONSTRUCTORS > "

        Public Sub New(ByVal dataSource As String, ByVal user As String, ByVal pwd As String, ByVal catalog As String, ByVal fileList As ICollection)
            SetConnectionParameters(dataSource, user, pwd, catalog)
            SetFileList(fileList)
        End Sub

#End Region

#Region " < PRIVATE METHODS > "

        Private Sub SetConnectionParameters(ByVal dataSource As String, ByVal user As String, ByVal pwd As String, ByVal catalog As String)
            Me._dataSource = dataSource
            Me._user = user
            Me._pwd = pwd
            Me._catalog = catalog
        End Sub

        Private Sub SetFileList(ByVal fileList As ICollection)
            Me._fileList = fileList
        End Sub

#End Region


#Region " <  PUBLIC METHODS > "


        Public Sub ExecuteScriptsOnList()
            Try
                For Each item As DictionaryEntry In _fileList
                    Try
                        Dim currentFile As New SQLScript(item.Value)
                        Dim currentScript As Queue = currentFile.GetFileContent
                        Dim totalCount As Integer = currentScript.Count
                        For currentCount As Integer = 1 To totalCount
                            ExecuteScript(currentScript.Dequeue())
                        Next
                    Catch ex As SqlClient.SqlException
                        Throw ex
                    End Try
                Next
            Catch ex As Exception
                Throw ex

            End Try
        End Sub

        Public Sub WriteScript(ByVal script As String)
            Try
                Dim wr As New StreamWriter("c:\temp.txt", True)
                wr.Write(script)
                wr.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function ExecuteScript(ByVal script As String) As Object
            Dim dbConn As New SqlClient.SqlConnection
            Dim dbComm As New SqlClient.SqlCommand

            Try
                dbConn.ConnectionString = Util.DBUtil.CreateConnectionString(_dataSource, _user, _pwd, _catalog)

                dbComm.Connection = dbConn
                dbComm.CommandType = CommandType.Text
                dbComm.CommandText = script

                dbConn.Open()
                dbComm.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                dbConn.Close()
            End Try
        End Function

#End Region
     

   

    End Class
End Namespace