using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.IO;
using GedcomLib;

namespace Family_Traces
{
    public class GedcomExporter
    {
        public List<GedcomIndividual> gedcomIndividuals = new List<GedcomIndividual>();
        public List<GedcomFamily> gedcomFamilies = new List<GedcomFamily>();
        public GedcomHeader gedcomHeader = new GedcomHeader();
        public GedcomExporter()
        {
        }

        public void Export()
        {
            GedcomIndividual currentGedcomIndividual;
            GedcomFamily currentGedcomFamily;

            DBAccess dbAccess = new DBAccess();
            dbAccess.Open();

            gedcomHeader.Source = "FamilyTraces";
            gedcomHeader.SourceName = "Family Traces";
            gedcomHeader.SourceCorporation = "Serge Meunier";
            gedcomHeader.Destination = "Standard GEDCOM";
            gedcomHeader.Date = DateTime.Now.ToShortDateString();
            gedcomHeader.GedcomVersion = "5.5";
            gedcomHeader.GedcomForm = "LINEAGE-LINKED";
            gedcomHeader.CharacterEncoding = "ANSEL";
            gedcomHeader.File = "";
            gedcomHeader.SourceVersion = "";
            
            DataSet individuals = dbAccess.GetAllIndividuals();
            for (int i = 0; i < individuals.Tables[0].Rows.Count; i++)
            {
                currentGedcomIndividual = new GedcomIndividual("@I" + individuals.Tables[0].Rows[i]["ID"].ToString() + "@");
                currentGedcomIndividual.GivenName = individuals.Tables[0].Rows[i]["Firstname"].ToString();
                currentGedcomIndividual.Surname = individuals.Tables[0].Rows[i]["Surname"].ToString();
                currentGedcomIndividual.Sex = individuals.Tables[0].Rows[i]["Gender"].ToString();
                currentGedcomIndividual.BirthDate = individuals.Tables[0].Rows[i]["BornDate"].ToString();
                currentGedcomIndividual.BirthPlace = individuals.Tables[0].Rows[i]["BornPlace"].ToString();
                currentGedcomIndividual.DiedDate = individuals.Tables[0].Rows[i]["DiedDate"].ToString();
                currentGedcomIndividual.DiedPlace = individuals.Tables[0].Rows[i]["DiedPlace"].ToString();
                currentGedcomIndividual.ParentFamilyId = "@F" + individuals.Tables[0].Rows[i]["ParentFamilyId"].ToString() + "@";
                if (individuals.Tables[0].Rows[0]["Gender"].ToString() == "M")
                {
                    DataSet family = dbAccess.GetFamilyForHusband((int)(individuals.Tables[0].Rows[i]["ID"]));
                    if (family.Tables[0].Rows.Count > 0)
                    {
                        if ((int)(family.Tables[0].Rows[0]["ID"]) != -1)
                        {
                            currentGedcomIndividual.SpouseFamilyId = "@F" + family.Tables[0].Rows[0]["ID"].ToString() + "@";
                        }
                        else
                        {
                            currentGedcomIndividual.SpouseFamilyId = "";
                        }
                    }
                    else
                    {
                        currentGedcomIndividual.SpouseFamilyId = "";
                    }
                }
                else
                {
                    DataSet family = dbAccess.GetFamilyForWife((int)(individuals.Tables[0].Rows[i]["ID"]));
                    if (family.Tables[0].Rows.Count > 0)
                    {
                        if ((int)(family.Tables[0].Rows[0]["ID"]) != -1)
                        {
                            currentGedcomIndividual.SpouseFamilyId = "@F" + family.Tables[0].Rows[0]["ID"].ToString() + "@";
                        }
                        else
                        {
                            currentGedcomIndividual.SpouseFamilyId = "";
                        }
                    }
                    else
                    {
                        currentGedcomIndividual.SpouseFamilyId = "";
                    }
                }
                gedcomIndividuals.Add(currentGedcomIndividual);
            }

            DataSet families = dbAccess.GetAllFamilies();

            for (int i = 0; i < families.Tables[0].Rows.Count; i++)
            {
                currentGedcomFamily = new GedcomFamily("@F" + families.Tables[0].Rows[i]["ID"].ToString() + "@");
                currentGedcomFamily.HusbandId = "@I" + families.Tables[0].Rows[i]["HusbandId"].ToString() + "@";
                currentGedcomFamily.WifeId = "@I" + families.Tables[0].Rows[i]["WifeId"].ToString() + "@";
                currentGedcomFamily.MarriagePlace = families.Tables[0].Rows[i]["MarriagePlace"].ToString();
                DataSet children = dbAccess.GetFamilyChildren((int)(families.Tables[0].Rows[i]["ID"]));
                for (int j = 0; j < children.Tables[0].Rows.Count; j++)
                {
                    currentGedcomFamily.Children.Add("@F" + children.Tables[0].Rows[j]["ChildId"].ToString() + "@");
                }
                gedcomFamilies.Add(currentGedcomFamily);
            }
        }

        public void Write(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            GedcomIndividual currentGedcomIndividual;
            GedcomFamily currentGedcomFamily;

            writer.WriteLine("0 HEAD");
            if ((gedcomHeader.Source.Length > 0) || (gedcomHeader.SourceCorporation.Length)  > 0 || (gedcomHeader.SourceName.Length > 0))
            {
                writer.WriteLine("1 SOUR " + gedcomHeader.Source);
                if (gedcomHeader.SourceVersion.Length > 0)
                {
                    writer.WriteLine("2 VERS " + gedcomHeader.SourceVersion);
                }
                if (gedcomHeader.SourceName.Length > 0)
                {
                    writer.WriteLine("2 NAME " + gedcomHeader.SourceName);
                }
                if (gedcomHeader.SourceCorporation.Length > 0)
                {
                    writer.WriteLine("2 CORP " + gedcomHeader.SourceCorporation);
                }
            }
            if (gedcomHeader.Destination.Length > 0)
            {
                writer.WriteLine("1 DEST " + gedcomHeader.Destination);
            }
            if (gedcomHeader.Date.Length > 0)
            {
                writer.WriteLine("1 DATE " + gedcomHeader.Date);
            }
            if (gedcomHeader.File.Length > 0)
            {
                writer.WriteLine("1 FILE " + gedcomHeader.File);
            }
            if (gedcomHeader.CharacterEncoding.Length > 0)
            {
                writer.WriteLine("1 CHAR " + gedcomHeader.CharacterEncoding);
            }
            if ((gedcomHeader.GedcomVersion.Length > 0) || (gedcomHeader.GedcomForm.Length > 0))
            {
                writer.WriteLine("1 GEDC");
                if (gedcomHeader.GedcomVersion.Length > 0)
                {
                    writer.WriteLine("1 VERS " + gedcomHeader.GedcomVersion);
                }
                if (gedcomHeader.GedcomForm.Length > 0)
                {
                    writer.WriteLine("1 FORM " + gedcomHeader.GedcomForm);
                }
            }

            for (int i = 0; i < gedcomIndividuals.Count; i++)
            {
                currentGedcomIndividual = (GedcomIndividual)(gedcomIndividuals[i]);
                writer.WriteLine("0 " + currentGedcomIndividual.Id + " INDI");
                writer.WriteLine("1 " + currentGedcomIndividual.GivenName + "/" + currentGedcomIndividual.Surname + "/");
                if (currentGedcomIndividual.GivenName.Length > 0)
                {
                    writer.WriteLine("2 GIVN " + currentGedcomIndividual.GivenName);
                }
                if (currentGedcomIndividual.Surname.Length > 0)
                {
                    writer.WriteLine("2 SURN " + currentGedcomIndividual.Surname);
                }
                if (currentGedcomIndividual.Sex.Length > 0)
                {
                    writer.WriteLine("1 SEX " + currentGedcomIndividual.Sex);
                }
                if (currentGedcomIndividual.Occupation.Length > 0)
                {
                    writer.WriteLine("1 OCCU " + currentGedcomIndividual.Occupation);
                }
                if ((currentGedcomIndividual.BirthDate.Length > 0) || (currentGedcomIndividual.BirthPlace.Length > 0))
                {
                    writer.WriteLine("1 BIRT");
                    if (currentGedcomIndividual.BirthDate.Length > 0)
                    {
                        writer.WriteLine("2 DATE " + currentGedcomIndividual.BirthDate);
                    }
                    if (currentGedcomIndividual.BirthDate.Length > 0)
                    {
                        writer.WriteLine("2 PLAC " + currentGedcomIndividual.BirthPlace);
                    }
                }
                if ((currentGedcomIndividual.DiedDate.Length > 0) || (currentGedcomIndividual.DiedPlace.Length > 0))
                {
                    writer.WriteLine("1 DEAT");
                    if (currentGedcomIndividual.DiedDate.Length > 0)
                    {
                        writer.WriteLine("2 DATE " + currentGedcomIndividual.DiedDate);
                    }
                    if (currentGedcomIndividual.DiedDate.Length > 0)
                    {
                        writer.WriteLine("2 PLAC " + currentGedcomIndividual.DiedPlace);
                    }
                }
                if (currentGedcomIndividual.Nationality.Length > 0)
                {
                    writer.WriteLine("1 NATI " + currentGedcomIndividual.Nationality);
                }
                if (currentGedcomIndividual.ParentFamilyId.Length > 0)
                {
                    writer.WriteLine("1 FAMC " + currentGedcomIndividual.ParentFamilyId);
                }
                if (currentGedcomIndividual.SpouseFamilyId.Length > 0)
                {
                    writer.WriteLine("1 FAMS " + currentGedcomIndividual.SpouseFamilyId);
                }

            }
            for (int i = 0; i < gedcomFamilies.Count; i++)
            {
                currentGedcomFamily = (GedcomFamily)(gedcomFamilies[i]);
                writer.WriteLine("0 " + currentGedcomFamily.Id + " FAM");
                if (currentGedcomFamily.HusbandId.Length > 0)
                {
                    writer.WriteLine("1 HUSB " + currentGedcomFamily.HusbandId);
                }
                if (currentGedcomFamily.WifeId.Length > 0)
                {
                    writer.WriteLine("1 WIFE " + currentGedcomFamily.WifeId);
                }
                if ((currentGedcomFamily.MarriageDate.Length > 0) || (currentGedcomFamily.MarriagePlace.Length > 0))
                {
                    writer.WriteLine("1 MARR");
                    if (currentGedcomFamily.MarriageDate.Length > 0)
                    {
                        writer.WriteLine("2 DATE " + currentGedcomFamily.MarriageDate);
                    }
                    if (currentGedcomFamily.MarriagePlace.Length > 0)
                    {
                        writer.WriteLine("2 PLAC " + currentGedcomFamily.MarriagePlace);
                    }
                }
                for (int j = 0; j < currentGedcomFamily.Children.Count; j++)
                {
                    writer.WriteLine("1 CHIL " + currentGedcomFamily.Children[j].ToString());
                }
            }
            writer.WriteLine("0 TRLR");
            writer.Close();
        }
    }
}
