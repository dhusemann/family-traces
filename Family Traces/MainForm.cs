using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Family_Traces
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuViewEditFamily_Click(object sender, EventArgs e)
        {
            FamilyForm familyForm = new FamilyForm();
            familyForm.MdiParent = this;
            familyForm.Show();
        }

        private void importGedcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GedcomImportForm gedcomImportForm = new GedcomImportForm(openFileDialog1.FileName);
                gedcomImportForm.ShowDialog();
                gedcomImportForm.Dispose();
            }
        }

        private void exportGedcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GedcomExportForm gedcomExportForm = new GedcomExportForm(saveFileDialog1.FileName);
                gedcomExportForm.ShowDialog();
                gedcomExportForm.Dispose();
            }
        }
    }
}
