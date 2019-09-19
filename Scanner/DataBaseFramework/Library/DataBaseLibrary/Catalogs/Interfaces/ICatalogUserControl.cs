using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using DataBaseLibrary.Catalogs;


namespace DataBaseLibrary
{
	namespace Catalogs.Interfaces
	{
		
		
		public interface ICatalogUserControl
		{
			
			bool Checked {get;}
			
			void SetSelectionMode(bool mode);
			
			// Event CheckedChanged(ByVal control As ICatalogUserControl, ByVal status As Boolean) VBConversions Warning: events in interfaces not supported in C#.
			
			// Event NewItemSelected(ByVal item As ICatalogItem) VBConversions Warning: events in interfaces not supported in C#.
			
			void LoadData();
			
			void ReloadData();
			
			bool IsElementSelected();
			
			ICatalogItem SelectedItem();
			
			void SetSelectedItem(ICatalogItem item);
			
			void DisplayRefreshCommand(bool show);
			
			
			
		}
		
		
	}
	
}
