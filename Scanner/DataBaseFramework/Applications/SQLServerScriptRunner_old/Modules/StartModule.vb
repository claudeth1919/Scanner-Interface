Imports UtilitiesLibrary.Configuration
Imports UtilitiesLibrary.Configuration.Data

Module StartModule

    Private _userName As String
    Private _password As String
    Private _SQLServeName As String
    Private _DBname As String
    Private _scriptsFilePath As String
    Private _scriptsFilePathList As SortedList

    Private _SQLServerScriptsRunner As SQLServerScripting.SQLScriptRunner

    Sub Main(ByVal args() As String)
        Try
            If args.Length <= 0 Then
                Console.WriteLine("No parameters specified!")
                showParametersUsageHelp()
                Exit Sub
            End If
            'PARAMETERS FORMAT 
            If args.Length < 2 Or args.Length > 5 Then
                Console.WriteLine("Wrong number of Parameters")
                showParametersUsageHelp()
                Exit Sub
            End If
            Select Case args.Length
                Case 5 '_SQLServeName
                    'load the scripts from the location specified in _scriptsFilePath
                    _SQLServeName = args(0)
                    _DBname = args(1)
                    _userName = args(2)
                    _password = args(3)
                    _scriptsFilePath = args(4)
                    _scriptsFilePathList = GetScriptFiles(_scriptsFilePath)
                Case 4
                    'load the scripts from the current location 
                    _SQLServeName = args(0)
                    _DBname = args(1)
                    _userName = args(2)
                    _password = args(3)
                    _scriptsFilePathList = GetScriptFiles()
                Case 3
                    'load the scripts from the location specified in _scriptsFilePath
                    'and looks for user ans passworf from a configuration file 
                    _SQLServeName = args(0)
                    _DBname = args(1)
                    _scriptsFilePath = args(4)
                    GetUserNameAndPasswordFromConfigurationFile()
                    _scriptsFilePathList = GetScriptFiles(_scriptsFilePath)
                Case 2
                    'load the scripts from the current location 
                    'and looks for user and password in a configuratio file 
                    _SQLServeName = args(0)
                    _DBname = args(1)
                    GetUserNameAndPasswordFromConfigurationFile()
                    _scriptsFilePathList = GetScriptFiles()
            End Select
            _SQLServerScriptsRunner = New SQLServerScripting.SQLScriptRunner(_SQLServeName, _DBname, _userName, _password, _scriptsFilePathList)
            Console.WriteLine("Running Scripts, please wait . . . ")
            _SQLServerScriptsRunner.Run()
            Console.WriteLine("Running Scripts finish!")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
       
    End Sub

    Private Sub showParametersUsageHelp()
        Console.WriteLine()
        Console.WriteLine("___________________________________________________")
        Console.WriteLine("USAGE Parameter list reference")
        Console.WriteLine("usage mode 1")
        Console.WriteLine("     1. SQLServer Name")
        Console.WriteLine("     2. DataBase Name")
        Console.WriteLine("     3. User")
        Console.WriteLine("     4. Password")
        Console.WriteLine("     5. SQL Scripts file path")
        Console.WriteLine()
        Console.WriteLine("usage mode 2")
        Console.WriteLine("     1. SQLServer Name")
        Console.WriteLine("     2. DataBase Name")
        Console.WriteLine("     3. User")
        Console.WriteLine("     4. Password")
        Console.WriteLine()
        Console.WriteLine("usage mode 3")
        Console.WriteLine("     1. SQLServer Name")
        Console.WriteLine("     2. DataBase Name")
        Console.WriteLine("     5. SQL Scripts file path")
        Console.WriteLine()
        Console.WriteLine("usage mode 4")
        Console.WriteLine("     1. SQLServer Name")
        Console.WriteLine("     2. DataBase Name")
    End Sub

    Private Sub GetUserNameAndPasswordFromConfigurationFile()
        Dim configfileHndlr As ConfigurationFileHandler
        configfileHndlr = ConfigurationFileHandlerProxyServer.GetInstance.GetFileHandler
        Dim key As KeyValue
        key = CType(configfileHndlr.GetValue("UTILITIES_FRAMEWORK/SQLSERVER_SCRIPT_RUNNER/USER"), KeyValue)
        If Not key Is Nothing Then
            _userName = key.Value
        Else
            Throw New Exception("No configuration found on UTILITIES_FRAMEWORK/SQLSERVER_SCRIPT_RUNNER/USER")
        End If

        key = CType(configfileHndlr.GetValue("UTILITIES_FRAMEWORK/SQLSERVER_SCRIPT_RUNNER/PASSWORD"), KeyValue)
        If Not key Is Nothing Then
            _password = key.Value
        Else
            Throw New Exception("No configuration found on UTILITIES_FRAMEWORK/SQLSERVER_SCRIPT_RUNNER/PASSWORD")
        End If
    End Sub

    Private Function GetScriptFiles() As SortedList
        Dim currentPath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Return GetScriptFiles(currentPath)
    End Function

    Private Function GetScriptFiles(ByVal PathName As String) As SortedList
        Try

            Dim dir As System.IO.DirectoryInfo

            If Not System.IO.Directory.Exists(PathName) Then
                Throw New Exception("The directory don't exists : " & PathName)
            Else
                dir = New System.IO.DirectoryInfo(PathName)

                Dim _fileList As New SortedList

                For Each fInfo As System.IO.FileInfo In dir.GetFiles("*.sql")
                    _fileList.Add(fInfo.Name, fInfo.FullName)
                Next

                Return _fileList
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Module
