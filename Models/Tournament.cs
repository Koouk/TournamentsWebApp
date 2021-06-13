using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TournamentsWebApp.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Tournament Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Entry Deadline")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        [Display(Name = "Type")]
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), StringLength(30)]
        public string Discipline { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9""'\s-./]*$"), StringLength(30)]
        [Display(Name = "Location")]
        public string localization { get; set; }

        public int currentPart { get; set; }

        [Required]
        [Display(Name = "Maximum members"), Range(1, 100)]
        public int maxPart { get; set; }

        public ICollection<Logo> SponsorsLogos { get; set; }
        [Required]
        public ApplicationUser Owner { get; set; }

        public ICollection<TournamentEnrollment> Enrollments { get; set; }


    }
}
