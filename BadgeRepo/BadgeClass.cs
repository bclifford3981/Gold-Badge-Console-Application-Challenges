using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepo
{
    public class BadgeClass
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }
        public BadgeClass()
        {

        }
        public BadgeClass(int badgeid, List<string> dooraccess)
        {
            BadgeID = badgeid;
            DoorAccess = dooraccess;
        }
    }
}
