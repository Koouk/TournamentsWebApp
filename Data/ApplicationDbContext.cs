using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TournamentsWebApp.Models;

namespace TournamentsWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TournamentsWebApp.Models.Tournament> Tournament { get; set; }
        public DbSet<TournamentsWebApp.Models.Logo> Logos { get; set; }
        public DbSet<TournamentsWebApp.Models.TournamentEnrollment> Enrollments { get; set; }

        public DbSet<TournamentsWebApp.Models.Match> Matches { get; set; }


    }
}
