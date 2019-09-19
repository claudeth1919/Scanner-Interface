Namespace Util

    Public Class DBUtil

        Public Shared Function CreateConnectionString(ByVal dataSource As String, ByVal user As String, ByVal pwd As String) As String
            Return "Data Source=" & dataSource & ";user=" & user & ";pwd=" & pwd
        End Function

        Public Shared Function CreateConnectionString(ByVal dataSource As String, ByVal user As String, ByVal pwd As String, ByVal initialCatalog As String) As String
            Return "Data Source=" & dataSource & ";user=" & user & ";pwd=" & pwd & ";Initial Catalog=" & initialCatalog
        End Function


    End Class
End Namespace