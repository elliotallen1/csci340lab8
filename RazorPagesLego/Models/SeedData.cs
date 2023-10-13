using Microsoft.EntityFrameworkCore;
using RazorPagesLego.Data;

namespace RazorPagesLego.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesLegoContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesLegoContext>>()))
        {
            if (context == null || context.Lego == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Lego.Any())
            {
                return;   // DB has been seeded
            }

            context.Lego.AddRange(
                new Lego
                {
                    Id = 75192,
                    Title = "Millennium Falcon",
                    ReleaseDate = DateTime.Parse("2017-10-01"),
                    PieceCount = 7541,
                    ReleasePrice = 849.99M
                });


            context.SaveChanges();
        }
    }
}