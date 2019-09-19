using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ALDSDataServerLibrary.Data.Handling
{
    public delegate void MachineStopped(MachineStopHandler sender);


    public class MachineStopHandler : IDisposable
    {
        #region < DATA MEMBERS > 

            private System.Timers.Timer _watchTimer;
            private string _machineName; 
           
        #endregion 

        #region < CONSTRUCTORS >

            public MachineStopHandler(string machineName)
            {
                this._machineName = machineName;
                this._watchTimer = new Timer(300000);                 
                this._watchTimer.AutoReset = false;
                this._watchTimer.Elapsed +=new ElapsedEventHandler(_watchTimer_Elapsed);
            }
            

        #endregion

        #region < PROPERTIES > 


            public string MAchineName
            {
                get
                {
                    return this._machineName;
                }
            }
        
        #endregion 

        #region  < EVENTS >

            public event MachineStopped MachineStopped;



        #endregion 

        #region < PUBLIC METHODS  > 

            public void StartWatching()
            {
                this._watchTimer.Start();
            }

            public void StopWatching()
            {
                this._watchTimer.Stop();
            }
        
        #endregion 

        #region < EVENT HANDLING  >

            public void _watchTimer_Elapsed(object sender, ElapsedEventArgs e)
            {
                try
                {
                    //time consumed 
                    if (MachineStopped != null)
                        MachineStopped(this);
                }
                catch (Exception ex)
                {

                }
            }


        #endregion

        #region < INTERFACE IMPLEMENTATION  >

            #region < IDisposable  >

                public void Dispose()
                {
                    this._watchTimer.Dispose();
                }

            #endregion          

        #endregion




          
    }
}
