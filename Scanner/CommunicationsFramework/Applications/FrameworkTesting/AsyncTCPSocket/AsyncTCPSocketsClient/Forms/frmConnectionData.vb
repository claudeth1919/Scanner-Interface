Public Class frmConnectionData

    Private Sub frmConnectionData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.HostName.Text.Length <= 0 Then
                Throw New Exception("No hostname specified")
            End If
            If Me.PortNumber.Text.Length <= 0 Then
                Throw New Exception("No port number specified")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.DialogResult = Windows.Forms.DialogResult.None
        End Try
       
    End Sub
End Class