Imports CommunicationsLibrary.Services.AsyncTCPSocketComms


Public Class frmAsyncTCPSocketListenerTestForm

    Private WithEvents _asyncTCPListener As AsynchronousTCPSocketListener
    Private _dataStats As DataTable

#Region " < UI SAFE ACCESS DELEGATES  > "

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

#Region " <EVENT HANDLING  > "

    Private Sub _asyncTCPListener_ClientConnectionReceived(ByVal clientID As String) Handles _asyncTCPListener.ClientConnectionReceived
        Try
            ListBox_Items_Add(Me.lstPortEvents, "New Client Connection received, client ID : " & clientID)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub _asyncTCPListener_ClientConnectionLost(ByVal clientID As String) Handles _asyncTCPListener.ClientConnectionLost
        Try
            ListBox_Items_Add(Me.lstPortEvents, "Client Connection Lost, Client ID : " & clientID)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub _asyncTCPListener_DataReceived(ByVal clientID As String, ByVal data() As Byte, ByVal dataLenght As Integer) Handles _asyncTCPListener.DataReceived
        Try
            Me.LogStatistics(clientID, dataLenght)
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " < PRIVATE METHODS > "

    Private Sub CreateStatsTable()
        Me._dataStats = New DataTable()
        Me._dataStats.Columns.Add("Client ID", System.Type.GetType("System.String"))
        Me._dataStats.Columns.Add("Data Size", System.Type.GetType("System.Int64"))
        Me._dataStats.Columns.Add("Receive count", System.Type.GetType("System.Int64"))
        Me._dataStats.Columns.Add("Total Data Size", System.Type.GetType("System.Int64"))
        Me.dgrDataStatistics.DataSource = Me._dataStats
    End Sub

    Private Sub LogStatistics(ByVal clientID As String, ByVal dataLength As Integer)
        Try
            SyncLock Me._dataStats
                Dim selectionCriteria As String
                Dim resultRows() As DataRow
                selectionCriteria = "[Client ID] = '" & clientID & "'"
                resultRows = Me._dataStats.Select(selectionCriteria)
                If resultRows.Length <= 0 Then
                    Dim row As DataRow
                    row = Me._dataStats.NewRow
                    row("Client ID") = clientID
                    row("Data Size") = dataLength
                    row("Receive count") = 1
                    row("Total Data Size") = dataLength
                    Me._dataStats.Rows.Add(row)
                Else
                    Dim count As Integer = CType(resultRows(0)("Receive count"), Long)
                    Dim totalSize As Integer = CType(resultRows(0)("Total Data Size"), Long)
                    count += 1
                    totalSize += dataLength
                    resultRows(0)("Receive count") = count
                    resultRows(0)("Total Data Size") = totalSize
                    resultRows(0).AcceptChanges()
                End If
            End SyncLock
           
        Catch ex As Exception
            ListBox_Items_Add(Me.lstErrors, ex.Message)
        End Try
    End Sub

#End Region

#Region " < UI CALLBACKS  > "

    Private Sub frmAsyncTCPSocketListenerTestForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me._asyncTCPListener.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OnePortTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim portStr As String
            Dim portCreated As Boolean = False

            portStr = InputBox("Enter a port number")
            If portStr.Length > 0 Then
                Try
                    Dim portNmr As Integer = CType(portStr, Integer)
                    _asyncTCPListener = New AsynchronousTCPSocketListener(portNmr)
                    portCreated = True
                    Me.Text = "Port : " & portNmr
                    Me.CreateStatsTable()
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.lstPortEvents.Items.Clear()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnClearStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearStats.Click
        Try
            Me._dataStats.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.dgrDataStatistics.DataSource = Me._dataStats
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me._asyncTCPListener.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region




  
  
End Class