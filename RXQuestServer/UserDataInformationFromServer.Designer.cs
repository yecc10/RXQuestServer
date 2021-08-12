
namespace RFTechnology
{
    partial class UserDataInformationFromServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDataInformationFromServer));
            this.MserchFromServer = new System.Windows.Forms.Button();
            this.CName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GetedDays = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LastUseDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ValidDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EndPayTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MserchFromServer
            // 
            this.MserchFromServer.Location = new System.Drawing.Point(302, 295);
            this.MserchFromServer.Name = "MserchFromServer";
            this.MserchFromServer.Size = new System.Drawing.Size(144, 43);
            this.MserchFromServer.TabIndex = 0;
            this.MserchFromServer.Text = "手动查询";
            this.MserchFromServer.UseVisualStyleBackColor = true;
            this.MserchFromServer.Click += new System.EventHandler(this.MserchFromServer_Click);
            // 
            // CName
            // 
            this.CName.Location = new System.Drawing.Point(180, 17);
            this.CName.Name = "CName";
            this.CName.ReadOnly = true;
            this.CName.Size = new System.Drawing.Size(266, 21);
            this.CName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "计算名:";
            // 
            // CID
            // 
            this.CID.Location = new System.Drawing.Point(180, 56);
            this.CID.Name = "CID";
            this.CID.ReadOnly = true;
            this.CID.Size = new System.Drawing.Size(266, 21);
            this.CID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "电脑指纹:";
            // 
            // CreateTime
            // 
            this.CreateTime.Location = new System.Drawing.Point(180, 95);
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Size = new System.Drawing.Size(266, 21);
            this.CreateTime.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "首次注册日期:";
            // 
            // GetedDays
            // 
            this.GetedDays.Location = new System.Drawing.Point(180, 134);
            this.GetedDays.Name = "GetedDays";
            this.GetedDays.ReadOnly = true;
            this.GetedDays.Size = new System.Drawing.Size(266, 21);
            this.GetedDays.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "购买天数:";
            // 
            // LastUseDate
            // 
            this.LastUseDate.Location = new System.Drawing.Point(180, 173);
            this.LastUseDate.Name = "LastUseDate";
            this.LastUseDate.ReadOnly = true;
            this.LastUseDate.Size = new System.Drawing.Size(266, 21);
            this.LastUseDate.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "上次使用日期:";
            // 
            // ValidDate
            // 
            this.ValidDate.Location = new System.Drawing.Point(180, 212);
            this.ValidDate.Name = "ValidDate";
            this.ValidDate.ReadOnly = true;
            this.ValidDate.Size = new System.Drawing.Size(266, 21);
            this.ValidDate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(23, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "软件到期日期:";
            // 
            // EndPayTime
            // 
            this.EndPayTime.Location = new System.Drawing.Point(180, 251);
            this.EndPayTime.Name = "EndPayTime";
            this.EndPayTime.ReadOnly = true;
            this.EndPayTime.Size = new System.Drawing.Size(266, 21);
            this.EndPayTime.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(23, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "最终下单日期:";
            // 
            // UserDataInformationFromServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(478, 354);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndPayTime);
            this.Controls.Add(this.ValidDate);
            this.Controls.Add(this.LastUseDate);
            this.Controls.Add(this.GetedDays);
            this.Controls.Add(this.CreateTime);
            this.Controls.Add(this.CID);
            this.Controls.Add(this.CName);
            this.Controls.Add(this.MserchFromServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserDataInformationFromServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户服务器信息查询";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MserchFromServer;
        private System.Windows.Forms.TextBox CName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CreateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GetedDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LastUseDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ValidDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EndPayTime;
        private System.Windows.Forms.Label label7;
    }
}