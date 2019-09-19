// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports


namespace SDHClientTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmDSH_ClientTestAppMainForm : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmSTXServiceHandlerClient_FormClosing);
			base.Load += new System.EventHandler(Form1_Load);
			this.btnSearchService = new System.Windows.Forms.Button();
			this.btnSearchService.Click += new System.EventHandler(this.btnSearchService_Click);
			this.txtServiceNameToLookfor = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.lstSErverParameters = new System.Windows.Forms.ListBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtOperationMode = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtServiceName = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.txtClientName = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.GroupBox1.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.SuspendLayout();
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.Button1);
			this.GroupBox1.Controls.Add(this.btnSearchService);
			this.GroupBox1.Controls.Add(this.txtServiceNameToLookfor);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Location = new System.Drawing.Point(2, 72);
			this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.GroupBox1.Size = new System.Drawing.Size(866, 100);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Service To Find Parameters";
			//
			//btnSearchService
			//
			this.btnSearchService.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnSearchService.Location = new System.Drawing.Point(580, 18);
			this.btnSearchService.Name = "btnSearchService";
			this.btnSearchService.Size = new System.Drawing.Size(155, 41);
			this.btnSearchService.TabIndex = 2;
			this.btnSearchService.Text = "Search Service";
			this.btnSearchService.UseVisualStyleBackColor = true;
			//
			//txtServiceNameToLookfor
			//
			this.txtServiceNameToLookfor.Location = new System.Drawing.Point(233, 37);
			this.txtServiceNameToLookfor.Margin = new System.Windows.Forms.Padding(4);
			this.txtServiceNameToLookfor.Name = "txtServiceNameToLookfor";
			this.txtServiceNameToLookfor.Size = new System.Drawing.Size(286, 26);
			this.txtServiceNameToLookfor.TabIndex = 1;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(20, 40);
			this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(206, 19);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Service Name to Look For";
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.btnClear);
			this.GroupBox2.Controls.Add(this.lstSErverParameters);
			this.GroupBox2.Controls.Add(this.Label4);
			this.GroupBox2.Controls.Add(this.txtOperationMode);
			this.GroupBox2.Controls.Add(this.Label3);
			this.GroupBox2.Controls.Add(this.txtServiceName);
			this.GroupBox2.Controls.Add(this.Label2);
			this.GroupBox2.Location = new System.Drawing.Point(2, 177);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(866, 460);
			this.GroupBox2.TabIndex = 1;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Service Parameters";
			//
			//btnClear
			//
			this.btnClear.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnClear.Location = new System.Drawing.Point(698, 413);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(155, 41);
			this.btnClear.TabIndex = 8;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			//
			//lstSErverParameters
			//
			this.lstSErverParameters.FormattingEnabled = true;
			this.lstSErverParameters.ItemHeight = 18;
			this.lstSErverParameters.Location = new System.Drawing.Point(24, 169);
			this.lstSErverParameters.Name = "lstSErverParameters";
			this.lstSErverParameters.Size = new System.Drawing.Size(829, 238);
			this.lstSErverParameters.TabIndex = 7;
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label4.Location = new System.Drawing.Point(20, 147);
			this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(157, 19);
			this.Label4.TabIndex = 6;
			this.Label4.Text = "Service Parameters";
			//
			//txtOperationMode
			//
			this.txtOperationMode.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtOperationMode.Location = new System.Drawing.Point(220, 84);
			this.txtOperationMode.Margin = new System.Windows.Forms.Padding(4);
			this.txtOperationMode.Name = "txtOperationMode";
			this.txtOperationMode.ReadOnly = true;
			this.txtOperationMode.Size = new System.Drawing.Size(633, 26);
			this.txtOperationMode.TabIndex = 5;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label3.Location = new System.Drawing.Point(20, 87);
			this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(191, 19);
			this.Label3.TabIndex = 4;
			this.Label3.Text = "Service Operation Mode";
			//
			//txtServiceName
			//
			this.txtServiceName.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtServiceName.Location = new System.Drawing.Point(142, 37);
			this.txtServiceName.Margin = new System.Windows.Forms.Padding(4);
			this.txtServiceName.Name = "txtServiceName";
			this.txtServiceName.ReadOnly = true;
			this.txtServiceName.Size = new System.Drawing.Size(711, 26);
			this.txtServiceName.TabIndex = 3;
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label2.Location = new System.Drawing.Point(20, 40);
			this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(114, 19);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Service Name";
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.txtClientName);
			this.GroupBox3.Controls.Add(this.Label5);
			this.GroupBox3.Location = new System.Drawing.Point(2, 3);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(866, 70);
			this.GroupBox3.TabIndex = 2;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Client Parameters";
			//
			//txtClientName
			//
			this.txtClientName.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtClientName.Location = new System.Drawing.Point(139, 22);
			this.txtClientName.Margin = new System.Windows.Forms.Padding(4);
			this.txtClientName.Name = "txtClientName";
			this.txtClientName.ReadOnly = true;
			this.txtClientName.Size = new System.Drawing.Size(711, 26);
			this.txtClientName.TabIndex = 5;
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label5.Location = new System.Drawing.Point(17, 25);
			this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(101, 19);
			this.Label5.TabIndex = 4;
			this.Label5.Text = "Client Name";
			//
			//Button1
			//
			this.Button1.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button1.Location = new System.Drawing.Point(580, 58);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(155, 41);
			this.Button1.TabIndex = 3;
			this.Button1.Text = "Discover All";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//frmSTXServiceHandlerClient
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (9.0F), (float) (18.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(868, 640);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.GroupBox1);
			this.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmSTXServiceHandlerClient";
			this.Text = "STX Service Handler Client Test Application";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button btnSearchService;
		internal System.Windows.Forms.TextBox txtServiceNameToLookfor;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.TextBox txtServiceName;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ListBox lstSErverParameters;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox txtOperationMode;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnClear;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.TextBox txtClientName;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Button Button1;
		
	}
	
}
