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
    public partial class FamilyForm : Form
    {
        private int familyId = -1;
        private int husbandId = -1;
        private int wifeId = -1;
        private int husbandParentId = -1;
        private int wifeParentId = -1;
        private int activePerson = -1;
        private History history = new History();

        public FamilyForm()
        {
            InitializeComponent();
        }

        private void AttachSpouse(int spouseId)
        {
            if (activePerson == husbandId)
            {
                familyId = DBAccessStatic.InsertFamily(husbandId, spouseId, "", "");
            }
            else
            {
                familyId = DBAccessStatic.InsertFamily(spouseId, wifeId, "", "");
            }
            LoadFamilyByFamily(familyId);
        }

        private void AttachChild(int childId)
        {
            if (familyId == -1)
            {
                familyId = DBAccessStatic.InsertFamily(husbandId, wifeId, "", "");
            }
            DBAccessStatic.InsertFamilyChild(familyId, childId);
            LoadFamilyByFamily(familyId);
        }

        private void DetachSpouse()
        {
            if (activePerson == husbandId)
            {
                wifeId = -1;
                DBAccessStatic.UpdateFamilyWifeId(familyId, wifeId);
            }
            else
            {
                husbandId = -1;
                DBAccessStatic.UpdateFamilyHusbandId(familyId, husbandId);
            }
            LoadFamilyByFamily(familyId);
        }

        private void DetachChild(int childId)
        {
            DBAccessStatic.DeleteFamilyChild(childId);
            LoadFamilyByFamily(familyId);
        }

        private void DeleteIndividual(int individualId)
        {
            DBAccessStatic.DeleteIndividual(individualId);
        }

        private void SetHusbandActive()
        {
            activePerson = husbandId;
            txtHusbandName.BackColor = Color.LightBlue;
            txtHusbandBornDate.BackColor = Color.LightBlue;
            txtHusbandBornPlace.BackColor = Color.LightBlue;
            txtHusbandDiedDate.BackColor = Color.LightBlue;
            txtHusbandDiedPlace.BackColor = Color.LightBlue;

            txtWifeName.BackColor = Color.White;
            txtWifeBornDate.BackColor = Color.White;
            txtWifeBornPlace.BackColor = Color.White;
            txtWifeDiedDate.BackColor = Color.White;
            txtWifeDiedPlace.BackColor = Color.White;
        }

        private void SetWifeActive()
        {
            activePerson = wifeId;
            txtWifeName.BackColor = Color.LightBlue;
            txtWifeBornDate.BackColor = Color.LightBlue;
            txtWifeBornPlace.BackColor = Color.LightBlue;
            txtWifeDiedDate.BackColor = Color.LightBlue;
            txtWifeDiedPlace.BackColor = Color.LightBlue;

            txtHusbandName.BackColor = Color.White;
            txtHusbandBornDate.BackColor = Color.White;
            txtHusbandBornPlace.BackColor = Color.White;
            txtHusbandDiedDate.BackColor = Color.White;
            txtHusbandDiedPlace.BackColor = Color.White;
        }

        private void LoadMarriageData(DataSet family, int familyIndex)
        {
            txtMarriedDate.Text = family.Tables[0].Rows[familyIndex]["MarriageDate"].ToString();
            txtMariedPlace.Text = family.Tables[0].Rows[familyIndex]["MarriagePlace"].ToString();
        }

        private void ClearMarriageData()
        {
            txtMarriedDate.Text = "";
            txtMariedPlace.Text = "";
        }

        private void LoadChildrenData(DataSet children)
        {
            grdChildren.Rows.Clear();
            for (int i = 0; i < children.Tables[0].Rows.Count; i++)
            {
                grdChildren.Rows.Add(new object[5] {
                    (int)(children.Tables[0].Rows[i]["ChildId"]),
                    children.Tables[0].Rows[i]["Firstname"].ToString() + " " + children.Tables[0].Rows[i]["Surname"].ToString(),
                    children.Tables[0].Rows[i]["Gender"].ToString(),
                    children.Tables[0].Rows[i]["BornDate"].ToString(),
                    children.Tables[0].Rows[i]["DiedDate"].ToString()});
            }
                
        }

        private void ClearChildrenData()
        {
            grdChildren.Rows.Clear();
        }

        private void LoadHusbandData(DataSet individual)
        {
            txtHusbandName.Text = individual.Tables[0].Rows[0]["Firstname"].ToString() + " " + individual.Tables[0].Rows[0]["Surname"].ToString();
            txtHusbandBornDate.Text = individual.Tables[0].Rows[0]["BornDate"].ToString();
            txtHusbandBornPlace.Text = individual.Tables[0].Rows[0]["BornPlace"].ToString();
            txtHusbandDiedDate.Text = individual.Tables[0].Rows[0]["DiedDate"].ToString();
            txtHusbandDiedPlace.Text = individual.Tables[0].Rows[0]["DiedPlace"].ToString();
        }

        private void ClearHusbandData()
        {
            txtHusbandName.Text = "";
            txtHusbandBornDate.Text = "";
            txtHusbandBornPlace.Text = "";
            txtHusbandDiedDate.Text = "";
            txtHusbandDiedPlace.Text = "";
        }

        private void LoadWifeData(DataSet individual)
        {
            txtWifeName.Text = individual.Tables[0].Rows[0]["Firstname"].ToString() + " " + individual.Tables[0].Rows[0]["Surname"].ToString();
            txtWifeBornDate.Text = individual.Tables[0].Rows[0]["BornDate"].ToString();
            txtWifeBornPlace.Text = individual.Tables[0].Rows[0]["BornPlace"].ToString();
            txtWifeDiedDate.Text = individual.Tables[0].Rows[0]["DiedDate"].ToString();
            txtWifeDiedPlace.Text = individual.Tables[0].Rows[0]["DiedPlace"].ToString();
        }

        private void ClearWifeData()
        {
            txtWifeName.Text = "";
            txtWifeBornDate.Text = "";
            txtWifeBornPlace.Text = "";
            txtWifeDiedDate.Text = "";
            txtWifeDiedPlace.Text = "";
        }

        private void LoadFamily(int individualId)
        {
            LoadFamily(individualId, 0);
        }

        private void LoadFamily(int individualId, int familyIndex)
        {
            ClearHusbandData();
            ClearWifeData();
            ClearMarriageData();
            ClearChildrenData();
            wifeParentId = -1;
            husbandParentId = -1;

            DataSet individual = DBAccessStatic.GetIndividual(individualId);
            if (individual.Tables[0].Rows[0]["Gender"].ToString() == "M")
            {
                husbandId = individualId;
                husbandParentId = (int)(individual.Tables[0].Rows[0]["ParentFamilyId"]);
                LoadHusbandData(individual);
                SetHusbandActive();
                DataSet family = DBAccessStatic.GetFamilyForHusband(husbandId);
                if (family.Tables[0].Rows.Count > 0) {
                    familyId = (int)(family.Tables[0].Rows[familyIndex]["ID"]);
                    wifeId = (int)(family.Tables[0].Rows[familyIndex]["WifeId"]);
                    if (wifeId != -1)
                    {
                        DataSet wife = DBAccessStatic.GetIndividual(wifeId);
                        wifeParentId = (int)(wife.Tables[0].Rows[0]["ParentFamilyId"]);
                        LoadWifeData(wife);
                    }
                    LoadMarriageData(family, familyIndex);
                    
                }
                else
                {
                    familyId = -1;
                    wifeId = -1;
                }
            }
            else
            {
                wifeId = individualId;
                wifeParentId = (int)(individual.Tables[0].Rows[0]["ParentFamilyId"]);
                LoadWifeData(individual);
                SetWifeActive();
                DataSet family = DBAccessStatic.GetFamilyForWife(wifeId);
                if (family.Tables[0].Rows.Count > 0)
                {
                    familyId = (int)(family.Tables[0].Rows[familyIndex]["ID"]);
                    husbandId = (int)(family.Tables[0].Rows[familyIndex]["HusbandId"]);
                    if (husbandId != -1)
                    {
                        DataSet husband = DBAccessStatic.GetIndividual(husbandId);
                        husbandParentId = (int)(husband.Tables[0].Rows[0]["ParentFamilyId"]);

                        LoadHusbandData(husband);
                    }
                    LoadMarriageData(family, familyIndex);
                }
                else
                {
                    familyId = -1;
                    wifeId = -1;
                }
            }

            if (familyId != -1)
            {
                DataSet children = DBAccessStatic.GetFamilyChildren(familyId);
                LoadChildrenData(children);
            }
            history.Add(individualId);
            if (!history.IsEmpty())
            {
                tbrBack.Enabled = true;
            }

        }

        private void LoadFamilyByFamily(int familyId)
        {
            ClearHusbandData();
            ClearWifeData();
            ClearMarriageData();
            ClearChildrenData();

            DataSet family = DBAccessStatic.GetFamily(familyId);
            if (family.Tables[0].Rows.Count > 0)
            {
                familyId = (int)(family.Tables[0].Rows[0]["ID"]);
                wifeId = (int)(family.Tables[0].Rows[0]["WifeId"]);
                husbandId = (int)(family.Tables[0].Rows[0]["HusbandId"]);
                if (husbandId != -1)
                {
                    DataSet husband = DBAccessStatic.GetIndividual(husbandId);
                    LoadHusbandData(husband);
                }
                if (wifeId != -1)
                {
                    DataSet wife = DBAccessStatic.GetIndividual(wifeId);
                    LoadWifeData(wife);
                }
                if (husbandId != -1)
                {
                    history.Add(husbandId);
                }
                else
                {
                    if (wifeId != -1)
                    {
                        history.Add(wifeId);
                    }
                }
                if (!history.IsEmpty())
                {
                    tbrBack.Enabled = true;
                }
                LoadMarriageData(family, 0);

                DataSet children = DBAccessStatic.GetFamilyChildren(familyId);
                if (children.Tables[0].Rows.Count > 0)
                {
                    LoadChildrenData(children);
                }

            }
            else
            {
                familyId = -1;
                wifeId = -1;
                husbandId = -1;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FamilyForm_Load(object sender, EventArgs e)
        {
            //Set up initial view
            LoadFamily(1);
        }

        private void txtHusbandName_Leave(object sender, EventArgs e)
        {
            if (txtHusbandName.Text.Trim().Length > 0)
            {
                string surname = GenValidation.GetSurname(txtHusbandName.Text.Trim());
                string firstname = GenValidation.GetFirstname(txtHusbandName.Text.Trim());
                if (husbandId == -1)
                {
                    husbandId = DBAccessStatic.InsertIndividual(surname, firstname, "", "", "", "", -1, "M");
                }
                else
                {
                    DBAccessStatic.UpdateIndividualSurname(husbandId, surname);
                    DBAccessStatic.UpdateIndividualFirstname(husbandId, firstname);
                }
                if ((familyId == -1) && (wifeId != -1))
                {
                    familyId = DBAccessStatic.InsertFamily(husbandId, wifeId, txtMarriedDate.Text, txtMariedPlace.Text);
                }
            }
            else
            {
                MessageBox.Show("Name field cannot be left empty.");
            }
        }

        private void txtHusbandBornDate_Leave(object sender, EventArgs e)
        {
            if (husbandId == -1)
            {
                MessageBox.Show("Please enter name first");
            }
            else
            {
                DBAccessStatic.UpdateIndividualBornDate(husbandId, txtHusbandBornDate.Text);
            }
        }

        private void txtHusbandBornPlace_Leave(object sender, EventArgs e)
        {
            if (husbandId == -1)
            {
                MessageBox.Show("Please enter name first");
            }
            else
            {
                DBAccessStatic.UpdateIndividualBornPlace(husbandId, txtHusbandBornPlace.Text);
            }
        }

        private void txtHusbandDiedDate_Leave(object sender, EventArgs e)
        {
            if (husbandId == -1)
            {
                MessageBox.Show("Please enter name first");
            }
            else
            {
                DBAccessStatic.UpdateIndividualDiedDate(husbandId, txtHusbandDiedDate.Text);
            }
        }

        private void txtHusbandDiedPlace_Leave(object sender, EventArgs e)
        {
            if (husbandId == -1)
            {
                MessageBox.Show("Please enter name first");
            }
            else
            {
                DBAccessStatic.UpdateIndividualDiedPlace(husbandId, txtHusbandDiedPlace.Text);
            }
        }

        private void txtWifeName_Leave(object sender, EventArgs e)
        {
            if (txtWifeName.Text.Trim().Length > 0)
            {
                string surname = GenValidation.GetSurname(txtWifeName.Text.Trim());
                string firstname = GenValidation.GetFirstname(txtWifeName.Text.Trim());
                if (wifeId == -1)
                {
                    wifeId = DBAccessStatic.InsertIndividual(surname, firstname, "", "", "", "", -1, "F");
                }
                else
                {
                    DBAccessStatic.UpdateIndividualSurname(wifeId, surname);
                    DBAccessStatic.UpdateIndividualFirstname(wifeId, firstname);
                }
                if ((familyId == -1) && (husbandId != -1))
                {
                    familyId = DBAccessStatic.InsertFamily(husbandId, wifeId, txtMarriedDate.Text, txtMariedPlace.Text);
                }
            }
            else
            {
                MessageBox.Show("Name field cannot be left empty.");
            }

        }

        private void txtWifeBornDate_Leave(object sender, EventArgs e)
        {
            if (wifeId == -1)
            {
                MessageBox.Show("Please enter name first");
            }
            else
            {
                DBAccessStatic.UpdateIndividualBornDate(wifeId, txtWifeBornDate.Text);
            }
        }

        private void txtWifeBornPlace_Leave(object sender, EventArgs e)
        {
            if (wifeId == -1)
            {
                MessageBox.Show("Please enter name first");
            }
            else
            {
                DBAccessStatic.UpdateIndividualBornPlace(wifeId, txtWifeBornPlace.Text);
            }
        }

        private void txtWifeDiedDate_Leave(object sender, EventArgs e)
        {
            if (wifeId == -1)
            {
                MessageBox.Show("Please enter name first");
            }
            else
            {
                DBAccessStatic.UpdateIndividualDiedDate(wifeId, txtWifeDiedDate.Text);
            }
        }

        private void txtWifeDiedPlace_Leave(object sender, EventArgs e)
        {
            if (wifeId == -1)
            {
                MessageBox.Show("Please enter name first");
            }
            else
            {
                DBAccessStatic.UpdateIndividualDiedPlace(wifeId, txtWifeDiedPlace.Text);
            }
        }

        private void txtMarriedDate_Leave(object sender, EventArgs e)
        {
            if (familyId == -1)
            {
                familyId = DBAccessStatic.InsertFamily(husbandId, wifeId, txtMarriedDate.Text, txtMariedPlace.Text);
            }
            else
            {
                DBAccessStatic.UpdateFamilyMarriageDate(familyId, txtMarriedDate.Text);
            }
        }

        private void txtMariedPlace_Leave(object sender, EventArgs e)
        {
            if (familyId == -1)
            {
                familyId = DBAccessStatic.InsertFamily(husbandId, wifeId, txtMarriedDate.Text, txtMariedPlace.Text);
            }
            else
            {
                DBAccessStatic.UpdateFamilyMarriagePlace(familyId, txtMariedPlace.Text);
            }

        }

        private void grdChildren_CellLeave(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void grdChildren_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdChildren[0, e.RowIndex].Value == null)
            {
                MessageBox.Show("Please enter some information for the child before moving to their record");
            } 
            else
            {
                if (grdChildren[2, e.RowIndex].Value == null)
                {
                    DBAccessStatic.UpdateIndividualGender((int)grdChildren[0, e.RowIndex].Value, "M");
                }
                LoadFamily((int)grdChildren[0, e.RowIndex].Value);
                
            }
        }

        private void grdChildren_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (familyId == -1)
            {
                familyId = DBAccessStatic.InsertFamily(husbandId, wifeId, txtMarriedDate.Text, txtMariedPlace.Text);
            }

            if (grdChildren[0, e.RowIndex].Value == null)
            {
                int childID = DBAccessStatic.InsertIndividual("", "", "", "", "", "", familyId, "");
                grdChildren[0, e.RowIndex].Value = childID;
                DBAccessStatic.InsertFamilyChild(familyId, childID);
            }

            if (e.ColumnIndex == 1)
            {
                string surname = GenValidation.GetSurname(grdChildren["ChildName", e.RowIndex].Value.ToString());
                string firstname = GenValidation.GetFirstname(grdChildren["ChildName", e.RowIndex].Value.ToString());

                DBAccessStatic.UpdateIndividualFirstname((int)grdChildren[0, e.RowIndex].Value, firstname);
                DBAccessStatic.UpdateIndividualSurname((int)grdChildren[0, e.RowIndex].Value, surname);
            }
            else if (e.ColumnIndex == 2)
            {
                DBAccessStatic.UpdateIndividualGender((int)grdChildren[0, e.RowIndex].Value, grdChildren[2, e.RowIndex].Value.ToString());
            }
            else if (e.ColumnIndex == 3)
            {
                DBAccessStatic.UpdateIndividualBornDate((int)grdChildren[0, e.RowIndex].Value, grdChildren[3, e.RowIndex].Value.ToString());
            }
            else if (e.ColumnIndex == 4)
            {
                DBAccessStatic.UpdateIndividualDiedDate((int)grdChildren[0, e.RowIndex].Value, grdChildren[4, e.RowIndex].Value.ToString());
            }

        }

        private void butHusbandParents_Click(object sender, EventArgs e)
        {
            LoadFamilyByFamily(husbandParentId);
        }

        private void butWifeParents_Click(object sender, EventArgs e)
        {
            LoadFamilyByFamily(wifeParentId);
        }

        private void ancestorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AncestryReportOptionsForm ancestryReportOptionsFrom = new AncestryReportOptionsForm();
            if (ancestryReportOptionsFrom.ShowDialog() == DialogResult.OK)
            {
                AncestryReportForm ancestryReportForm = new AncestryReportForm(activePerson, ancestryReportOptionsFrom.UniqueAncestors, ancestryReportOptionsFrom.MaxDepth);
                ancestryReportForm.MdiParent = this.MdiParent;
                ancestryReportForm.Show();
            }
            ancestryReportOptionsFrom.Dispose();
        }



        private void addNewIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFamilyByFamily(-1);
        }

        private void txtWifeName_Enter(object sender, EventArgs e)
        {
            SetWifeActive();
        }

        private void txtWifeBornDate_Enter(object sender, EventArgs e)
        {
            SetWifeActive();
        }

        private void txtWifeBornPlace_Enter(object sender, EventArgs e)
        {
            SetWifeActive();
        }

        private void txtWifeDiedDate_Enter(object sender, EventArgs e)
        {
            SetWifeActive();
        }

        private void txtWifeDiedPlace_Enter(object sender, EventArgs e)
        {
            SetWifeActive();
        }

        private void txtHusbandName_Enter(object sender, EventArgs e)
        {
            SetHusbandActive();
        }

        private void txtHusbandBornDate_Enter(object sender, EventArgs e)
        {
            SetHusbandActive();
        }

        private void txtHusbandBornPlace_Enter(object sender, EventArgs e)
        {
            SetHusbandActive();
        }

        private void txtHusbandDiedDate_Enter(object sender, EventArgs e)
        {
            SetHusbandActive();
        }

        private void txtHusbandDiedPlace_Enter(object sender, EventArgs e)
        {
            SetHusbandActive();
        }

        private void attachSpouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndexForm indexForm = new IndexForm();
            if (indexForm.ShowDialog() == DialogResult.OK)
            {
                AttachSpouse(indexForm.SelectedIndividualId);
            }
            indexForm.Dispose();
        }

        private void attachChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndexForm indexForm = new IndexForm();
            if (indexForm.ShowDialog() == DialogResult.OK)
            {
                AttachChild(indexForm.SelectedIndividualId);
            }
            indexForm.Dispose();

        }

        private void detachSpouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetachSpouse();
        }

        private void detachChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdChildren.SelectedRows.Count > 0)
            {
                DetachChild((int)(grdChildren.SelectedRows[0].Cells[0].Value));
            }
        }

        private void deleteIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndexForm indexForm = new IndexForm();
            if (indexForm.ShowDialog() == DialogResult.OK)
            {
                DeleteIndividual(indexForm.SelectedIndividualId);
            }
            indexForm.Dispose();
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndexForm indexForm = new IndexForm();
            if (indexForm.ShowDialog() == DialogResult.OK)
            {
                LoadFamily(indexForm.SelectedIndividualId);
            }
            indexForm.Dispose();

        }

        private void tbrBack_Click(object sender, EventArgs e)
        {
            LoadFamily(history.Back());
            if (history.IsEmpty())
            {
                tbrBack.Enabled = false;
            }
        }

        private void descendantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescendantReportOptionsForm descendantReportOptionsFrom = new DescendantReportOptionsForm();
            if (descendantReportOptionsFrom.ShowDialog() == DialogResult.OK)
            {
                DescendantReportForm descendantReportForm = new DescendantReportForm(activePerson, descendantReportOptionsFrom.UniqueDescendants, descendantReportOptionsFrom.MaxDepth);
                descendantReportForm.MdiParent = this.MdiParent;
                descendantReportForm.Show();
            }
           descendantReportOptionsFrom.Dispose();

        }

   
    }
}
