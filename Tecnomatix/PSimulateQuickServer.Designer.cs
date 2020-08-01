namespace Tecnomatix
{
    partial class PSimulateQuickServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSimulateQuickServer));
            this.cUiContinuousButton1 = new Tecnomatix.Engineering.Ui.CUiContinuousButton();
            this.txViewerUserControl1 = new Tecnomatix.Engineering.Ui.TxViewerUserControl();
            this.SuspendLayout();
            // 
            // cUiContinuousButton1
            // 
            this.cUiContinuousButton1.ClickInterval = 100;
            this.cUiContinuousButton1.Location = new System.Drawing.Point(649, 375);
            this.cUiContinuousButton1.Name = "cUiContinuousButton1";
            this.cUiContinuousButton1.Size = new System.Drawing.Size(139, 40);
            this.cUiContinuousButton1.TabIndex = 0;
            this.cUiContinuousButton1.Text = "cUiContinuousButton1";
            this.cUiContinuousButton1.UseVisualStyleBackColor = true;
            this.cUiContinuousButton1.Click += new System.EventHandler(this.cUiContinuousButton1_Click);
            // 
            // txViewerUserControl1
            // 
            this.txViewerUserControl1.Location = new System.Drawing.Point(24, 12);
            this.txViewerUserControl1.Name = "txViewerUserControl1";
            this.txViewerUserControl1.Size = new System.Drawing.Size(764, 357);
            this.txViewerUserControl1.TabIndex = 1;
            // 
            // PSimulateQuickServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txViewerUserControl1);
            this.Controls.Add(this.cUiContinuousButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PSimulateQuickServer";
            this.Text = "PSimulateQuickServer";
            this.ResumeLayout(false);

        }

        #endregion

        private Engineering.Ui.CUiContinuousButton cUiContinuousButton1;
        private Engineering.Ui.TxViewerUserControl txViewerUserControl1;
    }
}