using Family_Traces.Database;
using Family_Traces.Models;
using GedcomLib;
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
    public partial class GedcomImportForm : Form
    {
        private string Filename;
        private bool loaded = false;

        public GedcomImportForm(string filename)
        {
            InitializeComponent();
            Filename = filename;
        }

        private void GedcomImportForm_Activated(object sender, EventArgs e)
        {
            if (loaded == false)
            {
                loaded = true;
                lblParsing.Text = "Parsing Gedcom...";
                Application.DoEvents();
                GedcomParser gedcomParser = new GedcomParser();
                gedcomParser.Parse(Filename);
                lblParsing.Text = "Parsing Gedcom complete.";
                lblIndividuals.Text = "Parsed " + gedcomParser.gedcomIndividuals.Count.ToString() + " individuals...";
                lblFamilies.Text = "Parsed " + gedcomParser.gedcomFamilies.Count.ToString() + " families...";
                Application.DoEvents();
                GedcomImporter.Import(gedcomParser);

                Individual a = null;
                using (var ctx = new FamilyTracesContext())
                {
                    a = ctx.Individuals.First();
                }
                    /*
                    //Test code: TODO remove
                    AncestorList ancestorList = new AncestorList();
                    ancestorList.MaxDepth = 200;
                    ancestorList.CalcAncestorList("@I7952@", gedcomParser.gedcomIndividuals, gedcomParser.gedcomFamilies, true, @"C:\Users\Serge.Meunier\Downloads\mine\ancestry.txt");
                    lblIndividuals.Text = "Exporting completed";
                    */
                    butClose.Enabled = true;
            }
        }

        private void GedcomImportForm_Load(object sender, EventArgs e)
        {
            lblIndividuals.Text = "";
            lblFamilies.Text = "";
            lblParsing.Text = "";
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
