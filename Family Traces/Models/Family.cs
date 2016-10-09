using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Traces.Models
{
    public class Family
    {
        public string Id { get; set; }
        public string HusbandId { get; set; }
        public Individual Husband { get; set; }
        public string WifeId { get; set; }
        public Individual Wife { get; set; }
        public string MarriageDate { get; set; }
        public string MarriagePlace { get; set; }
        public ICollection<Individual> Children { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Source> Sources { get; set; }

        public Family()
        {

        }
    }
}
