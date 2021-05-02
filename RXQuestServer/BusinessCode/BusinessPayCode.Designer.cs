
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessPayCode));
            this.WxPayCode = new System.Windows.Forms.PictureBox();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.TextBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 67);
            this.button1.TabIndex = 3;
            this.button1.Text = "已有注册码[点击]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BusinessPayCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(813, 588);
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
    }
}