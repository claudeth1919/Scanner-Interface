<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataSocketPublicationsProxyServerTestForm
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgrdServiceParameters = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtErrorsCount = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.lststxEventLog = New System.Windows.Forms.ListBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Button3 = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.C1SizerLight1 = New C1.Win.C1Sizer.C1SizerLight(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgrdServiceParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.C1SizerLight1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(283, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 41)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Close Server"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(738, 530)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgrdServiceParameters)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(730, 501)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Service Status"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgrdServiceParameters
        '
        Me.dgrdServiceParameters.AllowUserToAddRows = False
        Me.dgrdServiceParameters.AllowUserToDeleteRows = False
        Me.dgrdServiceParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgrdServiceParameters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgrdServiceParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrdServiceParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrdServiceParameters.Location = New System.Drawing.Point(3, 3)
        Me.dgrdServiceParameters.MultiSelect = False
        Me.dgrdServiceParameters.Name = "dgrdServiceParameters"
        Me.dgrdServiceParameters.ReadOnly = True
        Me.dgrdServiceParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgrdServiceParameters.Size = New System.Drawing.Size(724, 495)
        Me.dgrdServiceParameters.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtErrorsCount)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.lststxEventLog)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(730, 501)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Event Log"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtErrorsCount
        '
        Me.txtErrorsCount.Location = New System.Drawing.Point(122, 468)
        Me.txtErrorsCount.Name = "txtErrorsCount"
        Me.txtErrorsCount.ReadOnly = True
        Me.txtErrorsCount.Size = New System.Drawing.Size(143, 22)
        Me.txtErrorsCount.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 471)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Errors Count"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(603, 464)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(119, 34)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Clear Log"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lststxEventLog
        '
        Me.lststxEventLog.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lststxEventLog.HorizontalScrollbar = True
        Me.lststxEventLog.ItemHeight = 16
        Me.lststxEventLog.Location = New System.Drawing.Point(3, 6)
        Me.lststxEventLog.Name = "lststxEventLog"
        Me.lststxEventLog.ScrollAlwaysVisible = True
        Me.lststxEventLog.Size = New System.Drawing.Size(723, 452)
        Me.lststxEventLog.TabIndex = 2
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer1.Size = New System.Drawing.Size(738, 593)
        Me.SplitContainer1.SplitterDistance = 530
        Me.SplitContainer1.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(546, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(164, 41)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Export Server Parameters"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'C1SizerLight1
        '
        Me.C1SizerLight1.ResizeFonts = False
        '
        'DataSocketPublicationsProxyServerTestForm
        '
        Me.C1SizerLight1.SetAutoResize(Me, True)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 593)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "DataSocketPublicationsProxyServerTestForm"
        Me.Text = "DSS Publications Data Proxy Server"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgrdServiceParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.C1SizerLight1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lststxEventLog As System.Windows.Forms.ListBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtErrorsCount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgrdServiceParameters As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents C1SizerLight1 As C1.Win.C1Sizer.C1SizerLight
End Class
