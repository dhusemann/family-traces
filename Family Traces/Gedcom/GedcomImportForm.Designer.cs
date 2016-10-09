namespace Family_Traces
{
    partial class GedcomImportForm
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
            this.butClose = new System.Windows.Forms.Button();
            this.lblMain = new System.Windows.Forms.Label();
            this.lblIndividuals = new System.Windows.Forms.Label();
            this.lblFamilies = new System.Windows.Forms.Label();
            this.lblParsing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Enabled = false;
            this.butClose.Location = new System.Drawing.Point(180, 104);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 1;
            this.butClose.Text = "&Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(12, 18);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(243, 20);
            this.lblMain.TabIndex = 2;
            this.lblMain.Text = "Busy importing Gedcom file...";
            // 
            // lblIndividuals
            // 
            this.lblIndividuals.AutoSize = true;
            this.lblIndividuals.Location = new System.Drawing.Point(12, 64);
            this.lblIndividuals.Name = "lblIndividuals";
            this.lblIndividuals.Size = new System.Drawing.Size(35, 13);
            this.lblIndividuals.TabIndex = 3;
            this.lblIndividuals.Text = "label2";
            // 
            // lblFamilies
            // 
            this.lblFamilies.AutoSize = true;
            this.lblFamilies.Location = new System.Drawing.Point(12, 77);
            this.lblFamilies.Name = "lblFamilies";
            this.lblFamilies.Size = new System.Drawing.Size(35, 13);
            this.lblFamilies.TabIndex = 4;
            this.lblFamilies.Text = "label3";
            // 
            // lblParsing
            // 
            this.lblParsing.AutoSize = true;
            this.lblParsing.Location = new System.Drawing.Point(12, 51);
            this.lblParsing.Name = "lblParsing";
            this.lblParsing.Size = new System.Drawing.Size(35, 13);
            this.lblParsing.TabIndex = 5;
            this.lblParsing.Text = "label2";
            // 
            // GedcomImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 131);
            this.Controls.Add(this.lblParsing);
            this.Controls.Add(this.lblFamilies);
            this.Controls.Add(this.lblIndividuals);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.butClose);
            this.Name = "GedcomImportForm";
            this.Text = "Gedcom Import";
            this.Load += new System.EventHandler(this.GedcomImportForm_Load);
            this.Activated += new System.EventHandler(this.GedcomImportForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Label lblIndividuals;
        private System.Windows.Forms.Label lblFamilies;
        private System.Windows.Forms.Label lblParsing;
    }
}