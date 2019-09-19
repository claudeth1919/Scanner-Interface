using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;


namespace DataBaseLibrary
{
	namespace Catalogs.Interfaces
	{
		
		public interface ICatalogListedVisualElement
		{
			
			Collection ListViewColumNamesCollection {get;}
			ListViewItem ToListViewItem();
			
		}
		
	}
	
	
}
