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
            this.InitDelmiaDocument = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InitDelmiaDocument
            // 
            this.InitDelmiaDocument.Location = new System.Drawing.Point(22, 38);
            this.InitDelmiaDocument.Name = "InitDelmiaDocument";
            this.InitDelmiaDocument.Size = new System.Drawing.Size(125, 41);
            this.InitDelmiaDocument.TabIndex = 0;
            this.InitDelmiaDocument.Text = "初始化Delmia目录";
            this.InitDelmiaDocument.UseVisualStyleBackColor = true;
            this.InitDelmiaDocument.Click += new System.EventHandler(this.InitDelmiaDocument_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 336);
            this.Controls.Add(this.InitDelmiaDocument);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InitDelmiaDocument;
    }
}

