namespace RXQuestServer.PLC_Advance
{
    partial class CAdvancePLC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAdvancePLC));
            this.ConnectPLC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectPLC
            // 
            this.ConnectPLC.Location = new System.Drawing.Point(365, 152);
            this.ConnectPLC.Name = "ConnectPLC";
            this.ConnectPLC.Size = new System.Drawing.Size(75, 23);
            this.ConnectPLC.TabIndex = 0;
            this.ConnectPLC.Text = "连接PLC";
            this.ConnectPLC.UseVisualStyleBackColor = true;
            // 
            // CAdvancePLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 187);
            this.Controls.Add(this.ConnectPLC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CAdvancePLC";
            this.Text = "CAdvancePLC";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectPLC;
    }
}