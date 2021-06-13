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
                        Deadline  = DateTime.Parse("1989-4-12"),
                        localization = "Poznan ul koszewskiego 5",
                        maxPart = 10

                    }
                  
                );
                context.SaveChanges();
            }
        }
    }
}