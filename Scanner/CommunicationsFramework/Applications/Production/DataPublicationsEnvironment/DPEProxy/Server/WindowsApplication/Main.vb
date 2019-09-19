Imports UtilitiesLibrary.EventLoging

Module MainModule


    Public Sub HandleException(ByVal sender As Object, ByVal t As System.Threading.ThreadExceptionEventArgs)
        Try
            Dim MSG As String = "Unhandled exception : " & t.Exception.Message
            stxEventLog.DisplayEvent(EventLogEntryType.Error, MSG)
        Catch ex As Exception
            stxEventLog.DisplayEvent(EventLogEntryType.Error, ex.Message)
        End Try
    End Sub


    Public Sub Main()

        AddHandler Application.ThreadException, New System.Threading.ThreadExceptionEventHandler(AddressOf HandleException)

        Application.Run(New DataSocketPublicationsProxyServerTestForm)

    End Sub

End Module
