Imports System.IO

Public Class TasksForm
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
    Friend WithEvents lbFilesToRun As System.Windows.Forms.ListBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lbFilesToRun = New System.Windows.Forms.ListBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPath)
        Me.GroupBox1.Controls.Add(Me.lbFilesToRun)
        Me.GroupBox1.Name = "GroupBox1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Name = "PictureBox1"
        '
        'cbCancel
        '
        Me.cbCancel.Name = "cbCancel"
        '
        'Label7
        '
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(336, 40)
        Me.Label7.Text = "En el recuadro inferior se muestra un listado de los archivos que se ejecutarán c" & _
        "omo parte de la instalación. Presione Instalar para continuar"
        '
        'cbNext
        '
        Me.cbNext.Name = "cbNext"
        Me.cbNext.Text = "&Instalar"
        '
        'Label6
        '
        Me.Label6.Name = "Label6"
        Me.Label6.Text = "Tareas a ejecutar"
        '
        'cbPrevious
        '
        Me.cbPrevious.Name = "cbPrevious"
        '
        'lbFilesToRun
        '
        Me.lbFilesToRun.Location = New System.Drawing.Point(96, 64)
        Me.lbFilesToRun.Name = "lbFilesToRun"
        Me.lbFilesToRun.Size = New System.Drawing.Size(320, 173)
        Me.lbFilesToRun.TabIndex = 0
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(136, 32)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(280, 20)
        Me.txtPath.TabIndex = 1
        Me.txtPath.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(96, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ruta:"
        '
        'TasksForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 358)
        Me.Name = "TasksForm"
        Me.Text = "Tareas a ejecutar"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected _dataSource As String
    Protected _user As String
    Protected _pwd As String
    Protected _catalog As String

    Protected _defaultPath As String
    Protected _fileSearchPattern As String
    Protected _fileList As SortedList


    Public Sub New(ByVal dataSource As String, ByVal user As String, ByVal pwd As String, ByVal initialCatalog As String, ByVal previousForm As Form)

        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        Me._PreviousForm = previousForm

        Me._dataSource = dataSource
        Me._user = user
        Me._pwd = pwd
        Me._catalog = initialCatalog

        Try
            ' Me._defaultPath = ConfigurationManager.GetValue("INSTALL_FILES", "DEFAULT_PATH")
            Me._defaultPath = Application.StartupPath & "\scripts"
            ' Me._fileSearchPattern = ConfigurationManager.GetValue("INSTALL_FILES", "FILE_SEARCH_PATTERN")
            Me._fileSearchPattern = "*.sql"

            Me.txtPath.Text = _defaultPath
            FillFileList(_defaultPath, _fileSearchPattern)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Friend Sub SetNextForm(ByVal nextForm As Form)
        Me._NextForm = nextForm
    End Sub

    Protected Sub FillFileList(ByVal path As String, ByVal searchPattern As String)

        Dim dir As DirectoryInfo
        _fileList = New SortedList

        Me.lbFilesToRun.Sorted = True

        Try
            If Not Directory.Exists(path) Then
                dir = Directory.CreateDirectory(path)
            Else
                dir = New DirectoryInfo(path)
            End If

            For Each fInfo As FileInfo In dir.GetFiles(searchPattern)
                Me.lbFilesToRun.Items.Add(fInfo.Name)
                _fileList.Add(fInfo.Name, fInfo.FullName)
            Next
        Catch ioex As System.IO.DirectoryNotFoundException

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub InstallFiles()
        Dim sqlRunner As Util.SQLScriptRunner = New Util.SQLScriptRunner(_dataSource, _user, _pwd, _catalog, _fileList)

        sqlRunner.Run()
    End Sub

    Private Sub cbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNext.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            InstallFiles()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
        End Try

        _nextform = New FinishForm
        Me.Hide()
        _nextform.Show()

    End Sub
End Class
