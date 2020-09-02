namespace GetYeccSKey
{
    partial class GetYeccSKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetYeccSKey));
            this.UserApplicatCode = new System.Windows.Forms.TextBox();
            this.KeyCode = new System.Windows.Forms.TextBox();
            this.regValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GetUserKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserApplicatCode
            // 
            this.UserApplicatCode.Location = new System.Drawing.Point(16, 45);
            this.UserApplicatCode.Multiline = true;
            this.UserApplicatCode.Name = "UserApplicatCode";
            this.UserApplicatCode.Size = new System.Drawing.Size(645, 104);
            this.UserApplicatCode.TabIndex = 0;
            // 
            // KeyCode
            // 
            this.KeyCode.Location = new System.Drawing.Point(16, 208);
            this.KeyCode.Multiline = true;
            this.KeyCode.Name = "KeyCode";
            this.KeyCode.ReadOnly = true;
            this.KeyCode.Size = new System.Drawing.Size(645, 121);
            this.KeyCode.TabIndex = 0;
            // 
            // regValue
            // 
            this.regValue.AutoSize = true;
            this.regValue.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regValue.Location = new System.Drawing.Point(12, 9);
            this.regValue.Name = "regValue";
            this.regValue.Size = new System.Drawing.Size(142, 24);
            this.regValue.TabIndex = 2;
            this.regValue.Text = "用户申请码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "注册码:";
            // 
            // GetUserKey
            // 
            this.GetUserKey.Location = new System.Drawing.Point(463, 346);
            this.GetUserKey.Name = "GetUserKey";
            this.GetUserKey.Size = new System.Drawing.Size(198, 56);
            this.GetUserKey.TabIndex = 3;
            this.GetUserKey.Text = "执行转换";
            this.GetUserKey.UseVisualStyleBackColor = true;
            this.GetUserKey.Click += new System.EventHandler(this.GetUserKey_Click);
            // 
            // GetYeccSKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(673, 417);
            this.Controls.Add(this.GetUserKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regValue);
            this.Controls.Add(this.KeyCode);
            this.Controls.Add(this.UserApplicatCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(689, 456);
            this.MinimumSize = new System.Drawing.Size(689, 456);
            this.Name = "GetYeccSKey";
            this.Text = "GetYeccSKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserApplicatCode;
        private System.Windows.Forms.TextBox KeyCode;
        private System.Windows.Forms.Label regValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GetUserKey;
    }
}

