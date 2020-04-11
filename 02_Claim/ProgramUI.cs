using _02_Claim.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{
    public class ProgramUI : IProgramUI
    {
        private readonly ClaimRepo _repo = new ClaimRepo();

        public void Run()
        {
            SeedClaims();
            MainMenu();
        }
        public void SeedClaims()
        {
            Claim claimOne = new Claim(1, ClaimType.Car, "Hit a horse and exploded", 25000.11234, new DateTime(2011, 11, 21), new DateTime(2020, 3, 19));
            Claim claimTwo = new Claim(2, ClaimType.Home, "Horse exploded and blew out my windows", 350.285678, new DateTime(2011, 11, 21), new DateTime(2011, 11, 30));
            Claim claimThree = new Claim(3, ClaimType.Theft, "Someone stole my horse and car for nefarious reasons", 20000.37466, new DateTime(2011, 10, 30), new DateTime(2011, 11, 21));

            _repo.CreateNewClaim(claimOne);
            _repo.CreateNewClaim(claimTwo);
            _repo.CreateNewClaim(claimThree);
        }

        public void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Select an option below:\n" +
                    "1. See all Claims\n" +
                    "2. Take care of next Claim\n" +
                    "3. Enter a new Claim\n" +
                    "4. Exit");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response");
                        break;
                }
            }
        }

        public void NewClaim()
        {
            Claim newClaim = new Claim();

            Console.WriteLine("Enter the Claim Id:");
            newClaim.ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the type of claim from the options below:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeResponse = Console.ReadLine();
            switch (typeResponse)
            {
                case "1":
                    newClaim.Type = ClaimType.Car;
                    break;
                case "2":
                    newClaim.Type = ClaimType.Home;
                    break;
                case "3":
                    newClaim.Type = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            Console.WriteLine("Enter a description of the accident:");
            string description = Console.ReadLine();
            newClaim.Description = description;

            Console.WriteLine("Enter the total cost for the Claim:");
            newClaim.Amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the date of the accident, by entering the Year, the Month, and the Day, pressing enter between each:");
            int year = Convert.ToInt32(Console.ReadLine());
            int month = Convert.ToInt32(Console.ReadLine());
            int day = Convert.ToInt32(Console.ReadLine());
            newClaim.DateOfIncident = new DateTime(year, month, day);

            newClaim.DateOfClaim = DateTime.Now;

            _repo.CreateNewClaim(newClaim);
        }

        public void NextClaim()
        {
            Claim nextClaim = _repo.GetNextClaim();
            if (nextClaim != null)
            {
                Console.WriteLine($"Here are the details for the next Claim to be Handled:\n" +
                    $"ClaimID: {nextClaim.ID}\n" +
                    $"Type: {nextClaim.Type}\n" +
                    $"Description: {nextClaim.Description}\n" +
                    $"Amount: ${_repo.RoundDoubleForDisplay(nextClaim.Amount)}\n" +
                    $"DateOfAccident: {nextClaim.DateOfIncident}\n" +
                    $"DateOfClaim: {nextClaim.DateOfClaim}\n" +
                    $"IsValid: {nextClaim.IsValid}\n");
                Console.WriteLine("Do you want to deal with this claim now? (y/n)");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    _repo.DeleteNextClaim();
                }
            }
            else
            {
                Console.WriteLine("No more claims!");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void SeeAllClaims()
        {
            List<Claim> tempList = _repo.GetAllClaims();
            if (tempList.Count > 0)
            {
                Console.WriteLine($"{"ClaimID",-10} {"Type",-15} {"Description",-55} {"Amount",-15} {"DateOfAccident",-15} {"DateOfClaim",-15} {"IsValid",-15}");
                foreach (Claim claim in tempList)
                {
                    Console.WriteLine($"{claim.ID,-10} {claim.Type,-15} {claim.Description,-55} ${_repo.RoundDoubleForDisplay(claim.Amount),-15} {claim.DateOfIncident.ToShortDateString(),-15} {claim.DateOfClaim.ToShortDateString(),-15} {claim.IsValid,-15}");
                }
            }
            else
            {
                Console.WriteLine("No more claims!");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
