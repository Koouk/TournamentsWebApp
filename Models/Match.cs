using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TournamentsWebApp.Services;

namespace TournamentsWebApp.Models
{
    public class Match
    {
        public int ID { get; set; }

        public int MatchNumber { get; set; }

        
        public int? nextMatchNumber { get; set; }

        public string OpponentFirstID { get; set; }

        public string LicenceNumberFirst { get; set; }

        public string LicenceNumberSecond { get; set; }

        public string OpponentSecondID { get; set; }

        public ApplicationUser OpponentFirst { get; set; }

        public ApplicationUser OpponentSecond { get; set; }

        public int TournamentID { get; set; }

        public Tournament tournament { get; set; }
        public string TemporaryResult { get; set; } = null;

        [isOneOfTwo("LicenceNumberFirst", "LicenceNumberSecond")]
        [Display(Name = "Winner licence")]
        public string WinnerID { get; set; } = null;

        public bool isFinished { get; set; } = false;
    }
}
