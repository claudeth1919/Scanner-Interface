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


namespace CNDServiceClient
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmServiceIndex : System.Windows.Forms.Form
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
			this.Label1 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.Button2 = new System.Windows.Forms.Button();
			this.nudNumeroAceria = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize) this.nudNumeroAceria).BeginInit();
			this.SuspendLayout();
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Arial", (float) (18.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(127, 20);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(218, 29);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Indice de Servicio";
			//
			//btnOk
			//
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnOk.Location = new System.Drawing.Point(183, 178);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(103, 37);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Aceptar";
			this.btnOk.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Button2.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button2.Location = new System.Drawing.Point(292, 178);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(103, 37);
			this.Button2.TabIndex = 2;
			this.Button2.Text = "Cancelar";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//nudNumeroAceria
			//
			this.nudNumeroAceria.Font = new System.Drawing.Font("Arial", (float) (72.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.nudNumeroAceria.Location = new System.Drawing.Point(233, 52);
			this.nudNumeroAceria.Maximum = new decimal(new int[] {2, 0, 0, 0});
			this.nudNumeroAceria.Minimum = new decimal(new int[] {1, 0, 0, 0});
			this.nudNumeroAceria.Name = "nudNumeroAceria";
			this.nudNumeroAceria.Size = new System.Drawing.Size(106, 118);
			this.nudNumeroAceria.TabIndex = 3;
			this.nudNumeroAceria.Value = new decimal(new int[] {1, 0, 0, 0});
			//
			//frmServiceIndex
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 227);
			this.ControlBox = false;
			this.Controls.Add(this.nudNumeroAceria);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmServiceIndex";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Indice de Servicio CND";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize) this.nudNumeroAceria).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnOk;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.NumericUpDown nudNumeroAceria;
	}
	
}
