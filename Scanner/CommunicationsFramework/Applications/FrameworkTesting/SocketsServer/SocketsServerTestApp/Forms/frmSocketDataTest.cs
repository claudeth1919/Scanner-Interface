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
using UtilitiesLibrary.Data;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;




namespace SocketsServerTestApp
{
	public partial class frmSocketDataTest
	{
		public frmSocketDataTest()
		{
			InitializeComponent();
		}
		
		public void Form1_Load(System.Object sender, System.EventArgs e)
		{
			
			
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			SocketData dataInteger = new SocketData("INTEGER_DATA", 13456);
			SocketData data = SocketData.ParseAndGet_SocketData_FromXMLDataString(dataInteger.XMLDataString);
			this.txtDataSocketXMLString.Text = "";
			this.txtDataSocketXMLString.Text = data.XMLDataString;
			
			
			
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			SocketData dataDEcimal = new SocketData("DECIMAL_DATA", System.Convert.ToDecimal(3.141516));
			SocketData data = SocketData.ParseAndGet_SocketData_FromXMLDataString(dataDEcimal.XMLDataString);
			this.txtDataSocketXMLString.Text = "";
			this.txtDataSocketXMLString.Text = data.XMLDataString;
			
			
		}
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			SocketData dataString = new SocketData("STRING_DATA", "This is a string test");
			SocketData data = SocketData.ParseAndGet_SocketData_FromXMLDataString(dataString.XMLDataString);
			this.txtDataSocketXMLString.Text = "";
			this.txtDataSocketXMLString.Text = data.XMLDataString;
			
			
		}
		
		public void Button4_Click(System.Object sender, System.EventArgs e)
		{
			SocketData dataBoolean = new SocketData("BOOLEAN_DATA", true);
			SocketData data = SocketData.ParseAndGet_SocketData_FromXMLDataString(dataBoolean.XMLDataString);
			this.txtDataSocketXMLString.Text = "";
			this.txtDataSocketXMLString.Text = data.XMLDataString;
			
			
		}
		
		public void Button5_Click(System.Object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection("Data Source=MARCOPOLO_;Initial Catalog=northwind;User ID=sa;Password=sqlpassword");
			System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand("select * from Shippers", cn);
			System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
			DataTable dt = new DataTable();
			da.Fill(dt);
			SocketData dataTable = new SocketData("DATATABLE_DATA", dt);
			SocketData data = SocketData.ParseAndGet_SocketData_FromXMLDataString(dataTable.XMLDataString);
			this.txtDataSocketXMLString.Text = "";
			this.txtDataSocketXMLString.Text = data.XMLDataString;
			
			
		}
		
		public void Button6_Click(System.Object sender, System.EventArgs e)
		{
			CustomSortedList sortedlist = new CustomSortedList();
			sortedlist.Add(1, 1);
			sortedlist.Add(2, 2);
			sortedlist.Add(3, 3);
			sortedlist.Add(4, 4);
			sortedlist.Add(5, 5);
			sortedlist.Add(6, 6);
			sortedlist.Add(7, 7);
			SocketData dataSortedList = new SocketData("SORTEDLIST_DATA", sortedlist);
			SocketData data = SocketData.ParseAndGet_SocketData_FromXMLDataString(dataSortedList.XMLDataString);
			this.txtDataSocketXMLString.Text = "";
			this.txtDataSocketXMLString.Text = data.XMLDataString;
		}
		
		public void Button7_Click(System.Object sender, System.EventArgs e)
		{
			CustomHashTable hashtable = new CustomHashTable();
			hashtable.Add(1, "hugo");
			hashtable.Add(2, "jose");
			hashtable.Add(3, 3);
			hashtable.Add(4, 32);
			SocketData dataSortedList = new SocketData("HASHTABLE_DATA", hashtable);
			SocketData data = SocketData.ParseAndGet_SocketData_FromXMLDataString(dataSortedList.XMLDataString);
			this.txtDataSocketXMLString.Text = "";
			this.txtDataSocketXMLString.Text = data.XMLDataString;
			
		}
	}
}
