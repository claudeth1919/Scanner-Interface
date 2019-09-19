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



namespace DPEServerApp
{
	namespace GeneralPurposeForms
	{
		
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
		partial class passwordConfirmationForm : System.Windows.Forms.Form
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(passwordConfirmationForm));
				this.btnCancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
				this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
				base.Load += new System.EventHandler(passwordConfirmationForm_Load);
				this.btnOk = new Klik.Windows.Forms.v1.EntryLib.ELButton();
				this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
				this.txtPassword = new System.Windows.Forms.TextBox();
				this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
				((System.ComponentModel.ISupportInitialize) this.btnCancel).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.btnOk).BeginInit();
				this.SuspendLayout();
				//
				//btnCancel
				//
				this.btnCancel.BackgroundImageStyle.Alpha = 100;
				this.btnCancel.BackgroundImageStyle.Image = (System.Drawing.Image) (resources.GetObject("resource.Image"));
				this.btnCancel.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
				this.btnCancel.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
				this.btnCancel.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(253)), System.Convert.ToInt32(System.Convert.ToByte(240)), System.Convert.ToInt32(System.Convert.ToByte(191)));
				this.btnCancel.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
				this.btnCancel.Location = new System.Drawing.Point(295, 141);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
				this.btnCancel.Size = new System.Drawing.Size(229, 57);
				this.btnCancel.TabIndex = 140;
				this.btnCancel.TextStyle.BackColor = System.Drawing.Color.Black;
				this.btnCancel.TextStyle.Font = new System.Drawing.Font("Segoe UI", (float) (27.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.btnCancel.TextStyle.ForeColor = System.Drawing.Color.Black;
				this.btnCancel.TextStyle.Text = "Cancelar";
				this.btnCancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
				this.btnCancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Office2003;
				//
				//btnOk
				//
				this.btnOk.BackgroundImageStyle.Alpha = 100;
				this.btnOk.BackgroundImageStyle.Image = (System.Drawing.Image) (resources.GetObject("resource.Image1"));
				this.btnOk.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
				this.btnOk.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
				this.btnOk.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(253)), System.Convert.ToInt32(System.Convert.ToByte(240)), System.Convert.ToInt32(System.Convert.ToByte(191)));
				this.btnOk.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
				this.btnOk.Location = new System.Drawing.Point(42, 141);
				this.btnOk.Name = "btnOk";
				this.btnOk.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
				this.btnOk.Size = new System.Drawing.Size(229, 57);
				this.btnOk.TabIndex = 139;
				this.btnOk.TextStyle.BackColor = System.Drawing.Color.Black;
				this.btnOk.TextStyle.Font = new System.Drawing.Font("Segoe UI", (float) (27.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.btnOk.TextStyle.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(64)), System.Convert.ToInt32(System.Convert.ToByte(64)), System.Convert.ToInt32(System.Convert.ToByte(64)));
				this.btnOk.TextStyle.Text = "Aceptar";
				this.btnOk.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
				this.btnOk.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Office2003;
				//
				//txtPassword
				//
				this.txtPassword.Font = new System.Drawing.Font("Arial", (float) (36.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.txtPassword.Location = new System.Drawing.Point(42, 29);
				this.txtPassword.Name = "txtPassword";
				this.txtPassword.PasswordChar = global::Microsoft.VisualBasic.Strings.ChrW(42);
				this.txtPassword.Size = new System.Drawing.Size(482, 63);
				this.txtPassword.TabIndex = 0;
				//
				//passwordConfirmationForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(565, 233);
				this.ControlBox = false;
				this.Controls.Add(this.txtPassword);
				this.Controls.Add(this.btnCancel);
				this.Controls.Add(this.btnOk);
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
				this.Name = "passwordConfirmationForm";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "confirmar contraseña";
				((System.ComponentModel.ISupportInitialize) this.btnCancel).EndInit();
				((System.ComponentModel.ISupportInitialize) this.btnOk).EndInit();
				this.ResumeLayout(false);
				this.PerformLayout();
				
			}
			internal Klik.Windows.Forms.v1.EntryLib.ELButton btnCancel;
			internal Klik.Windows.Forms.v1.EntryLib.ELButton btnOk;
			internal System.Windows.Forms.TextBox txtPassword;
		}
		
	}
	
	
}
