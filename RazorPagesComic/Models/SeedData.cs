using Microsoft.EntityFrameworkCore;
using RazorPagesComic.Data;

namespace RazorPagesComic.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesComicContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesComicContext>>()))
        {
            if (context == null || context.Comic == null)
            {
                throw new ArgumentNullException("Null RazorPagesComicContext");
            }

            // Look for any movies.
            if (context.Comic.Any())
            {
                return;   // DB has been seeded
            }

            context.Comic.AddRange(
                new Comic
                {
                    Title = "Absolute Martian Manhunter",
                    Issue = 1,
                    ReleaseDate = DateTime.Parse("2025-3-26"),
                    Publisher = "DC"
                },

                new Comic
                {
                    Title = "Absolute Martian Manhunter",
                    Issue = 2,
                    ReleaseDate = DateTime.Parse("2025-4-23"),
                    Publisher = "DC"
                },

                new Comic
                {
                    Title = "Absolute Martian Manhunter",
                    Issue = 3,
                    ReleaseDate = DateTime.Parse("2025-5-28"),
                    Publisher = "DC"
                },

                new Comic
                {
                    Title = "Marc Spector: Moon Knight",
                    Issue = 1,
                    ReleaseDate = DateTime.Parse("2026-2-11"),
                    Publisher = "Marvel"
                },

                new Comic
                {
                    Title = "Transformers",
                    Issue = 24,
                    ReleaseDate = DateTime.Parse("2025-9-10"),
                    Publisher = "Skybound"
                }
            );
            context.SaveChanges();
        }
    }
}