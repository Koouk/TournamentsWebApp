using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class Match
    {

        public int ID { get; set; }

        public int positionID { get; set; }

        public int nextMatchID { get; set; }

        public Match nextMatch { get; set; }

        public string OpponentFirstID { get; set; }

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
