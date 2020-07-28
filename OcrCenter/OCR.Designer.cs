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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCR));
            this.ReadTarget = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultTest = new System.Windows.Forms.TextBox();
            this.PBOCR = new System.Windows.Forms.ProgressBar();
            this.savetoword = new System.Windows.Forms.Button();
            this.ByBaiduEngner = new System.Windows.Forms.CheckBox();
            this.ByInnerEngner = new System.Windows.Forms.CheckBox();
            this.GetScreenOprator = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ReadTarget
            // 
            this.ReadTarget.Location = new System.Drawing.Point(13, 443);
            this.ReadTarget.Name = "ReadTarget";
            this.ReadTarget.Size = new System.Drawing.Size(107, 38);
            this.ReadTarget.TabIndex = 0;
            this.ReadTarget.Text = "读取文件";
            this.ReadTarget.UseVisualStyleBackColor = true;
            this.ReadTarget.Click += new System.EventHandler(this.ReadTarget_Click);
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(70, 12);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(788, 21);
            this.FilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件地址:";
            // 
            // ResultTest
            // 
            this.ResultTest.Location = new System.Drawing.Point(13, 42);
            this.ResultTest.Multiline = true;
            this.ResultTest.Name = "ResultTest";
            this.ResultTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultTest.Size = new System.Drawing.Size(845, 343);
            this.ResultTest.TabIndex = 3;
            // 
            // PBOCR
            // 
            this.PBOCR.Location = new System.Drawing.Point(13, 391);
            this.PBOCR.Name = "PBOCR";
            this.PBOCR.Size = new System.Drawing.Size(845, 23);
            this.PBOCR.TabIndex = 4;
            // 
            // savetoword
            // 
            this.savetoword.Location = new System.Drawing.Point(751, 443);
            this.savetoword.Name = "savetoword";
            this.savetoword.Size = new System.Drawing.Size(107, 38);
            this.savetoword.TabIndex = 0;
            this.savetoword.Text = "保存到Word";
            this.savetoword.UseVisualStyleBackColor = true;
            this.savetoword.Click += new System.EventHandler(this.savetoword_Click);
            // 
            // ByBaiduEngner
            // 
            this.ByBaiduEngner.AutoSize = true;
            this.ByBaiduEngner.Checked = true;
            this.ByBaiduEngner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ByBaiduEngner.Location = new System.Drawing.Point(13, 421);
            this.ByBaiduEngner.Name = "ByBaiduEngner";
            this.ByBaiduEngner.Size = new System.Drawing.Size(114, 16);
            this.ByBaiduEngner.TabIndex = 5;
            this.ByBaiduEngner.Text = "使用百度OCR引擎";
            this.ByBaiduEngner.UseVisualStyleBackColor = true;
            // 
            // ByInnerEngner
            // 
            this.ByInnerEngner.AutoSize = true;
            this.ByInnerEngner.Location = new System.Drawing.Point(133, 421);
            this.ByInnerEngner.Name = "ByInnerEngner";
            this.ByInnerEngner.Size = new System.Drawing.Size(114, 16);
            this.ByInnerEngner.TabIndex = 5;
            this.ByInnerEngner.Text = "使用内置OCR引擎";
            this.ByInnerEngner.UseVisualStyleBackColor = true;
            // 
            // GetScreenOprator
            // 
            this.GetScreenOprator.Location = new System.Drawing.Point(126, 443);
            this.GetScreenOprator.Name = "GetScreenOprator";
            this.GetScreenOprator.Size = new System.Drawing.Size(107, 38);
            this.GetScreenOprator.TabIndex = 0;
            this.GetScreenOprator.Text = "选取屏幕";
            this.GetScreenOprator.UseVisualStyleBackColor = true;
            this.GetScreenOprator.Click += new System.EventHandler(this.GetScreenOprator_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // OCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 496);
            this.Controls.Add(this.ByInnerEngner);
            this.Controls.Add(this.ByBaiduEngner);
            this.Controls.Add(this.PBOCR);
            this.Controls.Add(this.ResultTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.savetoword);
            this.Controls.Add(this.GetScreenOprator);
            this.Controls.Add(this.ReadTarget);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(885, 535);
            this.MinimumSize = new System.Drawing.Size(885, 535);
            this.Name = "OCR";
            this.Text = "OCR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OCR_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadTarget;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ResultTest;
        private System.Windows.Forms.ProgressBar PBOCR;
        private System.Windows.Forms.Button savetoword;
        private System.Windows.Forms.CheckBox ByBaiduEngner;
        private System.Windows.Forms.CheckBox ByInnerEngner;
        private System.Windows.Forms.Button GetScreenOprator;
        private System.Windows.Forms.Timer timer;
    }
}

