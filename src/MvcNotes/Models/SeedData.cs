using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MvcNotes.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            if (context.Note.Any())
            {
                return;
            }

            context.Note.AddRange(
                new Note
                {
                    Title = "Notka 1",
                    Name = "Kacper",
                    ReleaseDate = DateTime.Parse("2016-04-14"),
                    NoteContents = "Treść notatki",
                    Hashtag = "#Notatka"
                },

                new Note
                {
                    Title = "Notka 2",
                    Name = "Kacper2",
                    ReleaseDate = DateTime.Parse("2016-04-15"),
                    NoteContents = "Treść notatki2",
                    Hashtag = "#Notatka2"
                },
                new Note
                {
                    Title = "Notka 3",
                    Name = "Kacper3",
                    ReleaseDate = DateTime.Parse("2016-04-16"),
                    NoteContents = "Treść notatki3",
                    Hashtag = "#Notatka"
                },
                new Note
                {
                    Title = "Notka 4",
                    Name = "Kacper4",
                    ReleaseDate = DateTime.Parse("2016-04-17"),
                    NoteContents = "Treść notatki4",
                    Hashtag = "#Notatka4"
                                                                });
            context.SaveChanges();
        }
    }
}
