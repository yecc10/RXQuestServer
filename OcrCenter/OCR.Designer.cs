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
            this.ReadTarget.Location = new System.Drawing.Point(20, 664);
            this.ReadTarget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReadTarget.Name = "ReadTarget";
            this.ReadTarget.Size = new System.Drawing.Size(160, 57);
            this.ReadTarget.TabIndex = 0;
            this.ReadTarget.Text = "读取文件";
            this.ReadTarget.UseVisualStyleBackColor = true;
            this.ReadTarget.Click += new System.EventHandler(this.ReadTarget_Click);
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(105, 18);
            this.FilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(1180, 28);
            this.FilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件地址:";
            // 
            // ResultTest
            // 
            this.ResultTest.Location = new System.Drawing.Point(20, 63);
            this.ResultTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResultTest.Multiline = true;
            this.ResultTest.Name = "ResultTest";
            this.ResultTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultTest.Size = new System.Drawing.Size(1266, 512);
            this.ResultTest.TabIndex = 3;
            // 
            // PBOCR
            // 
            this.PBOCR.Location = new System.Drawing.Point(20, 586);
            this.PBOCR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PBOCR.Name = "PBOCR";
            this.PBOCR.Size = new System.Drawing.Size(1268, 34);
            this.PBOCR.TabIndex = 4;
            // 
            // savetoword
            // 
            this.savetoword.Location = new System.Drawing.Point(1126, 664);
            this.savetoword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.savetoword.Name = "savetoword";
            this.savetoword.Size = new System.Drawing.Size(160, 57);
            this.savetoword.TabIndex = 0;
            this.savetoword.Text = "保存到Word";
            this.savetoword.UseVisualStyleBackColor = true;
            this.savetoword.Click += new System.EventHandler(this.savetoword_Click);
            // 
            // ByBaiduEngner
            // 
            this.ByBaiduEngner.AutoSize = true;
            this.ByBaiduEngner.Location = new System.Drawing.Point(20, 632);
            this.ByBaiduEngner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ByBaiduEngner.Name = "ByBaiduEngner";
            this.ByBaiduEngner.Size = new System.Drawing.Size(169, 22);
            this.ByBaiduEngner.TabIndex = 5;
            this.ByBaiduEngner.Text = "使用百度OCR引擎";
            this.ByBaiduEngner.UseVisualStyleBackColor = true;
            // 
            // ByInnerEngner
            // 
            this.ByInnerEngner.AutoSize = true;
            this.ByInnerEngner.Checked = true;
            this.ByInnerEngner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ByInnerEngner.Location = new System.Drawing.Point(200, 632);
            this.ByInnerEngner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ByInnerEngner.Name = "ByInnerEngner";
            this.ByInnerEngner.Size = new System.Drawing.Size(169, 22);
            this.ByInnerEngner.TabIndex = 5;
            this.ByInnerEngner.Text = "使用内置OCR引擎";
            this.ByInnerEngner.UseVisualStyleBackColor = true;
            // 
            // GetScreenOprator
            // 
            this.GetScreenOprator.Location = new System.Drawing.Point(189, 664);
            this.GetScreenOprator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GetScreenOprator.Name = "GetScreenOprator";
            this.GetScreenOprator.Size = new System.Drawing.Size(160, 57);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 734);
            this.Controls.Add(this.ByInnerEngner);
            this.Controls.Add(this.ByBaiduEngner);
            this.Controls.Add(this.PBOCR);
            this.Controls.Add(this.ResultTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.savetoword);
            this.Controls.Add(this.GetScreenOprator);
            this.Controls.Add(this.ReadTarget);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(0, 790);
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

