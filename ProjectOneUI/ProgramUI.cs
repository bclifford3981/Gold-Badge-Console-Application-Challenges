using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOneUI
{
    public class ProgramUI
    {
        public void Run()
        {
            StartingMenu();
            RunMenu();
        }

        public void RunMenu()
        {
            bool shutDown = false;
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
                        shutDown = true;
                    default:
                        Console.WriteLine("Please enter a valid selection... \n" +
                            "Press a key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void DisplayFullMenu();
   

    }
}
