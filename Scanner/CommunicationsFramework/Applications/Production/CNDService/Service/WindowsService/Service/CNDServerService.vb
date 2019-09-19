Imports CommunicationsLibrary.CNDCommunicationsEnvironment.ComponentNetworkDirectoryService
Imports UtilitiesLibrary.EventLoging

Public Class CNDServerService


#Region " < DATA MEMBERS > "

    Private _CNDService As CNDService

#End Region


    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Try
            Me._CNDService = CNDService.GetInstance
        Catch ex As Exception
            CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString)
        End Try

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Try
            Me._CNDService.Dispose()
        Catch ex As Exception
            CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString)
        End Try
    End Sub

    Protected Overrides Sub OnShutdown()
        Try
            MyBase.OnShutdown()
        Catch ex As Exception
            CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString)
        End Try
        Try
            Me._CNDService.Dispose()
        Catch ex As Exception
            CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString)
        End Try
    End Sub

End Class
