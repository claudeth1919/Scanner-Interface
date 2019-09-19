using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;



namespace CommunicationsUISupportLibrary
{
	public partial class frm_DPE_IntervallValue
	{
		public frm_DPE_IntervallValue()
		{
			InitializeComponent();
		}
		
public int Interval
		{
			get
			{
				return (int) this.nudREadInterval.Value;
			}
		}
		
		
	}
}
