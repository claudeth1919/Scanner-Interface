<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsyncTCPSocketListenerTestForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsyncTCPSocketListenerTestForm))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.lstPortEvents = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgrDataStatistics = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnClearStats = New System.Windows.Forms.Button
        Me.C1SizerLight1 = New C1.Win.C1Sizer.C1SizerLight(Me.components)
        Me.lstErrors = New System.Windows.Forms.ListBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgrDataStatistics, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SizerLight1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 389)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port Events"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(4, 573)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(165, 26)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Clear List"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstPortEvents
        '
        Me.lstPortEvents.FormattingEnabled = True
        Me.lstPortEvents.HorizontalScrollbar = True
        Me.lstPortEvents.ItemHeight = 19
        Me.lstPortEvents.Location = New System.Drawing.Point(4, 411)
        Me.lstPortEvents.Name = "lstPortEvents"
        Me.lstPortEvents.ScrollAlwaysVisible = True
        Me.lstPortEvents.Size = New System.Drawing.Size(1077, 156)
        Me.lstPortEvents.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.dgrDataStatistics)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.btnClearStats)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1078, 384)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Reception statistics"
        '
        'dgrDataStatistics
        '
        Me.dgrDataStatistics.ColumnInfo = "0,0,0,0,0,115,Columns:"
        Me.dgrDataStatistics.Location = New System.Drawing.Point(6, 25)
        Me.dgrDataStatistics.Name = "dgrDataStatistics"
        Me.dgrDataStatistics.Rows.DefaultSize = 23
        Me.dgrDataStatistics.Size = New System.Drawing.Size(1063, 314)
        Me.dgrDataStatistics.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("dgrDataStatistics.Styles"))
        Me.dgrDataStatistics.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(755, 345)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(150, 36)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "update "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnClearStats
        '
        Me.btnClearStats.Location = New System.Drawing.Point(922, 345)
        Me.btnClearStats.Name = "btnClearStats"
        Me.btnClearStats.Size = New System.Drawing.Size(150, 36)
        Me.btnClearStats.TabIndex = 1
        Me.btnClearStats.Text = "clear Statistics"
        Me.btnClearStats.UseVisualStyleBackColor = True
        '
        'lstErrors
        '
        Me.lstErrors.FormattingEnabled = True
        Me.lstErrors.HorizontalScrollbar = True
        Me.lstErrors.ItemHeight = 19
        Me.lstErrors.Location = New System.Drawing.Point(3, 605)
        Me.lstErrors.Name = "lstErrors"
        Me.lstErrors.ScrollAlwaysVisible = True
        Me.lstErrors.Size = New System.Drawing.Size(1077, 156)
        Me.lstErrors.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(231, 345)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(150, 36)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Dispose Listener"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmAsyncTCPSocketListenerTestForm
        '
        Me.C1SizerLight1.SetAutoResize(Me, True)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1083, 764)
        Me.Controls.Add(Me.lstErrors)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstPortEvents)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmAsyncTCPSocketListenerTestForm"
        Me.Text = "OnePortTest"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgrDataStatistics, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SizerLight1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lstPortEvents As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents C1SizerLight1 As C1.Win.C1Sizer.C1SizerLight
    Friend WithEvents btnClearStats As System.Windows.Forms.Button
    Friend WithEvents lstErrors As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgrDataStatistics As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
