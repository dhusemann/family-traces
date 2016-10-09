using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Traces.Models
{
    public class Individual
    {
        public string Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public Enums.Gender Gender { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Occupation { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }
        public string DiedDate { get; set; }
        public string DiedPlace { get; set; }
        public string DiedCause { get; set; }
        public string ParentFamilyId { get; set; }
        public string SpouseFamilyId { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Source> Sources { get; set; }

        public Individual()
        {

        }
    }
}
