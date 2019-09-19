Public Class SetupParentForm
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Protected Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Protected Friend WithEvents Label7 As System.Windows.Forms.Label
    Protected Friend WithEvents Label6 As System.Windows.Forms.Label
    Protected Friend WithEvents cbCancel As System.Windows.Forms.Button
    Protected Friend WithEvents cbNext As System.Windows.Forms.Button
    Protected Friend WithEvents cbPrevious As System.Windows.Forms.Button
    Protected Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SetupParentForm))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbCancel = New System.Windows.Forms.Button
        Me.cbNext = New System.Windows.Forms.Button
        Me.cbPrevious = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 64)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(424, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 56)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(56, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(336, 32)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "<Texto>"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 24)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "<Title>"
        '
        'cbCancel
        '
        Me.cbCancel.Location = New System.Drawing.Point(416, 328)
        Me.cbCancel.Name = "cbCancel"
        Me.cbCancel.TabIndex = 4
        Me.cbCancel.Text = "&Cancelar"
        '
        'cbNext
        '
        Me.cbNext.Location = New System.Drawing.Point(320, 328)
        Me.cbNext.Name = "cbNext"
        Me.cbNext.Size = New System.Drawing.Size(80, 23)
        Me.cbNext.TabIndex = 3
        Me.cbNext.Text = "&Siguiente >"
        '
        'cbPrevious
        '
        Me.cbPrevious.Location = New System.Drawing.Point(232, 328)
        Me.cbPrevious.Name = "cbPrevious"
        Me.cbPrevious.Size = New System.Drawing.Size(80, 23)
        Me.cbPrevious.TabIndex = 2
        Me.cbPrevious.Text = "< &Anterior"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(-8, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(513, 256)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'SetupParentForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 358)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbPrevious)
        Me.Controls.Add(Me.cbCancel)
        Me.Controls.Add(Me.cbNext)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SetupParentForm"
        Me.Text = "<Please define Title>"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected _PreviousForm As SetupParentForm
    Protected _NextForm As SetupParentForm

    Friend Sub ReShowFromNextFrom()
        Me.Show()
        _NextForm = Nothing
    End Sub

    Private Sub cbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        If MsgBox("¿Cancelar la Instalación?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Instalador de base de datos") = MsgBoxResult.Yes Then
            Environment.Exit(0)
        End If
    End Sub

    Private Sub cbPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPrevious.Click
        Me.Hide()
        CType(_PreviousForm, SetupParentForm).Top = Me.Top
        CType(_PreviousForm, SetupParentForm).Left = Me.Left
        CType(_PreviousForm, SetupParentForm).ReShowFromNextFrom()
    End Sub
End Class
