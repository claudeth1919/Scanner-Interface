Public Class CreateDBForm
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents cbOk As System.Windows.Forms.Button
    Friend WithEvents cbCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateDBForm))
        Me.txtDBName = New System.Windows.Forms.TextBox
        Me.cbOk = New System.Windows.Forms.Button
        Me.cbCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(128, 73)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(208, 20)
        Me.txtDBName.TabIndex = 5
        '
        'cbOk
        '
        Me.cbOk.Location = New System.Drawing.Point(185, 128)
        Me.cbOk.Name = "cbOk"
        Me.cbOk.Size = New System.Drawing.Size(75, 23)
        Me.cbOk.TabIndex = 8
        Me.cbOk.Text = "&Aceptar"
        '
        'cbCancel
        '
        Me.cbCancel.Location = New System.Drawing.Point(265, 128)
        Me.cbCancel.Name = "cbCancel"
        Me.cbCancel.Size = New System.Drawing.Size(75, 23)
        Me.cbCancel.TabIndex = 9
        Me.cbCancel.Text = "&Cancelar"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&Nombre:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(56, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 32)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Especifique el nombre y las propiedades de la base de datos SQL Server."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 40)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(8, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 8)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CreateDBForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(369, 171)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbCancel)
        Me.Controls.Add(Me.cbOk)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CreateDBForm"
        Me.Text = "Crear base de datos"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Protected _datasource As String
    Protected _user As String
    Protected _pwd As String

    Protected _myCaller As Form

    Public Sub New(ByVal datasource As String, ByVal user As String, ByVal pwd As String, ByVal myCaller As Form)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        _datasource = datasource
        _user = user
        _pwd = pwd

        _myCaller = myCaller

    End Sub

    Private Sub cbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Me.Close()
    End Sub

    Private Sub cbOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOk.Click
        ' .. last two parameters are not being used
        Try
            CreateDatabase(Me.txtDBName.Text, 2, 2)

            CType(_myCaller, DBCredentialsForm).cbxCatalog.Items.Add(Me.txtDBName.Text)
            CType(_myCaller, DBCredentialsForm).cbxCatalog.Text = Me.txtDBName.Text
            Me.Close()
        Catch ex As SqlClient.SqlException
            Select Case ex.Number
                Case 1
                    '
                Case Else
                    '
            End Select
        Catch ex As Exception
            '
        End Try
    End Sub

    Protected Sub CreateDatabase(ByVal fileName As String, ByVal fileSize As Integer, ByVal logSize As Integer)
        Dim dbConn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim dbComm As SqlClient.SqlCommand = New SqlClient.SqlCommand

        dbConn.ConnectionString = Util.DBUtil.CreateConnectionString(_datasource, _user, _pwd)

        dbComm.Connection = dbConn
        dbComm.CommandType = CommandType.Text
        dbComm.CommandText = "USE master " & _
                             "CREATE DATABASE " & fileName
        Try
            dbConn.Open()
            dbComm.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

    End Sub
End Class
