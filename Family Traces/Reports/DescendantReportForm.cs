using System;
using System.Text;
using System.Windows.Forms;

namespace Family_Traces
{
    public partial class DescendantReportForm : Form
    {
        private DescendantCalc descendantCalc;
        private int IndividualId;
        private bool UniqueDescendants;
        private int MaxDepth;

        public DescendantReportForm(int individualId, bool uniqueDescendants, int maxDepth)
        {
            InitializeComponent();
            IndividualId = individualId;
            UniqueDescendants = uniqueDescendants;
            MaxDepth = maxDepth;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                report.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void DescendantReportForm_Activated(object sender, EventArgs e)
        {
            descendantCalc = new DescendantCalc(MaxDepth);
            descendantCalc.CalculateDescendants(IndividualId, UniqueDescendants);
            report.Clear();
            Individualg individual = new Individualg();

            StringBuilder reportText = new StringBuilder();
            string birthDate, diedDate;
            for (int i = 0; i <= descendantCalc.GenerationCount; i++)
            {
                reportText.AppendLine("Generation " + (i + 1).ToString());
                reportText.AppendLine("----------------");
                for (int j = 0; j < descendantCalc.descendantList[i].Count; j++)
                {
                    individual = (Individualg)(descendantCalc.descendantList[i][j]);

                    if (individual.BirthDate == "")
                    {
                        birthDate = "?";
                    }
                    else
                    {
                        birthDate = individual.BirthDate;
                    }

                    if (individual.DiedDate == "")
                    {
                        diedDate = "?";
                    }
                    else
                    {
                        diedDate = individual.DiedDate;
                    }

                    reportText.AppendLine(GenValidation.GetNameWithDates(individual.Surname, individual.Firstname, individual.BirthDate, individual.DiedDate));
                }
                reportText.AppendLine("");
            }
            reportText.AppendLine("Number of descendants: " + descendantCalc.IndividualCount.ToString());
            report.Text = reportText.ToString();

        }

        private void DescendantReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
