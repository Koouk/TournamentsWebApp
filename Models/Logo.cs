using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class Logo
    {
        public int ID { get; set; }
        public string link { get; set; }

        public int TournamentId { get; set; }
        public Tournament tournament { get; set; }
    }
}
