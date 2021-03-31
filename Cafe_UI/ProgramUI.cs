using CafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_UI
{
    public class ProgramUI
    {
        private readonly Cafe_Repo cafe_Classes = new Cafe_Repo();
        public void Run()
        {
            StartingMenu();
            RunMenu();
        }



        public void RunMenu()
        {
            bool shutDown = true;
            while (shutDown)
            {
                Console.Clear();
                Console.WriteLine("Enter a number listed and press enter: \n" +
                    "1: Show Menu Items... \n" +
                    "2: Add Menu Item... \n" +
                    "3: Delete Menu Item... \n" +
                    "4: Exit Menu");
                string userEntry = Console.ReadLine();

                switch (userEntry)
                {
                    case "1":
                        DisplayFullMenu();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        RemoveMenuItem();
                        break;
                    case "4":
                        shutDown = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection... \n" +
                            "Press a key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void DisplayFullMenu()
        {
            Console.Clear();

            List<MenuItem> cafe = cafe_Classes.ReadMenu();
            foreach (MenuItem meal in cafe)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber} \n" +
                    $"Meal Name: {meal.MealName} \n" +
                    $"Meal Description: {meal.MealDescription} \n" +
                    $"Meal Ingredients: {meal.MealIngerdients} \n" +
                    $"Meal Price: {meal.MealPrice} \n");
            }
            Console.WriteLine("Press Key to Return...");
            Console.ReadKey();
        }
        private void AddMenuItem()
        {
            Console.Clear();
            MenuItem cafe = new MenuItem();
            Console.WriteLine("Enter meal number:");
            cafe.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter meal name:");
            cafe.MealName = Console.ReadLine();
            Console.WriteLine("Enter meal description:");
            cafe.MealDescription = Console.ReadLine();
            Console.WriteLine("Enter meal ingredients:");
            cafe.MealIngerdients = Console.ReadLine();
            Console.WriteLine("Enter meal price:");
            cafe.MealPrice = double.Parse(Console.ReadLine());
            cafe_Classes.AddMenuItem(cafe);

        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the meal number you want to delete:");
            int userInputMenuItemID = int.Parse(Console.ReadLine());
            MenuItem itemToDelete = cafe_Classes.ReadMenuByItemNumber(userInputMenuItemID);

            if (itemToDelete == null)
            {
                Console.WriteLine($"User with {userInputMenuItemID} doesn't exist...");
            }
            else
            {
                bool isSuccessful = cafe_Classes.DeleteMenuItem(itemToDelete);
                if (isSuccessful)
                {
                    Console.WriteLine($"Deleted {userInputMenuItemID}");
                }
                else
                {
                    Console.WriteLine("Delete Failed...");
                }
            }
            Console.WriteLine("Press a key to return...");
            Console.ReadKey();
        }
        private void StartingMenu()
        {
            MenuItem aasdf = new MenuItem(1123, "asdfa", "asdfas", "asdf", 12.96);
            cafe_Classes.AddMenuItem(aasdf);
        }

    }

}
