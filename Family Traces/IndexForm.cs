using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Family_Traces
{
    public partial class IndexForm : Form
    {
        public int SelectedIndividualId = -1;
        ArrayList individualIds = new ArrayList();

        public IndexForm()
        {
            InitializeComponent();
        }

        private void LoadIndividuals()
        {
            lstIndividuals.Items.Clear();

            DataSet individuals = DBAccessStatic.GetAllIndividuals();
            for (int i = 0; i < individuals.Tables[0].Rows.Count; i++)
            {
                lstIndividuals.Items.Add(GenValidation.GetNameWithDates(individuals.Tables[0].Rows[i]["Surname"].ToString(), individuals.Tables[0].Rows[i]["Firstname"].ToString(), individuals.Tables[0].Rows[i]["BornDate"].ToString(), individuals.Tables[0].Rows[i]["DiedDate"].ToString()));
                individualIds.Add((int)(individuals.Tables[0].Rows[i]["ID"]));
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IndexForm_Activated(object sender, EventArgs e)
        {
            LoadIndividuals();
        }

        private void lstIndividuals_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndividualId = (int)(individualIds[lstIndividuals.SelectedIndex]);
        }
    }
}
