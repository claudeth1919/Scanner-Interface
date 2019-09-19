using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALDSDataServerClientTest
{
    public partial class frmALDSHostName : Form
    {
        public frmALDSHostName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtALDSHostName.Text.Length > 0)
                {
                    if (this.cboLinenumber.SelectedIndex >=0)
                    {
                        if (this.txtALDSDBName.Text.Length > 0)
                        {                            
                            string lineNumberStr = (string) this.cboLinenumber.SelectedItem;
                            int lineNumber;
                            int.TryParse(lineNumberStr, out lineNumber);
                            frmClientTest test = new frmClientTest(lineNumber , txtALDSHostName.Text , this.txtALDSDBName.Text);
                            test.ShowDialog();
                            test.Dispose();
                            this.Dispose();
                        }
                        else 
                        {
                             throw new Exception("No ALDS DB Name specified");
                        }

                    }
                    else
                    {
                         throw new Exception("No line number selected");
                    }
                   
                }
                else
                {
                    throw new Exception("No ALDS Data Server host name specified");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
