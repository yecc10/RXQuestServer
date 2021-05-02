namespace YeDassaultSystemDev
{
    partial class CatiaQuickTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatiaQuickTool));
            this.TryRead = new System.Windows.Forms.Button();
            this.KeepName = new System.Windows.Forms.CheckBox();
            this.OutToEXcel = new System.Windows.Forms.Button();
            this.BollToPoint = new System.Windows.Forms.Button();
            this.InsGun = new System.Windows.Forms.Button();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.ReadCoord = new System.Windows.Forms.Button();
            this.ClearAllData = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.PointToCoord = new System.Windows.Forms.Button();
            this.ReadAixPoint = new System.Windows.Forms.Button();
            this.Creat3dPoint = new System.Windows.Forms.Button();
            this.Creat3dBall = new System.Windows.Forms.Button();
            this.BallRadio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RepeatCheck = new System.Windows.Forms.CheckBox();
            this.IgRepeat = new System.Windows.Forms.CheckBox();
            this.ByExcel = new System.Windows.Forms.CheckBox();
            this.ARCChange = new System.Windows.Forms.CheckBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.SportOprator = new System.Windows.Forms.ToolStripDropDownButton();
            this.ExtraPadToSurface = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.InitCatia = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.skipViaPoint = new System.Windows.Forms.CheckBox();
            this.getJTCoord = new System.Windows.Forms.CheckBox();
            this.ConCatia = new System.Windows.Forms.RadioButton();
            this.ConDelmia = new System.Windows.Forms.RadioButton();
            this.myMessage = new System.Windows.Forms.Label();
            this.MinDistance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TryRead
            // 
            this.TryRead.Location = new System.Drawing.Point(602, 461);
            this.TryRead.Name = "TryRead";
            this.TryRead.Size = new System.Drawing.Size(118, 44);
            this.TryRead.TabIndex = 0;
            this.TryRead.Text = "返回上一级";
            this.TryRead.UseVisualStyleBackColor = true;
            this.TryRead.Click += new System.EventHandler(this.TryRead_Click);
            // 
            // KeepName
            // 
            this.KeepName.AutoSize = true;
            this.KeepName.Checked = true;
            this.KeepName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KeepName.Location = new System.Drawing.Point(12, 454);
            this.KeepName.Name = "KeepName";
            this.KeepName.Size = new System.Drawing.Size(72, 16);
            this.KeepName.TabIndex = 1;
            this.KeepName.Text = "保留名称";
            this.KeepName.UseVisualStyleBackColor = true;
            // 
            // OutToEXcel
            // 
            this.OutToEXcel.Location = new System.Drawing.Point(748, 402);
            this.OutToEXcel.Name = "OutToEXcel";
            this.OutToEXcel.Size = new System.Drawing.Size(118, 44);
            this.OutToEXcel.TabIndex = 2;
            this.OutToEXcel.Text = "导出EXCEL";
            this.OutToEXcel.UseVisualStyleBackColor = true;
            this.OutToEXcel.Click += new System.EventHandler(this.OutToEXcel_Click);
            // 
            // BollToPoint
            // 
            this.BollToPoint.Location = new System.Drawing.Point(164, 402);
            this.BollToPoint.Name = "BollToPoint";
            this.BollToPoint.Size = new System.Drawing.Size(118, 44);
            this.BollToPoint.TabIndex = 2;
            this.BollToPoint.Text = "球生成点";
            this.BollToPoint.UseVisualStyleBackColor = true;
            this.BollToPoint.Click += new System.EventHandler(this.BollToPoint_Click);
            // 
            // InsGun
            // 
            this.InsGun.Location = new System.Drawing.Point(602, 402);
            this.InsGun.Name = "InsGun";
            this.InsGun.Size = new System.Drawing.Size(118, 44);
            this.InsGun.TabIndex = 2;
            this.InsGun.Text = "插入焊钳";
            this.InsGun.UseVisualStyleBackColor = true;
            this.InsGun.Click += new System.EventHandler(this.InsGun_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(12, 39);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowTemplate.Height = 23;
            this.DataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGrid.Size = new System.Drawing.Size(852, 357);
            this.DataGrid.TabIndex = 3;
            // 
            // ReadCoord
            // 
            this.ReadCoord.Location = new System.Drawing.Point(164, 461);
            this.ReadCoord.Name = "ReadCoord";
            this.ReadCoord.Size = new System.Drawing.Size(118, 44);
            this.ReadCoord.TabIndex = 2;
            this.ReadCoord.Text = "求解任意坐标";
            this.ReadCoord.UseVisualStyleBackColor = true;
            this.ReadCoord.Click += new System.EventHandler(this.ReadCoord_Click);
            // 
            // ClearAllData
            // 
            this.ClearAllData.Location = new System.Drawing.Point(310, 402);
            this.ClearAllData.Name = "ClearAllData";
            this.ClearAllData.Size = new System.Drawing.Size(118, 44);
            this.ClearAllData.TabIndex = 2;
            this.ClearAllData.Text = "清空数据";
            this.ClearAllData.UseVisualStyleBackColor = true;
            this.ClearAllData.Click += new System.EventHandler(this.ClearAllData_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // PointToCoord
            // 
            this.PointToCoord.Location = new System.Drawing.Point(18, 402);
            this.PointToCoord.Name = "PointToCoord";
            this.PointToCoord.Size = new System.Drawing.Size(118, 44);
            this.PointToCoord.TabIndex = 2;
            this.PointToCoord.Text = "求解点坐标";
            this.PointToCoord.UseVisualStyleBackColor = true;
            this.PointToCoord.Click += new System.EventHandler(this.PointToCoord_Click);
            // 
            // ReadAixPoint
            // 
            this.ReadAixPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ReadAixPoint.Location = new System.Drawing.Point(310, 461);
            this.ReadAixPoint.Name = "ReadAixPoint";
            this.ReadAixPoint.Size = new System.Drawing.Size(118, 44);
            this.ReadAixPoint.TabIndex = 2;
            this.ReadAixPoint.Text = "坐标导入";
            this.ReadAixPoint.UseVisualStyleBackColor = false;
            this.ReadAixPoint.Click += new System.EventHandler(this.Aix_To_Ball_Click);
            // 
            // Creat3dPoint
            // 
            this.Creat3dPoint.Location = new System.Drawing.Point(456, 402);
            this.Creat3dPoint.Name = "Creat3dPoint";
            this.Creat3dPoint.Size = new System.Drawing.Size(118, 44);
            this.Creat3dPoint.TabIndex = 2;
            this.Creat3dPoint.Text = "生成3D点";
            this.Creat3dPoint.UseVisualStyleBackColor = true;
            this.Creat3dPoint.Click += new System.EventHandler(this.Creat3dPoint_Click);
            // 
            // Creat3dBall
            // 
            this.Creat3dBall.Location = new System.Drawing.Point(456, 461);
            this.Creat3dBall.Name = "Creat3dBall";
            this.Creat3dBall.Size = new System.Drawing.Size(118, 44);
            this.Creat3dBall.TabIndex = 2;
            this.Creat3dBall.Text = "生成3D球";
            this.Creat3dBall.UseVisualStyleBackColor = true;
            this.Creat3dBall.Click += new System.EventHandler(this.Creat3dBall_Click);
            // 
            // BallRadio
            // 
            this.BallRadio.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BallRadio.Location = new System.Drawing.Point(787, 455);
            this.BallRadio.Name = "BallRadio";
            this.BallRadio.Size = new System.Drawing.Size(77, 26);
            this.BallRadio.TabIndex = 4;
            this.BallRadio.Text = "6";
            this.BallRadio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(740, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "球半径";
            // 
            // RepeatCheck
            // 
            this.RepeatCheck.AutoSize = true;
            this.RepeatCheck.Checked = true;
            this.RepeatCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RepeatCheck.Location = new System.Drawing.Point(12, 477);
            this.RepeatCheck.Name = "RepeatCheck";
            this.RepeatCheck.Size = new System.Drawing.Size(72, 16);
            this.RepeatCheck.TabIndex = 1;
            this.RepeatCheck.Text = "重复检查";
            this.RepeatCheck.UseVisualStyleBackColor = true;
            // 
            // IgRepeat
            // 
            this.IgRepeat.AutoSize = true;
            this.IgRepeat.Checked = true;
            this.IgRepeat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgRepeat.Location = new System.Drawing.Point(92, 477);
            this.IgRepeat.Name = "IgRepeat";
            this.IgRepeat.Size = new System.Drawing.Size(72, 16);
            this.IgRepeat.TabIndex = 1;
            this.IgRepeat.Text = "过滤重复";
            this.IgRepeat.UseVisualStyleBackColor = true;
            // 
            // ByExcel
            // 
            this.ByExcel.AutoSize = true;
            this.ByExcel.Checked = true;
            this.ByExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ByExcel.Location = new System.Drawing.Point(92, 455);
            this.ByExcel.Name = "ByExcel";
            this.ByExcel.Size = new System.Drawing.Size(66, 16);
            this.ByExcel.TabIndex = 1;
            this.ByExcel.Text = "ByExcel";
            this.ByExcel.UseVisualStyleBackColor = true;
            // 
            // ARCChange
            // 
            this.ARCChange.AutoSize = true;
            this.ARCChange.Checked = true;
            this.ARCChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ARCChange.Location = new System.Drawing.Point(12, 499);
            this.ARCChange.Name = "ARCChange";
            this.ARCChange.Size = new System.Drawing.Size(108, 16);
            this.ARCChange.TabIndex = 1;
            this.ARCChange.Text = "Delmia->OutTag";
            this.ARCChange.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SportOprator,
            this.toolStripDropDownButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(878, 31);
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // SportOprator
            // 
            this.SportOprator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SportOprator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExtraPadToSurface});
            this.SportOprator.Image = global::YeDassaultSystemDev.Properties.Resources.Address_book;
            this.SportOprator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SportOprator.Name = "SportOprator";
            this.SportOprator.Size = new System.Drawing.Size(37, 28);
            this.SportOprator.Text = "实体焊点转化";
            // 
            // ExtraPadToSurface
            // 
            this.ExtraPadToSurface.Image = global::YeDassaultSystemDev.Properties.Resources.Arrow_upload;
            this.ExtraPadToSurface.Name = "ExtraPadToSurface";
            this.ExtraPadToSurface.Size = new System.Drawing.Size(160, 22);
            this.ExtraPadToSurface.Text = "实体焊点转几何";
            this.ExtraPadToSurface.Click += new System.EventHandler(this.ExtraPadToSurface_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InitCatia});
            this.toolStripDropDownButton1.Image = global::YeDassaultSystemDev.Properties.Resources.Gear;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(37, 28);
            this.toolStripDropDownButton1.Text = "CATIA操作";
            // 
            // InitCatia
            // 
            this.InitCatia.Image = global::YeDassaultSystemDev.Properties.Resources.Health;
            this.InitCatia.Name = "InitCatia";
            this.InitCatia.Size = new System.Drawing.Size(147, 22);
            this.InitCatia.Text = "初始化CATIA";
            this.InitCatia.Click += new System.EventHandler(this.InitCatia_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 545);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(854, 23);
            this.progressBar.TabIndex = 7;
            // 
            // skipViaPoint
            // 
            this.skipViaPoint.AutoSize = true;
            this.skipViaPoint.Checked = true;
            this.skipViaPoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skipViaPoint.Location = new System.Drawing.Point(12, 521);
            this.skipViaPoint.Name = "skipViaPoint";
            this.skipViaPoint.Size = new System.Drawing.Size(120, 16);
            this.skipViaPoint.TabIndex = 1;
            this.skipViaPoint.Text = "自动跳过ViaPoint";
            this.skipViaPoint.UseVisualStyleBackColor = true;
            // 
            // getJTCoord
            // 
            this.getJTCoord.AutoSize = true;
            this.getJTCoord.Checked = true;
            this.getJTCoord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.getJTCoord.Location = new System.Drawing.Point(162, 521);
            this.getJTCoord.Name = "getJTCoord";
            this.getJTCoord.Size = new System.Drawing.Size(120, 16);
            this.getJTCoord.TabIndex = 1;
            this.getJTCoord.Text = "Read-JT->STP坐标";
            this.getJTCoord.UseVisualStyleBackColor = true;
            // 
            // ConCatia
            // 
            this.ConCatia.AutoSize = true;
            this.ConCatia.Checked = true;
            this.ConCatia.Location = new System.Drawing.Point(682, 520);
            this.ConCatia.Name = "ConCatia";
            this.ConCatia.Size = new System.Drawing.Size(77, 16);
            this.ConCatia.TabIndex = 8;
            this.ConCatia.TabStop = true;
            this.ConCatia.Text = "CATIA通信";
            this.ConCatia.UseVisualStyleBackColor = true;
            this.ConCatia.CheckedChanged += new System.EventHandler(this.ConCatia_CheckedChanged);
            // 
            // ConDelmia
            // 
            this.ConDelmia.AutoSize = true;
            this.ConDelmia.Location = new System.Drawing.Point(783, 520);
            this.ConDelmia.Name = "ConDelmia";
            this.ConDelmia.Size = new System.Drawing.Size(83, 16);
            this.ConDelmia.TabIndex = 8;
            this.ConDelmia.Text = "Delmia通信";
            this.ConDelmia.UseVisualStyleBackColor = true;
            // 
            // myMessage
            // 
            this.myMessage.AutoSize = true;
            this.myMessage.Location = new System.Drawing.Point(310, 523);
            this.myMessage.Name = "myMessage";
            this.myMessage.Size = new System.Drawing.Size(0, 12);
            this.myMessage.TabIndex = 9;
            // 
            // MinDistance
            // 
            this.MinDistance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinDistance.Location = new System.Drawing.Point(787, 487);
            this.MinDistance.Name = "MinDistance";
            this.MinDistance.Size = new System.Drawing.Size(77, 26);
            this.MinDistance.TabIndex = 4;
            this.MinDistance.Text = "5";
            this.MinDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(729, 494);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "最小间距";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(308, 521);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(155, 12);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "https://blog.csdn.net/qingyangwuji/article/details/116357927";
            this.linkLabel1.Text = "点击查看提取CGR坐标的方法";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CatiaQuickTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(878, 580);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.myMessage);
            this.Controls.Add(this.ConDelmia);
            this.Controls.Add(this.ConCatia);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinDistance);
            this.Controls.Add(this.BallRadio);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.Creat3dBall);
            this.Controls.Add(this.Creat3dPoint);
            this.Controls.Add(this.InsGun);
            this.Controls.Add(this.PointToCoord);
            this.Controls.Add(this.ReadAixPoint);
            this.Controls.Add(this.ReadCoord);
            this.Controls.Add(this.ClearAllData);
            this.Controls.Add(this.BollToPoint);
            this.Controls.Add(this.OutToEXcel);
            this.Controls.Add(this.ByExcel);
            this.Controls.Add(this.IgRepeat);
            this.Controls.Add(this.getJTCoord);
            this.Controls.Add(this.skipViaPoint);
            this.Controls.Add(this.ARCChange);
            this.Controls.Add(this.RepeatCheck);
            this.Controls.Add(this.KeepName);
            this.Controls.Add(this.TryRead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CatiaQuickTool";
            this.Text = "CatiaQuickTool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CatiaQuickTool_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TryRead;
        private System.Windows.Forms.CheckBox KeepName;
        private System.Windows.Forms.Button OutToEXcel;
        private System.Windows.Forms.Button BollToPoint;
        private System.Windows.Forms.Button InsGun;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button ReadCoord;
        private System.Windows.Forms.Button ClearAllData;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button PointToCoord;
        private System.Windows.Forms.Button ReadAixPoint;
        private System.Windows.Forms.Button Creat3dPoint;
        private System.Windows.Forms.Button Creat3dBall;
        private System.Windows.Forms.TextBox BallRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox RepeatCheck;
        private System.Windows.Forms.CheckBox IgRepeat;
        private System.Windows.Forms.CheckBox ByExcel;
        private System.Windows.Forms.CheckBox ARCChange;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton SportOprator;
        private System.Windows.Forms.ToolStripMenuItem ExtraPadToSurface;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem InitCatia;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox skipViaPoint;
        private System.Windows.Forms.CheckBox getJTCoord;
        private System.Windows.Forms.RadioButton ConCatia;
        private System.Windows.Forms.RadioButton ConDelmia;
        private System.Windows.Forms.Label myMessage;
        private System.Windows.Forms.TextBox MinDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}