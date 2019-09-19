// VBConversions Note: VB project level imports
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
// End of VB project level imports


namespace CNDServiceClient
{
	public partial class frmServiceIndex
	{
		public frmServiceIndex()
		{
			InitializeComponent();
		}
		
		
		
		
#region  < PROPERTIES  >
		
public int ServiceIndex
		{
			get
			{
				return (int) this.nudNumeroAceria.Value;
			}
		}
		
		
#endregion
		
		
public int SteelmakingNumber
		{
			get
			{
				return (int) this.nudNumeroAceria.Value;
			}
		}
		
		
		public void btnOk_Click(System.Object sender, System.EventArgs e)
		{
			
		}
	}
}
