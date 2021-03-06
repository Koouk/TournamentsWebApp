using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public ICollection<Tournament> tournaments { get; set; }

        public ICollection<TournamentEnrollment> Enrollments { get; set; }
    }
}
