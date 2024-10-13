/*

// The code below will be based on code from here:
// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-8.0&tabs=visual-studio#seed-the-database
// It checks if any manga have been created, if not then it will seed 3
// Does not currently work because artists authors and genres need to be seeded as well
// which i only realized after so I will finish this later

using Microsoft.EntityFrameworkCore;
using SDA_ASP_Project.Data;

namespace SDA_ASP_Project.Models
{
    public class SeedMangaData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SDA_ASP_ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SDA_ASP_ProjectContext>>()))
            {
                // Look for any manga
                if (context.Manga.Any())
                {
                    return;   // if any then just return
                }
                context.Manga.AddRange(
                    new Manga
                    {
                        Title = "Naruto",
                        Description = "Ninjas...",
                        Rating = 3,
                        Chapters = 700,
                        CoverPhoto = "",
                        ReleaseDate = DateTime.Parse("1999-09-21"),
                        Favorite = false,
                        GenreId = 1,
                        AuthorId = 1,
                        ArtistId = 1
                    },
                    new Manga
                    {
                        Title = "One Piece",
                        Description = "Pirates and peak world building.",
                        Rating = 4,
                        Chapters = 1000,
                        CoverPhoto = "",
                        ReleaseDate = DateTime.Parse("1997-07-22"),
                        Favorite = false,
                        GenreId = 2,
                        AuthorId = 2,
                        ArtistId = 2
                    },
                    new Manga
                    {
                        Title = "Attack on Titan",
                        Description = "Utterly terrifying.",
                        Rating = 5,
                        Chapters = 139,
                        CoverPhoto = "",
                        ReleaseDate = DateTime.Parse("2009-09-09"),
                        Favorite = false,
                        GenreId = 3,
                        AuthorId = 3,
                        ArtistId = 3
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
*/