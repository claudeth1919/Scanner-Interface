Imports UtilitiesLibrary.EventLoging
Imports CommunicationsLibrary.STXDataSocketServer.Client.PublicationsConnectionManaging

Public Class DataSocketPublicationsProxyServerService

#Region " < DATA MEMBERS > "

    Private _STXDSSC_PublicationsConnectionsProxyServer As STXDSSC_PublicationsConnectionsProxyServer

#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Try
            Me._STXDSSC_PublicationsConnectionsProxyServer = STXDSSC_PublicationsConnectionsProxyServer.GetInstance
        Catch ex As Exception
            stxEventLog.writeEntry(EventLogEntryType.Error, ex.ToString)
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Try
            Me._STXDSSC_PublicationsConnectionsProxyServer.Dispose()
        Catch ex As Exception
            stxEventLog.writeEntry(EventLogEntryType.Error, ex.ToString)
        End Try

    End Sub

    Protected Overrides Sub OnShutdown()
        Try
            MyBase.OnShutdown()
        Catch ex As Exception
        End Try
        Try
            Me._STXDSSC_PublicationsConnectionsProxyServer.Dispose()
        Catch ex As Exception
            stxEventLog.writeEntry(EventLogEntryType.Error, ex.ToString)
        End Try

    End Sub
End Class
