using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;

namespace Family_Traces
{
    public class DescendantCalc
    {
                private int MaxDepth = 255;
        
        public int GenerationCount = 0;
        public int IndividualCount = 0;
        public bool UniqueDescendants = true;

        public ArrayList[] descendantList = new ArrayList[256];
        public ArrayList[] descendantFamilyList = new ArrayList[256];
        public Hashtable descendantIds = new Hashtable();

        private DBAccess dbAccess = new DBAccess();

        
        public DescendantCalc()
        {
            for (int i = 0; i < 256; i++)
            {
                descendantFamilyList[i] = new ArrayList();
                descendantList[i] = new ArrayList();
            }
        }

        public DescendantCalc(int maxDepth)
        {
            MaxDepth = maxDepth;

            for (int i = 0; i < 256; i++)
            {
                descendantFamilyList[i] = new ArrayList();
                descendantList[i] = new ArrayList();
            }
        }

        public void CalculateDescendants(int initialIndividualId, bool uniqueDescendants)
        {
            dbAccess.Open();

            GenerationCount = 0;
            IndividualCount = 0;
            UniqueDescendants = uniqueDescendants;
            GenerateDescendantsFamilyList(initialIndividualId, 0);
            
            dbAccess.Close();

        }

        public void GenerateDescendantsFamilyList(int individualId, int depth)
        {
            if ((descendantIds.ContainsKey(individualId)) && (UniqueDescendants == true))
            {
                //do nothing since we can ignore it
            }
            else
            {
                DataSet individualDS = dbAccess.GetIndividual(individualId);
                if (!descendantIds.ContainsKey(individualId))
                {
                    descendantIds.Add(individualId, individualId);
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
                    descendantList[depth].Add(individual);

                    if (depth < MaxDepth)
                    {
                        DataSet familyDS = dbAccess.GetFamilyByPerson(individualId);
                        for(int i = 0; i < familyDS.Tables[0].Rows.Count; i++){
                            int familyId = (int)(familyDS.Tables[0].Rows[i]["ID"]);

                            int husbandId = (int)(familyDS.Tables[0].Rows[i]["HusbandId"]);
                            int wifeId = (int)(familyDS.Tables[0].Rows[i]["WifeId"]);
                            Family family = new Family(familyId, husbandId, wifeId, familyDS.Tables[0].Rows[i]["MarriageDate"].ToString(), familyDS.Tables[0].Rows[i]["MarriagePlace"].ToString());
                            descendantFamilyList[depth].Add(family);

                            DataSet familyChildrenDS = dbAccess.GetFamilyChildren(familyId);

                            for (int j = 0; j < familyChildrenDS.Tables[0].Rows.Count; j++)
                            {
                                GenerateDescendantsFamilyList((int)(familyChildrenDS.Tables[0].Rows[j]["ChildId"]), depth + 1);
                            }
                        }
                    }
                }
            }
        }
    }
}
