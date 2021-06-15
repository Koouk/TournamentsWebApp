using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class ViewModel
    {
        public List<List<List<BracketModel>>> bracket { get; set; }
        public List<Match> allMatches { get; set; }
        public List<Match> userMatches { get; set; }
        public Tournament tournament { get; set; }
    }
}
