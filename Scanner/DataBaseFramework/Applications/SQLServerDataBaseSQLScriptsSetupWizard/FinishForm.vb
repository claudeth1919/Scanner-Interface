Public Class FinishForm
    Inherits DatabaseSetup.SetupParentForm

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.Name = "Label7"
        Me.Label7.Text = "Las bases de datos han sido instaladas de acuerdo a los parámetros indicados. Pre" & _
        "sione Terminar para salir."
        '
        'cbNext
        '
        Me.cbNext.Name = "cbNext"
        Me.cbNext.Text = "&Terminar"
        '
        'cbCancel
        '
        Me.cbCancel.Name = "cbCancel"
        Me.cbCancel.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Name = "PictureBox1"
        '
        'cbPrevious
        '
        Me.cbPrevious.Name = "cbPrevious"
        Me.cbPrevious.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Name = "GroupBox1"
        '
        'Label6
        '
        Me.Label6.Name = "Label6"
        Me.Label6.Text = "Instalación Completada"
        '
        'FinishForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 358)
        Me.Name = "FinishForm"
        Me.Text = "Fin de la Instalación"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNext.Click
        Environment.Exit(0)
    End Sub
End Class
