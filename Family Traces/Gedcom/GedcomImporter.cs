using System.Collections;
using System.Linq;
using Family_Traces.Database;
using Family_Traces.Models;
using GedcomLib;

namespace Family_Traces
{
    public class GedcomImporter
    {
        public static void Import(GedcomParser gedcomParser)
        {
            Hashtable individualIdMapper = new Hashtable();

            using (var ctx = new FamilyTracesContext())
            {
                ctx.Families.RemoveRange(ctx.Families);
                ctx.Individuals.RemoveRange(ctx.Individuals);
                ctx.Sources.RemoveRange(ctx.Sources);
                ctx.Notes.RemoveRange(ctx.Notes);
                ctx.SaveChanges();

                foreach (GedcomNote gedcomNote in gedcomParser.gedcomNotes.Values)
                {
                    ctx.Notes.Add(new Note()
                    {
                        Id = gedcomNote.Id,
                        Text = gedcomNote.Text
                    });

                }

                foreach (GedcomSource gedcomSource in gedcomParser.gedcomSources.Values)
                {
                    ctx.Sources.Add(new Source()
                    {
                        Id = gedcomSource.Id,
                        Text = gedcomSource.Text
                    });

                }

                foreach (GedcomIndividual gedcomIndividual in gedcomParser.gedcomIndividuals.Values.Take(20))
                {
                    ctx.Individuals.Add(new Individual()
                    {
                        Id = gedcomIndividual.Id,
                        GivenName = gedcomIndividual.GivenName,
                        BirthDate = gedcomIndividual.BirthDate,
                        BirthPlace = gedcomIndividual.BirthPlace,
                        Description = gedcomIndividual.Description,
                        DiedCause = gedcomIndividual.DiedCause,
                        DiedDate = gedcomIndividual.DiedDate,
                        DiedPlace = gedcomIndividual.DiedPlace,
                        Gender = Enums.Gender.Male,
                        Nationality = gedcomIndividual.Nationality,
                        Occupation = gedcomIndividual.Occupation,
                        Prefix = gedcomIndividual.Prefix,
                        Suffix = gedcomIndividual.Suffix,
                        Surname = gedcomIndividual.Surname

                    });

                }
                ctx.SaveChanges();

            }
        }
    }
}
