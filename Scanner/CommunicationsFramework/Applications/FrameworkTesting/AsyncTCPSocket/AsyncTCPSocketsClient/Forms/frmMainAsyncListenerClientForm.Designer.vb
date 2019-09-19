<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainAsyncListenerClientForm
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
        Me.components = New System.ComponentModel.Container
        Me.btnConnect = New System.Windows.Forms.Button
        Me.txtDataToSend = New System.Windows.Forms.TextBox
        Me.btnSendData = New System.Windows.Forms.Button
        Me.btnSend = New System.Windows.Forms.Button
        Me.C1SizerLight1 = New C1.Win.C1Sizer.C1SizerLight(Me.components)
        Me.tmrAutoSend = New System.Windows.Forms.Timer(Me.components)
        Me.grpAutoSend = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txttotalDataSize = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSendTrials = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDataSize = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudTimerIntervall = New System.Windows.Forms.NumericUpDown
        Me.txtConnectionStatus = New System.Windows.Forms.TextBox
        CType(Me.C1SizerLight1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAutoSend.SuspendLayout()
        CType(Me.nudTimerIntervall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.Location = New System.Drawing.Point(12, 12)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(190, 62)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect to Listener"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtDataToSend
        '
        Me.txtDataToSend.Enabled = False
        Me.txtDataToSend.Location = New System.Drawing.Point(2, 166)
        Me.txtDataToSend.Multiline = True
        Me.txtDataToSend.Name = "txtDataToSend"
        Me.txtDataToSend.Size = New System.Drawing.Size(811, 347)
        Me.txtDataToSend.TabIndex = 1
        '
        'btnSendData
        '
        Me.btnSendData.Enabled = False
        Me.btnSendData.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendData.Location = New System.Drawing.Point(12, 80)
        Me.btnSendData.Name = "btnSendData"
        Me.btnSendData.Size = New System.Drawing.Size(190, 33)
        Me.btnSendData.TabIndex = 2
        Me.btnSendData.Text = "Send Data"
        Me.btnSendData.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(6, 19)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(190, 33)
        Me.btnSend.TabIndex = 3
        Me.btnSend.Text = "Start Auto Send Data"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'C1SizerLight1
        '
        Me.C1SizerLight1.ResizeFonts = False
        '
        'tmrAutoSend
        '
        '
        'grpAutoSend
        '
        Me.grpAutoSend.Controls.Add(Me.Button1)
        Me.grpAutoSend.Controls.Add(Me.txttotalDataSize)
        Me.grpAutoSend.Controls.Add(Me.Label3)
        Me.grpAutoSend.Controls.Add(Me.txtSendTrials)
        Me.grpAutoSend.Controls.Add(Me.Label2)
        Me.grpAutoSend.Controls.Add(Me.txtDataSize)
        Me.grpAutoSend.Controls.Add(Me.Label1)
        Me.grpAutoSend.Controls.Add(Me.nudTimerIntervall)
        Me.grpAutoSend.Controls.Add(Me.btnSend)
        Me.grpAutoSend.Enabled = False
        Me.grpAutoSend.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAutoSend.Location = New System.Drawing.Point(226, 3)
        Me.grpAutoSend.Name = "grpAutoSend"
        Me.grpAutoSend.Size = New System.Drawing.Size(587, 157)
        Me.grpAutoSend.TabIndex = 4
        Me.grpAutoSend.TabStop = False
        Me.grpAutoSend.Text = "autosend"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(347, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 33)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Stop Auto Send Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txttotalDataSize
        '
        Me.txttotalDataSize.Location = New System.Drawing.Point(174, 122)
        Me.txttotalDataSize.Name = "txttotalDataSize"
        Me.txttotalDataSize.ReadOnly = True
        Me.txttotalDataSize.Size = New System.Drawing.Size(158, 26)
        Me.txttotalDataSize.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Total Data Size Sent"
        '
        'txtSendTrials
        '
        Me.txtSendTrials.Location = New System.Drawing.Point(120, 91)
        Me.txtSendTrials.Name = "txtSendTrials"
        Me.txtSendTrials.ReadOnly = True
        Me.txtSendTrials.Size = New System.Drawing.Size(100, 26)
        Me.txtSendTrials.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Send Trials"
        '
        'txtDataSize
        '
        Me.txtDataSize.Location = New System.Drawing.Point(120, 59)
        Me.txtDataSize.Name = "txtDataSize"
        Me.txtDataSize.ReadOnly = True
        Me.txtDataSize.Size = New System.Drawing.Size(100, 26)
        Me.txtDataSize.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "data Size"
        '
        'nudTimerIntervall
        '
        Me.nudTimerIntervall.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTimerIntervall.Location = New System.Drawing.Point(202, 20)
        Me.nudTimerIntervall.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudTimerIntervall.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudTimerIntervall.Name = "nudTimerIntervall"
        Me.nudTimerIntervall.Size = New System.Drawing.Size(120, 32)
        Me.nudTimerIntervall.TabIndex = 4
        Me.nudTimerIntervall.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'txtConnectionStatus
        '
        Me.txtConnectionStatus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConnectionStatus.Location = New System.Drawing.Point(12, 525)
        Me.txtConnectionStatus.Name = "txtConnectionStatus"
        Me.txtConnectionStatus.ReadOnly = True
        Me.txtConnectionStatus.Size = New System.Drawing.Size(555, 29)
        Me.txtConnectionStatus.TabIndex = 5
        Me.txtConnectionStatus.Text = "Not connected"
        '
        'frmMainAsyncListenerClientForm
        '
        Me.C1SizerLight1.SetAutoResize(Me, True)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 557)
        Me.Controls.Add(Me.txtConnectionStatus)
        Me.Controls.Add(Me.txtDataToSend)
        Me.Controls.Add(Me.grpAutoSend)
        Me.Controls.Add(Me.btnSendData)
        Me.Controls.Add(Me.btnConnect)
        Me.Name = "frmMainAsyncListenerClientForm"
        Me.Text = "Form1"
        CType(Me.C1SizerLight1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAutoSend.ResumeLayout(False)
        Me.grpAutoSend.PerformLayout()
        CType(Me.nudTimerIntervall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents txtDataToSend As System.Windows.Forms.TextBox
    Friend WithEvents btnSendData As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents C1SizerLight1 As C1.Win.C1Sizer.C1SizerLight
    Friend WithEvents tmrAutoSend As System.Windows.Forms.Timer
    Friend WithEvents grpAutoSend As System.Windows.Forms.GroupBox
    Friend WithEvents nudTimerIntervall As System.Windows.Forms.NumericUpDown
    Friend WithEvents txttotalDataSize As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSendTrials As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataSize As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConnectionStatus As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
