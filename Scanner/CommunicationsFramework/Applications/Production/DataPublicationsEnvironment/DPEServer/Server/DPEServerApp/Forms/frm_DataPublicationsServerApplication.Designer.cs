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


namespace DPEServerApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frm_DataPublicationsServerApplication : System.Windows.Forms.Form
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
			this.components = new System.ComponentModel.Container();
			base.Load += new System.EventHandler(frmDataSocketServerApplication_Load);
			this.btnCloseSErver = new System.Windows.Forms.Button();
			this.btnCloseSErver.Click += new System.EventHandler(this.btnCloseSErver_Click);
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.dgrdServiceParameters = new System.Windows.Forms.DataGridView();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.txtErrorsCount = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.lststxEventLog = new System.Windows.Forms.ListBox();
			this.lststxEventLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lststxEventLog_MouseDoubleClick);
			this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
			this.Button3 = new System.Windows.Forms.Button();
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrdServiceParameters).BeginInit();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).BeginInit();
			this.SuspendLayout();
			//
			//btnCloseSErver
			//
			this.btnCloseSErver.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnCloseSErver.Location = new System.Drawing.Point(278, 429);
			this.btnCloseSErver.Name = "btnCloseSErver";
			this.btnCloseSErver.Size = new System.Drawing.Size(134, 44);
			this.btnCloseSErver.TabIndex = 0;
			this.btnCloseSErver.Text = "Close Server";
			this.btnCloseSErver.UseVisualStyleBackColor = true;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.TabControl1.Location = new System.Drawing.Point(2, 3);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(737, 417);
			this.TabControl1.TabIndex = 1;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.dgrdServiceParameters);
			this.TabPage1.Location = new System.Drawing.Point(4, 25);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(729, 388);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Service Parameters";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//dgrdServiceParameters
			//
			this.dgrdServiceParameters.AllowUserToAddRows = false;
			this.dgrdServiceParameters.AllowUserToDeleteRows = false;
			this.dgrdServiceParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgrdServiceParameters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgrdServiceParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrdServiceParameters.Location = new System.Drawing.Point(6, 6);
			this.dgrdServiceParameters.MultiSelect = false;
			this.dgrdServiceParameters.Name = "dgrdServiceParameters";
			this.dgrdServiceParameters.ReadOnly = true;
			this.dgrdServiceParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgrdServiceParameters.Size = new System.Drawing.Size(720, 379);
			this.dgrdServiceParameters.TabIndex = 0;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.txtErrorsCount);
			this.TabPage2.Controls.Add(this.Label1);
			this.TabPage2.Controls.Add(this.Button1);
			this.TabPage2.Controls.Add(this.lststxEventLog);
			this.TabPage2.Location = new System.Drawing.Point(4, 25);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(729, 388);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "STXEventLog";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//txtErrorsCount
			//
			this.txtErrorsCount.Location = new System.Drawing.Point(111, 354);
			this.txtErrorsCount.Name = "txtErrorsCount";
			this.txtErrorsCount.ReadOnly = true;
			this.txtErrorsCount.Size = new System.Drawing.Size(143, 22);
			this.txtErrorsCount.TabIndex = 7;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(11, 357);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(86, 16);
			this.Label1.TabIndex = 6;
			this.Label1.Text = "Errors Count";
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(604, 348);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(119, 34);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Clear Log";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//lststxEventLog
			//
			this.lststxEventLog.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lststxEventLog.FormattingEnabled = true;
			this.lststxEventLog.ItemHeight = 16;
			this.lststxEventLog.Location = new System.Drawing.Point(3, 3);
			this.lststxEventLog.Name = "lststxEventLog";
			this.lststxEventLog.Size = new System.Drawing.Size(723, 340);
			this.lststxEventLog.TabIndex = 0;
			//
			//C1SizerLight1
			//
			this.C1SizerLight1.ResizeFonts = false;
			//
			//Button3
			//
			this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button3.Location = new System.Drawing.Point(565, 429);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(164, 41);
			this.Button3.TabIndex = 2;
			this.Button3.Text = "Export Server Parameters";
			this.Button3.UseVisualStyleBackColor = true;
			//
			//frm_DataPublicationsServerApplication
			//
			this.C1SizerLight1.SetAutoResize(this, true);
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(741, 482);
			this.ControlBox = false;
			this.Controls.Add(this.Button3);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.btnCloseSErver);
			this.Name = "frm_DataPublicationsServerApplication";
			this.Text = "Data Publications Server";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrdServiceParameters).EndInit();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).EndInit();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.Button btnCloseSErver;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.DataGridView dgrdServiceParameters;
		internal System.Windows.Forms.ListBox lststxEventLog;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.TextBox txtErrorsCount;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
		
	}
	
}
