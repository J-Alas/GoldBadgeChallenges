using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class BadgeRepository
    {  
        Dictionary<int, Badge> _badges = new Dictionary<int, Badge>() { };
        public void AddBadgeToDictionary(Badge badge)
        {
            _badges.Add(badge.BadgeID, badge); 
        }
        public Dictionary<int, Badge> DisplayAllBadges()
        {
            return _badges;
        }
        public Badge GetBadgeByID(int input)
        {
            foreach (KeyValuePair<int, Badge> keyValuePair in _badges)
            {
                Badge badge = keyValuePair.Value;
                if(input == keyValuePair.Key)
                {
                    return badge;
                }

            }
            return null;
        }
    }
}
