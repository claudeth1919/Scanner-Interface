Namespace GeneralPurposeForms

    Public Class passwordConfirmationForm

        Private _passwordToVerify As String

        Public Sub New(ByVal passwordToVerify As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me._passwordToVerify = passwordToVerify
        End Sub


        Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
            Try
                If Me.txtPassword.Text.Length <= 0 Then
                    Throw New Exception("No password specified")
                End If
                If Me.txtPassword.Text = Me._passwordToVerify Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
            Try
                If e.KeyCode = Windows.Forms.Keys.Enter Then
                    Me.btnOk_Click(Nothing, Nothing)
                End If
            Catch ex As Exception

            End Try
        End Sub

      
        Private Sub passwordConfirmationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.txtPassword.Focus()
            Catch ex As Exception
            End Try
        End Sub


    End Class


End Namespace

