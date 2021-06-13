using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class TournamentEnrollment
    {
        public int ID { get; set; }

        public string ApplicationUserID { get; set; }

        public int TournamentID { get; set; }

        public Tournament tournament { get; set; }
        public ApplicationUser user { get; set; }
    }
}
