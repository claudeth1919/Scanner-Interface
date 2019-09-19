Imports UtilitiesLibrary.EventLoging
Imports UtilitiesLibrary.Services
Imports CommunicationsLibrary.STXDataSocketServer.Client.PublicationsConnectionManaging

Public Class DataSocketPublicationsProxyServerTestForm


#Region " < DATA MEMBERS > "

    Private _STXDSSC_PublicationsConnectionsProxyServer As STXDSSC_PublicationsConnectionsProxyServer
    Private WithEvents _stxEventLog As stxEventLog
    Private _errorsCount As Integer

#End Region

#Region " < EVENT HANDLING > "

    Private Sub _stxEventLog_LogEntryReceived(ByVal LogEntryInfo As stxEventLogEntry) Handles _stxEventLog.LogEntryReceived
        Try
            Select Case LogEntryInfo.Type
                Case EventLogEntryType.Error, EventLogEntryType.FailureAudit, EventLogEntryType.Warning
                    Me._errorsCount += 1
                    TextBox_Text(Me.txtErrorsCount, CType(Me._errorsCount, String))
            End Select
           
            If Me.lststxEventLog.Items.Count >= 255 Then
                ListBox_Items_Clear(Me.lststxEventLog)
            End If
            ListBox_Items_Add(Me.lststxEventLog, LogEntryInfo.toString(stxEventLogEntry.toStringMode.singleLine))
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " < UI CALLBACKS > "

    Private Sub DataSocketPublicationsProxyServerTestForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me._STXDSSC_PublicationsConnectionsProxyServer.Dispose()
        Catch ex As Exception
            stxEventLog.writeEntry(EventLogEntryType.Error, ex.ToString)
        End Try

    End Sub

    Private Sub DataSocketPublicationsProxyServerTestForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AppRunCheck.Check_If_IAm_Running_ExitIfTrue_And_ShowMessage()

        Try
            _stxEventLog = stxEventLog.GetInstance
        Catch ex As Exception
        End Try
        Me._errorsCount = 0
        Me.txtErrorsCount.Text = Me._errorsCount
        Try
            Me._STXDSSC_PublicationsConnectionsProxyServer = STXDSSC_PublicationsConnectionsProxyServer.GetInstance
            Me.dgrdServiceParameters.DataSource = Me._STXDSSC_PublicationsConnectionsProxyServer.ServiceParametersTable
        Catch ex As Exception
            stxEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FRM As New GeneralPurposeForms.passwordConfirmationForm("1004HEX")
        Try
            If FRM.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Me._STXDSSC_PublicationsConnectionsProxyServer.Dispose()
                Catch ex As Exception
                End Try
                Try
                    Me.Dispose()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        Finally
            FRM.Dispose()
        End Try
       


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.lststxEventLog.Items.Clear()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lststxEventLog_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lststxEventLog.MouseDoubleClick
        Try
            If Me.lststxEventLog.SelectedIndex >= 0 Then
                MsgBox(Me.lststxEventLog.SelectedItem)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If Me.FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me._STXDSSC_PublicationsConnectionsProxyServer.ExportServerParametersToFile(Me.FolderBrowserDialog1.SelectedPath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region " < DELEGATE FUNCTIONS FOR THREAD SAFE CONTROL ACCESS >  "


    Delegate Function ListBoxItemsCountCallBack(ByVal ListBoxC As ListBox) As Integer
    Public Function ListBox_Items_Count(ByVal ListBoxCtrl As ListBox) As Integer
        Try
            If ListBoxCtrl.InvokeRequired Then
                Dim d As New ListBoxItemsCountCallBack(AddressOf ListBox_Items_Count)
                ListBoxCtrl.Invoke(d, New Object() {ListBoxCtrl})
            Else
                Dim count As Integer
                count = ListBoxCtrl.Items.Count
                Return count
            End If
        Catch ex As Exception
        End Try
    End Function

    Delegate Sub ListBoxItemsClearCallBack(ByVal ListBoxC As ListBox)
    Public Sub ListBox_Items_Clear(ByVal ListBoxCtrl As ListBox)
        Try
            If ListBoxCtrl.InvokeRequired Then
                Dim d As New ListBoxItemsClearCallBack(AddressOf ListBox_Items_Clear)
                ListBoxCtrl.Invoke(d, New Object() {ListBoxCtrl})
            Else
                ListBoxCtrl.Items.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub

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

    Delegate Sub TextBoxTextSetCallBack(ByVal TextBoxC As TextBox, ByVal data As Object)
    Public Sub TextBox_Text(ByVal TextBoxCtrl As TextBox, ByVal data As Object)
        Try
            If TextBoxCtrl.InvokeRequired Then
                Dim d As New TextBoxTextSetCallBack(AddressOf TextBox_Text)
                TextBoxCtrl.Invoke(d, New Object() {TextBoxCtrl, data})
            Else
                TextBoxCtrl.Text = data
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region


   
End Class