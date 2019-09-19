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



namespace SocketsServerTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmSocketDataTest : System.Windows.Forms.Form
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
			base.Load += new System.EventHandler(Form1_Load);
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3 = new System.Windows.Forms.Button();
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4 = new System.Windows.Forms.Button();
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Button5 = new System.Windows.Forms.Button();
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.txtDataSocketXMLString = new System.Windows.Forms.TextBox();
			this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
			this.Button6 = new System.Windows.Forms.Button();
			this.Button6.Click += new System.EventHandler(this.Button6_Click);
			this.Button7 = new System.Windows.Forms.Button();
			this.Button7.Click += new System.EventHandler(this.Button7_Click);
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).BeginInit();
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(12, 12);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "integer";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(12, 41);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 1;
			this.Button2.Text = "decimal";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//Button3
			//
			this.Button3.Location = new System.Drawing.Point(12, 70);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(75, 23);
			this.Button3.TabIndex = 2;
			this.Button3.Text = "string ";
			this.Button3.UseVisualStyleBackColor = true;
			//
			//Button4
			//
			this.Button4.Location = new System.Drawing.Point(12, 99);
			this.Button4.Name = "Button4";
			this.Button4.Size = new System.Drawing.Size(75, 23);
			this.Button4.TabIndex = 3;
			this.Button4.Text = "Boolean";
			this.Button4.UseVisualStyleBackColor = true;
			//
			//Button5
			//
			this.Button5.Location = new System.Drawing.Point(12, 128);
			this.Button5.Name = "Button5";
			this.Button5.Size = new System.Drawing.Size(75, 23);
			this.Button5.TabIndex = 4;
			this.Button5.Text = "Data Table";
			this.Button5.UseVisualStyleBackColor = true;
			//
			//txtDataSocketXMLString
			//
			this.txtDataSocketXMLString.Location = new System.Drawing.Point(93, 2);
			this.txtDataSocketXMLString.Multiline = true;
			this.txtDataSocketXMLString.Name = "txtDataSocketXMLString";
			this.txtDataSocketXMLString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDataSocketXMLString.Size = new System.Drawing.Size(668, 549);
			this.txtDataSocketXMLString.TabIndex = 5;
			//
			//Button6
			//
			this.Button6.Location = new System.Drawing.Point(12, 157);
			this.Button6.Name = "Button6";
			this.Button6.Size = new System.Drawing.Size(75, 23);
			this.Button6.TabIndex = 6;
			this.Button6.Text = "Sorted List";
			this.Button6.UseVisualStyleBackColor = true;
			//
			//Button7
			//
			this.Button7.Location = new System.Drawing.Point(12, 186);
			this.Button7.Name = "Button7";
			this.Button7.Size = new System.Drawing.Size(75, 23);
			this.Button7.TabIndex = 7;
			this.Button7.Text = "Hash table";
			this.Button7.UseVisualStyleBackColor = true;
			//
			//frmSocketDataTest
			//
			this.C1SizerLight1.SetAutoResize(this, true);
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 563);
			this.Controls.Add(this.Button7);
			this.Controls.Add(this.Button6);
			this.Controls.Add(this.txtDataSocketXMLString);
			this.Controls.Add(this.Button5);
			this.Controls.Add(this.Button4);
			this.Controls.Add(this.Button3);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Button1);
			this.Name = "frmSocketDataTest";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.Button Button4;
		internal System.Windows.Forms.Button Button5;
		internal System.Windows.Forms.TextBox txtDataSocketXMLString;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.Button Button6;
		internal System.Windows.Forms.Button Button7;
	}
	
}
