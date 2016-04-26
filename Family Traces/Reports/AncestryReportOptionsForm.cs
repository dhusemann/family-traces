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
    public partial class AncestryReportOptionsForm : Form
    {
        public bool UniqueAncestors;
        public int MaxDepth;

        public AncestryReportOptionsForm()
        {
            InitializeComponent();
        }

        private void AncestryReportOptionsForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 256; i++)
            {
                cboDepth.Items.Add(i.ToString());
            }
            cboDepth.SelectedIndex = 0;
            MaxDepth = 1;
            UniqueAncestors = true;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            MaxDepth = cboDepth.SelectedIndex;
            UniqueAncestors = chkUnique.Checked;
            this.Close();
        }
    }
}
