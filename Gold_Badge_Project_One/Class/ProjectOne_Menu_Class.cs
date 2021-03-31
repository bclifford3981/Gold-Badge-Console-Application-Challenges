using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gold_Badge_Project_One
{
    
    public class ProjectOne_Menu_Class
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngerdients { get; set; }
        public double MealPrice { get; set; }
        public ProjectOne_Menu_Class()
        {

        }
        public ProjectOne_Menu_Class(int mealNum, string mealName, string mealDescription, string mealIngredients, double mealPrice)
        {
            MealNumber = mealNum;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngerdients = mealIngredients;
            MealPrice = mealPrice;
        }
    }
}
