using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Challenge3Repository
{
    public class Challenge3Badges
    {
        public Challenge3Badges() { }

        public Challenge3Badges(int badgeNumber, List<string> doorAccess)
        {
            BadgeNumber = badgeNumber;
            DoorAccess = doorAccess;
        }
        
        public int BadgeNumber { get; set; }
        public List<string> DoorAccess { get; set; }

    }
}
