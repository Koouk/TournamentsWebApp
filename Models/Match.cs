using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public string FirstOpponentResult { get; set; } = null;

        public string SecondOpponentResult { get; set; } = null;

        public string WinnerID { get; set; } = null;


    }
}
