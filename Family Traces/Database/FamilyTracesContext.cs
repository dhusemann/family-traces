using Family_Traces.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Traces.Database
{
    public class FamilyTracesContext : DbContext
    {
        public FamilyTracesContext() : base()
        {

        }

        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Note> Notes { get; set; }

    }
}
