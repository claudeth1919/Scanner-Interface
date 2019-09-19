using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services.Queueing;
using System.Threading;


namespace CommunicationsLibrary
{
    namespace Services.P2PCommunicationsScheme.Statistics
    {


        public class P2PPortStatisticsHandler
        {

            #region  < DATAMEMBERS >

            private DataTable _generalStatisticsTable;
            private DataTable _dataReceptionStatisticsTable;
            private DataTable _dataRequestStatisticsTable;

            private TimedProducerConsumerQueue _LogDataReceptionEventQueue;
            private TimedProducerConsumerQueue _LogSuccesfulDataRequestEventQueue;
            private TimedProducerConsumerQueue _LogFailedDataRequestEventQueue;


            #endregion

            #region  < PROPERTIES >

            public DataTable GeneralStatisticsTable
            {
                get
                {
                    DataTable table = this._generalStatisticsTable;
                    return table;
                }
            }

            public DataTable DataReceptionStatisticsTable
            {
                get
                {
                    DataTable table = this._dataReceptionStatisticsTable;
                    return table;
                }
            }

            public DataTable DataRequestsStatisticsTable
            {
                get
                {
                    DataTable table = this._dataRequestStatisticsTable;
                    return table;
                }
            }

            #endregion

            #region  < CONSTRUCTORS  >

            internal P2PPortStatisticsHandler()
            {
                this.CreateP2PPortDataStatisticsTables();

                this._LogSuccesfulDataRequestEventQueue = new TimedProducerConsumerQueue();
                this._LogSuccesfulDataRequestEventQueue.NewItemDetected += new TimedProducerConsumerQueue.NewItemDetectedEventHandler(_LogSuccesfulDataRequestEventQueue_NewItemDetectedEventHandler);

                this._LogFailedDataRequestEventQueue = new TimedProducerConsumerQueue();
                this._LogFailedDataRequestEventQueue.NewItemDetected += new TimedProducerConsumerQueue.NewItemDetectedEventHandler(_LogFailedDataRequestEventQueue_NewItemDetectedEventHandler);

                this._LogDataReceptionEventQueue = new TimedProducerConsumerQueue();
                this._LogDataReceptionEventQueue.NewItemDetected += new TimedProducerConsumerQueue.NewItemDetectedEventHandler(LogDataReceptionEventQueue_NewItemDetectedEventHandler);


            }

            #endregion

            #region < EVENT HANDLING >


            private void LogDataReceptionEventQueue_NewItemDetectedEventHandler(object Item)
            {
                try
                {
                    if (Item != null)
                    {
                        P2PData data;
                        data = (P2PData)Item;
                        this.LogDataReceptionEventOnTable(data);
                    }
                }
                catch
                {

                }
            }


            private void _LogSuccesfulDataRequestEventQueue_NewItemDetectedEventHandler(object Item)
            {
                try
                {
                    if (Item != null)
                    {
                        P2PDataRequest dataRequest;
                        dataRequest = (P2PDataRequest)Item;
                        this.LogSuccesfulDataRequestEventOnTable(dataRequest);

                    }
                }
                catch
                {

                }
            }

            private void _LogFailedDataRequestEventQueue_NewItemDetectedEventHandler(object Item)
            {
                try
                {
                    if (Item != null)
                    {
                        P2PDataRequest dataRequest;
                        dataRequest = (P2PDataRequest)Item;
                        this.LogFailedDataRequestEventsOnTable(dataRequest);
                    }
                }
                catch
                {

                }
            }



            #endregion

            #region  < PRIVATE MEHTODS >

            private void CreateP2PPortDataStatisticsTables()
            {
                try
                {
                    //creation of the general statistics
                    this._generalStatisticsTable = new DataTable("P2PPortGeneralStatisticsTable");
                    this._generalStatisticsTable.Columns.Add("Port Event", System.Type.GetType("System.String"));
                    this._generalStatisticsTable.Columns.Add("Count", System.Type.GetType("System.Int64"));

                    //creation of the data recepction statistics table
                    this._dataReceptionStatisticsTable = new DataTable("P2PPortDataReceptionStatisticsTable");
                    this._dataReceptionStatisticsTable.Columns.Add("DataName", System.Type.GetType("System.String"));
                    this._dataReceptionStatisticsTable.Columns.Add("DataType", System.Type.GetType("System.String"));
                    this._dataReceptionStatisticsTable.Columns.Add("Count", System.Type.GetType("System.Int64"));
                    this._dataReceptionStatisticsTable.Columns.Add("FirstReceptionDateTime", System.Type.GetType("System.DateTime"));
                    this._dataReceptionStatisticsTable.Columns.Add("LastReceptionDateTime", System.Type.GetType("System.DateTime"));


                    //creation of the data request statistics table
                    this._dataRequestStatisticsTable = new DataTable("P2PPortDataRequestsStatisticsTable");
                    this._dataRequestStatisticsTable.Columns.Add("DataName", System.Type.GetType("System.String"));
                    this._dataRequestStatisticsTable.Columns.Add("Successful", System.Type.GetType("System.Int64"));
                    this._dataRequestStatisticsTable.Columns.Add("Failed", System.Type.GetType("System.Int64"));
                    this._dataRequestStatisticsTable.Columns.Add("FirstRequestDateTime", System.Type.GetType("System.DateTime"));
                    this._dataRequestStatisticsTable.Columns.Add("LastRequestDateTime", System.Type.GetType("System.DateTime"));
                }
                catch (Exception)
                {
                }
            }

            private void LogDataReceptionEventOnTable(P2PData data)
            {

                if (!(data == null))
                {


                    string selectionCriteria = "";
                    DataRow[] resultRows = null;

                    //*****************************************************************************
                    //updates the general statistics table
                    //*****************************************************************************

                    try
                    {
                        lock (this._generalStatisticsTable)
                        {

                            selectionCriteria = "[Port Event] = \'Data Reception\'";
                            resultRows = this._generalStatisticsTable.Select(selectionCriteria);
                            if (resultRows.Length <= 0)
                            {
                                DataRow row = this._generalStatisticsTable.NewRow();
                                row["Port Event"] = "Data Reception";
                                row["Count"] = 1;
                                this._generalStatisticsTable.Rows.Add(row);
                            }
                            else
                            {
                                long count = (long)(resultRows[0]["Count"]);
                                count++;
                                resultRows[0]["Count"] = count;
                                resultRows[0].AcceptChanges();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = "Error saving P2P port general statistics : " + ex.ToString();
                        CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
                    }

                    //*****************************************************************************
                    //updates the data reception statistics table
                    //*****************************************************************************

                    try
                    {

                        lock (this._dataReceptionStatisticsTable)
                        {

                            selectionCriteria = "DataName = \'" + data.DataName + "\' AND DataType = \'" + data.Value.GetType().ToString() + "\'";
                            resultRows = this._dataReceptionStatisticsTable.Select(selectionCriteria);
                            if (resultRows.Length <= 0)
                            {
                                //the dataname with the datatype is not registered
                                DataRow row = this._dataReceptionStatisticsTable.NewRow();
                                row["DataName"] = data.DataName;
                                row["DataType"] = data.Value.GetType().ToString();
                                row["Count"] = 1;
                                row["FirstReceptionDateTime"] = DateTime.Now;
                                row["LastReceptionDateTime"] = DateTime.Now;
                                this._dataReceptionStatisticsTable.Rows.Add(row);
                            }
                            else
                            {
                                //the dataname with the datatype is registered
                                long count = (long)(resultRows[0]["Count"]);
                                count++;
                                resultRows[0]["Count"] = count;
                                resultRows[0]["LastReceptionDateTime"] = DateTime.Now;
                                resultRows[0].AcceptChanges();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = "Error saving P2P port data reception statistics : " + ex.ToString();
                        CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
                    }

                }

            }

            private void LogSuccesfulDataRequestEventOnTable(P2PDataRequest dataRequest)
            {


                if (!(dataRequest == null))
                {

                    string selectionCriteria = "";
                    DataRow[] resultRows = null;

                    //*****************************************************************************
                    //updates the general statistics table
                    //*****************************************************************************
                    try
                    {

                        lock (this._generalStatisticsTable)
                        {

                            selectionCriteria = "[Port Event] = \'Succesful Data Request Attended\'";
                            resultRows = this._generalStatisticsTable.Select(selectionCriteria);
                            if (resultRows.Length <= 0)
                            {
                                DataRow row = this._generalStatisticsTable.NewRow();
                                row["Port Event"] = "Succesful Data Request Attended";
                                row["Count"] = 1;
                                this._generalStatisticsTable.Rows.Add(row);
                            }
                            else
                            {
                                long count = (long)(resultRows[0]["Count"]);
                                count++;
                                resultRows[0]["Count"] = count;
                                resultRows[0].AcceptChanges();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = "Error saving P2P port general statistics : " + ex.ToString();
                        CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
                    }

                    //*****************************************************************************
                    //updates the data requests statistics table
                    //*****************************************************************************
                    try
                    {

                        lock (this._dataRequestStatisticsTable)
                        {

                            selectionCriteria = "DataName = \'" + dataRequest.RequestedDataName + "\'";
                            resultRows = this._dataRequestStatisticsTable.Select(selectionCriteria);
                            if (resultRows.Length <= 0)
                            {
                                //the dataname with the datatype is not registered
                                DataRow row = this._dataRequestStatisticsTable.NewRow();
                                row["DataName"] = dataRequest.RequestedDataName;
                                row["Successful"] = 1;
                                row["Failed"] = 0;
                                row["FirstRequestDateTime"] = DateTime.Now;
                                row["LastRequestDateTime"] = DateTime.Now;
                                this._dataRequestStatisticsTable.Rows.Add(row);
                            }
                            else
                            {
                                //the dataname with the datatype is registered
                                long count = (long)(resultRows[0]["Successful"]);
                                count++;
                                resultRows[0]["Successful"] = count;
                                resultRows[0]["LastRequestDateTime"] = DateTime.Now;
                                resultRows[0].AcceptChanges();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = "Error saving P2P port data requests statistics : " + ex.ToString();
                        CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());

                    }
                }

            }

            private void LogFailedDataRequestEventsOnTable(P2PDataRequest dataRequest)
            {


                if (!(dataRequest == null))
                {

                    string selectionCriteria = "";
                    DataRow[] resultRows = null;
                    //*****************************************************************************
                    //updates the general statistics table
                    //*****************************************************************************
                    try
                    {
                        lock (this._generalStatisticsTable)
                        {

                            selectionCriteria = "[Port Event] = \'Failed Data Request Attended\'";
                            resultRows = this._generalStatisticsTable.Select(selectionCriteria);
                            if (resultRows.Length <= 0)
                            {
                                DataRow row = this._generalStatisticsTable.NewRow();
                                row["Port Event"] = "Failed Data Request Attended";
                                row["Count"] = 1;
                                this._generalStatisticsTable.Rows.Add(row);
                            }
                            else
                            {
                                long count = (long)(resultRows[0]["Count"]);
                                count++;
                                resultRows[0]["Count"] = count;
                                resultRows[0].AcceptChanges();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = "Error saving P2P port general statistics : " + ex.ToString();
                        CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
                    }


                    //*****************************************************************************
                    //updates the data requests failure statistics table
                    //*****************************************************************************
                    try
                    {

                        lock (this._dataRequestStatisticsTable)
                        {

                            selectionCriteria = "DataName = \'" + dataRequest.RequestedDataName + "\'";
                            resultRows = this._dataRequestStatisticsTable.Select(selectionCriteria);
                            if (resultRows.Length <= 0)
                            {
                                //the dataname with the datatype is not registered
                                DataRow row = this._dataRequestStatisticsTable.NewRow();
                                row["DataName"] = dataRequest.RequestedDataName;
                                row["Successful"] = 0;
                                row["Failed"] = 1;
                                row["FirstRequestDateTime"] = DateTime.Now;
                                row["LastRequestDateTime"] = DateTime.Now;
                                this._dataRequestStatisticsTable.Rows.Add(row);
                            }
                            else
                            {
                                //the dataname with the datatype is registered
                                long count = (long)(resultRows[0]["Failed"]);
                                count++;
                                resultRows[0]["Failed"] = count;
                                resultRows[0]["LastRequestDateTime"] = DateTime.Now;
                                resultRows[0].AcceptChanges();
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = "Error saving P2P port data requests failure statistics : " + ex.ToString();
                        CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
                    }



                }

            }

            #endregion

            #region  < FRIEND METHODS >

            internal void LogDataReceptionEvent(P2PData data)
            {
                try
                {
                    this._LogDataReceptionEventQueue.Enqueue(data);
                }
                catch (Exception)
                {
                }
            }

            internal void LogSuccesfulDataRequestEvent(P2PDataRequest dataRequest)
            {
                try
                {
                    this._LogSuccesfulDataRequestEventQueue.Enqueue(dataRequest);
                }
                catch (Exception)
                {
                }
            }

            internal void LogFailedDataRequestEvent(P2PDataRequest dataRequest)
            {
                try
                {
                    this._LogFailedDataRequestEventQueue.Enqueue(dataRequest);
                }
                catch (Exception)
                {
                }
            }

            #endregion

        }



    }


}
