﻿namespace OcrCenter
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultTest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ReadTarget
            // 
            this.ReadTarget.Location = new System.Drawing.Point(396, 391);
            this.ReadTarget.Name = "ReadTarget";
            this.ReadTarget.Size = new System.Drawing.Size(107, 38);
            this.ReadTarget.TabIndex = 0;
            this.ReadTarget.Text = "读取对象";
            this.ReadTarget.UseVisualStyleBackColor = true;
            this.ReadTarget.Click += new System.EventHandler(this.ReadTarget_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "\".Png图片文件|*.PNG|.PDF文件|*.pdf\"\"";
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(70, 12);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(433, 21);
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
            this.ResultTest.Size = new System.Drawing.Size(490, 343);
            this.ResultTest.TabIndex = 3;
            // 
            // OCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 441);
            this.Controls.Add(this.ResultTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.ReadTarget);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OCR";
            this.Text = "OCR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadTarget;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ResultTest;
    }
}
