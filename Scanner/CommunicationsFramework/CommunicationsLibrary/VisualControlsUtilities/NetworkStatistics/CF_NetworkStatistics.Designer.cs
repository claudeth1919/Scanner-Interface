namespace CommunicationsLibrary.VisualControlsUtilities.NetworkStatistics
{
    partial class CF_NetworkStatistics
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spltrMain = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgrdNetworkStatisticsIPv4 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgrdNetworkStatisticsIPv6 = new System.Windows.Forms.DataGridView();
            this.btnUpdateStatistics = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spltrMain)).BeginInit();
            this.spltrMain.Panel1.SuspendLayout();
            this.spltrMain.Panel2.SuspendLayout();
            this.spltrMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetworkStatisticsIPv4)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetworkStatisticsIPv6)).BeginInit();
            this.SuspendLayout();
            // 
            // spltrMain
            // 
            this.spltrMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrMain.IsSplitterFixed = true;
            this.spltrMain.Location = new System.Drawing.Point(0, 0);
            this.spltrMain.Name = "spltrMain";
            this.spltrMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrMain.Panel1
            // 
            this.spltrMain.Panel1.Controls.Add(this.tabControl);
            // 
            // spltrMain.Panel2
            // 
            this.spltrMain.Panel2.Controls.Add(this.btnUpdateStatistics);
            this.spltrMain.Size = new System.Drawing.Size(205, 190);
            this.spltrMain.SplitterDistance = 142;
            this.spltrMain.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(205, 142);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgrdNetworkStatisticsIPv4);
            this.tabPage1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(197, 110);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IPv4";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgrdNetworkStatisticsIPv4
            // 
            this.dgrdNetworkStatisticsIPv4.AllowUserToAddRows = false;
            this.dgrdNetworkStatisticsIPv4.AllowUserToDeleteRows = false;
            this.dgrdNetworkStatisticsIPv4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdNetworkStatisticsIPv4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdNetworkStatisticsIPv4.Location = new System.Drawing.Point(3, 3);
            this.dgrdNetworkStatisticsIPv4.Name = "dgrdNetworkStatisticsIPv4";
            this.dgrdNetworkStatisticsIPv4.ReadOnly = true;
            this.dgrdNetworkStatisticsIPv4.Size = new System.Drawing.Size(191, 104);
            this.dgrdNetworkStatisticsIPv4.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgrdNetworkStatisticsIPv6);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "IPv6";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrdNetworkStatisticsIPv6
            // 
            this.dgrdNetworkStatisticsIPv6.AllowUserToAddRows = false;
            this.dgrdNetworkStatisticsIPv6.AllowUserToDeleteRows = false;
            this.dgrdNetworkStatisticsIPv6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdNetworkStatisticsIPv6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdNetworkStatisticsIPv6.Location = new System.Drawing.Point(3, 3);
            this.dgrdNetworkStatisticsIPv6.Name = "dgrdNetworkStatisticsIPv6";
            this.dgrdNetworkStatisticsIPv6.ReadOnly = true;
            this.dgrdNetworkStatisticsIPv6.Size = new System.Drawing.Size(746, 444);
            this.dgrdNetworkStatisticsIPv6.TabIndex = 0;
            // 
            // btnUpdateStatistics
            // 
            this.btnUpdateStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateStatistics.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStatistics.Location = new System.Drawing.Point(10, 3);
            this.btnUpdateStatistics.Name = "btnUpdateStatistics";
            this.btnUpdateStatistics.Size = new System.Drawing.Size(189, 36);
            this.btnUpdateStatistics.TabIndex = 0;
            this.btnUpdateStatistics.Text = "Update Statistics ";
            this.btnUpdateStatistics.UseVisualStyleBackColor = true;
            this.btnUpdateStatistics.Click += new System.EventHandler(this.btnUpdateStatistics_Click);
            // 
            // CF_NetworkStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltrMain);
            this.Name = "CF_NetworkStatistics";
            this.Size = new System.Drawing.Size(205, 190);
            this.spltrMain.Panel1.ResumeLayout(false);
            this.spltrMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrMain)).EndInit();
            this.spltrMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetworkStatisticsIPv4)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetworkStatisticsIPv6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spltrMain;
        private System.Windows.Forms.Button btnUpdateStatistics;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgrdNetworkStatisticsIPv4;
        private System.Windows.Forms.DataGridView dgrdNetworkStatisticsIPv6;
    }
}
