namespace ToPlant
{
    partial class DrawFence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawFence));
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.mIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ydata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Radius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArcAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FwAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.MannuSetFW = new System.Windows.Forms.RadioButton();
            this.AutoSetFW = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LishanRoad = new System.Windows.Forms.RadioButton();
            this.ContinuRoad = new System.Windows.Forms.RadioButton();
            this.OutExcel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DoubleRoadSelected = new System.Windows.Forms.RadioButton();
            this.SingeRoadSelected = new System.Windows.Forms.RadioButton();
            this.DeleteLastFence = new System.Windows.Forms.Button();
            this.ClearData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Sscale = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.TextBox();
            this.ServerIP = new System.Windows.Forms.TextBox();
            this.OnlineModel = new System.Windows.Forms.CheckBox();
            this.KeepValue = new System.Windows.Forms.TextBox();
            this.ApplyPlantAix = new System.Windows.Forms.CheckBox();
            this.ChangeXY = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TestSocket = new System.Windows.Forms.Button();
            this.AutoRead = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ManulInputPoint = new System.Windows.Forms.Button();
            this.ManulInputLine = new System.Windows.Forms.Button();
            this.SY_AIX = new System.Windows.Forms.TextBox();
            this.SX_AIX = new System.Windows.Forms.TextBox();
            this.SetRefPoint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SocketLogs = new System.Windows.Forms.TextBox();
            this.ClearLogs = new System.Windows.Forms.Button();
            this.ClearModel = new System.Windows.Forms.Button();
            this.ExploreJT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mIndex,
            this.Xdata,
            this.Ydata,
            this.Zdata,
            this.TrackType,
            this.Radius,
            this.StartAngle,
            this.CenterX,
            this.CenterY,
            this.CenterZ,
            this.ArcAngle,
            this.FwAngle});
            this.DataGrid.Location = new System.Drawing.Point(12, 184);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowTemplate.Height = 23;
            this.DataGrid.Size = new System.Drawing.Size(747, 208);
            this.DataGrid.TabIndex = 8;
            // 
            // mIndex
            // 
            this.mIndex.DataPropertyName = "序号";
            this.mIndex.HeaderText = "序号";
            this.mIndex.Name = "mIndex";
            this.mIndex.Width = 80;
            // 
            // Xdata
            // 
            this.Xdata.DataPropertyName = "X坐标";
            this.Xdata.HeaderText = "X坐标";
            this.Xdata.Name = "Xdata";
            this.Xdata.Width = 120;
            // 
            // Ydata
            // 
            this.Ydata.DataPropertyName = "Y坐标";
            this.Ydata.HeaderText = "Y坐标";
            this.Ydata.Name = "Ydata";
            this.Ydata.Width = 120;
            // 
            // Zdata
            // 
            this.Zdata.DataPropertyName = "Z坐标";
            this.Zdata.HeaderText = "Z坐标";
            this.Zdata.Name = "Zdata";
            this.Zdata.Width = 120;
            // 
            // TrackType
            // 
            this.TrackType.DataPropertyName = "TrackType";
            this.TrackType.HeaderText = "路径类型";
            this.TrackType.Name = "TrackType";
            this.TrackType.Width = 120;
            // 
            // Radius
            // 
            this.Radius.DataPropertyName = "Radius";
            this.Radius.HeaderText = "弧半径";
            this.Radius.Name = "Radius";
            // 
            // StartAngle
            // 
            this.StartAngle.DataPropertyName = "StartAngle";
            this.StartAngle.HeaderText = "起始角";
            this.StartAngle.Name = "StartAngle";
            // 
            // CenterX
            // 
            this.CenterX.DataPropertyName = "CenterX";
            this.CenterX.HeaderText = "圆弧中心X";
            this.CenterX.Name = "CenterX";
            // 
            // CenterY
            // 
            this.CenterY.DataPropertyName = "CenterY";
            this.CenterY.HeaderText = "圆弧中心Y";
            this.CenterY.Name = "CenterY";
            // 
            // CenterZ
            // 
            this.CenterZ.DataPropertyName = "CenterZ";
            this.CenterZ.HeaderText = "圆弧中心Z";
            this.CenterZ.Name = "CenterZ";
            // 
            // ArcAngle
            // 
            this.ArcAngle.DataPropertyName = "EndAngle";
            this.ArcAngle.HeaderText = "终止角";
            this.ArcAngle.Name = "ArcAngle";
            // 
            // FwAngle
            // 
            this.FwAngle.DataPropertyName = "FwAngle";
            this.FwAngle.HeaderText = "方向角";
            this.FwAngle.Name = "FwAngle";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.MannuSetFW);
            this.groupBox5.Controls.Add(this.AutoSetFW);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(642, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(98, 104);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "路径方向设定";
            // 
            // MannuSetFW
            // 
            this.MannuSetFW.AutoSize = true;
            this.MannuSetFW.Checked = true;
            this.MannuSetFW.Location = new System.Drawing.Point(12, 67);
            this.MannuSetFW.Name = "MannuSetFW";
            this.MannuSetFW.Size = new System.Drawing.Size(71, 16);
            this.MannuSetFW.TabIndex = 4;
            this.MannuSetFW.TabStop = true;
            this.MannuSetFW.Text = "顺序设定";
            this.MannuSetFW.UseVisualStyleBackColor = true;
            // 
            // AutoSetFW
            // 
            this.AutoSetFW.AutoSize = true;
            this.AutoSetFW.Location = new System.Drawing.Point(12, 34);
            this.AutoSetFW.Name = "AutoSetFW";
            this.AutoSetFW.Size = new System.Drawing.Size(71, 16);
            this.AutoSetFW.TabIndex = 4;
            this.AutoSetFW.Text = "自动设定";
            this.AutoSetFW.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "小数位数";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LishanRoad);
            this.groupBox4.Controls.Add(this.ContinuRoad);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(533, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(98, 104);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "路径类型设定";
            // 
            // LishanRoad
            // 
            this.LishanRoad.AutoSize = true;
            this.LishanRoad.Location = new System.Drawing.Point(12, 67);
            this.LishanRoad.Name = "LishanRoad";
            this.LishanRoad.Size = new System.Drawing.Size(71, 16);
            this.LishanRoad.TabIndex = 4;
            this.LishanRoad.Text = "分散路径";
            this.LishanRoad.UseVisualStyleBackColor = true;
            // 
            // ContinuRoad
            // 
            this.ContinuRoad.AutoSize = true;
            this.ContinuRoad.Checked = true;
            this.ContinuRoad.Location = new System.Drawing.Point(12, 34);
            this.ContinuRoad.Name = "ContinuRoad";
            this.ContinuRoad.Size = new System.Drawing.Size(71, 16);
            this.ContinuRoad.TabIndex = 4;
            this.ContinuRoad.TabStop = true;
            this.ContinuRoad.Text = "连续路径";
            this.ContinuRoad.UseVisualStyleBackColor = true;
            // 
            // OutExcel
            // 
            this.OutExcel.Location = new System.Drawing.Point(12, 648);
            this.OutExcel.Name = "OutExcel";
            this.OutExcel.Size = new System.Drawing.Size(90, 30);
            this.OutExcel.TabIndex = 2;
            this.OutExcel.Text = "导出EXCEL";
            this.OutExcel.UseVisualStyleBackColor = true;
            this.OutExcel.Click += new System.EventHandler(this.OutExcel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DoubleRoadSelected);
            this.groupBox3.Controls.Add(this.SingeRoadSelected);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(424, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(98, 104);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "路径类型设定";
            // 
            // DoubleRoadSelected
            // 
            this.DoubleRoadSelected.AutoSize = true;
            this.DoubleRoadSelected.Location = new System.Drawing.Point(12, 67);
            this.DoubleRoadSelected.Name = "DoubleRoadSelected";
            this.DoubleRoadSelected.Size = new System.Drawing.Size(71, 16);
            this.DoubleRoadSelected.TabIndex = 4;
            this.DoubleRoadSelected.Text = "双向通道";
            this.DoubleRoadSelected.UseVisualStyleBackColor = true;
            // 
            // SingeRoadSelected
            // 
            this.SingeRoadSelected.AutoSize = true;
            this.SingeRoadSelected.Checked = true;
            this.SingeRoadSelected.Location = new System.Drawing.Point(12, 34);
            this.SingeRoadSelected.Name = "SingeRoadSelected";
            this.SingeRoadSelected.Size = new System.Drawing.Size(71, 16);
            this.SingeRoadSelected.TabIndex = 4;
            this.SingeRoadSelected.TabStop = true;
            this.SingeRoadSelected.Text = "单向通道";
            this.SingeRoadSelected.UseVisualStyleBackColor = true;
            // 
            // DeleteLastFence
            // 
            this.DeleteLastFence.Location = new System.Drawing.Point(448, 648);
            this.DeleteLastFence.Name = "DeleteLastFence";
            this.DeleteLastFence.Size = new System.Drawing.Size(90, 30);
            this.DeleteLastFence.TabIndex = 3;
            this.DeleteLastFence.Text = "删除最后围栏";
            this.DeleteLastFence.UseVisualStyleBackColor = true;
            this.DeleteLastFence.Click += new System.EventHandler(this.DeleteLastFence_Click);
            // 
            // ClearData
            // 
            this.ClearData.Enabled = false;
            this.ClearData.Location = new System.Drawing.Point(121, 648);
            this.ClearData.Name = "ClearData";
            this.ClearData.Size = new System.Drawing.Size(90, 30);
            this.ClearData.TabIndex = 4;
            this.ClearData.Text = "清空";
            this.ClearData.UseVisualStyleBackColor = true;
            this.ClearData.Click += new System.EventHandler(this.DeleteData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "比例";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
            // 
            // Sscale
            // 
            this.Sscale.Location = new System.Drawing.Point(53, 20);
            this.Sscale.Name = "Sscale";
            this.Sscale.Size = new System.Drawing.Size(61, 21);
            this.Sscale.TabIndex = 2;
            this.Sscale.Text = "1";
            this.Sscale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ServerPort);
            this.groupBox2.Controls.Add(this.ServerIP);
            this.groupBox2.Controls.Add(this.OnlineModel);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Sscale);
            this.groupBox2.Controls.Add(this.KeepValue);
            this.groupBox2.Controls.Add(this.ApplyPlantAix);
            this.groupBox2.Controls.Add(this.ChangeXY);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(746, 109);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "ServerIP:";
            // 
            // ServerPort
            // 
            this.ServerPort.Location = new System.Drawing.Point(249, 76);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(171, 21);
            this.ServerPort.TabIndex = 7;
            // 
            // ServerIP
            // 
            this.ServerIP.Location = new System.Drawing.Point(249, 49);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(171, 21);
            this.ServerIP.TabIndex = 7;
            // 
            // OnlineModel
            // 
            this.OnlineModel.AutoSize = true;
            this.OnlineModel.Location = new System.Drawing.Point(106, 51);
            this.OnlineModel.Name = "OnlineModel";
            this.OnlineModel.Size = new System.Drawing.Size(72, 16);
            this.OnlineModel.TabIndex = 6;
            this.OnlineModel.Text = "在线模式";
            this.OnlineModel.UseVisualStyleBackColor = true;
            this.OnlineModel.CheckedChanged += new System.EventHandler(this.OnlineModel_CheckedChanged);
            // 
            // KeepValue
            // 
            this.KeepValue.Location = new System.Drawing.Point(193, 20);
            this.KeepValue.Name = "KeepValue";
            this.KeepValue.Size = new System.Drawing.Size(61, 21);
            this.KeepValue.TabIndex = 2;
            this.KeepValue.Text = "1";
            this.KeepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ApplyPlantAix
            // 
            this.ApplyPlantAix.AutoSize = true;
            this.ApplyPlantAix.Checked = true;
            this.ApplyPlantAix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ApplyPlantAix.Location = new System.Drawing.Point(11, 78);
            this.ApplyPlantAix.Name = "ApplyPlantAix";
            this.ApplyPlantAix.Size = new System.Drawing.Size(126, 16);
            this.ApplyPlantAix.TabIndex = 0;
            this.ApplyPlantAix.Text = "应用Plant坐标规则";
            this.ApplyPlantAix.UseVisualStyleBackColor = true;
            // 
            // ChangeXY
            // 
            this.ChangeXY.AutoSize = true;
            this.ChangeXY.Location = new System.Drawing.Point(11, 51);
            this.ChangeXY.Name = "ChangeXY";
            this.ChangeXY.Size = new System.Drawing.Size(90, 16);
            this.ChangeXY.TabIndex = 0;
            this.ChangeXY.Text = "X\\Y坐标互换";
            this.ChangeXY.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y坐标";
            // 
            // TestSocket
            // 
            this.TestSocket.Location = new System.Drawing.Point(666, 648);
            this.TestSocket.Name = "TestSocket";
            this.TestSocket.Size = new System.Drawing.Size(90, 30);
            this.TestSocket.TabIndex = 6;
            this.TestSocket.Text = "测试连接";
            this.TestSocket.UseVisualStyleBackColor = true;
            this.TestSocket.Click += new System.EventHandler(this.TestSocket_Click);
            // 
            // AutoRead
            // 
            this.AutoRead.Enabled = false;
            this.AutoRead.Location = new System.Drawing.Point(646, 20);
            this.AutoRead.Name = "AutoRead";
            this.AutoRead.Size = new System.Drawing.Size(90, 30);
            this.AutoRead.TabIndex = 0;
            this.AutoRead.Text = "自动全部读取";
            this.AutoRead.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "X坐标";
            // 
            // ManulInputPoint
            // 
            this.ManulInputPoint.Enabled = false;
            this.ManulInputPoint.Location = new System.Drawing.Point(432, 20);
            this.ManulInputPoint.Name = "ManulInputPoint";
            this.ManulInputPoint.Size = new System.Drawing.Size(90, 30);
            this.ManulInputPoint.TabIndex = 0;
            this.ManulInputPoint.Text = "读点模式";
            this.ManulInputPoint.UseVisualStyleBackColor = true;
            this.ManulInputPoint.Click += new System.EventHandler(this.ManulInputPoint_Click);
            // 
            // ManulInputLine
            // 
            this.ManulInputLine.Location = new System.Drawing.Point(539, 20);
            this.ManulInputLine.Name = "ManulInputLine";
            this.ManulInputLine.Size = new System.Drawing.Size(90, 30);
            this.ManulInputLine.TabIndex = 0;
            this.ManulInputLine.Text = "读线模式";
            this.ManulInputLine.UseVisualStyleBackColor = true;
            this.ManulInputLine.Click += new System.EventHandler(this.ManulInputLine_Click);
            // 
            // SY_AIX
            // 
            this.SY_AIX.Location = new System.Drawing.Point(155, 34);
            this.SY_AIX.Name = "SY_AIX";
            this.SY_AIX.Size = new System.Drawing.Size(272, 21);
            this.SY_AIX.TabIndex = 2;
            // 
            // SX_AIX
            // 
            this.SX_AIX.Location = new System.Drawing.Point(155, 12);
            this.SX_AIX.Name = "SX_AIX";
            this.SX_AIX.Size = new System.Drawing.Size(272, 21);
            this.SX_AIX.TabIndex = 2;
            // 
            // SetRefPoint
            // 
            this.SetRefPoint.Location = new System.Drawing.Point(6, 20);
            this.SetRefPoint.Name = "SetRefPoint";
            this.SetRefPoint.Size = new System.Drawing.Size(90, 30);
            this.SetRefPoint.TabIndex = 0;
            this.SetRefPoint.Text = "设定参考点";
            this.SetRefPoint.UseVisualStyleBackColor = true;
            this.SetRefPoint.Click += new System.EventHandler(this.SetRefPoint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.AutoRead);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ManulInputPoint);
            this.groupBox1.Controls.Add(this.ManulInputLine);
            this.groupBox1.Controls.Add(this.SY_AIX);
            this.groupBox1.Controls.Add(this.SX_AIX);
            this.groupBox1.Controls.Add(this.SetRefPoint);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 59);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拾取对象";
            // 
            // SocketLogs
            // 
            this.SocketLogs.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SocketLogs.Location = new System.Drawing.Point(12, 398);
            this.SocketLogs.Multiline = true;
            this.SocketLogs.Name = "SocketLogs";
            this.SocketLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SocketLogs.Size = new System.Drawing.Size(747, 235);
            this.SocketLogs.TabIndex = 9;
            this.SocketLogs.Text = "SocketLogs:";
            // 
            // ClearLogs
            // 
            this.ClearLogs.Location = new System.Drawing.Point(230, 648);
            this.ClearLogs.Name = "ClearLogs";
            this.ClearLogs.Size = new System.Drawing.Size(90, 30);
            this.ClearLogs.TabIndex = 10;
            this.ClearLogs.Text = "清空记录";
            this.ClearLogs.UseVisualStyleBackColor = true;
            this.ClearLogs.Click += new System.EventHandler(this.ClearLogs_Click);
            // 
            // ClearModel
            // 
            this.ClearModel.Location = new System.Drawing.Point(339, 648);
            this.ClearModel.Name = "ClearModel";
            this.ClearModel.Size = new System.Drawing.Size(90, 30);
            this.ClearModel.TabIndex = 10;
            this.ClearModel.Text = "清空模型";
            this.ClearModel.UseVisualStyleBackColor = true;
            this.ClearModel.Click += new System.EventHandler(this.ClearModel_Click);
            // 
            // ExploreJT
            // 
            this.ExploreJT.Location = new System.Drawing.Point(557, 648);
            this.ExploreJT.Name = "ExploreJT";
            this.ExploreJT.Size = new System.Drawing.Size(90, 30);
            this.ExploreJT.TabIndex = 3;
            this.ExploreJT.Text = "导出JT";
            this.ExploreJT.UseVisualStyleBackColor = true;
            this.ExploreJT.Click += new System.EventHandler(this.ExploreJT_Click);
            // 
            // DrawFence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(770, 690);
            this.Controls.Add(this.ClearModel);
            this.Controls.Add(this.ClearLogs);
            this.Controls.Add(this.SocketLogs);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.OutExcel);
            this.Controls.Add(this.ExploreJT);
            this.Controls.Add(this.DeleteLastFence);
            this.Controls.Add(this.ClearData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TestSocket);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(786, 729);
            this.MinimumSize = new System.Drawing.Size(786, 729);
            this.Name = "DrawFence";
            this.Text = "围栏同步设计";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DrawFence_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn mIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ydata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radius;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArcAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn FwAngle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton MannuSetFW;
        private System.Windows.Forms.RadioButton AutoSetFW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton LishanRoad;
        private System.Windows.Forms.RadioButton ContinuRoad;
        private System.Windows.Forms.Button OutExcel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton DoubleRoadSelected;
        private System.Windows.Forms.RadioButton SingeRoadSelected;
        private System.Windows.Forms.Button DeleteLastFence;
        private System.Windows.Forms.Button ClearData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox Sscale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox KeepValue;
        private System.Windows.Forms.CheckBox ApplyPlantAix;
        private System.Windows.Forms.CheckBox ChangeXY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button TestSocket;
        private System.Windows.Forms.Button AutoRead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ManulInputPoint;
        private System.Windows.Forms.Button ManulInputLine;
        private System.Windows.Forms.TextBox SY_AIX;
        private System.Windows.Forms.TextBox SX_AIX;
        private System.Windows.Forms.Button SetRefPoint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox OnlineModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ServerIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ServerPort;
        private System.Windows.Forms.TextBox SocketLogs;
        private System.Windows.Forms.Button ClearLogs;
        private System.Windows.Forms.Button ClearModel;
        private System.Windows.Forms.Button ExploreJT;
    }
}