Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic
Imports System.IO
Imports CommunicationsLibrary.Services.AsyncTCPSocketComms

Public Class frmMainAsyncListenerClientForm

    Private WithEvents _AsynchronousClient As AsynchronousTCPSocketListenerClient
    Private _totalDataSizeSent As Integer
    Private _totalSendTrialsCounter As Integer

#Region " < EVENT HANDLING > "

    Private Sub _AsynchronousClient_ConnectionLost(ByVal ClientID As String) Handles _AsynchronousClient.ConnectionLost
        Try
            Me.tmrAutoSend.Stop()
            Me.btnConnect.Enabled = True
            Me.txtDataToSend.Enabled = False
            Me.btnSendData.Enabled = False
            Me.grpAutoSend.Enabled = False
            Me.txtConnectionStatus.Text = "Not Connected"

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " < UI CALLBACKS  > "

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try

            Dim frm As New frmConnectionData()
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                _AsynchronousClient = New AsynchronousTCPSocketListenerClient(frm.HostName.Text, frm.PortNumber.Text)
                Try
                    _AsynchronousClient.Connect()
                    Me.btnConnect.Enabled = False
                    Me.txtDataToSend.Enabled = True
                    Me.btnSendData.Enabled = True
                    Me.grpAutoSend.Enabled = True
                    Me.txtConnectionStatus.Text = "Connected"
                    Me.Text = "Listener Client_" & _AsynchronousClient.ClientID
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            frm.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSendData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendData.Click
        Try
            If Me.txtDataToSend.Text.Length <= 0 Then
                Throw New Exception("No data to send")
            End If
            Dim data() As Byte = Encoding.ASCII.GetBytes(Me.txtDataToSend.Text)
            Me._AsynchronousClient.SendData(data)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            If Me.txtDataToSend.Text.Length <= 0 Then
                Throw New Exception("No data to send")
            End If
            Me.txtDataToSend.Enabled = False
            Me._totalDataSizeSent = 0
            Me._totalSendTrialsCounter = 0
            Me.tmrAutoSend.Interval = Me.nudTimerIntervall.Value
            Me.tmrAutoSend.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tmrAutoSend_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAutoSend.Tick
        Try
            Dim data() As Byte = Encoding.ASCII.GetBytes(Me.txtDataToSend.Text)
            Me._AsynchronousClient.SendData(data)
            Me._totalSendTrialsCounter += 1
            Me._totalDataSizeSent += data.Length
            Me.txtDataSize.Text = data.Length
            Me.txttotalDataSize.Text = Me._totalDataSizeSent
            Me.txtSendTrials.Text = Me._totalSendTrialsCounter
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.tmrAutoSend.Stop()
        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub frmMainAsyncListenerClientForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
