
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
            this.FrontView = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LeftView = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BottomView = new System.Windows.Forms.PictureBox();
            this.属性缺失零件 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Reconnect = new System.Windows.Forms.Button();
            this.PartAttr = new System.Windows.Forms.TextBox();
            this.UpdateAttr = new System.Windows.Forms.Button();
            this.PartTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.PartAttList = new System.Windows.Forms.ComboBox();
            this.SetPartAtt = new System.Windows.Forms.Button();
            this.CreateDraftView = new System.Windows.Forms.Button();
            this.获取图框中路清单 = new System.Windows.Forms.GroupBox();
            this.AttrNumber = new System.Windows.Forms.TextBox();
            this.GetViaPartAtt = new System.Windows.Forms.Button();
            this.CheckMetera = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.materialList = new System.Windows.Forms.ComboBox();
            this.SetPartmaterial = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.materialNumber = new System.Windows.Forms.TextBox();
            this.GetmaterialFromDoc = new System.Windows.Forms.Button();
            this.ExploreIGS = new System.Windows.Forms.Button();
            this.ScalePicture = new System.Windows.Forms.PictureBox();
            this.FIA = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.TFA = new System.Windows.Forms.RadioButton();
            this.PictureFromCatia = new System.Windows.Forms.CheckBox();
            this.Symmetry = new System.Windows.Forms.CheckBox();
            this.PeNum = new System.Windows.Forms.TextBox();
            this.PeNumOpen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.FrontView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftView)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomView)).BeginInit();
            this.属性缺失零件.SuspendLayout();
            this.PartTypeGroupBox.SuspendLayout();
            this.获取图框中路清单.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScalePicture)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(4, 1014);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1641, 40);
            this.progressBar.TabIndex = 1;
            // 
            // myMessage
            // 
            this.myMessage.AutoSize = true;
            this.myMessage.Location = new System.Drawing.Point(848, 20);
            this.myMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myMessage.Name = "myMessage";
            this.myMessage.Size = new System.Drawing.Size(206, 18);
            this.myMessage.TabIndex = 10;
            this.myMessage.Text = "软件消息：锐锋科技2021";
            // 
            // Read3DPose
            // 
            this.Read3DPose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Read3DPose.Location = new System.Drawing.Point(4, 930);
            this.Read3DPose.Name = "Read3DPose";
            this.Read3DPose.Size = new System.Drawing.Size(334, 64);
            this.Read3DPose.TabIndex = 11;
            this.Read3DPose.Text = "读取单元信息";
            this.Read3DPose.UseVisualStyleBackColor = false;
            this.Read3DPose.Click += new System.EventHandler(this.Read3DPose_Click);
            // 
            // CheckPartDefine
            // 
            this.CheckPartDefine.BackColor = System.Drawing.Color.Goldenrod;
            this.CheckPartDefine.Location = new System.Drawing.Point(572, 930);
            this.CheckPartDefine.Name = "CheckPartDefine";
            this.CheckPartDefine.Size = new System.Drawing.Size(200, 64);
            this.CheckPartDefine.TabIndex = 11;
            this.CheckPartDefine.Text = "零件定义检查";
            this.CheckPartDefine.UseVisualStyleBackColor = false;
            this.CheckPartDefine.Click += new System.EventHandler(this.CheckPartDefine_Click);
            // 
            // Create2DDrawing
            // 
            this.Create2DDrawing.BackColor = System.Drawing.Color.Fuchsia;
            this.Create2DDrawing.Location = new System.Drawing.Point(1006, 930);
            this.Create2DDrawing.Name = "Create2DDrawing";
            this.Create2DDrawing.Size = new System.Drawing.Size(200, 64);
            this.Create2DDrawing.TabIndex = 11;
            this.Create2DDrawing.Text = "创建2D图框";
            this.Create2DDrawing.UseVisualStyleBackColor = false;
            this.Create2DDrawing.Click += new System.EventHandler(this.Create2DDrawing_Click);
            // 
            // PartlistBox
            // 
            this.PartlistBox.FormattingEnabled = true;
            this.PartlistBox.ItemHeight = 18;
            this.PartlistBox.Location = new System.Drawing.Point(10, 36);
            this.PartlistBox.Name = "PartlistBox";
            this.PartlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PartlistBox.Size = new System.Drawing.Size(336, 796);
            this.PartlistBox.TabIndex = 12;
            // 
            // UnitName
            // 
            this.UnitName.AutoSize = true;
            this.UnitName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UnitName.Location = new System.Drawing.Point(57, 16);
            this.UnitName.Name = "UnitName";
            this.UnitName.Size = new System.Drawing.Size(263, 21);
            this.UnitName.TabIndex = 13;
            this.UnitName.Text = "X-XXXX-XXXXX-XXX-XXX-00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID:";
            // 
            // UnitPartProductList
            // 
            this.UnitPartProductList.FormattingEnabled = true;
            this.UnitPartProductList.ItemHeight = 18;
            this.UnitPartProductList.Location = new System.Drawing.Point(6, 36);
            this.UnitPartProductList.Name = "UnitPartProductList";
            this.UnitPartProductList.Size = new System.Drawing.Size(342, 796);
            this.UnitPartProductList.TabIndex = 12;
            this.UnitPartProductList.Click += new System.EventHandler(this.UnitPartProductList_SelectedIndexChanged);
            // 
            // AddOne
            // 
            this.AddOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.AddOne.Location = new System.Drawing.Point(384, 75);
            this.AddOne.Name = "AddOne";
            this.AddOne.Size = new System.Drawing.Size(104, 60);
            this.AddOne.TabIndex = 14;
            this.AddOne.Text = "增加";
            this.AddOne.UseVisualStyleBackColor = false;
            this.AddOne.Click += new System.EventHandler(this.AddOne_Click);
            // 
            // RemoveOne
            // 
            this.RemoveOne.BackColor = System.Drawing.Color.SteelBlue;
            this.RemoveOne.Location = new System.Drawing.Point(384, 168);
            this.RemoveOne.Name = "RemoveOne";
            this.RemoveOne.Size = new System.Drawing.Size(104, 60);
            this.RemoveOne.TabIndex = 14;
            this.RemoveOne.Text = "移除";
            this.RemoveOne.UseVisualStyleBackColor = false;
            this.RemoveOne.Click += new System.EventHandler(this.RemoveOne_Click);
            // 
            // AddAll
            // 
            this.AddAll.BackColor = System.Drawing.Color.SteelBlue;
            this.AddAll.Location = new System.Drawing.Point(384, 261);
            this.AddAll.Name = "AddAll";
            this.AddAll.Size = new System.Drawing.Size(104, 60);
            this.AddAll.TabIndex = 14;
            this.AddAll.Text = "全选";
            this.AddAll.UseVisualStyleBackColor = false;
            this.AddAll.Click += new System.EventHandler(this.AddAll_Click);
            // 
            // ClearAll
            // 
            this.ClearAll.BackColor = System.Drawing.Color.SteelBlue;
            this.ClearAll.Location = new System.Drawing.Point(384, 354);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(104, 60);
            this.ClearAll.TabIndex = 14;
            this.ClearAll.Text = "清选";
            this.ClearAll.UseVisualStyleBackColor = false;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // ToTop
            // 
            this.ToTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ToTop.Location = new System.Drawing.Point(384, 447);
            this.ToTop.Name = "ToTop";
            this.ToTop.Size = new System.Drawing.Size(104, 60);
            this.ToTop.TabIndex = 14;
            this.ToTop.Text = "上移";
            this.ToTop.UseVisualStyleBackColor = false;
            this.ToTop.Click += new System.EventHandler(this.ToTop_Click);
            // 
            // ToBottom
            // 
            this.ToBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ToBottom.Location = new System.Drawing.Point(384, 540);
            this.ToBottom.Name = "ToBottom";
            this.ToBottom.Size = new System.Drawing.Size(104, 60);
            this.ToBottom.TabIndex = 14;
            this.ToBottom.Text = "下移";
            this.ToBottom.UseVisualStyleBackColor = false;
            this.ToBottom.Click += new System.EventHandler(this.ToBottom_Click);
            // 
            // UnFindAttrPartList
            // 
            this.UnFindAttrPartList.FormattingEnabled = true;
            this.UnFindAttrPartList.ItemHeight = 18;
            this.UnFindAttrPartList.Location = new System.Drawing.Point(6, 38);
            this.UnFindAttrPartList.Name = "UnFindAttrPartList";
            this.UnFindAttrPartList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.UnFindAttrPartList.Size = new System.Drawing.Size(374, 346);
            this.UnFindAttrPartList.TabIndex = 12;
            this.UnFindAttrPartList.Click += new System.EventHandler(this.UnFindAttrPartList_Click);
            // 
            // FrontView
            // 
            this.FrontView.Location = new System.Drawing.Point(12, 24);
            this.FrontView.Name = "FrontView";
            this.FrontView.Size = new System.Drawing.Size(380, 368);
            this.FrontView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FrontView.TabIndex = 15;
            this.FrontView.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PartlistBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 854);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单元内零件信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UnitPartProductList);
            this.groupBox2.Location = new System.Drawing.Point(495, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 854);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "需要创建2D草图的零件";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FrontView);
            this.groupBox3.Location = new System.Drawing.Point(838, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 400);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "正视图";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LeftView);
            this.groupBox4.Location = new System.Drawing.Point(1245, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 400);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "左视图";
            // 
            // LeftView
            // 
            this.LeftView.Location = new System.Drawing.Point(6, 24);
            this.LeftView.Name = "LeftView";
            this.LeftView.Size = new System.Drawing.Size(380, 368);
            this.LeftView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LeftView.TabIndex = 0;
            this.LeftView.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BottomView);
            this.groupBox5.Location = new System.Drawing.Point(838, 466);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(400, 400);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "俯视图";
            // 
            // BottomView
            // 
            this.BottomView.Location = new System.Drawing.Point(12, 27);
            this.BottomView.Name = "BottomView";
            this.BottomView.Size = new System.Drawing.Size(380, 368);
            this.BottomView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BottomView.TabIndex = 0;
            this.BottomView.TabStop = false;
            // 
            // 属性缺失零件
            // 
            this.属性缺失零件.Controls.Add(this.UnFindAttrPartList);
            this.属性缺失零件.Controls.Add(this.textBox1);
            this.属性缺失零件.Location = new System.Drawing.Point(1245, 466);
            this.属性缺失零件.Name = "属性缺失零件";
            this.属性缺失零件.Size = new System.Drawing.Size(400, 400);
            this.属性缺失零件.TabIndex = 21;
            this.属性缺失零件.TabStop = false;
            this.属性缺失零件.Text = "待解决对象【点击修复】";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(422, 225);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 43);
            this.textBox1.TabIndex = 22;
            // 
            // Reconnect
            // 
            this.Reconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Reconnect.Location = new System.Drawing.Point(1440, 930);
            this.Reconnect.Name = "Reconnect";
            this.Reconnect.Size = new System.Drawing.Size(200, 64);
            this.Reconnect.TabIndex = 11;
            this.Reconnect.Text = "重新连接CATIA";
            this.Reconnect.UseVisualStyleBackColor = false;
            this.Reconnect.Click += new System.EventHandler(this.Reconnect_Click);
            // 
            // PartAttr
            // 
            this.PartAttr.Location = new System.Drawing.Point(838, 873);
            this.PartAttr.Multiline = true;
            this.PartAttr.Name = "PartAttr";
            this.PartAttr.Size = new System.Drawing.Size(806, 43);
            this.PartAttr.TabIndex = 22;
            // 
            // UpdateAttr
            // 
            this.UpdateAttr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.UpdateAttr.Location = new System.Drawing.Point(356, 930);
            this.UpdateAttr.Name = "UpdateAttr";
            this.UpdateAttr.Size = new System.Drawing.Size(200, 64);
            this.UpdateAttr.TabIndex = 11;
            this.UpdateAttr.Text = "重新定义属性";
            this.UpdateAttr.UseVisualStyleBackColor = false;
            this.UpdateAttr.Click += new System.EventHandler(this.UpdateAttr_Click);
            // 
            // PartTypeGroupBox
            // 
            this.PartTypeGroupBox.Controls.Add(this.PartAttList);
            this.PartTypeGroupBox.Controls.Add(this.SetPartAtt);
            this.PartTypeGroupBox.Location = new System.Drawing.Point(1659, 466);
            this.PartTypeGroupBox.Name = "PartTypeGroupBox";
            this.PartTypeGroupBox.Size = new System.Drawing.Size(200, 189);
            this.PartTypeGroupBox.TabIndex = 23;
            this.PartTypeGroupBox.TabStop = false;
            this.PartTypeGroupBox.Text = "零件类型";
            // 
            // PartAttList
            // 
            this.PartAttList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartAttList.FormattingEnabled = true;
            this.PartAttList.Items.AddRange(new object[] {
            "定位块",
            "连接块",
            "脚座",
            "压紧块",
            "压臂",
            "销座",
            "Base"});
            this.PartAttList.Location = new System.Drawing.Point(8, 44);
            this.PartAttList.Name = "PartAttList";
            this.PartAttList.Size = new System.Drawing.Size(187, 32);
            this.PartAttList.TabIndex = 0;
            this.PartAttList.TextChanged += new System.EventHandler(this.PartAttList_TabIndexChanged);
            // 
            // SetPartAtt
            // 
            this.SetPartAtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.SetPartAtt.Location = new System.Drawing.Point(8, 94);
            this.SetPartAtt.Name = "SetPartAtt";
            this.SetPartAtt.Size = new System.Drawing.Size(188, 64);
            this.SetPartAtt.TabIndex = 11;
            this.SetPartAtt.Text = "定义属性";
            this.SetPartAtt.UseVisualStyleBackColor = false;
            this.SetPartAtt.Click += new System.EventHandler(this.SetPartAtt_Click);
            // 
            // CreateDraftView
            // 
            this.CreateDraftView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CreateDraftView.Location = new System.Drawing.Point(1222, 930);
            this.CreateDraftView.Name = "CreateDraftView";
            this.CreateDraftView.Size = new System.Drawing.Size(200, 64);
            this.CreateDraftView.TabIndex = 11;
            this.CreateDraftView.Text = "创建3D零件投影";
            this.CreateDraftView.UseVisualStyleBackColor = false;
            this.CreateDraftView.Click += new System.EventHandler(this.CreateDraftView_Click);
            // 
            // 获取图框中路清单
            // 
            this.获取图框中路清单.Controls.Add(this.AttrNumber);
            this.获取图框中路清单.Controls.Add(this.GetViaPartAtt);
            this.获取图框中路清单.Location = new System.Drawing.Point(1659, 664);
            this.获取图框中路清单.Name = "获取图框中路清单";
            this.获取图框中路清单.Size = new System.Drawing.Size(200, 178);
            this.获取图框中路清单.TabIndex = 23;
            this.获取图框中路清单.TabStop = false;
            this.获取图框中路清单.Text = "获取图框种类清单";
            // 
            // AttrNumber
            // 
            this.AttrNumber.Font = new System.Drawing.Font("宋体", 12F);
            this.AttrNumber.Location = new System.Drawing.Point(8, 40);
            this.AttrNumber.Name = "AttrNumber";
            this.AttrNumber.Size = new System.Drawing.Size(187, 35);
            this.AttrNumber.TabIndex = 12;
            this.AttrNumber.Text = "15";
            this.AttrNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GetViaPartAtt
            // 
            this.GetViaPartAtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.GetViaPartAtt.Location = new System.Drawing.Point(8, 94);
            this.GetViaPartAtt.Name = "GetViaPartAtt";
            this.GetViaPartAtt.Size = new System.Drawing.Size(188, 64);
            this.GetViaPartAtt.TabIndex = 11;
            this.GetViaPartAtt.Text = "获取属性";
            this.GetViaPartAtt.UseVisualStyleBackColor = false;
            this.GetViaPartAtt.Click += new System.EventHandler(this.GetViaPartAtt_Click);
            // 
            // CheckMetera
            // 
            this.CheckMetera.BackColor = System.Drawing.Color.Goldenrod;
            this.CheckMetera.Location = new System.Drawing.Point(789, 930);
            this.CheckMetera.Name = "CheckMetera";
            this.CheckMetera.Size = new System.Drawing.Size(200, 64);
            this.CheckMetera.TabIndex = 11;
            this.CheckMetera.Text = "零件材质检查";
            this.CheckMetera.UseVisualStyleBackColor = false;
            this.CheckMetera.Click += new System.EventHandler(this.CheckMetera_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.materialList);
            this.groupBox6.Controls.Add(this.SetPartmaterial);
            this.groupBox6.Location = new System.Drawing.Point(1653, 266);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 189);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "材料类型";
            // 
            // materialList
            // 
            this.materialList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialList.FormattingEnabled = true;
            this.materialList.Location = new System.Drawing.Point(8, 44);
            this.materialList.Name = "materialList";
            this.materialList.Size = new System.Drawing.Size(187, 32);
            this.materialList.TabIndex = 0;
            this.materialList.TextChanged += new System.EventHandler(this.PartAttList_TabIndexChanged);
            // 
            // SetPartmaterial
            // 
            this.SetPartmaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.SetPartmaterial.Location = new System.Drawing.Point(8, 94);
            this.SetPartmaterial.Name = "SetPartmaterial";
            this.SetPartmaterial.Size = new System.Drawing.Size(188, 64);
            this.SetPartmaterial.TabIndex = 11;
            this.SetPartmaterial.Text = "定义属性";
            this.SetPartmaterial.UseVisualStyleBackColor = false;
            this.SetPartmaterial.Click += new System.EventHandler(this.SetPartmaterial_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.materialNumber);
            this.groupBox7.Controls.Add(this.GetmaterialFromDoc);
            this.groupBox7.Location = new System.Drawing.Point(1653, 62);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 178);
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "获取系统零件材料";
            // 
            // materialNumber
            // 
            this.materialNumber.Font = new System.Drawing.Font("宋体", 12F);
            this.materialNumber.Location = new System.Drawing.Point(8, 40);
            this.materialNumber.Name = "materialNumber";
            this.materialNumber.Size = new System.Drawing.Size(187, 35);
            this.materialNumber.TabIndex = 12;
            this.materialNumber.Text = "10";
            // 
            // GetmaterialFromDoc
            // 
            this.GetmaterialFromDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.GetmaterialFromDoc.Location = new System.Drawing.Point(8, 94);
            this.GetmaterialFromDoc.Name = "GetmaterialFromDoc";
            this.GetmaterialFromDoc.Size = new System.Drawing.Size(188, 64);
            this.GetmaterialFromDoc.TabIndex = 11;
            this.GetmaterialFromDoc.Text = "获取属性";
            this.GetmaterialFromDoc.UseVisualStyleBackColor = false;
            this.GetmaterialFromDoc.Click += new System.EventHandler(this.GetmaterialFromDoc_Click);
            // 
            // ExploreIGS
            // 
            this.ExploreIGS.BackColor = System.Drawing.Color.LimeGreen;
            this.ExploreIGS.Location = new System.Drawing.Point(384, 633);
            this.ExploreIGS.Name = "ExploreIGS";
            this.ExploreIGS.Size = new System.Drawing.Size(104, 60);
            this.ExploreIGS.TabIndex = 14;
            this.ExploreIGS.Text = "EIGS";
            this.ExploreIGS.UseVisualStyleBackColor = false;
            this.ExploreIGS.Click += new System.EventHandler(this.ExploreIGS_Click);
            // 
            // ScalePicture
            // 
            this.ScalePicture.Location = new System.Drawing.Point(1659, 860);
            this.ScalePicture.Name = "ScalePicture";
            this.ScalePicture.Size = new System.Drawing.Size(200, 195);
            this.ScalePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ScalePicture.TabIndex = 24;
            this.ScalePicture.TabStop = false;
            // 
            // FIA
            // 
            this.FIA.AutoSize = true;
            this.FIA.Checked = true;
            this.FIA.Location = new System.Drawing.Point(15, 52);
            this.FIA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FIA.Name = "FIA";
            this.FIA.Size = new System.Drawing.Size(69, 22);
            this.FIA.TabIndex = 25;
            this.FIA.TabStop = true;
            this.FIA.Text = "国标";
            this.FIA.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.TFA);
            this.groupBox8.Controls.Add(this.FIA);
            this.groupBox8.Location = new System.Drawing.Point(376, 759);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Size = new System.Drawing.Size(115, 156);
            this.groupBox8.TabIndex = 26;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "默认视角";
            // 
            // TFA
            // 
            this.TFA.AutoSize = true;
            this.TFA.Location = new System.Drawing.Point(15, 100);
            this.TFA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TFA.Name = "TFA";
            this.TFA.Size = new System.Drawing.Size(69, 22);
            this.TFA.TabIndex = 25;
            this.TFA.Text = "日标";
            this.TFA.UseVisualStyleBackColor = true;
            // 
            // PictureFromCatia
            // 
            this.PictureFromCatia.AutoSize = true;
            this.PictureFromCatia.Location = new System.Drawing.Point(1688, 16);
            this.PictureFromCatia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PictureFromCatia.Name = "PictureFromCatia";
            this.PictureFromCatia.Size = new System.Drawing.Size(178, 22);
            this.PictureFromCatia.TabIndex = 27;
            this.PictureFromCatia.Text = "PictureFromCatia";
            this.PictureFromCatia.UseVisualStyleBackColor = true;
            // 
            // Symmetry
            // 
            this.Symmetry.AutoSize = true;
            this.Symmetry.Checked = true;
            this.Symmetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Symmetry.Location = new System.Drawing.Point(384, 720);
            this.Symmetry.Margin = new System.Windows.Forms.Padding(4);
            this.Symmetry.Name = "Symmetry";
            this.Symmetry.Size = new System.Drawing.Size(106, 22);
            this.Symmetry.TabIndex = 27;
            this.Symmetry.Text = "Symmetry";
            this.Symmetry.UseVisualStyleBackColor = true;
            // 
            // PeNum
            // 
            this.PeNum.Enabled = false;
            this.PeNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PeNum.Location = new System.Drawing.Point(1581, 11);
            this.PeNum.Name = "PeNum";
            this.PeNum.Size = new System.Drawing.Size(100, 31);
            this.PeNum.TabIndex = 28;
            this.PeNum.Text = "2";
            this.PeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PeNumOpen
            // 
            this.PeNumOpen.AutoSize = true;
            this.PeNumOpen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PeNumOpen.Location = new System.Drawing.Point(1402, 13);
            this.PeNumOpen.Name = "PeNumOpen";
            this.PeNumOpen.Size = new System.Drawing.Size(173, 25);
            this.PeNumOpen.TabIndex = 29;
            this.PeNumOpen.Text = "启用前置预留:";
            this.PeNumOpen.UseVisualStyleBackColor = true;
            this.PeNumOpen.CheckedChanged += new System.EventHandler(this.PeNumOpen_CheckedChanged);
            // 
            // _2DModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1886, 1086);
            this.Controls.Add(this.PeNumOpen);
            this.Controls.Add(this.PeNum);
            this.Controls.Add(this.Symmetry);
            this.Controls.Add(this.PictureFromCatia);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.ScalePicture);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.获取图框中路清单);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.PartTypeGroupBox);
            this.Controls.Add(this.PartAttr);
            this.Controls.Add(this.属性缺失零件);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExploreIGS);
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
            this.Controls.Add(this.CheckMetera);
            this.Controls.Add(this.Create2DDrawing);
            this.Controls.Add(this.CheckPartDefine);
            this.Controls.Add(this.Read3DPose);
            this.Controls.Add(this.myMessage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1690, 980);
            this.Name = "_2DModel";
            this.Text = "锐锋科技CATIA投影助手";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this._2DModel_FormClosed);
            this.Load += new System.EventHandler(this._2DModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FrontView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftView)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomView)).EndInit();
            this.属性缺失零件.ResumeLayout(false);
            this.属性缺失零件.PerformLayout();
            this.PartTypeGroupBox.ResumeLayout(false);
            this.获取图框中路清单.ResumeLayout(false);
            this.获取图框中路清单.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScalePicture)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
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
        private System.Windows.Forms.PictureBox FrontView;
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
        private System.Windows.Forms.Button CreateDraftView;
        private System.Windows.Forms.ComboBox PartAttList;
        private System.Windows.Forms.Button SetPartAtt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox 获取图框中路清单;
        private System.Windows.Forms.TextBox AttrNumber;
        private System.Windows.Forms.Button GetViaPartAtt;
        private System.Windows.Forms.Button CheckMetera;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox materialList;
        private System.Windows.Forms.Button SetPartmaterial;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox materialNumber;
        private System.Windows.Forms.Button GetmaterialFromDoc;
        private System.Windows.Forms.Button ExploreIGS;
        private System.Windows.Forms.PictureBox ScalePicture;
        private System.Windows.Forms.RadioButton FIA;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton TFA;
        private System.Windows.Forms.CheckBox PictureFromCatia;
        private System.Windows.Forms.CheckBox Symmetry;
        private System.Windows.Forms.TextBox PeNum;
        private System.Windows.Forms.CheckBox PeNumOpen;
    }
}