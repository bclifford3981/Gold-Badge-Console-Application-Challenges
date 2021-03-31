using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepo
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _accessDict = new Dictionary<int, List<string>>();

        //  Create
        public void AddNewBadgeToDict(BadgeClass badge)
        {
            _accessDict.Add(badge.BadgeID, badge.DoorAccess);
        }
        //  Read
        public Dictionary<int, List<string>> ReturnFullList()
        {
            return _accessDict;
        }
        //  Update
        public bool UpdateAccessList(int badgeID, string DoorAccess)
        {
            List<string> listOfDoors = _accessDict[badgeID];

            int doorNumber = listOfDoors.Count;
            listOfDoors.Add(DoorAccess);
            int listOfDoorNumber = listOfDoors.Count;

            if (listOfDoorNumber > doorNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete
        public bool DeleteAccessFromList(int BadgeID, string DoorAccess)
        {
            List<string> listofDoors = _accessDict[BadgeID];

            int doorNumber = listofDoors.Count;
            listofDoors.Remove(DoorAccess);
            int listofDoorsNumber = listofDoors.Count;

            if (listofDoorsNumber < doorNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
