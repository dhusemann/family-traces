using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace Family_Traces
{
    public struct Individual
    {
        public int Id;
        public string Firstname;
        public string Surname;
        public string Gender;
        public string BirthDate;
        public string BirthPlace;
        public string DiedDate;
        public string DiedPlace;
        public int ParentFamilyId;

        public Individual(int id, string firstname, string surname, string gender, string birthDate, string birthPlace, string diedDate, string diedPlace, int parentFamilyId)
        {
            Id = id;
            Firstname = firstname;
            Surname = surname;
            Gender = gender;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            DiedDate = diedDate;
            DiedPlace = diedPlace;
            ParentFamilyId = parentFamilyId;
        }
    }

    public struct Family
    {
        public int Id;
        public int HusbandId;
        public int WifeId;
        public string MarriageDate;
        public string MarriagePlace;

        public Family(int id, int husbandId, int wifeId, string marriageDate, string marriagePlace)
        {
            Id = id;
            HusbandId = husbandId;
            WifeId = wifeId;
            MarriageDate = marriageDate;
            MarriagePlace = marriagePlace;
        }
    }

    public class AncestorCalc
    {
        private int MaxDepth = 255;
        
        public int GenerationCount = 0;
        public int IndividualCount = 0;
        public bool UniqueAncestors = true;

        public ArrayList[] ancestryList = new ArrayList[256];
        public ArrayList[] ancestryFamilyList = new ArrayList[256];
        public Hashtable ancestryIds = new Hashtable();

        private DBAccess dbAccess = new DBAccess();

        
        public AncestorCalc()
        {
            for (int i = 0; i < 256; i++)
            {
                ancestryFamilyList[i] = new ArrayList();
                ancestryList[i] = new ArrayList();
            }
        }

        public AncestorCalc(int maxDepth)
        {
            MaxDepth = maxDepth;

            for (int i = 0; i < 256; i++)
            {
                ancestryFamilyList[i] = new ArrayList();
                ancestryList[i] = new ArrayList();
            }
        }

        public void CalculateAncestors(int initialIndividualId, bool uniqueAncestors)
        {
            dbAccess.Open();

            GenerationCount = 0;
            IndividualCount = 0;
            UniqueAncestors = uniqueAncestors;
            GenerateAncestryFamilyList(initialIndividualId, 0);
            
            dbAccess.Close();

        }

        private void GenerateAncestryFamilyList(int individualId, int depth)
        {
            if ((ancestryIds.ContainsKey(individualId)) && (UniqueAncestors == true))
            {
                //do nothing since we can ignore it
            }
            else
            {
                DataSet individualDS = dbAccess.GetIndividual(individualId);
                if (!ancestryIds.ContainsKey(individualId))
                {
                    ancestryIds.Add(individualId, individualId);
                }
                IndividualCount++;

                if (GenerationCount < depth)
                {
                    GenerationCount = depth;
                }

                if (individualDS.Tables[0].Rows.Count > 0)
                {
                    int parentFamilyId = (int)(individualDS.Tables[0].Rows[0]["ParentFamilyId"]);
                    Individual individual = new Individual(individualId, individualDS.Tables[0].Rows[0]["Firstname"].ToString(), individualDS.Tables[0].Rows[0]["Surname"].ToString(), individualDS.Tables[0].Rows[0]["Gender"].ToString(), individualDS.Tables[0].Rows[0]["BornDate"].ToString(), individualDS.Tables[0].Rows[0]["BornPlace"].ToString(), individualDS.Tables[0].Rows[0]["DiedDate"].ToString(), individualDS.Tables[0].Rows[0]["DiedPlace"].ToString(), parentFamilyId);
                    ancestryList[depth].Add(individual);

                    if (depth < MaxDepth)
                    {
                        DataSet familyDS = dbAccess.GetFamily(parentFamilyId);
                        if (familyDS.Tables[0].Rows.Count > 0)
                        {
                            int husbandId = (int)(familyDS.Tables[0].Rows[0]["HusbandId"]);
                            int wifeId = (int)(familyDS.Tables[0].Rows[0]["WifeId"]);
                            Family family = new Family(parentFamilyId, husbandId, wifeId, familyDS.Tables[0].Rows[0]["MarriageDate"].ToString(), familyDS.Tables[0].Rows[0]["MarriagePlace"].ToString());
                            ancestryFamilyList[depth].Add(family);
                            if (husbandId != -1)
                            {
                                GenerateAncestryFamilyList(husbandId, depth + 1);
                            }
                            if (wifeId != -1)
                            {
                                GenerateAncestryFamilyList(wifeId, depth + 1);
                            }
                        }
                    }
                }
            }
        }


    }
}
