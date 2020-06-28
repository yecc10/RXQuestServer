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
            this.SM_Group = new System.Windows.Forms.GroupBox();
            this.LayoutGroup = new System.Windows.Forms.GroupBox();
            this.Station_Group = new System.Windows.Forms.GroupBox();
            this.Fullint = new System.Windows.Forms.Button();
            this.SelectInit = new System.Windows.Forms.Button();
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
            this.Station_Group.Location = new System.Drawing.Point(12, 120);
            this.Station_Group.Name = "Station_Group";
            this.Station_Group.Size = new System.Drawing.Size(814, 173);
            this.Station_Group.TabIndex = 0;
            this.Station_Group.TabStop = false;
            this.Station_Group.Text = "Station_Group";
            // 
            // Fullint
            // 
            this.Fullint.Location = new System.Drawing.Point(12, 299);
            this.Fullint.Name = "Fullint";
            this.Fullint.Size = new System.Drawing.Size(102, 38);
            this.Fullint.TabIndex = 1;
            this.Fullint.Text = "完全初始化";
            this.Fullint.UseVisualStyleBackColor = true;
            // 
            // SelectInit
            // 
            this.SelectInit.Location = new System.Drawing.Point(120, 299);
            this.SelectInit.Name = "SelectInit";
            this.SelectInit.Size = new System.Drawing.Size(102, 38);
            this.SelectInit.TabIndex = 1;
            this.SelectInit.Text = "选择初始化";
            this.SelectInit.UseVisualStyleBackColor = true;
            this.SelectInit.Click += new System.EventHandler(this.SelectInit_Click);
            // 
            // InitDelmiaDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 429);
            this.Controls.Add(this.SelectInit);
            this.Controls.Add(this.Fullint);
            this.Controls.Add(this.Station_Group);
            this.Controls.Add(this.LayoutGroup);
            this.Controls.Add(this.SM_Group);
            this.Name = "InitDelmiaDocument";
            this.Text = "InitDelmiaDocument";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SM_Group;
        private System.Windows.Forms.GroupBox LayoutGroup;
        private System.Windows.Forms.GroupBox Station_Group;
        private System.Windows.Forms.Button Fullint;
        private System.Windows.Forms.Button SelectInit;
    }
}