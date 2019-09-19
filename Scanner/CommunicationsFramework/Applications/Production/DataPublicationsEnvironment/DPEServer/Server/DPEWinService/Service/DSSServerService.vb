Imports UtilitiesLibrary.EventLoging
Imports CommunicationsLibrary.STXDataSocketServer.Server




Public Class DSSServerService

#Region " < DATA MEMBERS > "

    Private _STXDataSocketServer As STXDataSocketServer

#End Region

#Region " < SERVICE PROTECTED METHODS > "

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Try
            Me._STXDataSocketServer = STXDataSocketServer.GetInstance
        Catch ex As Exception
            stxEventLog.writeEntry(EventLogEntryType.Error, ex.ToString)
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Try
            Me._STXDataSocketServer.Dispose()
        Catch ex As Exception
            stxEventLog.writeEntry(EventLogEntryType.Error, ex.ToString)
        End Try
    End Sub

    Protected Overrides Sub OnShutdown()
        Try
            MyBase.OnShutdown()
        Catch ex As Exception
            stxEventLog.writeEntry(EventLogEntryType.Error, ex.ToString)
        End Try
        Try
            Me._STXDataSocketServer.Dispose()
        Catch ex As Exception
            stxEventLog.writeEntry(EventLogEntryType.Error, ex.ToString)
        End Try
    End Sub

#End Region

  

End Class
