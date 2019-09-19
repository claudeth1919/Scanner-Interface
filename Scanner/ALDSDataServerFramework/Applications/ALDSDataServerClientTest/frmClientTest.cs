using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ALDSDataServerLibrary.Client;
using ALDSDataServerLibrary.Data;
using ALDSDataServerLibrary.Services;
using UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess;

namespace ALDSDataServerClientTest
{
    public partial class frmClientTest : Form
    {
        private string _hostName;
        private int _linenumber;
        private string _ALDSDBConnectionString;

      //  private ALDSDataClient _aldsDataClient;
        private ALDSMachineOperationMonitor _ALDSMachineOperationMonitor;


        public frmClientTest(int linenumber , string HostName, string AldsDBName )
        {
            InitializeComponent();
            this._hostName = HostName;
            this._linenumber = linenumber;
            string SQLInstanceName = this._hostName + "\\SQLEXPRESS";
            this._ALDSDBConnectionString = "Server=" + SQLInstanceName + " ;Database=" + AldsDBName  + " ;User Id=AIS_ALDS;Password=23erghiop0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _ALDSMachineOperationMonitor = new ALDSMachineOperationMonitor(this._linenumber , this._hostName ,  this._ALDSDBConnectionString);
                _ALDSMachineOperationMonitor.ALDSClient.DataReceived += new DataReceivedFromALDSDataServer(_aldsDataClient_DataReceived);
                _ALDSMachineOperationMonitor.MachineStopped +=new MachineStopped(_ALDSMachineOperationMonitor_MachineStopped);
                _ALDSMachineOperationMonitor.MachineResumeOperation += new MachineResumeOperation(_ALDSMachineOperationMonitor_MachineResumeOperation);
                _ALDSMachineOperationMonitor.WebNotificationSuccesfully += new WebNotificationSuccesfully(_ALDSMachineOperationMonitor_WebNotificationSuccesfully);
                _ALDSMachineOperationMonitor.WebNotificationError += new WebNotificationError(_ALDSMachineOperationMonitor_WebNotificationError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region < EVENT HANDLING > 

            private void _aldsDataClient_DataReceived(ALDSDataClient sender, ALDSData dataReceived)
            {
                try
                {
                    UIControlsSafeAccessFunctions.ListBox_Items_Add( this.lstEventsReceived , dataReceived);            
                }
                catch (Exception ex)
                {

                }
            }

            private void _ALDSMachineOperationMonitor_MachineStopped(string machineName)
            {
                try
                {
                    UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lstMAchineEvents, "MACHINE STOPPED : " + machineName );
                }
                catch (Exception ex)
                {

                }
            }

            private void _ALDSMachineOperationMonitor_MachineResumeOperation(string machineName)
            {
                try
                {
                    UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lstMAchineEvents, "MACHINE RESUME OPERATION : " + machineName);
                }
                catch (Exception ex)
                {

                }
            }

            private void _ALDSMachineOperationMonitor_WebNotificationSuccesfully(string machineName)
            {
                try
                {
                    UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lstWebNotificationsOK, "[ " + machineName  + " ] Web notification = OK");                   
                }
                catch (Exception ex)
                {

                }
            }

            private void _ALDSMachineOperationMonitor_WebNotificationError(string machine, string error)
            {
                try
                {
                    UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lstWebNotificationErrors, "[ " + machine + " ] Web notification  error : " + error);
                }
                catch (Exception ex)
                {

                }
            }
                
        #endregion 

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lstEventsReceived.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.lstMAchineEvents.Items.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.lstWebNotificationsOK.Items.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.lstWebNotificationErrors.Items.Clear();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
