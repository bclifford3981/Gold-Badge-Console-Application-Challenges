using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repo
{
    public class Cafe_Repo
    {

        protected readonly List<Cafe_Class> cafe_Classes = new List<Cafe_Class>();

        //Create
        public bool AddMenuItem(Cafe_Class MenuRepo)
        {
            int starting = cafe_Classes.Count;
            cafe_Classes.Add(MenuRepo);
            bool Confirm = (cafe_Classes.Count > starting) ? true : false;
            return Confirm;
        }
        //Read
        public List<Cafe_Class> ReadMenu()
        {
            return cafe_Classes;
        }
        //Delete
        public bool DeleteMenuItem(Cafe_Class desired)
        {
            bool killed = cafe_Classes.Remove(desired);
            return killed;
        }
    }
}

