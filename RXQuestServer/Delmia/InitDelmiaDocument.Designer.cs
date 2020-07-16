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
            this.NSTagGroup = new System.Windows.Forms.CheckBox();
            this.Fullint = new System.Windows.Forms.Button();
            this.SelectInit = new System.Windows.Forms.Button();
            this.SavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderInit = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.InitRobot = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StudWeld = new System.Windows.Forms.CheckBox();
            this.Glue = new System.Windows.Forms.CheckBox();
            this.PickAndUp = new System.Windows.Forms.CheckBox();
            this.RPWeld = new System.Windows.Forms.CheckBox();
            this.GPWeld = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ModelNumt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ELEID = new System.Windows.Forms.TextBox();
            this.RobotID = new System.Windows.Forms.TextBox();
            this.ModelName = new System.Windows.Forms.TextBox();
            this.ModelNum = new System.Windows.Forms.TextBox();
            this.RobotCtrlNum = new System.Windows.Forms.TextBox();
            this.BackForm = new System.Windows.Forms.Button();
            this.ELEADD = new System.Windows.Forms.Button();
            this.ELEREMOVE = new System.Windows.Forms.Button();
            this.Station_Group.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.Station_Group.Controls.Add(this.NSTagGroup);
            this.Station_Group.Location = new System.Drawing.Point(12, 120);
            this.Station_Group.Name = "Station_Group";
            this.Station_Group.Size = new System.Drawing.Size(814, 86);
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
            this.StationNum.TabIndex = 18;
            this.StationNum.Text = "8";
            this.StationNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NSTagGroup
            // 
            this.NSTagGroup.AutoSize = true;
            this.NSTagGroup.Location = new System.Drawing.Point(8, 56);
            this.NSTagGroup.Name = "NSTagGroup";
            this.NSTagGroup.Size = new System.Drawing.Size(96, 16);
            this.NSTagGroup.TabIndex = 19;
            this.NSTagGroup.Text = "包含TagGroup";
            this.NSTagGroup.UseVisualStyleBackColor = true;
            // 
            // Fullint
            // 
            this.Fullint.Location = new System.Drawing.Point(12, 353);
            this.Fullint.Name = "Fullint";
            this.Fullint.Size = new System.Drawing.Size(102, 38);
            this.Fullint.TabIndex = 11;
            this.Fullint.Text = "完全初始化";
            this.Fullint.UseVisualStyleBackColor = true;
            this.Fullint.Click += new System.EventHandler(this.Fullint_Click);
            // 
            // SelectInit
            // 
            this.SelectInit.Location = new System.Drawing.Point(120, 353);
            this.SelectInit.Name = "SelectInit";
            this.SelectInit.Size = new System.Drawing.Size(102, 38);
            this.SelectInit.TabIndex = 12;
            this.SelectInit.Text = "指定初始化";
            this.SelectInit.UseVisualStyleBackColor = true;
            this.SelectInit.Click += new System.EventHandler(this.SelectInit_Click);
            // 
            // SavePath
            // 
            this.SavePath.Location = new System.Drawing.Point(101, 313);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(725, 21);
            this.SavePath.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "设置存储路径:";
            // 
            // FolderInit
            // 
            this.FolderInit.Location = new System.Drawing.Point(228, 353);
            this.FolderInit.Name = "FolderInit";
            this.FolderInit.Size = new System.Drawing.Size(102, 38);
            this.FolderInit.TabIndex = 13;
            this.FolderInit.Text = "目录初始化";
            this.FolderInit.UseVisualStyleBackColor = true;
            this.FolderInit.Click += new System.EventHandler(this.FolderInit_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // InitRobot
            // 
            this.InitRobot.Location = new System.Drawing.Point(336, 353);
            this.InitRobot.Name = "InitRobot";
            this.InitRobot.Size = new System.Drawing.Size(102, 38);
            this.InitRobot.TabIndex = 14;
            this.InitRobot.Text = "机器人初始化";
            this.InitRobot.UseVisualStyleBackColor = true;
            this.InitRobot.Click += new System.EventHandler(this.InitRobot_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ELEREMOVE);
            this.groupBox1.Controls.Add(this.ELEADD);
            this.groupBox1.Controls.Add(this.StudWeld);
            this.groupBox1.Controls.Add(this.Glue);
            this.groupBox1.Controls.Add(this.PickAndUp);
            this.groupBox1.Controls.Add(this.RPWeld);
            this.groupBox1.Controls.Add(this.GPWeld);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ModelNumt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ELEID);
            this.groupBox1.Controls.Add(this.RobotID);
            this.groupBox1.Controls.Add(this.ModelName);
            this.groupBox1.Controls.Add(this.ModelNum);
            this.groupBox1.Controls.Add(this.RobotCtrlNum);
            this.groupBox1.Location = new System.Drawing.Point(12, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Robot_Group";
            // 
            // StudWeld
            // 
            this.StudWeld.AutoSize = true;
            this.StudWeld.Location = new System.Drawing.Point(609, 55);
            this.StudWeld.Name = "StudWeld";
            this.StudWeld.Size = new System.Drawing.Size(60, 16);
            this.StudWeld.TabIndex = 7;
            this.StudWeld.Text = "螺柱焊";
            this.StudWeld.UseVisualStyleBackColor = true;
            // 
            // Glue
            // 
            this.Glue.AutoSize = true;
            this.Glue.Location = new System.Drawing.Point(525, 55);
            this.Glue.Name = "Glue";
            this.Glue.Size = new System.Drawing.Size(48, 16);
            this.Glue.TabIndex = 6;
            this.Glue.Text = "涂胶";
            this.Glue.UseVisualStyleBackColor = true;
            // 
            // PickAndUp
            // 
            this.PickAndUp.AutoSize = true;
            this.PickAndUp.Checked = true;
            this.PickAndUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PickAndUp.Location = new System.Drawing.Point(432, 55);
            this.PickAndUp.Name = "PickAndUp";
            this.PickAndUp.Size = new System.Drawing.Size(48, 16);
            this.PickAndUp.TabIndex = 5;
            this.PickAndUp.Text = "搬运";
            this.PickAndUp.UseVisualStyleBackColor = true;
            // 
            // RPWeld
            // 
            this.RPWeld.AutoSize = true;
            this.RPWeld.Checked = true;
            this.RPWeld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RPWeld.Location = new System.Drawing.Point(348, 55);
            this.RPWeld.Name = "RPWeld";
            this.RPWeld.Size = new System.Drawing.Size(48, 16);
            this.RPWeld.TabIndex = 4;
            this.RPWeld.Text = "补焊";
            this.RPWeld.UseVisualStyleBackColor = true;
            // 
            // GPWeld
            // 
            this.GPWeld.AutoSize = true;
            this.GPWeld.Checked = true;
            this.GPWeld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GPWeld.Location = new System.Drawing.Point(259, 55);
            this.GPWeld.Name = "GPWeld";
            this.GPWeld.Size = new System.Drawing.Size(60, 16);
            this.GPWeld.TabIndex = 3;
            this.GPWeld.Text = "定位焊";
            this.GPWeld.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "设备编号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "机器人编号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "车型编号:";
            // 
            // ModelNumt
            // 
            this.ModelNumt.AutoSize = true;
            this.ModelNumt.Location = new System.Drawing.Point(72, 57);
            this.ModelNumt.Name = "ModelNumt";
            this.ModelNumt.Size = new System.Drawing.Size(59, 12);
            this.ModelNumt.TabIndex = 1;
            this.ModelNumt.Text = "车型数量:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "RobotController数量:";
            // 
            // ELEID
            // 
            this.ELEID.Location = new System.Drawing.Point(702, 19);
            this.ELEID.Name = "ELEID";
            this.ELEID.ReadOnly = true;
            this.ELEID.Size = new System.Drawing.Size(100, 21);
            this.ELEID.TabIndex = 2;
            this.ELEID.Text = "01";
            this.ELEID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ELEID.TextChanged += new System.EventHandler(this.RobotID_TextChanged);
            // 
            // RobotID
            // 
            this.RobotID.Location = new System.Drawing.Point(511, 19);
            this.RobotID.Name = "RobotID";
            this.RobotID.Size = new System.Drawing.Size(100, 21);
            this.RobotID.TabIndex = 1;
            this.RobotID.Text = "R11";
            this.RobotID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RobotID.TextChanged += new System.EventHandler(this.RobotID_TextChanged);
            // 
            // ModelName
            // 
            this.ModelName.Location = new System.Drawing.Point(320, 19);
            this.ModelName.Name = "ModelName";
            this.ModelName.Size = new System.Drawing.Size(100, 21);
            this.ModelName.TabIndex = 0;
            this.ModelName.Text = "T15";
            this.ModelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ModelName.TextChanged += new System.EventHandler(this.ModelName_TextChanged);
            // 
            // ModelNum
            // 
            this.ModelNum.Location = new System.Drawing.Point(137, 53);
            this.ModelNum.Name = "ModelNum";
            this.ModelNum.Size = new System.Drawing.Size(100, 21);
            this.ModelNum.TabIndex = 17;
            this.ModelNum.Text = "1";
            this.ModelNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RobotCtrlNum
            // 
            this.RobotCtrlNum.Location = new System.Drawing.Point(141, 19);
            this.RobotCtrlNum.Name = "RobotCtrlNum";
            this.RobotCtrlNum.Size = new System.Drawing.Size(100, 21);
            this.RobotCtrlNum.TabIndex = 16;
            this.RobotCtrlNum.Text = "10";
            this.RobotCtrlNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BackForm
            // 
            this.BackForm.Location = new System.Drawing.Point(724, 353);
            this.BackForm.Name = "BackForm";
            this.BackForm.Size = new System.Drawing.Size(102, 38);
            this.BackForm.TabIndex = 15;
            this.BackForm.Text = "返回上一级";
            this.BackForm.UseVisualStyleBackColor = true;
            // 
            // ELEADD
            // 
            this.ELEADD.Location = new System.Drawing.Point(702, 51);
            this.ELEADD.Name = "ELEADD";
            this.ELEADD.Size = new System.Drawing.Size(50, 23);
            this.ELEADD.TabIndex = 8;
            this.ELEADD.Text = "+1";
            this.ELEADD.UseVisualStyleBackColor = true;
            this.ELEADD.Click += new System.EventHandler(this.ELEADD_Click);
            // 
            // ELEREMOVE
            // 
            this.ELEREMOVE.Location = new System.Drawing.Point(752, 51);
            this.ELEREMOVE.Name = "ELEREMOVE";
            this.ELEREMOVE.Size = new System.Drawing.Size(50, 23);
            this.ELEREMOVE.TabIndex = 9;
            this.ELEREMOVE.Text = "-1";
            this.ELEREMOVE.UseVisualStyleBackColor = true;
            this.ELEREMOVE.Click += new System.EventHandler(this.ELEREMOVE_Click);
            // 
            // InitDelmiaDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 429);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.BackForm);
            this.Controls.Add(this.InitRobot);
            this.Controls.Add(this.FolderInit);
            this.Controls.Add(this.SelectInit);
            this.Controls.Add(this.Fullint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Station_Group);
            this.Controls.Add(this.LayoutGroup);
            this.Controls.Add(this.SM_Group);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(854, 468);
            this.MinimumSize = new System.Drawing.Size(854, 468);
            this.Name = "InitDelmiaDocument";
            this.Text = "InitDelmiaDocument";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InitDelmiaDocument_FormClosed);
            this.Station_Group.ResumeLayout(false);
            this.Station_Group.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button InitRobot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RobotCtrlNum;
        private System.Windows.Forms.CheckBox StudWeld;
        private System.Windows.Forms.CheckBox Glue;
        private System.Windows.Forms.CheckBox PickAndUp;
        private System.Windows.Forms.CheckBox RPWeld;
        private System.Windows.Forms.CheckBox GPWeld;
        private System.Windows.Forms.Label ModelNumt;
        private System.Windows.Forms.TextBox ModelNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ModelName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RobotID;
        private System.Windows.Forms.CheckBox NSTagGroup;
        private System.Windows.Forms.Button BackForm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ELEID;
        private System.Windows.Forms.Button ELEREMOVE;
        private System.Windows.Forms.Button ELEADD;
    }
}