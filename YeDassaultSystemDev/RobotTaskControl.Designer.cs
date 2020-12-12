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
            this.robotTaskName = new System.Windows.Forms.TextBox();
            this.ReSelectRobotTask = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器人程序:";
            // 
            // robotTaskName
            // 
            this.robotTaskName.Location = new System.Drawing.Point(83, 24);
            this.robotTaskName.Name = "robotTaskName";
            this.robotTaskName.ReadOnly = true;
            this.robotTaskName.Size = new System.Drawing.Size(401, 21);
            this.robotTaskName.TabIndex = 1;
            this.robotTaskName.Text = "Please Select a Robot Task";
            // 
            // ReSelectRobotTask
            // 
            this.ReSelectRobotTask.Location = new System.Drawing.Point(490, 23);
            this.ReSelectRobotTask.Name = "ReSelectRobotTask";
            this.ReSelectRobotTask.Size = new System.Drawing.Size(134, 23);
            this.ReSelectRobotTask.TabIndex = 2;
            this.ReSelectRobotTask.Text = "重新选择";
            this.ReSelectRobotTask.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ReSelectRobotTask);
            this.groupBox1.Controls.Add(this.robotTaskName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目标选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 142);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "标签设置";
            // 
            // groupBox3
            // 
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
            this.groupBox5.Location = new System.Drawing.Point(8, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(269, 190);
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
            this.TaskListA.Size = new System.Drawing.Size(256, 160);
            this.TaskListA.Sorted = true;
            this.TaskListA.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TaskListB);
            this.groupBox4.Location = new System.Drawing.Point(355, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 190);
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
            this.TaskListB.Size = new System.Drawing.Size(256, 160);
            this.TaskListB.Sorted = true;
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
            // 
            // onlyForProcess
            // 
            this.onlyForProcess.Location = new System.Drawing.Point(330, 20);
            this.onlyForProcess.Name = "onlyForProcess";
            this.onlyForProcess.Size = new System.Drawing.Size(132, 39);
            this.onlyForProcess.TabIndex = 2;
            this.onlyForProcess.Text = "仅操作Process";
            this.onlyForProcess.UseVisualStyleBackColor = true;
            // 
            // clearAll
            // 
            this.clearAll.Location = new System.Drawing.Point(169, 20);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(132, 39);
            this.clearAll.TabIndex = 2;
            this.clearAll.Text = "清空";
            this.clearAll.UseVisualStyleBackColor = true;
            // 
            // allTaget
            // 
            this.allTaget.Location = new System.Drawing.Point(8, 20);
            this.allTaget.Name = "allTaget";
            this.allTaget.Size = new System.Drawing.Size(132, 39);
            this.allTaget.TabIndex = 2;
            this.allTaget.Text = "所有对象";
            this.allTaget.UseVisualStyleBackColor = true;
            // 
            // WorkToBefore
            // 
            this.WorkToBefore.Location = new System.Drawing.Point(12, 546);
            this.WorkToBefore.Name = "WorkToBefore";
            this.WorkToBefore.Size = new System.Drawing.Size(174, 39);
            this.WorkToBefore.TabIndex = 2;
            this.WorkToBefore.Text = "执行重命名";
            this.WorkToBefore.UseVisualStyleBackColor = true;
            // 
            // OutTargetListAix
            // 
            this.OutTargetListAix.Location = new System.Drawing.Point(240, 546);
            this.OutTargetListAix.Name = "OutTargetListAix";
            this.OutTargetListAix.Size = new System.Drawing.Size(174, 39);
            this.OutTargetListAix.TabIndex = 2;
            this.OutTargetListAix.Text = "导出目标坐标";
            this.OutTargetListAix.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "返回上一级";
            this.button1.UseVisualStyleBackColor = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "起始编号:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "新的TagName:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "5";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(90, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(108, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "5";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(90, 107);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(409, 21);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "LHP";
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
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(391, 56);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(108, 21);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "5";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(391, 80);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(108, 21);
            this.textBox6.TabIndex = 1;
            this.textBox6.Text = "5";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "00",
            "000",
            "0000"});
            this.comboBox1.Location = new System.Drawing.Point(90, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // RobotTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(654, 608);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OutTargetListAix);
            this.Controls.Add(this.WorkToBefore);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RobotTaskControl";
            this.Text = "RobotTaskControl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RobotTaskControl_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox robotTaskName;
        private System.Windows.Forms.Button ReSelectRobotTask;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox TaskListA;
        private System.Windows.Forms.ListBox TaskListB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}