using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class TournamentEnrollment
    {
        public int ID { get; set; }

        public string ApplicationUserID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9""'\s-./]*$"), StringLength(30)]
        [Display(Name = "Licence number")]
        public string LicenceNumber { get; set; }
        [Required]
        [Display(Name = "Ranking"), Range(1, 10000)]
        public int Ranking { get; set; }

        public int TournamentID { get; set; }

        public Tournament tournament { get; set; }
        public ApplicationUser user { get; set; }
    }
}
