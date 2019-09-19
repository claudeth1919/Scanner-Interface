using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommunicationsLibrary.Utilities;


namespace CommunicationsLibrary.VisualControlsUtilities.NetworkStatistics
{
    public partial class CF_NetworkStatistics : UserControl
    {
        public CF_NetworkStatistics()
        {
            InitializeComponent();
        }

        private void btnUpdateStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgrdNetworkStatisticsIPv4.DataSource = CommunicationsUtilities.GetNetworkingStatiticsTable(System.Net.NetworkInformation.NetworkInterfaceComponent.IPv4);
                
                this.dgrdNetworkStatisticsIPv4.Columns[0].Width =  (this.dgrdNetworkStatisticsIPv4.Width / this.dgrdNetworkStatisticsIPv4.ColumnCount ) - 5;
                this.dgrdNetworkStatisticsIPv4.Columns[1].Width =  (this.dgrdNetworkStatisticsIPv4.Width / this.dgrdNetworkStatisticsIPv4.ColumnCount ) - 5;
                this.dgrdNetworkStatisticsIPv4.Columns[2].Width =  (this.dgrdNetworkStatisticsIPv4.Width / this.dgrdNetworkStatisticsIPv4.ColumnCount ) - 5;
            
            }
            catch (Exception)
            {
            }
            try
            {
                this.dgrdNetworkStatisticsIPv6.DataSource = CommunicationsUtilities.GetNetworkingStatiticsTable(System.Net.NetworkInformation.NetworkInterfaceComponent.IPv6);
                this.dgrdNetworkStatisticsIPv6.Columns[0].Width = (this.dgrdNetworkStatisticsIPv6.Width / this.dgrdNetworkStatisticsIPv6.ColumnCount) - 5;
                this.dgrdNetworkStatisticsIPv6.Columns[1].Width = (this.dgrdNetworkStatisticsIPv6.Width / this.dgrdNetworkStatisticsIPv6.ColumnCount) - 5;
                this.dgrdNetworkStatisticsIPv6.Columns[2].Width = (this.dgrdNetworkStatisticsIPv6.Width / this.dgrdNetworkStatisticsIPv6.ColumnCount) - 5;
            }
            catch (Exception)
            {
            }
        }
    }
}
