﻿namespace Family_Traces
{
    partial class DescendantReportForm
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
            this.butSave = new System.Windows.Forms.Button();
            this.butPrint = new System.Windows.Forms.Button();
            this.report = new System.Windows.Forms.RichTextBox();
            this.butClose = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(35, 233);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 7;
            this.butSave.Text = "&Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butPrint
            // 
            this.butPrint.Location = new System.Drawing.Point(116, 233);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(75, 23);
            this.butPrint.TabIndex = 6;
            this.butPrint.Text = "&Print";
            this.butPrint.UseVisualStyleBackColor = true;
            // 
            // report
            // 
            this.report.Dock = System.Windows.Forms.DockStyle.Top;
            this.report.Location = new System.Drawing.Point(0, 0);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(284, 221);
            this.report.TabIndex = 5;
            this.report.Text = "";
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(197, 233);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 4;
            this.butClose.Text = "&Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "ancestors.txt";
            this.saveFileDialog1.Filter = "Text files|*.txt|All files|*.*";
            // 
            // DescendantReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.report);
            this.Controls.Add(this.butClose);
            this.Name = "DescendantReportForm";
            this.Text = "DescendantReportForm";
            this.Load += new System.EventHandler(this.DescendantReportForm_Load);
            this.Activated += new System.EventHandler(this.DescendantReportForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.RichTextBox report;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}