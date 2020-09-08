namespace WordToAix
{
    partial class WordToAix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordToAix));
            this.TextPicture = new System.Windows.Forms.PictureBox();
            this.OpratorZero = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Ypix = new System.Windows.Forms.TextBox();
            this.Xpix = new System.Windows.Forms.TextBox();
            this.TargetText = new System.Windows.Forms.TextBox();
            this.SaveAix = new System.Windows.Forms.Button();
            this.DoTranslate = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TextPicture)).BeginInit();
            this.OpratorZero.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextPicture
            // 
            this.TextPicture.Location = new System.Drawing.Point(12, 12);
            this.TextPicture.Name = "TextPicture";
            this.TextPicture.Size = new System.Drawing.Size(700, 500);
            this.TextPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TextPicture.TabIndex = 0;
            this.TextPicture.TabStop = false;
            // 
            // OpratorZero
            // 
            this.OpratorZero.Controls.Add(this.label2);
            this.OpratorZero.Controls.Add(this.label1);
            this.OpratorZero.Controls.Add(this.Ypix);
            this.OpratorZero.Controls.Add(this.Xpix);
            this.OpratorZero.Controls.Add(this.TargetText);
            this.OpratorZero.Controls.Add(this.SaveAix);
            this.OpratorZero.Controls.Add(this.DoTranslate);
            this.OpratorZero.Location = new System.Drawing.Point(13, 519);
            this.OpratorZero.Name = "OpratorZero";
            this.OpratorZero.Size = new System.Drawing.Size(698, 100);
            this.OpratorZero.TabIndex = 1;
            this.OpratorZero.TabStop = false;
            this.OpratorZero.Text = "操作区域";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(587, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y_PIX:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "X_PIX:";
            // 
            // Ypix
            // 
            this.Ypix.Location = new System.Drawing.Point(634, 70);
            this.Ypix.Name = "Ypix";
            this.Ypix.Size = new System.Drawing.Size(58, 21);
            this.Ypix.TabIndex = 2;
            this.Ypix.Text = "500";
            this.Ypix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Xpix
            // 
            this.Xpix.Location = new System.Drawing.Point(523, 70);
            this.Xpix.Name = "Xpix";
            this.Xpix.Size = new System.Drawing.Size(58, 21);
            this.Xpix.TabIndex = 2;
            this.Xpix.Text = "500";
            this.Xpix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TargetText
            // 
            this.TargetText.Location = new System.Drawing.Point(6, 20);
            this.TargetText.Multiline = true;
            this.TargetText.Name = "TargetText";
            this.TargetText.Size = new System.Drawing.Size(464, 73);
            this.TargetText.TabIndex = 1;
            // 
            // SaveAix
            // 
            this.SaveAix.Location = new System.Drawing.Point(587, 20);
            this.SaveAix.Name = "SaveAix";
            this.SaveAix.Size = new System.Drawing.Size(105, 45);
            this.SaveAix.TabIndex = 0;
            this.SaveAix.Text = "另存坐标";
            this.SaveAix.UseVisualStyleBackColor = true;
            this.SaveAix.Click += new System.EventHandler(this.SaveAix_Click);
            // 
            // DoTranslate
            // 
            this.DoTranslate.Location = new System.Drawing.Point(476, 20);
            this.DoTranslate.Name = "DoTranslate";
            this.DoTranslate.Size = new System.Drawing.Size(105, 45);
            this.DoTranslate.TabIndex = 0;
            this.DoTranslate.Text = "执行转换";
            this.DoTranslate.UseVisualStyleBackColor = true;
            this.DoTranslate.Click += new System.EventHandler(this.DoTranslate_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // WordToAix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 631);
            this.Controls.Add(this.OpratorZero);
            this.Controls.Add(this.TextPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(739, 670);
            this.MinimumSize = new System.Drawing.Size(739, 670);
            this.Name = "WordToAix";
            this.Text = "文字转点阵";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WordToAix_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TextPicture)).EndInit();
            this.OpratorZero.ResumeLayout(false);
            this.OpratorZero.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TextPicture;
        private System.Windows.Forms.GroupBox OpratorZero;
        private System.Windows.Forms.TextBox TargetText;
        private System.Windows.Forms.Button SaveAix;
        private System.Windows.Forms.Button DoTranslate;
        private System.Windows.Forms.TextBox Ypix;
        private System.Windows.Forms.TextBox Xpix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
    }
}

