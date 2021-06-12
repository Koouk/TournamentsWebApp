using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TournamentsWebApp.Data;
using System;
using System.Linq;

namespace TournamentsWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Tournament.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tournament.AddRange(
                    new Tournament
                    {
                        Name = "When Harry Met Sally",
                        StartDate = DateTime.Parse("1989-2-12"),

                    },

                    new Tournament
                    {
                        Name = "Ghostbusters ",
                        StartDate = DateTime.Parse("1984-3-13"),

                    },

                    new Tournament
                    {
                        Name = "Ghostbusters 2",
                        StartDate = DateTime.Parse("1986-2-23"),

                    },

                    new Tournament
                    {
                        Name = "Rio Bravo",
                        StartDate = DateTime.Parse("1959-4-15"),

                    }
                );
                context.SaveChanges();
            }
        }
    }
}