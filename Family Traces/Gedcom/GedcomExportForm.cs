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
    public partial class GedcomExportForm : Form
    {
        string Filename = "";
        bool loaded = false;

        public GedcomExportForm(string filename)
        {
            InitializeComponent();
            Filename = filename;
        }

        private void GedcomExportForm_Load(object sender, EventArgs e)
        {
            lblFamilies.Text = "";
            lblIndividuals.Text = "";
            lblWriting.Text = "";
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GedcomExportForm_Activated(object sender, EventArgs e)
        {
            if (loaded == false)
            {
                loaded = true;
                GedcomExporter gedcomExporter = new GedcomExporter();
                lblIndividuals.Text = "Exporting individuals...";
                lblFamilies.Text = "Exporting families...";
                Application.DoEvents();
                gedcomExporter.Export();
                lblIndividuals.Text = "Exported " + gedcomExporter.gedcomIndividuals.Count.ToString() + " individuals";
                lblFamilies.Text = "Exported " + gedcomExporter.gedcomFamilies.Count.ToString() + " families";
                lblWriting.Text = "Writing to file...";
                Application.DoEvents();
                gedcomExporter.Write(Filename);
                lblWriting.Text = "Finished writing file";
                Application.DoEvents();
                butClose.Enabled = true;
            }
        }
    }
}
