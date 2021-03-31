using System;

namespace _01_Cafe_Repo
{
    public class Cafe_Class
    {   
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngerdients { get; set; }
        public double MealPrice { get; set; }
        public Cafe_Class()
        {

        }
        public Cafe_Class(int mealNum, string mealName, string mealDescription, string mealIngredients, double mealPrice)
        {
            MealNumber = mealNum;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngerdients = mealIngredients;
            MealPrice = mealPrice;
        }
    }
}
