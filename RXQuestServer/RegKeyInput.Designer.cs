﻿namespace RXQuestServer
{
    partial class RegKeyInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegKeyInput));
            this.RegKey = new System.Windows.Forms.TextBox();
            this.regValue = new System.Windows.Forms.Label();
            this.RegRxSoft = new System.Windows.Forms.Button();
            this.AppliCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RegKey
            // 
            this.RegKey.Location = new System.Drawing.Point(112, 12);
            this.RegKey.Multiline = true;
            this.RegKey.Name = "RegKey";
            this.RegKey.Size = new System.Drawing.Size(466, 85);
            this.RegKey.TabIndex = 0;
            this.RegKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regValue
            // 
            this.regValue.AutoSize = true;
            this.regValue.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regValue.Location = new System.Drawing.Point(12, 12);
            this.regValue.Name = "regValue";
            this.regValue.Size = new System.Drawing.Size(94, 24);
            this.regValue.TabIndex = 1;
            this.regValue.Text = "注册码:";
            // 
            // RegRxSoft
            // 
            this.RegRxSoft.Location = new System.Drawing.Point(12, 50);
            this.RegRxSoft.Name = "RegRxSoft";
            this.RegRxSoft.Size = new System.Drawing.Size(93, 47);
            this.RegRxSoft.TabIndex = 2;
            this.RegRxSoft.Text = "执行注册";
            this.RegRxSoft.UseVisualStyleBackColor = true;
            this.RegRxSoft.Click += new System.EventHandler(this.RegRxSoft_Click);
            // 
            // AppliCode
            // 
            this.AppliCode.Location = new System.Drawing.Point(111, 103);
            this.AppliCode.Multiline = true;
            this.AppliCode.Name = "AppliCode";
            this.AppliCode.ReadOnly = true;
            this.AppliCode.Size = new System.Drawing.Size(466, 39);
            this.AppliCode.TabIndex = 0;
            this.AppliCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "申请码:";
            // 
            // RegKeyInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(590, 148);
            this.Controls.Add(this.RegRxSoft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regValue);
            this.Controls.Add(this.AppliCode);
            this.Controls.Add(this.RegKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(606, 187);
            this.MinimumSize = new System.Drawing.Size(606, 187);
            this.Name = "RegKeyInput";
            this.Text = "RegKeyInput";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegKeyInput_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RegKey;
        private System.Windows.Forms.Label regValue;
        private System.Windows.Forms.Button RegRxSoft;
        private System.Windows.Forms.TextBox AppliCode;
        private System.Windows.Forms.Label label1;
    }
}