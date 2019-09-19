// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports


namespace CommunicationsUISupportLibrary
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class CF_SocketsSErver_DataManagerContainer : System.Windows.Forms.UserControl
	{
		
		//UserControl overrides dispose to clean up the component list.
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
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnAddDataToContainer = new System.Windows.Forms.Button();
			this.btnAddDataToContainer.Click += new System.EventHandler(this.btnAddDataToBroadCast_Click);
			this.lstAvailableData = new System.Windows.Forms.ListBox();
			this.lstAvailableData.SelectedIndexChanged += new System.EventHandler(this.lstAvailableData_SelectedIndexChanged);
			this.txtIntDecStringBol = new System.Windows.Forms.TextBox();
			this.dgrDataTable = new System.Windows.Forms.DataGridView();
			this.lstCollectionsDataType = new System.Windows.Forms.ListBox();
			this.pnlPanelToSize = new System.Windows.Forms.Panel();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Label1 = new System.Windows.Forms.Label();
			this.lstDataAttributes = new System.Windows.Forms.ListBox();
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			((System.ComponentModel.ISupportInitialize) this.dgrDataTable).BeginInit();
			this.SuspendLayout();
			//
			//btnRemove
			//
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnRemove.Location = new System.Drawing.Point(257, 50);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(92, 45);
			this.btnRemove.TabIndex = 20;
			this.btnRemove.Text = "Remove Data";
			this.btnRemove.UseVisualStyleBackColor = true;
			//
			//btnAddDataToContainer
			//
			this.btnAddDataToContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnAddDataToContainer.Location = new System.Drawing.Point(257, 3);
			this.btnAddDataToContainer.Name = "btnAddDataToContainer";
			this.btnAddDataToContainer.Size = new System.Drawing.Size(92, 45);
			this.btnAddDataToContainer.TabIndex = 19;
			this.btnAddDataToContainer.Text = "Add Data";
			this.btnAddDataToContainer.UseVisualStyleBackColor = true;
			//
			//lstAvailableData
			//
			this.lstAvailableData.FormattingEnabled = true;
			this.lstAvailableData.HorizontalScrollbar = true;
			this.lstAvailableData.Location = new System.Drawing.Point(3, 3);
			this.lstAvailableData.Name = "lstAvailableData";
			this.lstAvailableData.ScrollAlwaysVisible = true;
			this.lstAvailableData.Size = new System.Drawing.Size(252, 199);
			this.lstAvailableData.TabIndex = 17;
			//
			//txtIntDecStringBol
			//
			this.txtIntDecStringBol.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtIntDecStringBol.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (14.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtIntDecStringBol.Location = new System.Drawing.Point(352, 2);
			this.txtIntDecStringBol.Multiline = true;
			this.txtIntDecStringBol.Name = "txtIntDecStringBol";
			this.txtIntDecStringBol.ReadOnly = true;
			this.txtIntDecStringBol.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtIntDecStringBol.Size = new System.Drawing.Size(410, 199);
			this.txtIntDecStringBol.TabIndex = 0;
			this.txtIntDecStringBol.Visible = false;
			//
			//dgrDataTable
			//
			this.dgrDataTable.AllowUserToAddRows = false;
			this.dgrDataTable.AllowUserToDeleteRows = false;
			this.dgrDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrDataTable.Location = new System.Drawing.Point(355, 3);
			this.dgrDataTable.Name = "dgrDataTable";
			this.dgrDataTable.ReadOnly = true;
			this.dgrDataTable.Size = new System.Drawing.Size(407, 199);
			this.dgrDataTable.TabIndex = 0;
			this.dgrDataTable.Visible = false;
			//
			//lstCollectionsDataType
			//
			this.lstCollectionsDataType.FormattingEnabled = true;
			this.lstCollectionsDataType.HorizontalScrollbar = true;
			this.lstCollectionsDataType.Location = new System.Drawing.Point(352, 2);
			this.lstCollectionsDataType.Name = "lstCollectionsDataType";
			this.lstCollectionsDataType.ScrollAlwaysVisible = true;
			this.lstCollectionsDataType.Size = new System.Drawing.Size(410, 199);
			this.lstCollectionsDataType.TabIndex = 0;
			this.lstCollectionsDataType.Visible = false;
			//
			//pnlPanelToSize
			//
			this.pnlPanelToSize.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pnlPanelToSize.Location = new System.Drawing.Point(352, 3);
			this.pnlPanelToSize.Name = "pnlPanelToSize";
			this.pnlPanelToSize.Size = new System.Drawing.Size(410, 199);
			this.pnlPanelToSize.TabIndex = 21;
			//
			//Button1
			//
			this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button1.Location = new System.Drawing.Point(257, 96);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(92, 45);
			this.Button1.TabIndex = 22;
			this.Button1.Text = "Add Data Attributes";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(768, 2);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(132, 20);
			this.Label1.TabIndex = 23;
			this.Label1.Text = "Data Attributes";
			//
			//lstDataAttributes
			//
			this.lstDataAttributes.FormattingEnabled = true;
			this.lstDataAttributes.Location = new System.Drawing.Point(768, 29);
			this.lstDataAttributes.Name = "lstDataAttributes";
			this.lstDataAttributes.Size = new System.Drawing.Size(300, 147);
			this.lstDataAttributes.TabIndex = 24;
			//
			//Button2
			//
			this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button2.Location = new System.Drawing.Point(768, 177);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(165, 23);
			this.Button2.TabIndex = 23;
			this.Button2.Text = "Remove Attribute";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//CF_SocketsSErver_DataManagerContainer
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (96.0F), (float) (96.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.lstDataAttributes);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.pnlPanelToSize);
			this.Controls.Add(this.dgrDataTable);
			this.Controls.Add(this.txtIntDecStringBol);
			this.Controls.Add(this.lstCollectionsDataType);
			this.Controls.Add(this.lstAvailableData);
			this.Controls.Add(this.btnAddDataToContainer);
			this.Controls.Add(this.btnRemove);
			this.Name = "CF_SocketsSErver_DataManagerContainer";
			this.Size = new System.Drawing.Size(1071, 205);
			((System.ComponentModel.ISupportInitialize) this.dgrDataTable).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Button btnRemove;
		internal System.Windows.Forms.Button btnAddDataToContainer;
		internal System.Windows.Forms.ListBox lstAvailableData;
		private System.Windows.Forms.TextBox txtIntDecStringBol;
		private System.Windows.Forms.DataGridView dgrDataTable;
		private System.Windows.Forms.ListBox lstCollectionsDataType;
		internal System.Windows.Forms.Panel pnlPanelToSize;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ListBox lstDataAttributes;
		internal System.Windows.Forms.Button Button2;
		
	}
	
}
