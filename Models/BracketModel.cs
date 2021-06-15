using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Models
{
    public class BracketModel
    {
        public string name { get; set; } = "";

        public string id { get; set; } = "";

        public int seed { get; set; } = 1;

        public string displaySeed { get; set; } = "";

        public string score { get; set; } = "";
    }
}
