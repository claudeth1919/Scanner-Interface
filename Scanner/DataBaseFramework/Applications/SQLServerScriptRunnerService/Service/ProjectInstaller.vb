Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)> Public Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

#Region " Código generado por el Diseñador de componentes "

    Public Sub New()
        MyBase.New()

        'El Diseñador de componentes requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Installer reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de componentes
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de componentes requiere el siguiente procedimiento
    'Se puede modificar utilizando el Diseñador de componentes.
    'No lo modifique con el editor de código.
    Friend WithEvents ServiceProcessInstaller As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents ServiceInstaller As System.ServiceProcess.ServiceInstaller
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ServiceProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller
        Me.ServiceInstaller = New System.ServiceProcess.ServiceInstaller
        '
        'ServiceProcessInstaller
        '
        Me.ServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.ServiceProcessInstaller.Password = Nothing
        Me.ServiceProcessInstaller.Username = Nothing
        '
        'ServiceInstaller
        '
        Me.ServiceInstaller.DisplayName = "STX SQL Script Runner"
        Me.ServiceInstaller.ServiceName = "SQLServerScriptRunnerService"
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ServiceProcessInstaller, Me.ServiceInstaller})

    End Sub

#End Region

End Class
