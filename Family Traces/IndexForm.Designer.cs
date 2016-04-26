namespace Family_Traces
{
    partial class IndexForm
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
            this.butSelect = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.lstIndividuals = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // butSelect
            // 
            this.butSelect.Location = new System.Drawing.Point(124, 236);
            this.butSelect.Name = "butSelect";
            this.butSelect.Size = new System.Drawing.Size(75, 23);
            this.butSelect.TabIndex = 4;
            this.butSelect.Text = "&Select";
            this.butSelect.UseVisualStyleBackColor = true;
            this.butSelect.Click += new System.EventHandler(this.butSelect_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(205, 236);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "&Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // lstIndividuals
            // 
            this.lstIndividuals.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstIndividuals.FormattingEnabled = true;
            this.lstIndividuals.Location = new System.Drawing.Point(0, 0);
            this.lstIndividuals.Name = "lstIndividuals";
            this.lstIndividuals.Size = new System.Drawing.Size(284, 225);
            this.lstIndividuals.TabIndex = 5;
            this.lstIndividuals.SelectedIndexChanged += new System.EventHandler(this.lstIndividuals_SelectedIndexChanged);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lstIndividuals);
            this.Controls.Add(this.butSelect);
            this.Controls.Add(this.butCancel);
            this.Name = "IndexForm";
            this.Text = "Index";
            this.Activated += new System.EventHandler(this.IndexForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butSelect;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.ListBox lstIndividuals;
    }
}