using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaderboardWebApi
{
    public class Highscore
    {
        public long UniqueId { get; set; }
        public string Name { get; set; }
        public long Score { get; set; }
        public string TimeStamp { get; set; }
    }
}
