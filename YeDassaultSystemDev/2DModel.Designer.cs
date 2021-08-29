
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ReConnectCATIA = new System.Windows.Forms.ToolStripButton();
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
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReConnectCATIA});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1514, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ReConnectCATIA
            // 
            this.ReConnectCATIA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReConnectCATIA.Image = global::YeDassaultSystemDev.Properties.Resources.Add;
            this.ReConnectCATIA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReConnectCATIA.Name = "ReConnectCATIA";
            this.ReConnectCATIA.Size = new System.Drawing.Size(34, 28);
            this.ReConnectCATIA.Text = "ReConnectCATIA";
            this.ReConnectCATIA.Click += new System.EventHandler(this.ReConnectCATIA_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 1040);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1499, 41);
            this.progressBar.TabIndex = 1;
            // 
            // myMessage
            // 
            this.myMessage.AutoSize = true;
            this.myMessage.Location = new System.Drawing.Point(9, 1084);
            this.myMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myMessage.Name = "myMessage";
            this.myMessage.Size = new System.Drawing.Size(35, 18);
            this.myMessage.TabIndex = 10;
            this.myMessage.Text = "AAA";
            // 
            // Read3DPose
            // 
            this.Read3DPose.Location = new System.Drawing.Point(4, 970);
            this.Read3DPose.Name = "Read3DPose";
            this.Read3DPose.Size = new System.Drawing.Size(335, 64);
            this.Read3DPose.TabIndex = 11;
            this.Read3DPose.Text = "读取单元信息";
            this.Read3DPose.UseVisualStyleBackColor = true;
            this.Read3DPose.Click += new System.EventHandler(this.Read3DPose_Click);
            // 
            // CheckPartDefine
            // 
            this.CheckPartDefine.Location = new System.Drawing.Point(355, 970);
            this.CheckPartDefine.Name = "CheckPartDefine";
            this.CheckPartDefine.Size = new System.Drawing.Size(200, 64);
            this.CheckPartDefine.TabIndex = 11;
            this.CheckPartDefine.Text = "检查零件定义";
            this.CheckPartDefine.UseVisualStyleBackColor = true;
            // 
            // Create2DDrawing
            // 
            this.Create2DDrawing.Location = new System.Drawing.Point(561, 970);
            this.Create2DDrawing.Name = "Create2DDrawing";
            this.Create2DDrawing.Size = new System.Drawing.Size(200, 64);
            this.Create2DDrawing.TabIndex = 11;
            this.Create2DDrawing.Text = "创建3D投图";
            this.Create2DDrawing.UseVisualStyleBackColor = true;
            // 
            // PartlistBox
            // 
            this.PartlistBox.FormattingEnabled = true;
            this.PartlistBox.ItemHeight = 18;
            this.PartlistBox.Location = new System.Drawing.Point(4, 90);
            this.PartlistBox.Name = "PartlistBox";
            this.PartlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PartlistBox.Size = new System.Drawing.Size(335, 796);
            this.PartlistBox.TabIndex = 12;
            // 
            // UnitName
            // 
            this.UnitName.AutoSize = true;
            this.UnitName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UnitName.Location = new System.Drawing.Point(76, 46);
            this.UnitName.Name = "UnitName";
            this.UnitName.Size = new System.Drawing.Size(263, 21);
            this.UnitName.TabIndex = 13;
            this.UnitName.Text = "X-XXXX-XXXXX-XXX-XXX-00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID:";
            // 
            // UnitPartProductList
            // 
            this.UnitPartProductList.FormattingEnabled = true;
            this.UnitPartProductList.ItemHeight = 18;
            this.UnitPartProductList.Location = new System.Drawing.Point(426, 90);
            this.UnitPartProductList.Name = "UnitPartProductList";
            this.UnitPartProductList.Size = new System.Drawing.Size(335, 796);
            this.UnitPartProductList.TabIndex = 12;
            // 
            // AddOne
            // 
            this.AddOne.Location = new System.Drawing.Point(345, 225);
            this.AddOne.Name = "AddOne";
            this.AddOne.Size = new System.Drawing.Size(75, 44);
            this.AddOne.TabIndex = 14;
            this.AddOne.Text = "增加";
            this.AddOne.UseVisualStyleBackColor = true;
            this.AddOne.Click += new System.EventHandler(this.AddOne_Click);
            // 
            // RemoveOne
            // 
            this.RemoveOne.Location = new System.Drawing.Point(345, 321);
            this.RemoveOne.Name = "RemoveOne";
            this.RemoveOne.Size = new System.Drawing.Size(75, 44);
            this.RemoveOne.TabIndex = 14;
            this.RemoveOne.Text = "移除";
            this.RemoveOne.UseVisualStyleBackColor = true;
            this.RemoveOne.Click += new System.EventHandler(this.RemoveOne_Click);
            // 
            // AddAll
            // 
            this.AddAll.Location = new System.Drawing.Point(345, 417);
            this.AddAll.Name = "AddAll";
            this.AddAll.Size = new System.Drawing.Size(75, 44);
            this.AddAll.TabIndex = 14;
            this.AddAll.Text = "全选";
            this.AddAll.UseVisualStyleBackColor = true;
            this.AddAll.Click += new System.EventHandler(this.AddAll_Click);
            // 
            // ClearAll
            // 
            this.ClearAll.Location = new System.Drawing.Point(345, 513);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(75, 44);
            this.ClearAll.TabIndex = 14;
            this.ClearAll.Text = "清选";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // ToTop
            // 
            this.ToTop.Location = new System.Drawing.Point(345, 609);
            this.ToTop.Name = "ToTop";
            this.ToTop.Size = new System.Drawing.Size(75, 44);
            this.ToTop.TabIndex = 14;
            this.ToTop.Text = "上移";
            this.ToTop.UseVisualStyleBackColor = true;
            // 
            // ToBottom
            // 
            this.ToBottom.Location = new System.Drawing.Point(345, 705);
            this.ToBottom.Name = "ToBottom";
            this.ToBottom.Size = new System.Drawing.Size(75, 44);
            this.ToBottom.TabIndex = 14;
            this.ToBottom.Text = "下移";
            this.ToBottom.UseVisualStyleBackColor = true;
            // 
            // _2DModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1514, 1111);
            this.Controls.Add(this.ToBottom);
            this.Controls.Add(this.ToTop);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.AddAll);
            this.Controls.Add(this.RemoveOne);
            this.Controls.Add(this.AddOne);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UnitName);
            this.Controls.Add(this.UnitPartProductList);
            this.Controls.Add(this.PartlistBox);
            this.Controls.Add(this.Create2DDrawing);
            this.Controls.Add(this.CheckPartDefine);
            this.Controls.Add(this.Read3DPose);
            this.Controls.Add(this.myMessage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "_2DModel";
            this.Text = "_2DModel";
            this.Load += new System.EventHandler(this._2DModel_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripButton ReConnectCATIA;
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
    }
}