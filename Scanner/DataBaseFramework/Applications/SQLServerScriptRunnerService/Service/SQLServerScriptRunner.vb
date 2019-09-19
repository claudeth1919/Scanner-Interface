Imports System.ServiceProcess
Imports UtilitiesLibrary.EventLoging
Imports DataBaseLibrary


Public Class SQLServerScriptRunnerService
    Inherits System.ServiceProcess.ServiceBase

#Region " Código generado por el Diseñador de componentes "

    Public Sub New()
        MyBase.New()

        ' El Diseñador de componentes requiere esta llamada.
        InitializeComponent()

        ' Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'UserService reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' El punto de entrada principal para el proceso
    <MTAThread()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' Se puede ejecutar en el mismo proceso más de un servicio NT. Para agregar
        ' otro servicio a este proceso, cambie la siguiente línea a fin de
        ' crear otro objeto de servicio. Por ejemplo,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New SQLServerScriptRunnerService}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Requerido por el Diseñador de componentes
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de componentes requiere el siguiente procedimiento
    'Se puede modificar utilizando el Diseñador de componentes. No lo modifique
    ' con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'SQLServerScriptRunnerService
        '
        Me.CanHandlePowerEvent = True
        Me.ServiceName = "SQLServerScriptRunnerService"

    End Sub

#End Region
#Region " < DATA MEMBERS > "

    Private WithEvents _DBCleaningTaskTimer As Timers.Timer

#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Agregar código aquí para iniciar el servicio. Este método debería poner en movimiento
        ' los elementos para que el servicio pueda funcionar.
        Try
            stxEventLog.writeEntry(EventLogEntryType.SuccessAudit, "Data Base Cleaning Task Strated Succesfully")

            _DBCleaningTaskTimer = New System.Timers.Timer(604800000)
            _DBCleaningTaskTimer.Start()
        Catch ex As Exception
            Dim msg As String = "Error starting the Script runner"
            stxEventLog.writeEntry(EventLogEntryType.Error, msg)
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        ' Agregar código aquí para realizar cualquier anulación necesaria para detener el servicio.
    End Sub

#Region " < TIMING HANDLING > "

    Private Sub TaskTimer(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles _DBCleaningTaskTimer.Elapsed
        Try
            _DBCleaningTaskTimer.Stop()
            Dim query As New ManagedDBQueryDef("PRODUCTION", "usp_CleanUpDataBase", Definitions.queryType.StoredProcedure)
            DBManager.ExecuteQuery(query)
            stxEventLog.writeEntry(EventLogEntryType.SuccessAudit, "Data Base Cleaning Task Executes Succesfully")
        Catch ex As Exception
            Dim msg As String = "Error executing Data Base cleaning task : " & ex.Message
            stxEventLog.writeEntry(EventLogEntryType.Error, msg)
        Finally
            _DBCleaningTaskTimer.Start()
        End Try
    End Sub

#End Region

End Class
