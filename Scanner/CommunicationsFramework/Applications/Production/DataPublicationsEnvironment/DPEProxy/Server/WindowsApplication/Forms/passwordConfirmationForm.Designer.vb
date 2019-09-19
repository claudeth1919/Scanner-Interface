
Namespace GeneralPurposeForms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class passwordConfirmationForm
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(passwordConfirmationForm))
            Me.btnCancel = New Klik.Windows.Forms.v1.EntryLib.ELButton
            Me.btnOk = New Klik.Windows.Forms.v1.EntryLib.ELButton
            Me.txtPassword = New System.Windows.Forms.TextBox
            CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.btnOk, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnCancel
            '
            Me.btnCancel.BackgroundImageStyle.Alpha = 100
            Me.btnCancel.BackgroundImageStyle.Image = CType(resources.GetObject("resource.Image"), System.Drawing.Image)
            Me.btnCancel.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No
            Me.btnCancel.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
            Me.btnCancel.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
            Me.btnCancel.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.btnCancel.Location = New System.Drawing.Point(295, 141)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver
            Me.btnCancel.Size = New System.Drawing.Size(229, 57)
            Me.btnCancel.TabIndex = 140
            Me.btnCancel.TextStyle.BackColor = System.Drawing.Color.Black
            Me.btnCancel.TextStyle.Font = New System.Drawing.Font("Segoe UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.TextStyle.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.TextStyle.Text = "Cancelar"
            Me.btnCancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnCancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Office2003
            '
            'btnOk
            '
            Me.btnOk.BackgroundImageStyle.Alpha = 100
            Me.btnOk.BackgroundImageStyle.Image = CType(resources.GetObject("resource.Image1"), System.Drawing.Image)
            Me.btnOk.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes
            Me.btnOk.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
            Me.btnOk.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
            Me.btnOk.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.btnOk.Location = New System.Drawing.Point(42, 141)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver
            Me.btnOk.Size = New System.Drawing.Size(229, 57)
            Me.btnOk.TabIndex = 139
            Me.btnOk.TextStyle.BackColor = System.Drawing.Color.Black
            Me.btnOk.TextStyle.Font = New System.Drawing.Font("Segoe UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOk.TextStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.btnOk.TextStyle.Text = "Aceptar"
            Me.btnOk.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnOk.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Office2003
            '
            'txtPassword
            '
            Me.txtPassword.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPassword.Location = New System.Drawing.Point(42, 29)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.Size = New System.Drawing.Size(482, 63)
            Me.txtPassword.TabIndex = 0
            '
            'passwordConfirmationForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(565, 233)
            Me.ControlBox = False
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Name = "passwordConfirmationForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "confirmar contraseña"
            CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.btnOk, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnCancel As Klik.Windows.Forms.v1.EntryLib.ELButton
        Friend WithEvents btnOk As Klik.Windows.Forms.v1.EntryLib.ELButton
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    End Class

End Namespace

