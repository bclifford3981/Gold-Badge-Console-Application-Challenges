using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngerdients { get; set; }
        public double MealPrice { get; set; }
        public MenuItem()
        {

        }
        public MenuItem(int mealNum, string mealName, string mealDescription, string mealIngredients, double mealPrice)
        {
            MealNumber = mealNum;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngerdients = mealIngredients;
            MealPrice = mealPrice;
        }
    }
}
