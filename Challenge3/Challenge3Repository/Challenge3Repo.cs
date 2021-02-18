using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Challenge3Repository
{
    public class Challenge3Repo
    {
        protected  Dictionary<int, List<string>> _repo = new Dictionary<int, List<string>>();

        public bool AddBadgeToDictionary(Challenge3Badges badges)
        {
            Dictionary<int, List<string>> dictionary = ShowBadges();
            int badgeNumber = badges.BadgeNumber;
            List<string> doors = badges.DoorAccess;

            int badgeCount = _repo.Count();
            dictionary.Add(badgeNumber, doors);
            bool checkAdded = badgeCount + 1 == _repo.Count();
            return checkAdded;
        }
        public Dictionary<int, List<string>> ShowBadges()
        {
            return _repo;
        }

        public List<string> PullBadgeByNumber(int badgeNumber)
        {
            List<string> doors;
            if(_repo.TryGetValue(badgeNumber, out doors))
            {
                return doors;
            }
            return null;
        }

        public void EditBadge(int badgeNumber, string newDoor)
        {
            foreach(int id in _repo.Keys)
            {
                if(badgeNumber == id)
                {
                    _repo[id].Add(newDoor);
                }
            }
        }

        public void DeleteDoorFromBadge(int badgeNumber, string door)
        {
            foreach(int idNumber in _repo.Keys)
            {
                if(badgeNumber == idNumber)
                {
                    List<string> doors = _repo[idNumber];
                    doors.Remove(door);
                }
            }
        }

        public void DeleteAllDoorsFromBadge(int badgeNumber)
        {
            foreach(int idNumber in _repo.Keys)
            {
                if(badgeNumber == idNumber)
                {
                    List<string> doors = _repo[idNumber];
                    doors.Clear();
                } 
            }
        }




    }
}
