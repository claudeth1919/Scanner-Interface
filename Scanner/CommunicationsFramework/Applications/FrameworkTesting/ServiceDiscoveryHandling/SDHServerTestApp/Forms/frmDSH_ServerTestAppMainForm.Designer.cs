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
using C1.Win.C1Sizer;


namespace STXServiceHandlerServerTestApplication
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmDSH_ServerTestAppMainForm : System.Windows.Forms.Form
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
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.grpServiceDefinition = new System.Windows.Forms.GroupBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.lstServiceParameters = new System.Windows.Forms.ListBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnNormalMode = new System.Windows.Forms.RadioButton();
            this.rbtnSingletonMode = new System.Windows.Forms.RadioButton();
            this.txtSErviceName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.chkEmulate = new System.Windows.Forms.CheckBox();
            this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.txtCountQueriesCount = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Button3 = new System.Windows.Forms.Button();
            this.lstReceivedQueries = new System.Windows.Forms.ListBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.txtSuccesfullQueriesCount = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.lstSuccesfullQueries = new System.Windows.Forms.ListBox();
            this.grpServiceDefinition.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpServiceDefinition
            // 
            this.grpServiceDefinition.Controls.Add(this.GroupBox3);
            this.grpServiceDefinition.Controls.Add(this.GroupBox2);
            this.grpServiceDefinition.Controls.Add(this.txtSErviceName);
            this.grpServiceDefinition.Controls.Add(this.Label2);
            this.grpServiceDefinition.Location = new System.Drawing.Point(3, 12);
            this.grpServiceDefinition.Name = "grpServiceDefinition";
            this.grpServiceDefinition.Size = new System.Drawing.Size(823, 322);
            this.grpServiceDefinition.TabIndex = 2;
            this.grpServiceDefinition.TabStop = false;
            this.grpServiceDefinition.Text = "Service Definition";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Button2);
            this.GroupBox3.Controls.Add(this.btnAddParameter);
            this.GroupBox3.Controls.Add(this.lstServiceParameters);
            this.GroupBox3.Location = new System.Drawing.Point(12, 48);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(811, 206);
            this.GroupBox3.TabIndex = 4;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Service Parameters";
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(204, 158);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(176, 37);
            this.Button2.TabIndex = 5;
            this.Button2.Text = "Remove Parameter";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddParameter.Location = new System.Drawing.Point(7, 158);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(176, 37);
            this.btnAddParameter.TabIndex = 4;
            this.btnAddParameter.Text = "Add Parameter";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // lstServiceParameters
            // 
            this.lstServiceParameters.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstServiceParameters.FormattingEnabled = true;
            this.lstServiceParameters.ItemHeight = 19;
            this.lstServiceParameters.Location = new System.Drawing.Point(6, 19);
            this.lstServiceParameters.Name = "lstServiceParameters";
            this.lstServiceParameters.Size = new System.Drawing.Size(795, 118);
            this.lstServiceParameters.TabIndex = 0;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.rbtnNormalMode);
            this.GroupBox2.Controls.Add(this.rbtnSingletonMode);
            this.GroupBox2.Location = new System.Drawing.Point(12, 257);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(204, 45);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Service Operation Mode";
            // 
            // rbtnNormalMode
            // 
            this.rbtnNormalMode.AutoSize = true;
            this.rbtnNormalMode.Location = new System.Drawing.Point(125, 19);
            this.rbtnNormalMode.Name = "rbtnNormalMode";
            this.rbtnNormalMode.Size = new System.Drawing.Size(58, 17);
            this.rbtnNormalMode.TabIndex = 1;
            this.rbtnNormalMode.Text = "Normal";
            this.rbtnNormalMode.UseVisualStyleBackColor = true;
            // 
            // rbtnSingletonMode
            // 
            this.rbtnSingletonMode.AutoSize = true;
            this.rbtnSingletonMode.Checked = true;
            this.rbtnSingletonMode.Location = new System.Drawing.Point(28, 19);
            this.rbtnSingletonMode.Name = "rbtnSingletonMode";
            this.rbtnSingletonMode.Size = new System.Drawing.Size(69, 17);
            this.rbtnSingletonMode.TabIndex = 0;
            this.rbtnSingletonMode.TabStop = true;
            this.rbtnSingletonMode.Text = "Singleton";
            this.rbtnSingletonMode.UseVisualStyleBackColor = true;
            // 
            // txtSErviceName
            // 
            this.txtSErviceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSErviceName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSErviceName.Location = new System.Drawing.Point(154, 18);
            this.txtSErviceName.Name = "txtSErviceName";
            this.txtSErviceName.Size = new System.Drawing.Size(482, 26);
            this.txtSErviceName.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(9, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(142, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Discoverable Service Name ";
            // 
            // chkEmulate
            // 
            this.chkEmulate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkEmulate.AutoSize = true;
            this.chkEmulate.BackColor = System.Drawing.Color.Lime;
            this.chkEmulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmulate.Location = new System.Drawing.Point(474, 276);
            this.chkEmulate.Name = "chkEmulate";
            this.chkEmulate.Size = new System.Drawing.Size(339, 30);
            this.chkEmulate.TabIndex = 3;
            this.chkEmulate.Text = "Emulate Discoverable Service Definition";
            this.chkEmulate.UseVisualStyleBackColor = false;
            this.chkEmulate.CheckedChanged += new System.EventHandler(this.chkEmulate_CheckedChanged);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.TabControl1);
            this.GroupBox4.Controls.Add(this.chkEmulate);
            this.GroupBox4.Location = new System.Drawing.Point(3, 340);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(823, 317);
            this.GroupBox4.TabIndex = 4;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Service Emulation";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(6, 19);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(807, 245);
            this.TabControl1.TabIndex = 4;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.txtCountQueriesCount);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.Button3);
            this.TabPage1.Controls.Add(this.lstReceivedQueries);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(799, 219);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Queries Received From Clients";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCountQueriesCount
            // 
            this.txtCountQueriesCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountQueriesCount.Location = new System.Drawing.Point(65, 186);
            this.txtCountQueriesCount.Name = "txtCountQueriesCount";
            this.txtCountQueriesCount.ReadOnly = true;
            this.txtCountQueriesCount.Size = new System.Drawing.Size(80, 20);
            this.txtCountQueriesCount.TabIndex = 8;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(24, 189);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(35, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Count";
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Location = new System.Drawing.Point(711, 176);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(82, 37);
            this.Button3.TabIndex = 6;
            this.Button3.Text = "Clear";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // lstReceivedQueries
            // 
            this.lstReceivedQueries.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstReceivedQueries.FormattingEnabled = true;
            this.lstReceivedQueries.ItemHeight = 17;
            this.lstReceivedQueries.Location = new System.Drawing.Point(2, 3);
            this.lstReceivedQueries.Name = "lstReceivedQueries";
            this.lstReceivedQueries.Size = new System.Drawing.Size(791, 157);
            this.lstReceivedQueries.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txtSuccesfullQueriesCount);
            this.TabPage2.Controls.Add(this.Label4);
            this.TabPage2.Controls.Add(this.Button1);
            this.TabPage2.Controls.Add(this.lstSuccesfullQueries);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(799, 219);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Resulted Successful Queries";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // txtSuccesfullQueriesCount
            // 
            this.txtSuccesfullQueriesCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSuccesfullQueriesCount.Location = new System.Drawing.Point(55, 191);
            this.txtSuccesfullQueriesCount.Name = "txtSuccesfullQueriesCount";
            this.txtSuccesfullQueriesCount.ReadOnly = true;
            this.txtSuccesfullQueriesCount.Size = new System.Drawing.Size(80, 20);
            this.txtSuccesfullQueriesCount.TabIndex = 10;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 194);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 13);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Count";
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(598, 177);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(82, 37);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "Clear";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lstSuccesfullQueries
            // 
            this.lstSuccesfullQueries.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSuccesfullQueries.FormattingEnabled = true;
            this.lstSuccesfullQueries.ItemHeight = 17;
            this.lstSuccesfullQueries.Location = new System.Drawing.Point(0, 2);
            this.lstSuccesfullQueries.Name = "lstSuccesfullQueries";
            this.lstSuccesfullQueries.Size = new System.Drawing.Size(686, 157);
            this.lstSuccesfullQueries.TabIndex = 1;
            // 
            // frmDSH_ServerTestAppMainForm
            // 
            this.C1SizerLight1.SetAutoResize(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 658);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.grpServiceDefinition);
            this.Name = "frmDSH_ServerTestAppMainForm";
            this.Text = "Discoverable Service Handling Server Test Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSTXServiceTestApplication_FormClosing);
            this.Load += new System.EventHandler(this.frmSTXServiceTestApplication_Load);
            this.grpServiceDefinition.ResumeLayout(false);
            this.grpServiceDefinition.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

        }
		internal System.Windows.Forms.GroupBox grpServiceDefinition;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.RadioButton rbtnNormalMode;
		internal System.Windows.Forms.RadioButton rbtnSingletonMode;
		internal System.Windows.Forms.TextBox txtSErviceName;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Button btnAddParameter;
		internal System.Windows.Forms.ListBox lstServiceParameters;
		internal System.Windows.Forms.CheckBox chkEmulate;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.ListBox lstReceivedQueries;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.ListBox lstSuccesfullQueries;
		internal System.Windows.Forms.TextBox txtCountQueriesCount;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.TextBox txtSuccesfullQueriesCount;
		internal System.Windows.Forms.Label Label4;
        private System.ComponentModel.IContainer components;
		
	}
	
}
