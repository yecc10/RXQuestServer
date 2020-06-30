namespace RXQuestServer.Delmia
{
    partial class InitDelmiaDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitDelmiaDocument));
            this.SM_Group = new System.Windows.Forms.GroupBox();
            this.LayoutGroup = new System.Windows.Forms.GroupBox();
            this.Station_Group = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StationNum = new System.Windows.Forms.TextBox();
            this.Fullint = new System.Windows.Forms.Button();
            this.SelectInit = new System.Windows.Forms.Button();
            this.SavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderInit = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Station_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // SM_Group
            // 
            this.SM_Group.Location = new System.Drawing.Point(12, 12);
            this.SM_Group.Name = "SM_Group";
            this.SM_Group.Size = new System.Drawing.Size(814, 48);
            this.SM_Group.TabIndex = 0;
            this.SM_Group.TabStop = false;
            this.SM_Group.Text = "SM_Group";
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Location = new System.Drawing.Point(12, 66);
            this.LayoutGroup.Name = "LayoutGroup";
            this.LayoutGroup.Size = new System.Drawing.Size(814, 48);
            this.LayoutGroup.TabIndex = 0;
            this.LayoutGroup.TabStop = false;
            this.LayoutGroup.Text = "LayoutGroup";
            // 
            // Station_Group
            // 
            this.Station_Group.Controls.Add(this.label2);
            this.Station_Group.Controls.Add(this.StationNum);
            this.Station_Group.Location = new System.Drawing.Point(12, 120);
            this.Station_Group.Name = "Station_Group";
            this.Station_Group.Size = new System.Drawing.Size(814, 173);
            this.Station_Group.TabIndex = 0;
            this.Station_Group.TabStop = false;
            this.Station_Group.Text = "Station_Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "工位数:";
            // 
            // StationNum
            // 
            this.StationNum.Location = new System.Drawing.Point(59, 19);
            this.StationNum.Name = "StationNum";
            this.StationNum.Size = new System.Drawing.Size(100, 21);
            this.StationNum.TabIndex = 0;
            this.StationNum.Text = "8";
            this.StationNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Fullint
            // 
            this.Fullint.Location = new System.Drawing.Point(12, 326);
            this.Fullint.Name = "Fullint";
            this.Fullint.Size = new System.Drawing.Size(102, 38);
            this.Fullint.TabIndex = 1;
            this.Fullint.Text = "完全初始化";
            this.Fullint.UseVisualStyleBackColor = true;
            this.Fullint.Click += new System.EventHandler(this.Fullint_Click);
            // 
            // SelectInit
            // 
            this.SelectInit.Location = new System.Drawing.Point(120, 326);
            this.SelectInit.Name = "SelectInit";
            this.SelectInit.Size = new System.Drawing.Size(102, 38);
            this.SelectInit.TabIndex = 1;
            this.SelectInit.Text = "指定初始化";
            this.SelectInit.UseVisualStyleBackColor = true;
            this.SelectInit.Click += new System.EventHandler(this.SelectInit_Click);
            // 
            // SavePath
            // 
            this.SavePath.Location = new System.Drawing.Point(101, 299);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(725, 21);
            this.SavePath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "设置存储路径:";
            // 
            // FolderInit
            // 
            this.FolderInit.Location = new System.Drawing.Point(228, 326);
            this.FolderInit.Name = "FolderInit";
            this.FolderInit.Size = new System.Drawing.Size(102, 38);
            this.FolderInit.TabIndex = 1;
            this.FolderInit.Text = "目录初始化";
            this.FolderInit.UseVisualStyleBackColor = true;
            this.FolderInit.Click += new System.EventHandler(this.FolderInit_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // InitDelmiaDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 429);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.FolderInit);
            this.Controls.Add(this.SelectInit);
            this.Controls.Add(this.Fullint);
            this.Controls.Add(this.Station_Group);
            this.Controls.Add(this.LayoutGroup);
            this.Controls.Add(this.SM_Group);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InitDelmiaDocument";
            this.Text = "InitDelmiaDocument";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InitDelmiaDocument_FormClosed);
            this.Station_Group.ResumeLayout(false);
            this.Station_Group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SM_Group;
        private System.Windows.Forms.GroupBox LayoutGroup;
        private System.Windows.Forms.GroupBox Station_Group;
        private System.Windows.Forms.Button Fullint;
        private System.Windows.Forms.Button SelectInit;
        private System.Windows.Forms.TextBox SavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StationNum;
        private System.Windows.Forms.Button FolderInit;
        private System.Windows.Forms.Timer timer;
    }
}