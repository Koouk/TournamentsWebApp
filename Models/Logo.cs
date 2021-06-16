using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TournamentsWebApp.Services;

namespace TournamentsWebApp.Models
{
    public class Logo
    {
        [Key]
        public int ID { get; set; }

        [Url]
        [Display(Name = "Tournament logo link")]
        [imageLink]
        [Required]
        public string link { get; set; }

        [NotMapped]
        [Display(Name = "Tournament logo")]
        public IFormFile picture { get; set; }

        [Required]
        public int TournamentId { get; set; }
        public Tournament tournament { get; set; }
    }
}
