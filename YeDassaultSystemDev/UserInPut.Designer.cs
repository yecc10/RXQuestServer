namespace YeDassaultSystemDev
{
    partial class UserInPut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInPut));
            this.UserLable = new System.Windows.Forms.Label();
            this.UserValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserLable
            // 
            this.UserLable.AutoSize = true;
            this.UserLable.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserLable.Location = new System.Drawing.Point(12, 21);
            this.UserLable.Name = "UserLable";
            this.UserLable.Size = new System.Drawing.Size(114, 19);
            this.UserLable.TabIndex = 0;
            this.UserLable.Text = "请输入名称:";
            this.UserLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserValue
            // 
            this.UserValue.Font = new System.Drawing.Font("宋体", 14.25F);
            this.UserValue.Location = new System.Drawing.Point(16, 59);
            this.UserValue.Name = "UserValue";
            this.UserValue.Size = new System.Drawing.Size(387, 29);
            this.UserValue.TabIndex = 1;
            // 
            // UserInPut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(415, 110);
            this.Controls.Add(this.UserValue);
            this.Controls.Add(this.UserLable);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInPut";
            this.Text = "UserInPut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label UserLable;
        public System.Windows.Forms.TextBox UserValue;
    }
}