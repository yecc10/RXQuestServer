
namespace RFTechnology.BusinessCode
{
    partial class BusinessPayCode
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessPayCode));
            this.WxPayCode = new System.Windows.Forms.PictureBox();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.purchase3 = new System.Windows.Forms.RadioButton();
            this.purchase6 = new System.Windows.Forms.RadioButton();
            this.purchase12 = new System.Windows.Forms.RadioButton();
            this.purchase24 = new System.Windows.Forms.RadioButton();
            this.purchase36 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PayFinishedGetResult = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WxPayCode)).BeginInit();
            this.SuspendLayout();
            // 
            // WxPayCode
            // 
            this.WxPayCode.BackColor = System.Drawing.Color.Transparent;
            this.WxPayCode.InitialImage = global::RFTechnology.Properties.Resources.Document_refresh;
            this.WxPayCode.Location = new System.Drawing.Point(236, 27);
            this.WxPayCode.Name = "WxPayCode";
            this.WxPayCode.Size = new System.Drawing.Size(350, 350);
            this.WxPayCode.TabIndex = 1;
            this.WxPayCode.TabStop = false;
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(12, 395);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(789, 77);
            this.TextBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 67);
            this.button1.TabIndex = 6;
            this.button1.Text = "已有注册码[点击]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // purchase3
            // 
            this.purchase3.AutoSize = true;
            this.purchase3.Checked = true;
            this.purchase3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.purchase3.Location = new System.Drawing.Point(22, 542);
            this.purchase3.Name = "purchase3";
            this.purchase3.Size = new System.Drawing.Size(137, 18);
            this.purchase3.TabIndex = 1;
            this.purchase3.TabStop = true;
            this.purchase3.Text = "购买3个月【9折】";
            this.purchase3.UseVisualStyleBackColor = true;
            this.purchase3.CheckedChanged += new System.EventHandler(this.purchase3_CheckedChanged);
            // 
            // purchase6
            // 
            this.purchase6.AutoSize = true;
            this.purchase6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.purchase6.Location = new System.Drawing.Point(182, 542);
            this.purchase6.Name = "purchase6";
            this.purchase6.Size = new System.Drawing.Size(144, 18);
            this.purchase6.TabIndex = 2;
            this.purchase6.Text = "购买6个月【85折】";
            this.purchase6.UseVisualStyleBackColor = true;
            this.purchase6.CheckedChanged += new System.EventHandler(this.purchase6_CheckedChanged);
            // 
            // purchase12
            // 
            this.purchase12.AutoSize = true;
            this.purchase12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.purchase12.Location = new System.Drawing.Point(348, 542);
            this.purchase12.Name = "purchase12";
            this.purchase12.Size = new System.Drawing.Size(123, 18);
            this.purchase12.TabIndex = 3;
            this.purchase12.Text = "购买1年【8折】";
            this.purchase12.UseVisualStyleBackColor = true;
            this.purchase12.CheckedChanged += new System.EventHandler(this.purchase12_CheckedChanged);
            // 
            // purchase24
            // 
            this.purchase24.AutoSize = true;
            this.purchase24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.purchase24.Location = new System.Drawing.Point(496, 542);
            this.purchase24.Name = "purchase24";
            this.purchase24.Size = new System.Drawing.Size(144, 18);
            this.purchase24.TabIndex = 4;
            this.purchase24.Text = "购买个2年【75折】";
            this.purchase24.UseVisualStyleBackColor = true;
            this.purchase24.CheckedChanged += new System.EventHandler(this.purchase24_CheckedChanged);
            // 
            // purchase36
            // 
            this.purchase36.AutoSize = true;
            this.purchase36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.purchase36.Location = new System.Drawing.Point(662, 542);
            this.purchase36.Name = "purchase36";
            this.purchase36.Size = new System.Drawing.Size(123, 18);
            this.purchase36.TabIndex = 4;
            this.purchase36.Text = "购买3年【7折】";
            this.purchase36.UseVisualStyleBackColor = true;
            this.purchase36.CheckedChanged += new System.EventHandler(this.purchase36_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(16, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "【折后】售价：81 ¥";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(169, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "【折后】售价：153 ¥";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(329, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "【折后】售价：288 ¥";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(489, 512);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "【折后】售价：510 ¥";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Aqua;
            this.label5.Location = new System.Drawing.Point(649, 512);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "【折后】售价：756 ¥";
            // 
            // PayFinishedGetResult
            // 
            this.PayFinishedGetResult.Location = new System.Drawing.Point(592, 195);
            this.PayFinishedGetResult.Name = "PayFinishedGetResult";
            this.PayFinishedGetResult.Size = new System.Drawing.Size(181, 67);
            this.PayFinishedGetResult.TabIndex = 6;
            this.PayFinishedGetResult.Text = "已支付/手动刷新";
            this.PayFinishedGetResult.UseVisualStyleBackColor = true;
            this.PayFinishedGetResult.Click += new System.EventHandler(this.PayFinishedGetResult_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // BusinessPayCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(813, 588);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.purchase36);
            this.Controls.Add(this.purchase24);
            this.Controls.Add(this.purchase12);
            this.Controls.Add(this.purchase6);
            this.Controls.Add(this.purchase3);
            this.Controls.Add(this.PayFinishedGetResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.WxPayCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BusinessPayCode";
            this.Text = "BusinessPayCode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BusinessPayCode_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.WxPayCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WxPayCode;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton purchase3;
        private System.Windows.Forms.RadioButton purchase6;
        private System.Windows.Forms.RadioButton purchase12;
        private System.Windows.Forms.RadioButton purchase24;
        private System.Windows.Forms.RadioButton purchase36;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button PayFinishedGetResult;
        private System.Windows.Forms.Timer timer;
    }
}