using BadgeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeUI
{
    class ProgramUI
    {
        private readonly BadgeRepository _badgeRepository = new BadgeRepository();
        public void Run()
        {
            SeedBadgeList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1: Add a Badge \n" +
                    "2: Edit a Badge \n" +
                    "3: List all Badges\n" +
                    "4: Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please try again...");
                        Console.ReadKey();
                        break;
                }
                
            }
        }
        private void AddBadge()
        {
            Console.Clear();

            BadgeClass input = new BadgeClass();
            input.DoorAccess = new List<string>();

            Console.WriteLine("Enter Badge ID number:");
            input.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the door the badge can access:");
            string access = Console.ReadLine();

            int beginCount = input.DoorAccess.Count;
            input.DoorAccess.Add(access);
            int endCount = input.DoorAccess.Count;

            if (beginCount < endCount)
            {
                Console.WriteLine("door was added.");
            }
            else
            {
                Console.WriteLine("error not added.");
            }

            Console.WriteLine("Add another door (y/n)?");
            string YNinput = Console.ReadLine().ToLower();
            while (YNinput == "y") 
            {
                Console.WriteLine("Add another door:");
                input.DoorAccess.Add(Console.ReadLine());

                Console.WriteLine("Add another door (y/n)?");
                YNinput = Console.ReadLine().ToLower();
            } 
            _badgeRepository.AddNewBadgeToDict(input);
            RunMenu();
        }
        public void UpdateBadge()
        {
            BadgeClass input = new BadgeClass();
            input.DoorAccess = new List<string>();

            Console.Clear();

            Console.WriteLine("Enter the badge number to update:");
            input.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine($"Choose category of {input.BadgeID} to Update: \n"+
                $"1: Add access to a door \n"+
                $"2: Remove access to a door \n"+
                $"3: Exit 'Edit a Badge'");
            string caseInput = Console.ReadLine();
            switch (caseInput)
            {
                case "1":
                    AddDoor(input.BadgeID);
                    break;
                case "2":
                    RemoveDoor(input.BadgeID);
                    break;
                case "3":
                    RunMenu();
                    break;
            }
        }
        public void AddDoor(int badgeid)
        {
            Console.WriteLine("Enter the door:");
            string input = Console.ReadLine();
            _badgeRepository.UpdateAccessList(badgeid, input);

            Console.WriteLine($"Access to {input} added for {badgeid}");
            Console.ReadKey();
        }
        public void RemoveDoor(int badgeid)
        {
            Console.WriteLine("Enter the door to remove:");
            string input = Console.ReadLine();
            _badgeRepository.DeleteAccessFromList(badgeid, input);

            Console.WriteLine($"Access to {input} removed for {badgeid}");
            Console.ReadKey();
        }
        public void ListAllBadges()
        {
            Dictionary<int, List<string>> badgeList = _badgeRepository.ReturnFullList();

            foreach (KeyValuePair<int, List<string>> badge in badgeList)
            {
                Console.WriteLine($"Badge: {badge.Key}");

                foreach (string door in badge.Value)        
                {
                    Console.WriteLine(door);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public void SeedBadgeList()
        {
            BadgeClass badgeOne = new BadgeClass(123456, new List<string>() { "A1", "A2" });
            BadgeClass badgeTwo = new BadgeClass(234567, new List<string>() { "B1", "B2" });

            _badgeRepository.AddNewBadgeToDict(badgeOne);
            _badgeRepository.AddNewBadgeToDict(badgeTwo);
        }
    }
}
