using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;


namespace DataBaseLibrary
{
	[Serializable()]public class QueryParameter
	{
		
#region < DATAMEMBERS >
		
		private string _parameterName;
		private System.Data.SqlDbType _parameterDataType;
		private object _value;
        private ParameterDirection _direction;
        private int _size;
		
#endregion
		
#region < PROPERTIES >
		
        public string Name
		{
			get
			{
				return this._parameterName;
			}
		}

        public SqlDbType sqlType
		{
			get
			{
				return this._parameterDataType;
			}
		}
		
        public dynamic Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

        public ParameterDirection Direction
        {
            get
            {
                return this._direction;
            }
        }

        public int Size
        {
            get
            {
                return this._size;
            }
        }
		
#endregion
		
#region < CONSTRUCTORS >

        public QueryParameter(string name, System.Data.SqlDbType dataType, ParameterDirection direction, int size)
        {
            this._parameterName = name;
            this._parameterDataType = dataType;
            this._direction = direction;
            this._size = size;
        }

        public QueryParameter(string name, System.Data.SqlDbType dataType, ParameterDirection direction):
            this(name, dataType , direction , 0 )
        {        }


		public QueryParameter(string name, System.Data.SqlDbType dataType) : this (name, dataType , ParameterDirection.Input , 0)
		{		}

      
		
#endregion
		
		
	}
	
}
