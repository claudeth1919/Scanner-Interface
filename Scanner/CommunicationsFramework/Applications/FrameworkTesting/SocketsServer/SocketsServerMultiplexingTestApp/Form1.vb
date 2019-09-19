Imports CommunicationsLibrary.Services.SocketsServer
Imports CommunicationsLibrary.Services.SocketsServer.Data
Imports CommunicationsLibrary.Services.SocketsServer.ClientConnectionsHandling

Public Class Form1

#Region " < DATA MEMBERS  >  "

    Private WithEvents _serverManager As SocketsServerMultiplexingManager

#End Region

#Region " < DELEGATES > "

    Delegate Sub ListBoxItemsAddCallBack(ByVal ListBoxC As ListBox, ByVal data As Object)
    Public Sub ListBox_Items_Add(ByVal ListBoxCtrl As ListBox, ByVal DataC As Object)
        Try
            If ListBoxCtrl.InvokeRequired Then
                Dim d As New ListBoxItemsAddCallBack(AddressOf ListBox_Items_Add)
                ListBoxCtrl.Invoke(d, New Object() {ListBoxCtrl, DataC})
            Else
                ListBoxCtrl.Items.Add(CStr(DataC))
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub EventHandling_serverManager_DataReceivedFromClient(ByVal server As SocketsServer, ByVal ClientHandler As SocketsServerClientConnectionHandler, ByVal data As SocketData) Handles _serverManager.DataReceivedFromClient
        Try
            Me.ListBox_Items_Add(Me.lstDataReception, data.Value)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim flag As Boolean = False

            Dim numberOfClientsPerServer As Integer = 0
            Dim numberOfClientsPerServerAsStrig As String = ""

            While Not flag
                numberOfClientsPerServerAsStrig = InputBox("Enter the max number of clients per server")
                If Not numberOfClientsPerServerAsStrig Is Nothing Then
                    Try
                        numberOfClientsPerServer = CType(numberOfClientsPerServerAsStrig, Integer)
                        flag = True
                    Catch ex1 As ArgumentException
                        MsgBox("Can not convert to a integer number")
                    Catch ex As Exception
                    End Try
                End If

            End While
            _serverManager = New SocketsServerMultiplexingManager(4000, 5000, numberOfClientsPerServer, True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim server As SocketsServer = Me._serverManager.GetCurrentAvailableServer
            Dim client As New SocketsServerClient(server.HostName, server.ListeningPort)
            client.Connect()
            Me.lstclients.Items.Add(client)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim server As SocketsServer = Me._serverManager.GetCurrentAvailableServer
            Dim msg As String = "Current Server ID = " & server.ServerID & vbNewLine & "Client Connections : " & server.ClientConnectionsCount
            MsgBox(msg)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim msg As String = "Total Servers : " & Me._serverManager.ServersCount & vbNewLine & "Total Client Connections : " & Me._serverManager.ClientsConnectionsCount & vbNewLine & "Connections per server : " & Me._serverManager.ConnectionsPerServer
            MsgBox(msg)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If Me.lstclients.SelectedIndex < 0 Then
                Throw New Exception("No client selected")
            End If
            If Me.txtData.Text.Length <= 0 Then
                Throw New Exception("No data to send ")
            End If

            Dim client As SocketsServerClient = Me.lstclients.SelectedItem

            Dim data As New SocketData("TEST", Me.txtData.Text)
            client.SendDataToServer(data)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Me.lstDataReception.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If Me.lstclients.SelectedIndex < 0 Then
                Throw New Exception("No client selected")
            End If
          
            Dim client As SocketsServerClient = Me.lstclients.SelectedItem

            client.DisconnectFromServer()
            client.Dispose()

            Me.lstclients.Items.Remove(client)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Me.lstServers.Items.Clear()
            Dim enumm As IEnumerator = Me._serverManager.ServersList.GetEnumerator
            Dim server As SocketsServer

            While enumm.MoveNext
                server = enumm.Current
                Me.lstServers.Items.Add(server)
            End While

        Catch ex As Exception

        End Try
    End Sub
End Class
