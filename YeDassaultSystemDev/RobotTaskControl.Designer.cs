namespace YeDassaultSystemDev
{
    partial class RobotTaskControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobotTaskControl));
            this.label1 = new System.Windows.Forms.Label();
            this.selectedrobotTaskName = new System.Windows.Forms.TextBox();
            this.reSelectRobotTask = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CompayIco = new System.Windows.Forms.PictureBox();
            this.taskNameTotalNum = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.taskNameTagName = new System.Windows.Forms.TextBox();
            this.taskNameRearStr = new System.Windows.Forms.TextBox();
            this.taskNameFrontStr = new System.Windows.Forms.TextBox();
            this.taskNameStartNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.taskNameNumStep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TaskListA = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TaskListB = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.onlyForVia = new System.Windows.Forms.Button();
            this.onlyForProcess = new System.Windows.Forms.Button();
            this.clearAll = new System.Windows.Forms.Button();
            this.allTaget = new System.Windows.Forms.Button();
            this.WorkToBefore = new System.Windows.Forms.Button();
            this.OutTargetListAix = new System.Windows.Forms.Button();
            this.goBackToFather = new System.Windows.Forms.Button();
            this.Pbar = new System.Windows.Forms.ProgressBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ProcessTaskAddress = new System.Windows.Forms.ListBox();
            this.reSelectRobot = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompayIco)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器人程序:";
            // 
            // selectedrobotTaskName
            // 
            this.selectedrobotTaskName.Location = new System.Drawing.Point(83, 25);
            this.selectedrobotTaskName.Name = "selectedrobotTaskName";
            this.selectedrobotTaskName.ReadOnly = true;
            this.selectedrobotTaskName.Size = new System.Drawing.Size(290, 21);
            this.selectedrobotTaskName.TabIndex = 1;
            this.selectedrobotTaskName.Text = "Please Select a Robot Task";
            // 
            // reSelectRobotTask
            // 
            this.reSelectRobotTask.Location = new System.Drawing.Point(379, 11);
            this.reSelectRobotTask.Name = "reSelectRobotTask";
            this.reSelectRobotTask.Size = new System.Drawing.Size(118, 48);
            this.reSelectRobotTask.TabIndex = 2;
            this.reSelectRobotTask.Text = "选择目标Task";
            this.reSelectRobotTask.UseVisualStyleBackColor = true;
            this.reSelectRobotTask.Click += new System.EventHandler(this.reSelectRobotTask_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.reSelectRobot);
            this.groupBox1.Controls.Add(this.reSelectRobotTask);
            this.groupBox1.Controls.Add(this.selectedrobotTaskName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目标选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CompayIco);
            this.groupBox2.Controls.Add(this.taskNameTotalNum);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.taskNameTagName);
            this.groupBox2.Controls.Add(this.taskNameRearStr);
            this.groupBox2.Controls.Add(this.taskNameFrontStr);
            this.groupBox2.Controls.Add(this.taskNameStartNum);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.taskNameNumStep);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 142);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "标签设置";
            // 
            // CompayIco
            // 
            this.CompayIco.Image = global::YeDassaultSystemDev.Properties.Resources.tp;
            this.CompayIco.InitialImage = global::YeDassaultSystemDev.Properties.Resources.tp;
            this.CompayIco.Location = new System.Drawing.Point(506, 12);
            this.CompayIco.Name = "CompayIco";
            this.CompayIco.Size = new System.Drawing.Size(116, 116);
            this.CompayIco.TabIndex = 3;
            this.CompayIco.TabStop = false;
            this.CompayIco.WaitOnLoad = true;
            // 
            // taskNameTotalNum
            // 
            this.taskNameTotalNum.DisplayMember = "1";
            this.taskNameTotalNum.FormattingEnabled = true;
            this.taskNameTotalNum.Items.AddRange(new object[] {
            "00",
            "000",
            "0000"});
            this.taskNameTotalNum.Location = new System.Drawing.Point(90, 81);
            this.taskNameTotalNum.Name = "taskNameTotalNum";
            this.taskNameTotalNum.Size = new System.Drawing.Size(107, 20);
            this.taskNameTotalNum.TabIndex = 2;
            this.taskNameTotalNum.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "新的TagName:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "编号后缀:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "位数:";
            // 
            // taskNameTagName
            // 
            this.taskNameTagName.Location = new System.Drawing.Point(90, 107);
            this.taskNameTagName.Name = "taskNameTagName";
            this.taskNameTagName.Size = new System.Drawing.Size(409, 21);
            this.taskNameTagName.TabIndex = 1;
            this.taskNameTagName.Text = "LHP";
            // 
            // taskNameRearStr
            // 
            this.taskNameRearStr.Location = new System.Drawing.Point(391, 80);
            this.taskNameRearStr.Name = "taskNameRearStr";
            this.taskNameRearStr.Size = new System.Drawing.Size(108, 21);
            this.taskNameRearStr.TabIndex = 1;
            this.taskNameRearStr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // taskNameFrontStr
            // 
            this.taskNameFrontStr.Location = new System.Drawing.Point(391, 56);
            this.taskNameFrontStr.Name = "taskNameFrontStr";
            this.taskNameFrontStr.Size = new System.Drawing.Size(108, 21);
            this.taskNameFrontStr.TabIndex = 1;
            this.taskNameFrontStr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // taskNameStartNum
            // 
            this.taskNameStartNum.Location = new System.Drawing.Point(90, 56);
            this.taskNameStartNum.Name = "taskNameStartNum";
            this.taskNameStartNum.Size = new System.Drawing.Size(108, 21);
            this.taskNameStartNum.TabIndex = 1;
            this.taskNameStartNum.Text = "10";
            this.taskNameStartNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "编号前缀:";
            // 
            // taskNameNumStep
            // 
            this.taskNameNumStep.Location = new System.Drawing.Point(90, 29);
            this.taskNameNumStep.Name = "taskNameNumStep";
            this.taskNameNumStep.Size = new System.Drawing.Size(108, 21);
            this.taskNameNumStep.TabIndex = 1;
            this.taskNameNumStep.Text = "5";
            this.taskNameNumStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "起始编号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "跨步计数:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(12, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(630, 222);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择要重命名的Tag(s)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TaskListA);
            this.groupBox5.Location = new System.Drawing.Point(258, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(180, 190);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Task地址";
            // 
            // TaskListA
            // 
            this.TaskListA.FormattingEnabled = true;
            this.TaskListA.ItemHeight = 12;
            this.TaskListA.Location = new System.Drawing.Point(7, 21);
            this.TaskListA.Name = "TaskListA";
            this.TaskListA.Size = new System.Drawing.Size(167, 160);
            this.TaskListA.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TaskListB);
            this.groupBox4.Location = new System.Drawing.Point(444, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 190);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "目标Task清单";
            // 
            // TaskListB
            // 
            this.TaskListB.FormattingEnabled = true;
            this.TaskListB.ItemHeight = 12;
            this.TaskListB.Location = new System.Drawing.Point(7, 21);
            this.TaskListB.Name = "TaskListB";
            this.TaskListB.Size = new System.Drawing.Size(167, 160);
            this.TaskListB.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.onlyForVia);
            this.groupBox6.Controls.Add(this.onlyForProcess);
            this.groupBox6.Controls.Add(this.clearAll);
            this.groupBox6.Controls.Add(this.allTaget);
            this.groupBox6.Location = new System.Drawing.Point(12, 459);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(630, 65);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "快速选择";
            // 
            // onlyForVia
            // 
            this.onlyForVia.Location = new System.Drawing.Point(491, 20);
            this.onlyForVia.Name = "onlyForVia";
            this.onlyForVia.Size = new System.Drawing.Size(132, 39);
            this.onlyForVia.TabIndex = 2;
            this.onlyForVia.Text = "仅操作Via";
            this.onlyForVia.UseVisualStyleBackColor = true;
            this.onlyForVia.Click += new System.EventHandler(this.onlyForVia_Click);
            // 
            // onlyForProcess
            // 
            this.onlyForProcess.Location = new System.Drawing.Point(330, 20);
            this.onlyForProcess.Name = "onlyForProcess";
            this.onlyForProcess.Size = new System.Drawing.Size(132, 39);
            this.onlyForProcess.TabIndex = 2;
            this.onlyForProcess.Text = "仅操作Process";
            this.onlyForProcess.UseVisualStyleBackColor = true;
            this.onlyForProcess.Click += new System.EventHandler(this.onlyForProcess_Click);
            // 
            // clearAll
            // 
            this.clearAll.Location = new System.Drawing.Point(169, 20);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(132, 39);
            this.clearAll.TabIndex = 2;
            this.clearAll.Text = "清空";
            this.clearAll.UseVisualStyleBackColor = true;
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // allTaget
            // 
            this.allTaget.Location = new System.Drawing.Point(8, 20);
            this.allTaget.Name = "allTaget";
            this.allTaget.Size = new System.Drawing.Size(132, 39);
            this.allTaget.TabIndex = 2;
            this.allTaget.Text = "所有对象";
            this.allTaget.UseVisualStyleBackColor = true;
            this.allTaget.Click += new System.EventHandler(this.allTaget_Click);
            // 
            // WorkToBefore
            // 
            this.WorkToBefore.Location = new System.Drawing.Point(12, 537);
            this.WorkToBefore.Name = "WorkToBefore";
            this.WorkToBefore.Size = new System.Drawing.Size(174, 39);
            this.WorkToBefore.TabIndex = 2;
            this.WorkToBefore.Text = "执行重命名";
            this.WorkToBefore.UseVisualStyleBackColor = true;
            this.WorkToBefore.Click += new System.EventHandler(this.WorkToBefore_Click);
            // 
            // OutTargetListAix
            // 
            this.OutTargetListAix.Location = new System.Drawing.Point(240, 537);
            this.OutTargetListAix.Name = "OutTargetListAix";
            this.OutTargetListAix.Size = new System.Drawing.Size(174, 39);
            this.OutTargetListAix.TabIndex = 2;
            this.OutTargetListAix.Text = "导出目标坐标";
            this.OutTargetListAix.UseVisualStyleBackColor = true;
            // 
            // goBackToFather
            // 
            this.goBackToFather.Location = new System.Drawing.Point(468, 537);
            this.goBackToFather.Name = "goBackToFather";
            this.goBackToFather.Size = new System.Drawing.Size(174, 39);
            this.goBackToFather.TabIndex = 2;
            this.goBackToFather.Text = "返回上一级";
            this.goBackToFather.UseVisualStyleBackColor = true;
            // 
            // Pbar
            // 
            this.Pbar.Location = new System.Drawing.Point(12, 586);
            this.Pbar.Name = "Pbar";
            this.Pbar.Size = new System.Drawing.Size(630, 23);
            this.Pbar.TabIndex = 5;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ProcessTaskAddress);
            this.groupBox7.Location = new System.Drawing.Point(8, 20);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(244, 190);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "ProcessTask地址";
            // 
            // ProcessTaskAddress
            // 
            this.ProcessTaskAddress.FormattingEnabled = true;
            this.ProcessTaskAddress.ItemHeight = 12;
            this.ProcessTaskAddress.Location = new System.Drawing.Point(7, 21);
            this.ProcessTaskAddress.Name = "ProcessTaskAddress";
            this.ProcessTaskAddress.Size = new System.Drawing.Size(231, 160);
            this.ProcessTaskAddress.TabIndex = 0;
            this.ProcessTaskAddress.SelectedIndexChanged += new System.EventHandler(this.ProcessTaskAddress_SelectedIndexChanged);
            // 
            // reSelectRobot
            // 
            this.reSelectRobot.Location = new System.Drawing.Point(506, 11);
            this.reSelectRobot.Name = "reSelectRobot";
            this.reSelectRobot.Size = new System.Drawing.Size(118, 48);
            this.reSelectRobot.TabIndex = 2;
            this.reSelectRobot.Text = "选择目标机器人";
            this.reSelectRobot.UseVisualStyleBackColor = true;
            this.reSelectRobot.Click += new System.EventHandler(this.reSelectRobot_Click);
            // 
            // RobotTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(654, 621);
            this.Controls.Add(this.Pbar);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.goBackToFather);
            this.Controls.Add(this.OutTargetListAix);
            this.Controls.Add(this.WorkToBefore);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RobotTaskControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RobotTaskControl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RobotTaskControl_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompayIco)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox selectedrobotTaskName;
        private System.Windows.Forms.Button reSelectRobotTask;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button onlyForVia;
        private System.Windows.Forms.Button onlyForProcess;
        private System.Windows.Forms.Button clearAll;
        private System.Windows.Forms.Button allTaget;
        private System.Windows.Forms.Button WorkToBefore;
        private System.Windows.Forms.Button OutTargetListAix;
        private System.Windows.Forms.Button goBackToFather;
        private System.Windows.Forms.ListBox TaskListA;
        private System.Windows.Forms.ListBox TaskListB;
        private System.Windows.Forms.ComboBox taskNameTotalNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox taskNameTagName;
        private System.Windows.Forms.TextBox taskNameRearStr;
        private System.Windows.Forms.TextBox taskNameFrontStr;
        private System.Windows.Forms.TextBox taskNameStartNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox taskNameNumStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar Pbar;
        private System.Windows.Forms.PictureBox CompayIco;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox ProcessTaskAddress;
        private System.Windows.Forms.Button reSelectRobot;
    }
}