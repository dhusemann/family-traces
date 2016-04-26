using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.IO;

namespace Family_Traces
{
    public class AncestorList
    {
        public int MaxDepth = 255;
        public int GreatestDepth = 0;
        public int GenerationCount = 0;
        public int IndividualCount = 0;
        private Dictionary<string, GedcomIndividual> gedcomIndividuals;
        private Dictionary<string, GedcomFamily> gedcomFamilies;
        private Dictionary<string, AncestorIndividual> ancestors;

        public void CalcAncestorList(string initialIndividualId, Dictionary<string, GedcomIndividual> gedcomIndividuals, Dictionary<string, GedcomFamily> gedcomFamilies, string outputFile)
        {
            this.ancestors = new Dictionary<string, AncestorIndividual>();
            this.gedcomFamilies = gedcomFamilies;
            this.gedcomIndividuals = gedcomIndividuals;
            GreatestDepth = 0;
            GenerateAncestorList(initialIndividualId, "", 0);
            OutputToWord(1, outputFile);
        }

        private void GenerateAncestorList(string individualId, string spouseId, int depth)
        {
            if (depth > GreatestDepth)
                GreatestDepth = depth;

            if (ancestors.ContainsKey(individualId))
            {
                IncrementAppearance(individualId, depth);
            }
            else
            {
                AncestorIndividual individual = new AncestorIndividual(individualId);
                GedcomIndividual gedcomIndividual = gedcomIndividuals[individualId];

                individual.GivenName = gedcomIndividual.GivenName.Trim();
                individual.Surname = gedcomIndividual.Surname.Trim();
                individual.Prefix = gedcomIndividual.Prefix.Trim();
                individual.Suffix = gedcomIndividual.Suffix.Trim();
                individual.Sex = gedcomIndividual.Sex.Trim();
                individual.BirthDate = gedcomIndividual.BirthDate.Trim();
                individual.DiedDate = gedcomIndividual.DiedDate.Trim();
                individual.appearanceCount = 1;
                individual.lowestGeneration = depth;

                GedcomFamily? gedcomFamily = gedcomFamilies.FirstOrDefault(x => x.Value.Children.Contains(individualId)).Value;
                if (gedcomFamily != null)
                {
                    individual.FatherId = gedcomFamily.Value.HusbandId;
                    individual.MotherId = gedcomFamily.Value.WifeId;
                }
                individual.SpouseId = spouseId;

                ancestors.Add(individualId, individual);
                if (depth <= MaxDepth)
                {
                    if (!string.IsNullOrEmpty(individual.FatherId))
                        GenerateAncestorList(individual.FatherId, individual.MotherId, depth + 1);

                    if (!string.IsNullOrEmpty(individual.MotherId))
                        GenerateAncestorList(individual.MotherId, individual.FatherId, depth + 1);
                }
            }
        }

        private void IncrementAppearance(string individualId, int depth)
        {
            if (ancestors.ContainsKey(individualId))
            {
                AncestorIndividual individual = ancestors[individualId];
                if (depth < individual.lowestGeneration)
                    individual.lowestGeneration = depth;
                individual.appearanceCount++;
                ancestors[individualId] = individual;

                if (!string.IsNullOrEmpty(individual.FatherId))
                    IncrementAppearance(individual.FatherId, depth + 1);

                if (!string.IsNullOrEmpty(individual.MotherId))
                    IncrementAppearance(individual.MotherId, depth + 1);

            }
        }


        private void OutputToWord(int startingDepth, string outputFile)
        {
			StreamWriter writer = new StreamWriter(outputFile);


                long total = 0;
                long unique = 0;
                for (var depth = startingDepth; depth <= GreatestDepth; depth++)
                {
					writer.WriteLine(string.Format("Generation {0} - {1}", depth, GetGenerationHeading(depth)));


                    IEnumerable<KeyValuePair<string, AncestorIndividual>> individuals = ancestors.Where(x => x.Value.lowestGeneration == depth);
                    foreach (KeyValuePair<string, AncestorIndividual> individual in individuals)
                    {
                        total += individual.Value.appearanceCount;
                        unique++;
                        OutputIndividualText(individual.Value.Id, individual.Value.SpouseId, writer);
                    }
      
                }
			writer.Flush();
			writer.Close();
            
            
        }

        private void OutputIndividualText(string individualId, string spouseId, StreamWriter writer)
        {

            AncestorIndividual individual = ancestors[individualId];
            AncestorIndividual? father = null;
            AncestorIndividual? mother = null;
            AncestorIndividual? spouse = null;

            if ((!string.IsNullOrEmpty(individual.FatherId)) && (ancestors.ContainsKey(individual.FatherId)))
                father = ancestors[individual.FatherId];
            if ((!string.IsNullOrEmpty(individual.MotherId)) && (ancestors.ContainsKey(individual.MotherId)))
                mother = ancestors[individual.MotherId];
            if ((!string.IsNullOrEmpty(spouseId)) && (ancestors.ContainsKey(spouseId)))
                spouse = ancestors[spouseId];

            writer.WriteLine(GenerateFullName(individual, false));
          

            if (spouse.HasValue) 
            {
               writer.WriteLine("     x " + GenerateFullName(spouse.Value, false));
               
            }
            if (father.HasValue)
            {
				writer.WriteLine("     f. " + GenerateFullName(father.Value, false));
            }
            if (mother.HasValue)
            {
				writer.WriteLine("     m. " + GenerateFullName(mother.Value, false));
			}
			writer.WriteLine();
        }

        public string GenerateFullName(AncestorIndividual individual, bool SurnameFirst)
        {

            string name = "";
            if (string.IsNullOrEmpty(individual.Surname))
                name = string.Format("{0}", individual.GivenName);
            else
            {
				if (individual.Suffix.Length > 0)
				{
					if (SurnameFirst)
						name = string.Format("{2}, {0} ({1})", individual.GivenName, individual.Suffix, individual.Surname);
					else
						name = string.Format("{0} {2} ({1})", individual.GivenName, individual.Suffix, individual.Surname);
				}
				else
				{
					if (SurnameFirst)
						name = string.Format("{1}, {0}", individual.GivenName, individual.Surname);
					else
						name = string.Format("{0} {1}", individual.GivenName, individual.Surname);
				}
			}

			string born = ProcessDate(individual.BirthDate);
            string died = ProcessDate(individual.DiedDate);
            if (born != "?" || died != "?")
            {
                if (born == "?")
                    name = name + string.Format(" (d.{0})", died);
                else if (died == "?")
                    name = name + string.Format(" (b.{0})", born);
                else
                    name = name + string.Format(" (b.{0}, d.{1})", born, died);
            }    
            name = name.Replace("  ", " ").Replace("  ", " ");
            return name;
        }

        public string GetRandomHexNumber(int digits)
        {
            Random random = new Random();
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }



        private string GetGenerationHeading(int depth)
        {
            string str;

            if (depth == 1)
                str = "Parents";
            else if (depth == 2)
                str = "Grandparents";
            else if (depth == 3)
                str = "Great-grandparents";
            else
                str = string.Format("Great({0})-grandparents", depth - 2);
            return str;
        }

        private string ProcessDate(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                date = "?";
            }
            else
            {
                string[] dateArr = date.Split(new char[] { ' ' });
                if (dateArr.Length > 1)
                {
                    date = "";
                    if (dateArr[0] == "ABT")
                        date = "c";
                    else if (dateArr[0] == "AFT")
                        date = ">";
                    else if (dateArr[0] == "BEF")
                        date = "<";
                    date += dateArr[dateArr.Length - 1];

                    int year = 0;
                    Int32.TryParse(dateArr[dateArr.Length - 1], out year);
                    if (year > 2008)
                        date = "?";
                }
            }

            return date;
        }
    }
}
