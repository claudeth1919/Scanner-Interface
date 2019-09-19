using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace CommunicationsUISupportLibrary
{
	public partial class CF_CNDCommsEnvironment_ComponentsContainer
	{
		public CF_CNDCommsEnvironment_ComponentsContainer()
		{
			InitializeComponent();
		}
		
#region  < DATAMEMBERS >
		
		private Hashtable _handlersTable = new Hashtable();
		private Hashtable _handlersTabPagesTable = new Hashtable();
		
		
#endregion
		
#region  < UI METHODS >
		
		public void btnAddNewComponent_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				string ComponentName = "";
				ComponentName = Interaction.InputBox("Enter a name for the New Component", "Data Publications Communications Environment", "", -1, -1);
				if (ComponentName.Length > 0)
				{
					ComponentName = ComponentName.ToUpper();
					CF_CNDCommsEnvironment_ComponentHandler newcomponentHandler = new CF_CNDCommsEnvironment_ComponentHandler(ComponentName);
					System.Windows.Forms.TabPage tabPage = new System.Windows.Forms.TabPage(ComponentName);
					newcomponentHandler.Dock = System.Windows.Forms.DockStyle.Fill;
					tabPage.Controls.Add(newcomponentHandler);
					this.tabComponentHandlers.TabPages.Add(tabPage);
					this.lstComponents.Items.Add(ComponentName);
					this._handlersTable.Add(ComponentName, newcomponentHandler);
					this._handlersTabPagesTable.Add(ComponentName, tabPage);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnRemoveComponent_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstComponents.Items.Count <= 0)
				{
					throw (new Exception("No components to delete"));
				}
				
				if (this.lstComponents.SelectedIndex < 0)
				{
					throw (new Exception("No component selected from list"));
				}
				
				string componentNAme = System.Convert.ToString(this.lstComponents.SelectedItem);
                System.Windows.Forms.TabPage tabPage = (System.Windows.Forms.TabPage)this._handlersTabPagesTable[componentNAme];
                CF_CNDCommsEnvironment_ComponentHandler handler = (CF_CNDCommsEnvironment_ComponentHandler)this._handlersTable[componentNAme];
				handler.DisposeHandler();
				this.tabComponentHandlers.TabPages.Remove(tabPage);
				this.lstComponents.Items.Remove(componentNAme);
				this._handlersTable.Remove(componentNAme);
				this._handlersTabPagesTable.Remove(componentNAme);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void lstComponents_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.tabComponentHandlers.SelectedIndex = this.lstComponents.SelectedIndex;
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < PUBLIC METHODS >
		
		public void DisposeContainer()
		{
			try
			{
				IEnumerator enumm = this._handlersTable.GetEnumerator();
				CF_CNDCommsEnvironment_ComponentHandler handler = default(CF_CNDCommsEnvironment_ComponentHandler);
				
				while (enumm.MoveNext())
				{
					handler = (CF_CNDCommsEnvironment_ComponentHandler) (((DictionaryEntry) enumm.Current).Value);
					handler.DisposeHandler();
				}
			}
			catch (Exception)
			{
				
			}
			
		}
		
#endregion
		
		
		
	}
	
}
