namespace OcrCenter
{
    partial class OCR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCR));
            this.ReadTarget = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReadTarget
            // 
            this.ReadTarget.Location = new System.Drawing.Point(364, 189);
            this.ReadTarget.Name = "ReadTarget";
            this.ReadTarget.Size = new System.Drawing.Size(107, 38);
            this.ReadTarget.TabIndex = 0;
            this.ReadTarget.Text = "读取对象";
            this.ReadTarget.UseVisualStyleBackColor = true;
            this.ReadTarget.Click += new System.EventHandler(this.ReadTarget_Click);
            // 
            // OCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 239);
            this.Controls.Add(this.ReadTarget);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OCR";
            this.Text = "OCR";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadTarget;
    }
}

