Imports CommunicationsLibrary.STXDataSocketServer.Client.PublicationsConnectionManaging
Imports UtilitiesLibrary.EventLoging

Public Class Form1

    Private WithEvents _STXDSSC_PublicationsConnectionsProxyServerClient As STXDSSC_PublicationsConnectionsProxyServerClient
    Private WithEvents _stxEventLog As stxEventLog

#Region " < UI CALLBACKS > "

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me._STXDSSC_PublicationsConnectionsProxyServerClient.Connect()
            MsgBox("Connection Succesful")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region

#Region " < EVENT HANDLING > "

    Private Sub _stxEventLog_LogEntryReceived(ByVal LogEntryInfo As stxEventLogEntry) Handles _stxEventLog.LogEntryReceived
        Try
            MsgBox(LogEntryInfo.toString(stxEventLogEntry.toStringMode.multiLine))
         
        Catch ex As Exception
        End Try
    End Sub

#End Region


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me._STXDSSC_PublicationsConnectionsProxyServerClient = STXDSSC_PublicationsConnectionsProxyServerClient.GetInstance()
        Catch ex As Exception

        End Try
    End Sub
End Class
