using Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsUI
{
    public class ProgramUI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the menu you wish to access and press 'enter': \n" +
                    "1: Show All Claims\n" +
                    "2: Take Care of Next Claim\n" +
                    "3: Enter a New Claim\n" +
                    "4: Exit...");
                string promptinput = Console.ReadLine();

                switch (promptinput)
                {
                    case "1":
                        ReadFullQueue();
                        break;
                    case "2":
                        PeakNextClaimInQueue();
                        break;
                    case "3":
                        AddItemsToQueue();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, not a valid please try again... \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddItemsToQueue()
        {
            Console.Clear();

            ClaimQueue claimqueue = new ClaimQueue();
            Console.WriteLine("Page: Add New Claim");

            Console.WriteLine("Enter type of claim: \n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    claimqueue.TypeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    claimqueue.TypeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    claimqueue.TypeOfClaim = ClaimType.Theft;
                    break;
            }
            Console.WriteLine("Enter claim description:");
            claimqueue.ClaimDescription = Console.ReadLine();
            Console.WriteLine("Enter claim amount (example: 2200.99):");
            claimqueue.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the incident date in the format: month/day/year");
            string incidentDate = Console.ReadLine();
            DateTime incidentPass = DateTime.Parse(incidentDate);
            claimqueue.DateOfIncident = incidentPass;
            Console.WriteLine("Enter the claim creation date format: month/day/year");
            string claimDate = Console.ReadLine();
            DateTime claimDatePass = DateTime.Parse(claimDate);
            claimqueue.DateOfClaim = claimDatePass;
            _claimsRepo.AddItemsToQueue(claimqueue);
        }

        private void PeakNextClaimInQueue()
        {
            ClaimQueue claim = _claimsRepo.PeakNextClaimInQueue();
            if (claim == null)
            {
                Console.WriteLine("No available claims");
            }
            else
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID} \n" +
                $"Type of Claim: {claim.TypeOfClaim} \n" +
                $"Claim Description: {claim.ClaimDescription}\n" +
                $"Claim Amount: {claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident.Date}\n" +
                $"Date of Claim: {claim.DateOfClaim.Date}\n" +
                $"Claim is Valid: {claim.IsValid}");

                Console.WriteLine("Do you want to deal with this y or n ?");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "y")
                {
                    _claimsRepo.ProcessClaim();
                }
                else
                {
                    RunMenu();
                }
            }
            Console.ReadKey();
        }

        private void ReadFullQueue()
        {
            Console.Clear();

            Queue<ClaimQueue> listOfClaims = _claimsRepo.ReadFullQueue();
            foreach (ClaimQueue claim in listOfClaims)
            {
               Console.WriteLine($"Claim ID: {claim.ClaimID} \n" +
                $"Type of Claim: {claim.TypeOfClaim} \n" +
                $"Claim Description: {claim.ClaimDescription}\n" +
                $"Claim Amount: {claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident.Date}\n" +
                $"Date of Claim: {claim.DateOfClaim.Date}\n" +
                $"Claim is Valid: {claim.IsValid}");
            }
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();

        }
        private void SeedClaimList()
        {
            ClaimQueue thisone = new ClaimQueue(ClaimType.Car, "no tires", 2000.20, new DateTime(2000, 12, 2), new DateTime(2000, 12, 20));

            _claimsRepo.AddItemsToQueue(thisone);
        }
    }
}
