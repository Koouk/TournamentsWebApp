using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class DetailsModel
    {
        public List<Logo> allLogos { get; set; }

        public Tournament tournament { get; set; }
    }
}
