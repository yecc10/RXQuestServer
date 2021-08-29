
namespace YeDassaultSystemDev
{
    partial class _2DModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_2DModel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ReConnectCATIA = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.myMessage = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReConnectCATIA});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1511, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ReConnectCATIA
            // 
            this.ReConnectCATIA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReConnectCATIA.Image = global::YeDassaultSystemDev.Properties.Resources.Add;
            this.ReConnectCATIA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReConnectCATIA.Name = "ReConnectCATIA";
            this.ReConnectCATIA.Size = new System.Drawing.Size(34, 28);
            this.ReConnectCATIA.Text = "ReConnectCATIA";
            this.ReConnectCATIA.Click += new System.EventHandler(this.ReConnectCATIA_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 753);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1487, 41);
            this.progressBar.TabIndex = 1;
            // 
            // myMessage
            // 
            this.myMessage.AutoSize = true;
            this.myMessage.Location = new System.Drawing.Point(13, 797);
            this.myMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myMessage.Name = "myMessage";
            this.myMessage.Size = new System.Drawing.Size(35, 18);
            this.myMessage.TabIndex = 10;
            this.myMessage.Text = "AAA";
            // 
            // _2DModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 824);
            this.Controls.Add(this.myMessage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "_2DModel";
            this.Text = "_2DModel";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripButton ReConnectCATIA;
        private System.Windows.Forms.Label myMessage;
    }
}