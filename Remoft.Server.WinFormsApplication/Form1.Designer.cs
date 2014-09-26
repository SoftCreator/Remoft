namespace Remoft.Server.WinFormsApplication
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timerSendUdp = new System.Windows.Forms.Timer(this.components);
            this.imageListCompImages = new System.Windows.Forms.ImageList(this.components);
            this.timerRefreshMachinesList = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 402);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // timerSendUdp
            // 
            this.timerSendUdp.Enabled = true;
            this.timerSendUdp.Interval = 5000;
            this.timerSendUdp.Tick += new System.EventHandler(this.TimerSendUdpTick);
            // 
            // imageListCompImages
            // 
            this.imageListCompImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCompImages.ImageStream")));
            this.imageListCompImages.TransparentColor = System.Drawing.Color.White;
            this.imageListCompImages.Images.SetKeyName(0, "blue");
            this.imageListCompImages.Images.SetKeyName(1, "green");
            this.imageListCompImages.Images.SetKeyName(2, "gray");
            this.imageListCompImages.Images.SetKeyName(3, "yellow");
            // 
            // timerRefreshMachinesList
            // 
            this.timerRefreshMachinesList.Enabled = true;
            this.timerRefreshMachinesList.Interval = 4000;
            this.timerRefreshMachinesList.Tick += new System.EventHandler(this.timerRefreshMachinesList_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 402);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timerSendUdp;
        private System.Windows.Forms.ImageList imageListCompImages;
        private System.Windows.Forms.Timer timerRefreshMachinesList;
    }
}

