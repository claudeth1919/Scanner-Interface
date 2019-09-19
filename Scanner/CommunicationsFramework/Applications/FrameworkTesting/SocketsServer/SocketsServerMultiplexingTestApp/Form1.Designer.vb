<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.lstclients = New System.Windows.Forms.ListBox
        Me.txtData = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.lstDataReception = New System.Windows.Forms.ListBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lstServers = New System.Windows.Forms.ListBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 67)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "connect Client"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 80)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 67)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Get Current Server"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(3, 153)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(135, 65)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Get Manager Info"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lstclients
        '
        Me.lstclients.FormattingEnabled = True
        Me.lstclients.Location = New System.Drawing.Point(6, 6)
        Me.lstclients.Name = "lstclients"
        Me.lstclients.Size = New System.Drawing.Size(546, 225)
        Me.lstclients.TabIndex = 3
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(0, 240)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(552, 96)
        Me.txtData.TabIndex = 5
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(558, 240)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(139, 46)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Send Text Data with Selected client"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lstDataReception
        '
        Me.lstDataReception.FormattingEnabled = True
        Me.lstDataReception.Location = New System.Drawing.Point(6, 19)
        Me.lstDataReception.Name = "lstDataReception"
        Me.lstDataReception.Size = New System.Drawing.Size(805, 238)
        Me.lstDataReception.TabIndex = 7
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(817, 19)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(97, 46)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "ClearData"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(558, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(139, 46)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "Disconnect Client"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(144, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(786, 375)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstclients)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.txtData)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(727, 339)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clients "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button7)
        Me.TabPage2.Controls.Add(Me.lstServers)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(778, 349)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Servers"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstServers
        '
        Me.lstServers.FormattingEnabled = True
        Me.lstServers.Location = New System.Drawing.Point(3, 6)
        Me.lstServers.Name = "lstServers"
        Me.lstServers.Size = New System.Drawing.Size(663, 342)
        Me.lstServers.TabIndex = 4
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(672, 6)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(97, 46)
        Me.Button7.TabIndex = 10
        Me.Button7.Text = "Get Servers List"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.lstDataReception)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 378)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(920, 305)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Reception"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 695)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lstclients As System.Windows.Forms.ListBox
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents lstDataReception As System.Windows.Forms.ListBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents lstServers As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
