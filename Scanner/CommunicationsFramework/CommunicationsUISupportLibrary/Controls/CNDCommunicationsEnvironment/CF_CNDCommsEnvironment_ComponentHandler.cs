using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.CNDCommunicationsEnvironment;
using CommunicationsLibrary.CNDCommunicationsEnvironment.Interfaces;
using CommunicationsLibrary.CNDCommunicationsEnvironment.Data; 
using System.Windows.Forms;




namespace CommunicationsUISupportLibrary
{
	public partial class CF_CNDCommsEnvironment_ComponentHandler : IUseCNDCommunicationsScheme 
	{
		
#region  < DATAMEMBERS >
		
		private string _ComponentName;
		private CFDataDisplayCtrl _dataReceptionDataDisplayCtrl;
		private CFDataDisplayCtrl _dataRequestedDataDisplayCtrl;
		private CFDataManagerContainer _dataToRetrieveBackFromRequestContainer;
		private CFDataManagerContainer _dataToSendContainer;
		
		
		
#endregion
		
#region  < CONSTRUCTORS>
		
		public CF_CNDCommsEnvironment_ComponentHandler(string ComponentName)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Add any initialization after the InitializeComponent() call.
			this._ComponentName = ComponentName;
			this._dataReceptionDataDisplayCtrl = new CFDataDisplayCtrl();
			this._dataRequestedDataDisplayCtrl = new CFDataDisplayCtrl();
			this._dataToRetrieveBackFromRequestContainer = new CFDataManagerContainer();
			this._dataToSendContainer = new CFDataManagerContainer();
			this.SubscribeToCommunicationsService();
		}
		
		public CF_CNDCommsEnvironment_ComponentHandler()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Add any initialization after the InitializeComponent() call.
			this._ComponentName = Guid.NewGuid().ToString().ToUpper();
			this._dataReceptionDataDisplayCtrl = new CFDataDisplayCtrl();
			this._dataRequestedDataDisplayCtrl = new CFDataDisplayCtrl();
			this._dataToRetrieveBackFromRequestContainer = new CFDataManagerContainer();
			this._dataToSendContainer = new CFDataManagerContainer();
			this.SubscribeToCommunicationsService();
		}
		
		
#endregion
		
#region  < SAFE UI CONTROL ACCESS >



        private delegate void SetListBoxItemCallBack_Delegate(System.Windows.Forms.ListBox ListBox, object item);		
        private void SetListBox_Item(System.Windows.Forms.ListBox ListBox, object item)
		{
			if (ListBox.InvokeRequired)
			{
                SetListBoxItemCallBack_Delegate d = new  SetListBoxItemCallBack_Delegate(SetListBox_Item); 
     		    this.Invoke(d, new object[] {ListBox, item});
			}
			else
			{
				ListBox.Items.Add(item);
			}
		}
             
		
		
		
#endregion
		
#region  < INTERFACE IMPLEMENTATION >
		
#region  < IUseCNDCommunicationsScheme>
		
        public string ComponentName
		{
			get
			{
				return this._ComponentName;
			}
		}

        public void ReceiveData(CommunicationsData data)
		{
			if (this.chkLogDataReception.Checked)
			{
				this.SetListBox_Item(this.lstBoxDataReception, data);
			}
		}
					
		public void SendData(CommunicationsData data)
		{
			CommunicationsManager.GetInstance().SendData(data);
		}
		
		public void SubscribeToCommunicationsService()
		{
			CommunicationsManager.GetInstance().SubscribeToCommunicationsService(this);
		}
		
		public void UnsubscribeFromCommunicationsService()
		{
			CommunicationsManager.GetInstance().UnsubscribeFromCommunicationsService(this);
		}
				
        public CommunicationsData RequestDataFromRemoteComponent(CommunicationsDataRequest dataRequest)
        {
            return CommunicationsManager.GetInstance().RequestDataFromRemoteComponent(dataRequest);
        }

        public CommunicationsData RetrieveDataToRemoteComponent(CommunicationsDataRequest dataRequest)
        {
            if (this._dataToRetrieveBackFromRequestContainer.ContainsData(System.Convert.ToString(dataRequest.RequestedDataName)))
            {
                Data data = this._dataToRetrieveBackFromRequestContainer.DataItem(System.Convert.ToString(dataRequest.RequestedDataName));
                CommunicationsData dataToRetrieve = default(CommunicationsData);
                dataToRetrieve = CommunicationsData.GetCommunicationsDataObject(dataRequest.SenderComponentName, this.ComponentName, data.DataName, data.data);
                return dataToRetrieve;
            }
            else
            {
                throw (new Exception("The component \'" + this.ComponentName + "\' can retrieve the data \'" + dataRequest.RequestedDataName + "\' becuase it doesn\'t handle it"));
            }
        }
		
#endregion
		
#endregion
		
#region  < PUBLIC METHODS >
		
		public void DisposeHandler()
		{
			this.UnsubscribeFromCommunicationsService();
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void CFSTXCommsEnvironment_ComponentSimulationHandler_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				
				this.txtComponentName.Text = this._ComponentName;
				this.pnlDataReception.Controls.Add(this._dataReceptionDataDisplayCtrl);
				this.pnlDataRequest.Controls.Add(this._dataToRetrieveBackFromRequestContainer);
				this.pnlDataRequestedResult.Controls.Add(this._dataRequestedDataDisplayCtrl);
				this.pnlDatacontainerForDataSend.Controls.Add(this._dataToSendContainer);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnClearDataReception_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._dataReceptionDataDisplayCtrl.ClearData();
				this.lstBoxDataReception.Items.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnUpdateStatistics_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.dgrdGeneralStatistics.DataSource = CommunicationsManager.GetInstance().ComponentGeneralStatisticsTable(this.ComponentName);
				this.dgrdReceptionStatistics.DataSource = CommunicationsManager.GetInstance().ComponentDataReceptionStatisticsTable(this.ComponentName);
				this.dgrdRequestStatistics.DataSource = CommunicationsManager.GetInstance().ComponentDataRequestsStatisticsTable(this.ComponentName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void lstBoxDataReception_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstBoxDataReception.Items.Count > 0)
				{
					if (this.lstBoxDataReception.SelectedIndex >= 0)
					{
						CommunicationsData data = default(CommunicationsData);
						data = (CommunicationsData) this.lstBoxDataReception.SelectedItem;
						this._dataReceptionDataDisplayCtrl.ShowData(data.Value);
					}
					else
					{
						this._dataReceptionDataDisplayCtrl.ClearData();
					}
				}
				else
				{
					this._dataReceptionDataDisplayCtrl.ClearData();
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void btnRequestFromRemotecomponent_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtDataNameToRequest.Text.Length <= 0)
				{
					throw (new Exception("No data name specified to request"));
				}
				
				if (this.txtRemoteComponentToRequestData.Text.Length <= 0)
				{
					throw (new Exception("No selected component to request data"));
				}
				
				CommunicationsDataRequest datarequest = new CommunicationsDataRequest(this.txtRemoteComponentToRequestData.Text, this.ComponentName, this.txtDataNameToRequest.Text);
				CommunicationsData data = default(CommunicationsData);
                data = ((IUseCNDCommunicationsScheme)this).RequestDataFromRemoteComponent(datarequest);
				this._dataRequestedDataDisplayCtrl.ShowData(data.Value);
			}
			catch (Exception ex)
			{
				string err = ex.Message + " -> " + ex.StackTrace + " -> " + ex.TargetSite.ToString();
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		}
		
		public void btnChoseComponentForDataRequest_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frmCF_CND_CommsEnvironment_AvailableComponents frm = new frmCF_CND_CommsEnvironment_AvailableComponents();
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this.txtRemoteComponentToRequestData.Text = frm.SelectedComponentName;
				}
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnSendDataToComponent_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtRemoteComponentNameToSendData.Text.Length <= 0)
				{
					throw (new Exception("No selected component to send data"));
				}
				
				if (this._dataToSendContainer.DataCount <= 0)
				{
					throw (new Exception("No data available to send"));
				}
				
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				Data data = this._dataToSendContainer.SelectedData;
				if (!(data == null))
				{
					CommunicationsData comData = default(CommunicationsData);
					comData = CommunicationsData.GetCommunicationsDataObject(this.txtRemoteComponentNameToSendData.Text, this.ComponentName, data.DataName, data.data);
                    ((IUseCNDCommunicationsScheme)this).SendData(comData);
				}
				else
				{
					throw (new Exception("No data selected from list to send"));
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		}
		
		public void btnChoseComponentToDataSend_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frmCF_CND_CommsEnvironment_AvailableComponents frm = new frmCF_CND_CommsEnvironment_AvailableComponents();
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this.txtRemoteComponentNameToSendData.Text = frm.SelectedComponentName;
				}
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
#endregion






    
    }
	
}
