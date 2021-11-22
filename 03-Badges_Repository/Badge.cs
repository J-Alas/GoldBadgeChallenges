using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class Badge
    {
        //BadgeID
        public int BadgeID { get; set; }
        //List of door names for access
        public List<string> DoorNames { get; set; }

        public Badge()
        { 
        }
        public Badge(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}
