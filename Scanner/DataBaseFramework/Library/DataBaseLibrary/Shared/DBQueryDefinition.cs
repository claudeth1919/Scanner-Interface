using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using DataBaseLibrary.Definitions;


namespace DataBaseLibrary
{
	[Serializable()]public abstract class DBQueryDefinition
	{
		
#region < DATAMEMBERS >
		
		private queryType _queryTpe;
		private string _commandText;
        ParametersContainer _parameters;
		
#endregion
		
#region < PROPERTIES >
		
        public string CommandText
		{
			get
			{
				return _commandText;
			}
			set
			{
				_commandText = value;
			}
		}
		
        public queryType QueryType
		{
			get
			{
				return this._queryTpe;
			}
			set
			{
				this._queryTpe = value;
			}
		}

        public ParametersContainer Parameters
		{
			get
			{
                return _parameters;
			}
		}
		
#endregion
		
#region < CONSTRUCTORS >
		
		protected DBQueryDefinition(string commandText, queryType queryType)
		{
            this._parameters = new ParametersContainer();
			this._commandText = commandText;
			this._queryTpe = queryType;
		}

        protected DBQueryDefinition(queryType queryType)
            : this("", queryType)
		{          
		}
		
		
#endregion
		
		

		
		
		
	}
	
}
