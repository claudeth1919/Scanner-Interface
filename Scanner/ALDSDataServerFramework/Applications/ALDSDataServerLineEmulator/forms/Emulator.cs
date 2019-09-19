using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ALDSDataServerLibrary.Server;
using ALDSDataServerLibrary.Data;


namespace ALDSDataServerLineEmulator
{
    public partial class Emulator : Form
    {
        private ALDSDataServer _server;
     

        public Emulator()
        {
            InitializeComponent();

            try
            {

                this._server = ALDSDataServer.GetInstance();
                this.cboStatus.Items.Add(ALDSDataServerLibrary.Data.MachineStatus.automatic);
                this.cboStatus.Items.Add(ALDSDataServerLibrary.Data.MachineStatus.manual);
                this.cboStatus.Items.Add(ALDSDataServerLibrary.Data.MachineStatus.failure);
                this.lblServerStatus.Text = "Server is RUNNING OK";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.lblServerStatus.Text = "Server is Not running";
            }

        }

        private void btnBroadCastData_Click(object sender, EventArgs e)
        {
            try
            {


                if (this.cboLine.SelectedIndex < 0)
                    throw new Exception("No line name selected from list");
                if (this.cboMachine.SelectedIndex < 0)
                    throw new Exception("No machine selected from list");
                if (this.cboStatus.SelectedIndex < 0)               
                    throw new Exception("No machine status selected from list");
                   
                              

                string lineName = this.cboLine.SelectedItem.ToString();
                string machineName = this.cboMachine.SelectedItem.ToString();
                MachineStatus status = (MachineStatus)this.cboStatus.SelectedItem;

               
                MachineStatusData data = new MachineStatusData(lineName, machineName, status);
                ALDSDataServer.GetInstance().DistributeData(data);
                this.lblSendStatus.Text = "Last Data sent OK";
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.lblSendStatus.Text = "No data sent";
            }
        }

      
    }
}
