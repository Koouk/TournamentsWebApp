using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Services
{
    public class AuthMessageSenderOptions
    {
        public const string Name = "AuthMessageSender";
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
