using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TournamentsWebApp.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        public string Discipline { get; set; }

        public string localization { get; set; }

        public int currentPart { get; set; }

        public int maxPart { get; set; }

        public ICollection<Logo> SponsorsLogos { get; set; }

        public ApplicationUser Owner { get; set; }

        public ICollection<TournamentEnrollment> Enrollments { get; set; }


    }
}
