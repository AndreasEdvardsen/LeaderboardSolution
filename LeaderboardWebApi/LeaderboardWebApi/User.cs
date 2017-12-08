using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaderboardWebApi
{
    public class User
    {
        public string Username { get; set; }
        public string SecurityCode { get; set; }
        public int UniqueId { get; set; }
    }
}
