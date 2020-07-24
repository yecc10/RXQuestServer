namespace RXQuestServer
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.InitDelmiaDocument = new System.Windows.Forms.Button();
            this.WeldSportTool = new System.Windows.Forms.Button();
            this.GotoOCR = new System.Windows.Forms.Button();
            this.ShowToPlc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InitDelmiaDocument
            // 
            this.InitDelmiaDocument.Location = new System.Drawing.Point(22, 12);
            this.InitDelmiaDocument.Name = "InitDelmiaDocument";
            this.InitDelmiaDocument.Size = new System.Drawing.Size(125, 41);
            this.InitDelmiaDocument.TabIndex = 0;
            this.InitDelmiaDocument.Text = "Delmia初始化工具";
            this.InitDelmiaDocument.UseVisualStyleBackColor = true;
            this.InitDelmiaDocument.Click += new System.EventHandler(this.InitDelmiaDocument_Click);
            // 
            // WeldSportTool
            // 
            this.WeldSportTool.Location = new System.Drawing.Point(153, 12);
            this.WeldSportTool.Name = "WeldSportTool";
            this.WeldSportTool.Size = new System.Drawing.Size(125, 41);
            this.WeldSportTool.TabIndex = 0;
            this.WeldSportTool.Text = "焊点快捷工具";
            this.WeldSportTool.UseVisualStyleBackColor = true;
            this.WeldSportTool.Click += new System.EventHandler(this.WeldSportTool_Click);
            // 
            // GotoOCR
            // 
            this.GotoOCR.Location = new System.Drawing.Point(22, 59);
            this.GotoOCR.Name = "GotoOCR";
            this.GotoOCR.Size = new System.Drawing.Size(125, 41);
            this.GotoOCR.TabIndex = 0;
            this.GotoOCR.Text = "OCR工具";
            this.GotoOCR.UseVisualStyleBackColor = true;
            this.GotoOCR.Click += new System.EventHandler(this.GotoOCR_Click);
            // 
            // ShowToPlc
            // 
            this.ShowToPlc.Location = new System.Drawing.Point(153, 59);
            this.ShowToPlc.Name = "ShowToPlc";
            this.ShowToPlc.Size = new System.Drawing.Size(125, 41);
            this.ShowToPlc.TabIndex = 0;
            this.ShowToPlc.Text = "PLC通讯";
            this.ShowToPlc.UseVisualStyleBackColor = true;
            this.ShowToPlc.Click += new System.EventHandler(this.GotoOCR_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(304, 111);
            this.Controls.Add(this.WeldSportTool);
            this.Controls.Add(this.ShowToPlc);
            this.Controls.Add(this.GotoOCR);
            this.Controls.Add(this.InitDelmiaDocument);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(320, 150);
            this.MinimumSize = new System.Drawing.Size(320, 150);
            this.Name = "Main";
            this.Text = "主入口";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InitDelmiaDocument;
        private System.Windows.Forms.Button WeldSportTool;
        private System.Windows.Forms.Button GotoOCR;
        private System.Windows.Forms.Button ShowToPlc;
    }
}

