using Scanner.General;
using System;
using System.Timers;
using System.Windows.Forms;
using ALDSDataServerLibrary.Data;
using ALDSDataServerLibrary.Server;

namespace Scanner
{
    public partial class ScannesListener : Form
    {
        private LowLevelKeyboardListener _listener;
        private String InputString;
        private const int TOOLING_TOOL_LENGTH = 36; //36
        private System.Timers.Timer MyTimer; //For Validating input key speed
        ALDSDataServer Server;
        private const int CP_NOCLOSE_BUTTON = 0x200;

        public ScannesListener()
        {
            InitializeComponent();
            MyTimer = new System.Timers.Timer();
            InputString = String.Empty;
            Server = ALDSDataServer.GetInstance();
            this.SuccessImage.Visible = false;
        }

        private void StartMyTimer()
        {
            int waitIntervalTimer = 500;
            if (!MyTimer.Enabled)
            {
                MyTimer.Elapsed += new ElapsedEventHandler(SendDataInput);
                MyTimer.Interval = waitIntervalTimer;
                MyTimer.Enabled = true;
            }
            else if (InputString.Length == TOOLING_TOOL_LENGTH)
            {
                this.textBox_DisplayKeyboardInput.Text = InputString;
                ALDSData containerData = new ALDSData(Defs.ALDSDATA_MESSAGEID);
                containerData.AttachDataAttribute(Defs.TOOLING_ID, InputString);
                Server.DistributeData(containerData);
                InputString = String.Empty;
                this.SuccessImage.Visible = true;
            }
        }

        private void SendDataInput(object source, ElapsedEventArgs es)
        {
            string sasa = InputString;
            InputString = String.Empty;
            MyTimer.Enabled = false;
            MyTimer.Stop();
        }


        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            char charItem = Utils.KeyToChar(e.KeyPressed);
            if (Char.IsLetter(charItem)||Char.IsDigit(charItem)|| charItem== '-')
            {
                InputString += charItem;
                this.textBox_DisplayKeyboardInput.Text = String.Empty;
                this.SuccessImage.Visible = false;
                StartMyTimer();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        private void Load_Event(object sender, EventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
