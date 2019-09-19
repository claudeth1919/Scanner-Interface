using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDSDataServerLibrary.Data.Handling
{
    public delegate void MachineHasStopped(string machineName);
    public delegate void MachineResumedOperation(string machineName);

    public class MachineOperationManager
    {
        #region < DATAMEMBERS  > 
                            
            private object _locker = new object();
            private SortedDictionary<string, MachineStopHandler> _handlersList;
        
        #endregion 
    
        #region < CONSTRUCTORS >

            public MachineOperationManager()
            {
                this._handlersList = new SortedDictionary<string, MachineStopHandler>();
            }

        #endregion

        #region< EVENTS > 
            
            public event MachineHasStopped MachineIsStopped;
            public event MachineResumedOperation MachineHasResumedOperation;

        #endregion 

        #region < PUBLIC METHODS  >

            public void HandleMachineStatus(string machineName , MachineStatus machineStatus)
            {
                lock (_locker)
                {
                    if (machineStatus == MachineStatus.manual)
                    {
                        //starts a handler if not exists
                        if (!this._handlersList.ContainsKey(machineName))
                        {
                            MachineStopHandler handler = new MachineStopHandler(machineName);
                            handler.StartWatching();
                            handler.MachineStopped += new MachineStopped(handler_MachineStopped);
                            this._handlersList.Add(machineName, handler);
                        }
                    }
                    else if (machineStatus == MachineStatus.automatic)
                    {
                        //removes a hander if exists because machine resume operation 
                        if (this._handlersList.ContainsKey(machineName))
                        {
                            MachineStopHandler handler = this._handlersList[machineName];
                            handler.StopWatching();
                            handler.MachineStopped -= handler_MachineStopped;
                            handler.Dispose();

                            this._handlersList.Remove(machineName);

                            if (MachineHasResumedOperation != null)
                                MachineHasResumedOperation(machineName);
                        }
                    }                    
                }
            }

        #endregion 

        #region < EVENT HANDLING  > 

            public void handler_MachineStopped(MachineStopHandler sender)
            {
                if (MachineIsStopped != null)
                {
                    MachineIsStopped(sender.MAchineName);
                    //removes the handler 
                    lock (_locker)
                    {
                        this._handlersList.Remove(sender.MAchineName);
                        sender.Dispose();
                    }
                }

            }

        #endregion 


    }
}
