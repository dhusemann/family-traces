using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Family_Traces
{
    public partial class AncestryReportForm : Form
    {
        private AncestorCalc ancestorCalculation;
        private int IndividualId;
        private bool UniqueAncestors;
        private int MaxDepth;

        public AncestryReportForm(int individualId, bool uniqueAncestors, int maxDepth)
        {
            InitializeComponent();
            IndividualId = individualId;
            UniqueAncestors = uniqueAncestors;
            MaxDepth = maxDepth;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AncestryReportForm_Activated(object sender, EventArgs e)
        {
            ancestorCalculation = new AncestorCalc(MaxDepth);
            ancestorCalculation.CalculateAncestors(IndividualId, UniqueAncestors);
            report.Clear();
            Individual individual = new Individual();

            StringBuilder reportText = new StringBuilder();

            for(int i = 0; i <= ancestorCalculation.GenerationCount; i++)
            {
                reportText.AppendLine("Generation " + (i+1).ToString());
                reportText.AppendLine("----------------");
                for(int j = 0; j < ancestorCalculation.ancestryList[i].Count; j++)
                {
                    individual = (Individual)(ancestorCalculation.ancestryList[i][j]);
                   

                    reportText.AppendLine(GenValidation.GetNameWithDates(individual.Surname, individual.Firstname, individual.BirthDate, individual.DiedDate));
                }
                reportText.AppendLine("");
            }
            reportText.AppendLine("Number of ancestors: " + ancestorCalculation.IndividualCount.ToString());
            report.Text = reportText.ToString();
        }

        private void AncestryReportForm_Load(object sender, EventArgs e)
        {

        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                report.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
