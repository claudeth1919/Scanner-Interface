Public Class DBCredentialsForm
    Inherits SetupParentForm

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        Me.cbNext.Enabled = False
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
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtDataSource As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbxCatalog As System.Windows.Forms.ComboBox
    Friend WithEvents cbSearchDB As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DBCredentialsForm))
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.txtDataSource = New System.Windows.Forms.TextBox
        Me.cbxCatalog = New System.Windows.Forms.ComboBox
        Me.cbSearchDB = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(312, 24)
        Me.Label6.Text = "¿Dónde desea instalar la base de datos?"
        '
        'Label7
        '
        Me.Label7.Name = "Label7"
        Me.Label7.Text = "Destino de la instalación"
        '
        'PictureBox1
        '
        Me.PictureBox1.Name = "PictureBox1"
        '
        'cbNext
        '
        Me.cbNext.Name = "cbNext"
        Me.cbNext.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Name = "GroupBox1"
        '
        'cbCancel
        '
        Me.cbCancel.Name = "cbCancel"
        Me.cbCancel.TabIndex = 3
        '
        'cbPrevious
        '
        Me.cbPrevious.Name = "cbPrevious"
        Me.cbPrevious.TabIndex = 4
        Me.cbPrevious.Visible = False
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(152, 106)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(256, 20)
        Me.txtUser.TabIndex = 1
        Me.txtUser.Text = ""
        '
        'txtPwd
        '
        Me.txtPwd.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPwd.Location = New System.Drawing.Point(152, 132)
        Me.txtPwd.MaxLength = 100
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(256, 20)
        Me.txtPwd.TabIndex = 2
        Me.txtPwd.Text = ""
        '
        'txtDataSource
        '
        Me.txtDataSource.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataSource.Location = New System.Drawing.Point(152, 80)
        Me.txtDataSource.Name = "txtDataSource"
        Me.txtDataSource.Size = New System.Drawing.Size(256, 20)
        Me.txtDataSource.TabIndex = 0
        Me.txtDataSource.Text = ""
        '
        'cbxCatalog
        '
        Me.cbxCatalog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCatalog.Items.AddRange(New Object() {"<Nueva>"})
        Me.cbxCatalog.Location = New System.Drawing.Point(152, 158)
        Me.cbxCatalog.Name = "cbxCatalog"
        Me.cbxCatalog.Size = New System.Drawing.Size(168, 22)
        Me.cbxCatalog.TabIndex = 3
        Me.cbxCatalog.Text = "<Seleccione>"
        '
        'cbSearchDB
        '
        Me.cbSearchDB.Location = New System.Drawing.Point(320, 158)
        Me.cbSearchDB.Name = "cbSearchDB"
        Me.cbSearchDB.Size = New System.Drawing.Size(88, 23)
        Me.cbSearchDB.TabIndex = 4
        Me.cbSearchDB.Text = "&Actualizar"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre de Usuario:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(48, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 23)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Servidor:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(48, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 23)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Base de Datos:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(48, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(360, 32)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Para conectar a Microsoft SQL Server, debe especificar el servidor, el nombre de " & _
        "usuario y la contraseña"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(8, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 48)
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtUser)
        Me.GroupBox2.Controls.Add(Me.txtDataSource)
        Me.GroupBox2.Controls.Add(Me.txtPwd)
        Me.GroupBox2.Controls.Add(Me.cbxCatalog)
        Me.GroupBox2.Controls.Add(Me.cbSearchDB)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(448, 208)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'DBCredentialsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(498, 368)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DBCredentialsForm"
        Me.Text = "Asistente para instalación de base de datos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Sub fillDBList(ByVal datasource As String, ByVal user As String, ByVal pwd As String)
        Dim dbList As DataTable

        Try
            dbList = searchDatabases(datasource, user, pwd)

            If Not dbList Is Nothing Then
                Me.cbxCatalog.Items.Clear()

                For Each row As DataRow In dbList.Rows
                    Me.cbxCatalog.Items.Add(row.Item("name"))
                Next

                Me.cbxCatalog.Items.Add("<Nueva>")
            End If
        Catch ex As SqlClient.SqlException
            Select Case ex.Number
                Case 4060

                Case Else

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Function searchDatabases(ByVal dataSource As String, ByVal user As String, ByVal pwd As String) As DataTable

        Dim dbConn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim dbComm As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Dim dsMaster As DataSet = New DataSet
        Dim daDatabases As SqlClient.SqlDataAdapter

        dbConn.ConnectionString = Util.DBUtil.CreateConnectionString(dataSource, user, pwd)

        dbComm.Connection = dbConn
        dbComm.CommandType = CommandType.Text
        dbComm.CommandText = "USE MASTER " & _
                             "SELECT [name] " & _
                             "FROM sysdatabases"
        Try
            daDatabases = New SqlClient.SqlDataAdapter(dbComm)
            daDatabases.Fill(dsMaster, "SYSDB")
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
            Me.cbNext.Enabled = True
        End Try

        Return dsMaster.Tables("SYSDB")
    End Function

#Region "Form Methods"

    Private Sub cbSearchDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSearchDB.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        fillDBList(Me.txtDataSource.Text, Me.txtUser.Text, Me.txtPwd.Text)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub cbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Me.Close()
    End Sub

    Private Sub cbxCatalog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCatalog.SelectedIndexChanged
        If Trim(Me.cbxCatalog.Text) = "<Nueva>" Then
            Dim newDBForm As CreateDBForm = New CreateDBForm(Me.txtDataSource.Text, Me.txtUser.Text, Me.txtPwd.Text, Me)
            newDBForm.ShowDialog()
        End If
    End Sub

    Private Sub cbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNext.Click
        Dim newTaskForm As TasksForm = New TasksForm(Me.txtDataSource.Text, Me.txtUser.Text, Me.txtPwd.Text, Me.cbxCatalog.Text, Me)
        newTaskForm.Top = Me.Top
        newTaskForm.Left = Me.Left
        newTaskForm.Show()
        Me.Hide()
    End Sub

    Private Sub txtPwd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPwd.LostFocus
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        fillDBList(Me.txtDataSource.Text, Me.txtUser.Text, Me.txtPwd.Text)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
#End Region

End Class
