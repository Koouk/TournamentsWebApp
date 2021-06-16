using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class MatchesTournaments
    {

        public List<Match> Matches { get; set; }
        public List<TournamentEnrollment> Tournaments { get; set; }

    }
}
