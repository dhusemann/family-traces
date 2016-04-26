using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Family_Traces
{
    public class GedcomImporter
    {
        public static void Import(ArrayList gedcomIndividuals, ArrayList gedcomFamilies)
        {
            Hashtable individualIdMapper = new Hashtable();
            GedcomFamily currentGedcomFamily;
            GedcomIndividual currentGedcomIndividual;
            DBAccess dbAccess = new DBAccess();
            int individualId;
            int familyId, husbandId, wifeId, childId;
            int i;
            dbAccess.Open();

            for (i = 0; i < gedcomIndividuals.Count; i++)
            {
                currentGedcomIndividual = (GedcomIndividual)(gedcomIndividuals[i]);

                individualId = dbAccess.InsertIndividual(currentGedcomIndividual.Surname.Trim() + " " + currentGedcomIndividual.Suffix.Trim(), currentGedcomIndividual.GivenName.Trim(), currentGedcomIndividual.BirthDate.Trim(), currentGedcomIndividual.BirthPlace.Trim(), currentGedcomIndividual.DiedDate.Trim(), currentGedcomIndividual.DiedPlace.Trim(), -1, currentGedcomIndividual.Sex.Trim());
                individualIdMapper.Add(currentGedcomIndividual.Id, individualId);
            }

            for (i = 0; i < gedcomFamilies.Count; i++)
            {
                currentGedcomFamily = (GedcomFamily)(gedcomFamilies[i]);
                if (currentGedcomFamily.HusbandId.Trim() == "")
                {
                    husbandId = -1;
                }
                else
                {
                    if (individualIdMapper.ContainsKey(currentGedcomFamily.HusbandId))
                    {
                        husbandId = (int)(individualIdMapper[currentGedcomFamily.HusbandId]);
                    }
                    else
                    {
                        husbandId = -1;
                    }
                }

                if (currentGedcomFamily.WifeId.Trim() == "")
                {
                    wifeId = -1;
                }
                else
                {
                    if (individualIdMapper.ContainsKey(currentGedcomFamily.WifeId))
                    {
                        wifeId = (int)(individualIdMapper[currentGedcomFamily.WifeId]);
                    }
                    else
                    {
                        wifeId = -1;
                    }
                }

                familyId = dbAccess.InsertFamily(husbandId, wifeId, currentGedcomFamily.MarriageDate.Trim(), currentGedcomFamily.MarriagePlace.Trim());
                for (int j = 0; j < currentGedcomFamily.Children.Count; j++)
                {
                    if (individualIdMapper.ContainsKey(currentGedcomFamily.Children[j].ToString()))
                    {
                        childId = (int)(individualIdMapper[currentGedcomFamily.Children[j].ToString()]);
                        dbAccess.UpdateIndividualPArentFamilyId(childId, familyId);
                    }
                }
            }

            dbAccess.Close();
        }
    }
}
