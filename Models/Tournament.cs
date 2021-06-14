using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TournamentsWebApp.Services;

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
        [CheckDateRangeAttribute]
        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DateLessThan("StartDate")]
        [CheckDateRangeAttribute]
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
        [Display(Name = "Current participants")]
        public int currentPart { get; set; }

        [Required]
        [NumberHigherThann("currentPart")]
        [Display(Name = "Maximum members"), Range(2, 100)]
        public int maxPart { get; set; }

        public bool isBracket { get; set; } = false;

        public ICollection<Logo> SponsorsLogos { get; set; }
     
        public ApplicationUser Owner { get; set; }

        public ICollection<TournamentEnrollment> Enrollments { get; set; }


    }
}
