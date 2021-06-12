using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentsWebApp.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

    }
}
