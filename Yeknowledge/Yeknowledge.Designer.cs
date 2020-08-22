namespace Yeknowledge
{
    partial class Yeknowledge
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("knowledge", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode11,
            treeNode13});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yeknowledge));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdataKn = new System.Windows.Forms.ToolStripMenuItem();
            this.newkn = new System.Windows.Forms.ToolStripMenuItem();
            this.managerkn = new System.Windows.Forms.ToolStripMenuItem();
            this.Deletekn = new System.Windows.Forms.ToolStripMenuItem();
            this.wCP转SqlServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wcptosql = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadWcp = new System.Windows.Forms.ToolStripMenuItem();
            this.sqltowcp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.testweb = new System.Windows.Forms.ToolStripMenuItem();
            this.testsql = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.EdietKnowledge = new System.Windows.Forms.WebBrowser();
            this.MainTree = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aAToolStripMenuItem,
            this.wCP转SqlServerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1503, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aAToolStripMenuItem
            // 
            this.aAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdataKn,
            this.newkn,
            this.managerkn,
            this.Deletekn});
            this.aAToolStripMenuItem.Name = "aAToolStripMenuItem";
            this.aAToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.aAToolStripMenuItem.Text = "控制";
            // 
            // UpdataKn
            // 
            this.UpdataKn.Name = "UpdataKn";
            this.UpdataKn.Size = new System.Drawing.Size(124, 22);
            this.UpdataKn.Text = "更新文档";
            // 
            // newkn
            // 
            this.newkn.Name = "newkn";
            this.newkn.Size = new System.Drawing.Size(124, 22);
            this.newkn.Text = "新建文档";
            // 
            // managerkn
            // 
            this.managerkn.Name = "managerkn";
            this.managerkn.Size = new System.Drawing.Size(124, 22);
            this.managerkn.Text = "管理文档";
            // 
            // Deletekn
            // 
            this.Deletekn.Name = "Deletekn";
            this.Deletekn.Size = new System.Drawing.Size(124, 22);
            this.Deletekn.Text = "删除文档";
            // 
            // wCP转SqlServerToolStripMenuItem
            // 
            this.wCP转SqlServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wcptosql,
            this.ReadWcp,
            this.sqltowcp,
            this.toolStripSeparator1,
            this.testweb,
            this.testsql});
            this.wCP转SqlServerToolStripMenuItem.Name = "wCP转SqlServerToolStripMenuItem";
            this.wCP转SqlServerToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.wCP转SqlServerToolStripMenuItem.Text = "转化控制";
            // 
            // wcptosql
            // 
            this.wcptosql.Name = "wcptosql";
            this.wcptosql.Size = new System.Drawing.Size(170, 22);
            this.wcptosql.Text = "WCP转SqlServer";
            // 
            // ReadWcp
            // 
            this.ReadWcp.Name = "ReadWcp";
            this.ReadWcp.Size = new System.Drawing.Size(170, 22);
            this.ReadWcp.Text = "读取WCP";
            this.ReadWcp.Click += new System.EventHandler(this.ReadWcp_Click);
            // 
            // sqltowcp
            // 
            this.sqltowcp.Name = "sqltowcp";
            this.sqltowcp.Size = new System.Drawing.Size(170, 22);
            this.sqltowcp.Text = "SQL转WCP";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // testweb
            // 
            this.testweb.Name = "testweb";
            this.testweb.Size = new System.Drawing.Size(170, 22);
            this.testweb.Text = "测试知识库连接";
            // 
            // testsql
            // 
            this.testsql.Name = "testsql";
            this.testsql.Size = new System.Drawing.Size(170, 22);
            this.testsql.Text = "测试数据库链接";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(206, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1285, 761);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1277, 735);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "阅读";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1271, 729);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("http://desktop-5hk1a1i:8040/", System.UriKind.Absolute);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.EdietKnowledge);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1277, 735);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "编辑";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EdietKnowledge
            // 
            this.EdietKnowledge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EdietKnowledge.Location = new System.Drawing.Point(3, 3);
            this.EdietKnowledge.MinimumSize = new System.Drawing.Size(20, 20);
            this.EdietKnowledge.Name = "EdietKnowledge";
            this.EdietKnowledge.Size = new System.Drawing.Size(1271, 729);
            this.EdietKnowledge.TabIndex = 0;
            // 
            // MainTree
            // 
            this.MainTree.Location = new System.Drawing.Point(12, 29);
            this.MainTree.Name = "MainTree";
            treeNode8.Name = "节点3";
            treeNode8.Text = "节点3";
            treeNode9.Name = "节点0";
            treeNode9.Text = "节点0";
            treeNode10.Name = "节点4";
            treeNode10.Text = "节点4";
            treeNode11.Name = "节点1";
            treeNode11.Text = "节点1";
            treeNode12.Name = "节点5";
            treeNode12.Text = "节点5";
            treeNode13.Name = "节点2";
            treeNode13.Text = "节点2";
            treeNode14.Name = "Yeknowledge";
            treeNode14.Text = "knowledge";
            this.MainTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.MainTree.Size = new System.Drawing.Size(192, 761);
            this.MainTree.TabIndex = 3;
            // 
            // Yeknowledge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 802);
            this.Controls.Add(this.MainTree);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Yeknowledge";
            this.Text = "Yeknowledge";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdataKn;
        private System.Windows.Forms.ToolStripMenuItem newkn;
        private System.Windows.Forms.ToolStripMenuItem managerkn;
        private System.Windows.Forms.ToolStripMenuItem Deletekn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView MainTree;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.WebBrowser EdietKnowledge;
        private System.Windows.Forms.ToolStripMenuItem wCP转SqlServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wcptosql;
        private System.Windows.Forms.ToolStripMenuItem sqltowcp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem testweb;
        private System.Windows.Forms.ToolStripMenuItem testsql;
        private System.Windows.Forms.ToolStripMenuItem ReadWcp;
    }
}

