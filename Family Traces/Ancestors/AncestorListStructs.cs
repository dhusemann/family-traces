using System;
using System.Collections.Generic;
using System.Collections;

namespace Family_Traces
{


    public struct AncestorIndividual
    {
        public string Id;
        public string GivenName;
        public string Surname;
        public string Suffix;
        public string Prefix;
        public string Sex;
        public string BirthDate;
        public string DiedDate;
        public string FatherId;
        public string MotherId;
        public string SpouseId;
        public int LowestGeneration;
        public int HighestGeneration;
        public int AppearanceCount;
        public HashSet<string> ChildrenIds;

        public AncestorIndividual(string id)
        {
            Id = id;
            GivenName = "";
            Surname = "";
            Suffix = "";
            Prefix = "";
            Sex = "";
            BirthDate = "";
            DiedDate = "";
            FatherId = "";
            MotherId = "";
            SpouseId = "";
            LowestGeneration = 0;
            HighestGeneration = 0;
            AppearanceCount = 0;
            ChildrenIds = new HashSet<string>();
        }
    }
}
