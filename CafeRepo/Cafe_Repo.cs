using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class Cafe_Repo
    {
        public List<MenuItem> cafe_Classes = new List<MenuItem>();

        //Create
        public bool AddMenuItem(MenuItem MenuRepo)
        {
            int starting = cafe_Classes.Count;
            cafe_Classes.Add(MenuRepo);
            bool Confirm = (cafe_Classes.Count > starting) ? true : false;
            return Confirm;
        }
        //Read
        public List<MenuItem> ReadMenu()
        {
            return cafe_Classes;
        }
        //Read by item Number
        public MenuItem ReadMenuByItemNumber(int item)
        {
            foreach (MenuItem cafe in cafe_Classes)
            {
                if (cafe.MealNumber == item)
                {
                    return cafe;
                }
            }
            return null;
        }
        //Delete
        public bool DeleteMenuItem(MenuItem desired)
        {
            foreach (var mItem in cafe_Classes)
            {
                if (mItem.MealNumber == desired.MealNumber)
                {
                    cafe_Classes.Remove(mItem);
                    return true;
                }
                
            }
            return false;
        }
    }
}
