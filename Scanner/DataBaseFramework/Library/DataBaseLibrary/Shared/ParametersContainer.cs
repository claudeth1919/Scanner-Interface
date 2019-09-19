using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataBaseLibrary.Definitions;

namespace DataBaseLibrary
{
    public class ParametersContainer : IEnumerable<QueryParameter>
    {   
        
        #region < DATA MEMBERS >
            
            private SortedList<string, QueryParameter> _ParametersList;
        
        #endregion

        #region < PROPERTIES   >

            public QueryParameter this[string Name]
            {
                get
                {
                    if (!Name.StartsWith("@"))
                    {
                        Name = "@" + Name;
                    }
                    return this._ParametersList[Name];
                }
            }

        #endregion

        #region < CONSTRUCTOR >

            public ParametersContainer()
            {
                this._ParametersList = new SortedList<string, QueryParameter>();
            }
            

        #endregion

      

        #region < PUBLIC METHODS >

            public void AddParameter(string paramName, System.Data.SqlDbType datatype, object value, ParameterDirection direction, int size)
            {
                try
                {
                    if (!this._ParametersList.ContainsKey(paramName))
                    {
                        //evaluates if the parameter name is preceded by the @ character
                        if (!paramName.StartsWith("@"))
                        {
                            paramName = "@" + paramName;
                        }
                        //creates the paremeter object
                        QueryParameter param = new QueryParameter(paramName, datatype, direction, size);
                        //inserts the parameter to parameter list
                        this._ParametersList.Add(param.Name, param);
                        this.SetParameterValue(param.Name, value);
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

            public void AddParameter(string paramName, System.Data.SqlDbType datatype, object value, ParameterDirection direction)
            {
                this.AddParameter(paramName, datatype, value, direction, 0);
            }


            public void AddParameter(QueryParameter parameter)
            {
                if (!this._ParametersList.ContainsKey(parameter.Name))
                {
                    //inserts the parameter to parameter list
                    this._ParametersList.Add(parameter.Name, parameter);
                }
            }

            public void AddParameter(string paramName, System.Data.SqlDbType datatype)
            {
                this.AddParameter(paramName, datatype, null, ParameterDirection.Input, 0);
            }

            public void AddParameter(string paramName, System.Data.SqlDbType datatype, object value)
            {
                this.AddParameter(paramName, datatype, value, ParameterDirection.Input);
            }     


            public void Add_OUTPUT_Parameter(string paramName, System.Data.SqlDbType datatype)
            {
                this.AddParameter(paramName, datatype, null, ParameterDirection.Output, 0);
            }

            public void Add_OUTPUT_Parameter(string paramName, System.Data.SqlDbType datatype, int size)
            {
                this.AddParameter(paramName, datatype, null, ParameterDirection.Output, size);
            }

            public void RemoveParameter(string paramName)
            {
                if (this._ParametersList.ContainsKey(paramName))
                {
                    this._ParametersList.Remove(paramName);
                }
            }

            public void SetParameterValue(string paramName, object value)
            {
                if (!paramName.StartsWith("@"))
                {
                    paramName = "@" + paramName;
                }

                if (this._ParametersList.ContainsKey(paramName))
                {
                    QueryParameter param;
                    param = (DataBaseLibrary.QueryParameter)(this._ParametersList[paramName]);
                    param.Value = value;
                }
            }

            public void ClearParameters()
            {
                this._ParametersList.Clear();
            }
        #endregion

                
        #region < INTERFACE IMPLEMENTATIONS > 
        
            #region < IEnumerable >

                public IEnumerator<QueryParameter> GetEnumerator()
                {
                    return this._ParametersList.Values.GetEnumerator();
                }

                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this._ParametersList.Values.GetEnumerator();
                }

                IEnumerator<QueryParameter> IEnumerable<QueryParameter>.GetEnumerator()
                {
                    return this._ParametersList.Values.GetEnumerator();
                }

            #endregion
        
        #endregion





              
    }
}
