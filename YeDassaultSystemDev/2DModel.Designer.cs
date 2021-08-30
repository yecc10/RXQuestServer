
namespace YeDassaultSystemDev
{
    partial class _2DModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_2DModel));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.myMessage = new System.Windows.Forms.Label();
            this.Read3DPose = new System.Windows.Forms.Button();
            this.CheckPartDefine = new System.Windows.Forms.Button();
            this.Create2DDrawing = new System.Windows.Forms.Button();
            this.PartlistBox = new System.Windows.Forms.ListBox();
            this.UnitName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UnitPartProductList = new System.Windows.Forms.ListBox();
            this.AddOne = new System.Windows.Forms.Button();
            this.RemoveOne = new System.Windows.Forms.Button();
            this.AddAll = new System.Windows.Forms.Button();
            this.ClearAll = new System.Windows.Forms.Button();
            this.ToTop = new System.Windows.Forms.Button();
            this.ToBottom = new System.Windows.Forms.Button();
            this.UnFindAttrPartList = new System.Windows.Forms.ListBox();
            this.TopView = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LeftView = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BottomView = new System.Windows.Forms.PictureBox();
            this.属性缺失零件 = new System.Windows.Forms.GroupBox();
            this.Reconnect = new System.Windows.Forms.Button();
            this.PartAttr = new System.Windows.Forms.TextBox();
            this.UpdateAttr = new System.Windows.Forms.Button();
            this.PartTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.NewType = new System.Windows.Forms.TextBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.RB7 = new System.Windows.Forms.RadioButton();
            this.RB6 = new System.Windows.Forms.RadioButton();
            this.RB5 = new System.Windows.Forms.RadioButton();
            this.RB4 = new System.Windows.Forms.RadioButton();
            this.RB3 = new System.Windows.Forms.RadioButton();
            this.RB2 = new System.Windows.Forms.RadioButton();
            this.RB1 = new System.Windows.Forms.RadioButton();
            this.CreateDraftView = new System.Windows.Forms.Button();
            this.ScalePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TopView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftView)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomView)).BeginInit();
            this.属性缺失零件.SuspendLayout();
            this.PartTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScalePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 676);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1094, 27);
            this.progressBar.TabIndex = 1;
            // 
            // myMessage
            // 
            this.myMessage.AutoSize = true;
            this.myMessage.Location = new System.Drawing.Point(565, 13);
            this.myMessage.Name = "myMessage";
            this.myMessage.Size = new System.Drawing.Size(137, 12);
            this.myMessage.TabIndex = 10;
            this.myMessage.Text = "软件消息：锐锋科技2021";
            // 
            // Read3DPose
            // 
            this.Read3DPose.Location = new System.Drawing.Point(3, 620);
            this.Read3DPose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Read3DPose.Name = "Read3DPose";
            this.Read3DPose.Size = new System.Drawing.Size(223, 43);
            this.Read3DPose.TabIndex = 11;
            this.Read3DPose.Text = "读取单元信息";
            this.Read3DPose.UseVisualStyleBackColor = true;
            this.Read3DPose.Click += new System.EventHandler(this.Read3DPose_Click);
            // 
            // CheckPartDefine
            // 
            this.CheckPartDefine.Location = new System.Drawing.Point(247, 620);
            this.CheckPartDefine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckPartDefine.Name = "CheckPartDefine";
            this.CheckPartDefine.Size = new System.Drawing.Size(133, 43);
            this.CheckPartDefine.TabIndex = 11;
            this.CheckPartDefine.Text = "检查零件定义";
            this.CheckPartDefine.UseVisualStyleBackColor = true;
            this.CheckPartDefine.Click += new System.EventHandler(this.CheckPartDefine_Click);
            // 
            // Create2DDrawing
            // 
            this.Create2DDrawing.Location = new System.Drawing.Point(558, 620);
            this.Create2DDrawing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Create2DDrawing.Name = "Create2DDrawing";
            this.Create2DDrawing.Size = new System.Drawing.Size(133, 43);
            this.Create2DDrawing.TabIndex = 11;
            this.Create2DDrawing.Text = "创建2D图框";
            this.Create2DDrawing.UseVisualStyleBackColor = true;
            this.Create2DDrawing.Click += new System.EventHandler(this.Create2DDrawing_Click);
            // 
            // PartlistBox
            // 
            this.PartlistBox.FormattingEnabled = true;
            this.PartlistBox.ItemHeight = 12;
            this.PartlistBox.Location = new System.Drawing.Point(7, 24);
            this.PartlistBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PartlistBox.Name = "PartlistBox";
            this.PartlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PartlistBox.Size = new System.Drawing.Size(225, 532);
            this.PartlistBox.TabIndex = 12;
            // 
            // UnitName
            // 
            this.UnitName.AutoSize = true;
            this.UnitName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UnitName.Location = new System.Drawing.Point(38, 11);
            this.UnitName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UnitName.Name = "UnitName";
            this.UnitName.Size = new System.Drawing.Size(168, 14);
            this.UnitName.TabIndex = 13;
            this.UnitName.Text = "X-XXXX-XXXXX-XXX-XXX-00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID:";
            // 
            // UnitPartProductList
            // 
            this.UnitPartProductList.FormattingEnabled = true;
            this.UnitPartProductList.ItemHeight = 12;
            this.UnitPartProductList.Location = new System.Drawing.Point(8, 24);
            this.UnitPartProductList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UnitPartProductList.Name = "UnitPartProductList";
            this.UnitPartProductList.Size = new System.Drawing.Size(225, 532);
            this.UnitPartProductList.TabIndex = 12;
            this.UnitPartProductList.SelectedIndexChanged += new System.EventHandler(this.UnitPartProductList_SelectedIndexChanged);
            // 
            // AddOne
            // 
            this.AddOne.Location = new System.Drawing.Point(262, 131);
            this.AddOne.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddOne.Name = "AddOne";
            this.AddOne.Size = new System.Drawing.Size(50, 29);
            this.AddOne.TabIndex = 14;
            this.AddOne.Text = "增加";
            this.AddOne.UseVisualStyleBackColor = true;
            this.AddOne.Click += new System.EventHandler(this.AddOne_Click);
            // 
            // RemoveOne
            // 
            this.RemoveOne.Location = new System.Drawing.Point(262, 195);
            this.RemoveOne.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RemoveOne.Name = "RemoveOne";
            this.RemoveOne.Size = new System.Drawing.Size(50, 29);
            this.RemoveOne.TabIndex = 14;
            this.RemoveOne.Text = "移除";
            this.RemoveOne.UseVisualStyleBackColor = true;
            this.RemoveOne.Click += new System.EventHandler(this.RemoveOne_Click);
            // 
            // AddAll
            // 
            this.AddAll.Location = new System.Drawing.Point(262, 259);
            this.AddAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddAll.Name = "AddAll";
            this.AddAll.Size = new System.Drawing.Size(50, 29);
            this.AddAll.TabIndex = 14;
            this.AddAll.Text = "全选";
            this.AddAll.UseVisualStyleBackColor = true;
            this.AddAll.Click += new System.EventHandler(this.AddAll_Click);
            // 
            // ClearAll
            // 
            this.ClearAll.Location = new System.Drawing.Point(262, 323);
            this.ClearAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(50, 29);
            this.ClearAll.TabIndex = 14;
            this.ClearAll.Text = "清选";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // ToTop
            // 
            this.ToTop.Location = new System.Drawing.Point(262, 387);
            this.ToTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ToTop.Name = "ToTop";
            this.ToTop.Size = new System.Drawing.Size(50, 29);
            this.ToTop.TabIndex = 14;
            this.ToTop.Text = "上移";
            this.ToTop.UseVisualStyleBackColor = true;
            // 
            // ToBottom
            // 
            this.ToBottom.Location = new System.Drawing.Point(262, 451);
            this.ToBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ToBottom.Name = "ToBottom";
            this.ToBottom.Size = new System.Drawing.Size(50, 29);
            this.ToBottom.TabIndex = 14;
            this.ToBottom.Text = "下移";
            this.ToBottom.UseVisualStyleBackColor = true;
            // 
            // UnFindAttrPartList
            // 
            this.UnFindAttrPartList.FormattingEnabled = true;
            this.UnFindAttrPartList.ItemHeight = 12;
            this.UnFindAttrPartList.Location = new System.Drawing.Point(4, 25);
            this.UnFindAttrPartList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UnFindAttrPartList.Name = "UnFindAttrPartList";
            this.UnFindAttrPartList.Size = new System.Drawing.Size(251, 232);
            this.UnFindAttrPartList.TabIndex = 12;
            this.UnFindAttrPartList.Click += new System.EventHandler(this.UnFindAttrPartList_Click);
            // 
            // TopView
            // 
            this.TopView.Location = new System.Drawing.Point(8, 16);
            this.TopView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TopView.Name = "TopView";
            this.TopView.Size = new System.Drawing.Size(253, 245);
            this.TopView.TabIndex = 15;
            this.TopView.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PartlistBox);
            this.groupBox1.Location = new System.Drawing.Point(8, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(240, 569);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单元内零件信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UnitPartProductList);
            this.groupBox2.Location = new System.Drawing.Point(316, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(239, 569);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "需要创建2D草图的零件";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TopView);
            this.groupBox3.Location = new System.Drawing.Point(559, 41);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(267, 267);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "正视图";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LeftView);
            this.groupBox4.Location = new System.Drawing.Point(830, 41);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(267, 267);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "左视图";
            // 
            // LeftView
            // 
            this.LeftView.Location = new System.Drawing.Point(4, 16);
            this.LeftView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LeftView.Name = "LeftView";
            this.LeftView.Size = new System.Drawing.Size(253, 245);
            this.LeftView.TabIndex = 0;
            this.LeftView.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BottomView);
            this.groupBox5.Location = new System.Drawing.Point(559, 311);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(267, 267);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "俯视图";
            // 
            // BottomView
            // 
            this.BottomView.Location = new System.Drawing.Point(8, 18);
            this.BottomView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BottomView.Name = "BottomView";
            this.BottomView.Size = new System.Drawing.Size(253, 245);
            this.BottomView.TabIndex = 0;
            this.BottomView.TabStop = false;
            // 
            // 属性缺失零件
            // 
            this.属性缺失零件.Controls.Add(this.UnFindAttrPartList);
            this.属性缺失零件.Location = new System.Drawing.Point(830, 311);
            this.属性缺失零件.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.属性缺失零件.Name = "属性缺失零件";
            this.属性缺失零件.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.属性缺失零件.Size = new System.Drawing.Size(267, 267);
            this.属性缺失零件.TabIndex = 21;
            this.属性缺失零件.TabStop = false;
            this.属性缺失零件.Text = "属性缺失零件【点击修复】";
            // 
            // Reconnect
            // 
            this.Reconnect.Location = new System.Drawing.Point(963, 620);
            this.Reconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reconnect.Name = "Reconnect";
            this.Reconnect.Size = new System.Drawing.Size(133, 43);
            this.Reconnect.TabIndex = 11;
            this.Reconnect.Text = "重新连接CATIA";
            this.Reconnect.UseVisualStyleBackColor = true;
            this.Reconnect.Click += new System.EventHandler(this.Reconnect_Click);
            // 
            // PartAttr
            // 
            this.PartAttr.Location = new System.Drawing.Point(559, 582);
            this.PartAttr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PartAttr.Multiline = true;
            this.PartAttr.Name = "PartAttr";
            this.PartAttr.Size = new System.Drawing.Size(539, 30);
            this.PartAttr.TabIndex = 22;
            // 
            // UpdateAttr
            // 
            this.UpdateAttr.Location = new System.Drawing.Point(403, 620);
            this.UpdateAttr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UpdateAttr.Name = "UpdateAttr";
            this.UpdateAttr.Size = new System.Drawing.Size(133, 43);
            this.UpdateAttr.TabIndex = 11;
            this.UpdateAttr.Text = "重新定义属性";
            this.UpdateAttr.UseVisualStyleBackColor = true;
            this.UpdateAttr.Click += new System.EventHandler(this.UpdateAttr_Click);
            // 
            // PartTypeGroupBox
            // 
            this.PartTypeGroupBox.Controls.Add(this.NewType);
            this.PartTypeGroupBox.Controls.Add(this.radioButton4);
            this.PartTypeGroupBox.Controls.Add(this.radioButton2);
            this.PartTypeGroupBox.Controls.Add(this.radioButton3);
            this.PartTypeGroupBox.Controls.Add(this.radioButton1);
            this.PartTypeGroupBox.Controls.Add(this.RB7);
            this.PartTypeGroupBox.Controls.Add(this.RB6);
            this.PartTypeGroupBox.Controls.Add(this.RB5);
            this.PartTypeGroupBox.Controls.Add(this.RB4);
            this.PartTypeGroupBox.Controls.Add(this.RB3);
            this.PartTypeGroupBox.Controls.Add(this.RB2);
            this.PartTypeGroupBox.Controls.Add(this.RB1);
            this.PartTypeGroupBox.Location = new System.Drawing.Point(1101, 47);
            this.PartTypeGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PartTypeGroupBox.Name = "PartTypeGroupBox";
            this.PartTypeGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PartTypeGroupBox.Size = new System.Drawing.Size(133, 521);
            this.PartTypeGroupBox.TabIndex = 23;
            this.PartTypeGroupBox.TabStop = false;
            this.PartTypeGroupBox.Text = "零件类型";
            // 
            // NewType
            // 
            this.NewType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewType.Location = new System.Drawing.Point(0, 491);
            this.NewType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NewType.Name = "NewType";
            this.NewType.Size = new System.Drawing.Size(126, 26);
            this.NewType.TabIndex = 4;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton4.Location = new System.Drawing.Point(10, 412);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(75, 16);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "感知支架";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(10, 326);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 16);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "连接销";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(10, 369);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(62, 16);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "防护罩";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(10, 283);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "定位销";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // RB7
            // 
            this.RB7.AutoSize = true;
            this.RB7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RB7.Location = new System.Drawing.Point(10, 455);
            this.RB7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RB7.Name = "RB7";
            this.RB7.Size = new System.Drawing.Size(51, 16);
            this.RB7.TabIndex = 0;
            this.RB7.Text = "Base";
            this.RB7.UseVisualStyleBackColor = true;
            this.RB7.CheckedChanged += new System.EventHandler(this.RB7_CheckedChanged);
            // 
            // RB6
            // 
            this.RB6.AutoSize = true;
            this.RB6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RB6.Location = new System.Drawing.Point(10, 240);
            this.RB6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RB6.Name = "RB6";
            this.RB6.Size = new System.Drawing.Size(49, 16);
            this.RB6.TabIndex = 0;
            this.RB6.Text = "销座";
            this.RB6.UseVisualStyleBackColor = true;
            this.RB6.CheckedChanged += new System.EventHandler(this.RB6_CheckedChanged);
            // 
            // RB5
            // 
            this.RB5.AutoSize = true;
            this.RB5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RB5.Location = new System.Drawing.Point(10, 197);
            this.RB5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RB5.Name = "RB5";
            this.RB5.Size = new System.Drawing.Size(49, 16);
            this.RB5.TabIndex = 0;
            this.RB5.Text = "压臂";
            this.RB5.UseVisualStyleBackColor = true;
            this.RB5.CheckedChanged += new System.EventHandler(this.RB5_CheckedChanged);
            // 
            // RB4
            // 
            this.RB4.AutoSize = true;
            this.RB4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RB4.Location = new System.Drawing.Point(10, 154);
            this.RB4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RB4.Name = "RB4";
            this.RB4.Size = new System.Drawing.Size(62, 16);
            this.RB4.TabIndex = 0;
            this.RB4.Text = "压紧块";
            this.RB4.UseVisualStyleBackColor = true;
            this.RB4.CheckedChanged += new System.EventHandler(this.RB4_CheckedChanged);
            // 
            // RB3
            // 
            this.RB3.AutoSize = true;
            this.RB3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RB3.Location = new System.Drawing.Point(10, 111);
            this.RB3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RB3.Name = "RB3";
            this.RB3.Size = new System.Drawing.Size(49, 16);
            this.RB3.TabIndex = 0;
            this.RB3.Text = "脚座";
            this.RB3.UseVisualStyleBackColor = true;
            this.RB3.CheckedChanged += new System.EventHandler(this.RB3_CheckedChanged);
            // 
            // RB2
            // 
            this.RB2.AutoSize = true;
            this.RB2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RB2.Location = new System.Drawing.Point(10, 68);
            this.RB2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RB2.Name = "RB2";
            this.RB2.Size = new System.Drawing.Size(62, 16);
            this.RB2.TabIndex = 0;
            this.RB2.Text = "连接块";
            this.RB2.UseVisualStyleBackColor = true;
            this.RB2.CheckedChanged += new System.EventHandler(this.RB2_CheckedChanged);
            // 
            // RB1
            // 
            this.RB1.AutoSize = true;
            this.RB1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RB1.Location = new System.Drawing.Point(10, 25);
            this.RB1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RB1.Name = "RB1";
            this.RB1.Size = new System.Drawing.Size(62, 16);
            this.RB1.TabIndex = 0;
            this.RB1.Text = "定位块";
            this.RB1.UseVisualStyleBackColor = true;
            this.RB1.CheckedChanged += new System.EventHandler(this.RB1_CheckedChanged);
            // 
            // CreateDraftView
            // 
            this.CreateDraftView.Location = new System.Drawing.Point(713, 620);
            this.CreateDraftView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreateDraftView.Name = "CreateDraftView";
            this.CreateDraftView.Size = new System.Drawing.Size(133, 43);
            this.CreateDraftView.TabIndex = 11;
            this.CreateDraftView.Text = "创建3D零件投影";
            this.CreateDraftView.UseVisualStyleBackColor = true;
            this.CreateDraftView.Click += new System.EventHandler(this.CreateDraftView_Click);
            // 
            // ScalePicture
            // 
            this.ScalePicture.Location = new System.Drawing.Point(1106, 573);
            this.ScalePicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ScalePicture.Name = "ScalePicture";
            this.ScalePicture.Size = new System.Drawing.Size(130, 130);
            this.ScalePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ScalePicture.TabIndex = 24;
            this.ScalePicture.TabStop = false;
            // 
            // _2DModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1247, 727);
            this.Controls.Add(this.ScalePicture);
            this.Controls.Add(this.PartTypeGroupBox);
            this.Controls.Add(this.PartAttr);
            this.Controls.Add(this.属性缺失零件);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ToBottom);
            this.Controls.Add(this.ToTop);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.AddAll);
            this.Controls.Add(this.RemoveOne);
            this.Controls.Add(this.AddOne);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UnitName);
            this.Controls.Add(this.Reconnect);
            this.Controls.Add(this.CreateDraftView);
            this.Controls.Add(this.UpdateAttr);
            this.Controls.Add(this.Create2DDrawing);
            this.Controls.Add(this.CheckPartDefine);
            this.Controls.Add(this.Read3DPose);
            this.Controls.Add(this.myMessage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(1142, 696);
            this.Name = "_2DModel";
            this.Text = "锐锋科技CATIA投影助手";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this._2DModel_FormClosed);
            this.Load += new System.EventHandler(this._2DModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TopView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftView)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomView)).EndInit();
            this.属性缺失零件.ResumeLayout(false);
            this.PartTypeGroupBox.ResumeLayout(false);
            this.PartTypeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScalePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label myMessage;
        private System.Windows.Forms.Button Read3DPose;
        private System.Windows.Forms.Button CheckPartDefine;
        private System.Windows.Forms.Button Create2DDrawing;
        private System.Windows.Forms.ListBox PartlistBox;
        private System.Windows.Forms.Label UnitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox UnitPartProductList;
        private System.Windows.Forms.Button AddOne;
        private System.Windows.Forms.Button RemoveOne;
        private System.Windows.Forms.Button AddAll;
        private System.Windows.Forms.Button ClearAll;
        private System.Windows.Forms.Button ToTop;
        private System.Windows.Forms.Button ToBottom;
        private System.Windows.Forms.ListBox UnFindAttrPartList;
        private System.Windows.Forms.PictureBox TopView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox 属性缺失零件;
        private System.Windows.Forms.PictureBox LeftView;
        private System.Windows.Forms.PictureBox BottomView;
        private System.Windows.Forms.Button Reconnect;
        private System.Windows.Forms.TextBox PartAttr;
        private System.Windows.Forms.Button UpdateAttr;
        private System.Windows.Forms.GroupBox PartTypeGroupBox;
        private System.Windows.Forms.RadioButton RB7;
        private System.Windows.Forms.RadioButton RB6;
        private System.Windows.Forms.RadioButton RB5;
        private System.Windows.Forms.RadioButton RB4;
        private System.Windows.Forms.RadioButton RB3;
        private System.Windows.Forms.RadioButton RB2;
        private System.Windows.Forms.RadioButton RB1;
        private System.Windows.Forms.TextBox NewType;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button CreateDraftView;
        private System.Windows.Forms.PictureBox ScalePicture;
    }
}