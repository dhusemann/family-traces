using System;
using System.Windows.Forms;

namespace Family_Traces
{
    public partial class DescendantReportOptionsForm : Form
    {
        public bool UniqueDescendants;
        public int MaxDepth;

        public DescendantReportOptionsForm()
        {
            InitializeComponent();
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
            UniqueDescendants = chkUnique.Checked;
            this.Close();
        }

        private void DescendantReportOptionsForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 256; i++)
            {
                cboDepth.Items.Add(i.ToString());
            }
            cboDepth.SelectedIndex = 0;
            MaxDepth = 1;
            UniqueDescendants = true;
        }
    }
}
