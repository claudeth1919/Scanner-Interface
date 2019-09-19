namespace ALDSDataServerLineEmulator
{
    partial class Emulator
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBroadCastData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboMachine = new System.Windows.Forms.ComboBox();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblSendStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBroadCastData
            // 
            this.btnBroadCastData.Location = new System.Drawing.Point(216, 175);
            this.btnBroadCastData.Name = "btnBroadCastData";
            this.btnBroadCastData.Size = new System.Drawing.Size(75, 23);
            this.btnBroadCastData.TabIndex = 0;
            this.btnBroadCastData.Text = "Send Status";
            this.btnBroadCastData.UseVisualStyleBackColor = true;
            this.btnBroadCastData.Click += new System.EventHandler(this.btnBroadCastData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSendStatus);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.cboMachine);
            this.groupBox1.Controls.Add(this.cboLine);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBroadCastData);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 232);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ALDS Machine Status ";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(130, 120);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 21);
            this.cboStatus.TabIndex = 6;
            // 
            // cboMachine
            // 
            this.cboMachine.FormattingEnabled = true;
            this.cboMachine.Items.AddRange(new object[] {
            "ST_10",
            "ST_20",
            "ST_30",
            "ST_40",
            "ST_50",
            "ST_60",
            "ST_70",
            "ST_80"});
            this.cboMachine.Location = new System.Drawing.Point(130, 90);
            this.cboMachine.Name = "cboMachine";
            this.cboMachine.Size = new System.Drawing.Size(121, 21);
            this.cboMachine.TabIndex = 5;
            // 
            // cboLine
            // 
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Items.AddRange(new object[] {
            "VS7",
            "VS8",
            "VS10"});
            this.cboLine.Location = new System.Drawing.Point(130, 55);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(121, 21);
            this.cboLine.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Line ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Machine Name ";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(31, 314);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(105, 13);
            this.lblServerStatus.TabIndex = 3;
            this.lblServerStatus.Text = "ALDS Server Status ";
            // 
            // lblSendStatus
            // 
            this.lblSendStatus.AutoSize = true;
            this.lblSendStatus.Location = new System.Drawing.Point(213, 201);
            this.lblSendStatus.Name = "lblSendStatus";
            this.lblSendStatus.Size = new System.Drawing.Size(68, 13);
            this.lblSendStatus.TabIndex = 7;
            this.lblSendStatus.Text = "No data sent";
            // 
            // Emulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 336);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.groupBox1);
            this.Name = "Emulator";
            this.Text = "Emulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBroadCastData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cboMachine;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblSendStatus;
    }
}