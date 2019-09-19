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

using System.Data.SqlClient;
using System.Windows.Forms;


namespace CommunicationsUISupportLibrary
{
	public partial class frmDataTableDataCreationForm
	{
		public frmDataTableDataCreationForm()
		{
			InitializeComponent();
		}
		
		private DataTable _datatable = new DataTable();
		
		
public DataTable Data
		{
			get
			{
				return _datatable;
			}
		}
		
public string DataName
		{
			get
			{
				return this.txtDataName.Text;
			}
		}
		
		
		public void frmIntegerDataCreationForm_Load(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtSQLServerName.Text.Length <= 0)
				{
					throw (new Exception("No SQL Server Specified"));
				}
				
				if (this.txtUser.Text.Length <= 0)
				{
					throw (new Exception("No User Specified"));
				}
				
				if (this.txtPassword.Text.Length <= 0)
				{
					throw (new Exception("No password specified"));
				}
				
				if (this.txtDataBase.Text.Length <= 0)
				{
					throw (new Exception("No data base specified"));
				}
				
				if (this.txtQuery.Text.Length <= 0)
				{
					throw (new Exception("No query specified"));
				}
				
				string connectionStr = "";
				connectionStr = "Data Source=" + this.txtSQLServerName.Text + ";Initial Catalog=" + this.txtDataBase.Text + ";User ID=" + this.txtUser.Text + ";Password=" + this.txtPassword.Text + "";
				SqlConnection cn = new SqlConnection(connectionStr);
				SqlCommand cm = new SqlCommand(this.txtQuery.Text, cn);
				SqlDataAdapter da = new SqlDataAdapter(cm);
				da.Fill(this._datatable);
				this.dgrvDataTable.DataSource = this._datatable;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnOk_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtDataName.Text.Length <= 0)
				{
					MessageBox.Show("No dataname specified");
					this.DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
				
				if (this._datatable.Rows.Count <= 0)
				{
					MessageBox.Show("No data Specified");
					this.DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
	}
}
