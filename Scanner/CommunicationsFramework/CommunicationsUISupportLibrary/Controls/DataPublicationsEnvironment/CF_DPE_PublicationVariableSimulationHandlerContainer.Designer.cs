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
	partial class CF_DPE_PublicationVariableSimulationHandlerContainer : System.Windows.Forms.UserControl
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
			this.tabVariablesSimulationHandler = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			//
			//tabVariablesSimulationHandler
			//
			this.tabVariablesSimulationHandler.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabVariablesSimulationHandler.Location = new System.Drawing.Point(0, 0);
			this.tabVariablesSimulationHandler.Name = "tabVariablesSimulationHandler";
			this.tabVariablesSimulationHandler.SelectedIndex = 0;
			this.tabVariablesSimulationHandler.Size = new System.Drawing.Size(462, 381);
			this.tabVariablesSimulationHandler.TabIndex = 0;
			//
			//CF_DPE_PublicationVariableSimulationHandlerContainer
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabVariablesSimulationHandler);
			this.Name = "CF_DPE_PublicationVariableSimulationHandlerContainer";
			this.Size = new System.Drawing.Size(462, 381);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.TabControl tabVariablesSimulationHandler;
		
	}
	
}
