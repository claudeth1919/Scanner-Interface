namespace Scanner
{
    partial class ScannesListener
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannesListener));
            this.textBox_DisplayKeyboardInput = new System.Windows.Forms.Label();
            this.SuccessImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SuccessImage)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_DisplayKeyboardInput
            // 
            this.textBox_DisplayKeyboardInput.AutoSize = true;
            this.textBox_DisplayKeyboardInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_DisplayKeyboardInput.Location = new System.Drawing.Point(31, 158);
            this.textBox_DisplayKeyboardInput.Name = "textBox_DisplayKeyboardInput";
            this.textBox_DisplayKeyboardInput.Size = new System.Drawing.Size(0, 20);
            this.textBox_DisplayKeyboardInput.TabIndex = 0;
            // 
            // SuccessImage
            // 
            this.SuccessImage.Image = global::Scanner.Properties.Resources.success;
            this.SuccessImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("SuccessImage.InitialImage")));
            this.SuccessImage.Location = new System.Drawing.Point(123, 12);
            this.SuccessImage.Name = "SuccessImage";
            this.SuccessImage.Size = new System.Drawing.Size(133, 131);
            this.SuccessImage.TabIndex = 1;
            this.SuccessImage.TabStop = false;
            // 
            // ScannesListener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 195);
            this.Controls.Add(this.SuccessImage);
            this.Controls.Add(this.textBox_DisplayKeyboardInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScannesListener";
            this.Text = "Scanner";
            this.Load += new System.EventHandler(this.Load_Event);
            ((System.ComponentModel.ISupportInitialize)(this.SuccessImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textBox_DisplayKeyboardInput;
        private System.Windows.Forms.PictureBox SuccessImage;
    }
}

