namespace WorkOffice
{
    partial class WorkTimeUpdata
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkTimeUpdata));
            this.ReadData = new System.Windows.Forms.Button();
            this.ByExcel = new System.Windows.Forms.CheckBox();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.pbar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadData
            // 
            this.ReadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ReadData.Location = new System.Drawing.Point(844, 637);
            this.ReadData.Name = "ReadData";
            this.ReadData.Size = new System.Drawing.Size(118, 44);
            this.ReadData.TabIndex = 3;
            this.ReadData.Text = "数据导入";
            this.ReadData.UseVisualStyleBackColor = false;
            this.ReadData.Click += new System.EventHandler(this.ReadData_Click);
            // 
            // ByExcel
            // 
            this.ByExcel.AutoSize = true;
            this.ByExcel.Checked = true;
            this.ByExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ByExcel.Location = new System.Drawing.Point(771, 644);
            this.ByExcel.Name = "ByExcel";
            this.ByExcel.Size = new System.Drawing.Size(66, 16);
            this.ByExcel.TabIndex = 4;
            this.ByExcel.Text = "ByExcel";
            this.ByExcel.UseVisualStyleBackColor = true;
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGrid.Location = new System.Drawing.Point(12, 12);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGrid.RowTemplate.Height = 23;
            this.DataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGrid.Size = new System.Drawing.Size(950, 619);
            this.DataGrid.TabIndex = 5;
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(12, 637);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(753, 23);
            this.pbar.TabIndex = 6;
            // 
            // WorkTimeUpdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 703);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.ByExcel);
            this.Controls.Add(this.ReadData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkTimeUpdata";
            this.Text = "WorkTimeUpdata";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadData;
        private System.Windows.Forms.CheckBox ByExcel;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.ProgressBar pbar;
    }
}

