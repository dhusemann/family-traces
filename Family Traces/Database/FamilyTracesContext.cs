using System.Data.Entity;
using Family_Traces.Models;

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
