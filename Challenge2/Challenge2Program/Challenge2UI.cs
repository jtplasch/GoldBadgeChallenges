using Challenge2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    public class Challenge2UI
    {
        private Challenge2Repo _repo = new Challenge2Repo();
        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a Menu Item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "0. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        _repo.ShowClaims();
                        Console.ReadKey();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddClaim();
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Error, try again");
                        break;
                }
            }
        }

        public void NextClaim()
        {
            Challenge2Claims nextClaim = _repo.GetClaims()[0];
            Console.Clear();
            Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
                $"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n +" +
                $"Amount: {nextClaim.ClaimAmount}\n +" +
                $"Date of Accident: {nextClaim.DateofAccident.ToShortDateString()}\n" +
                $"Date of Claim: {nextClaim.DateofClaim.ToShortDateString()}\n" +
                $"IsValid: {nextClaim.IsValid}\n");
            bool validSelection = false;
            while (!validSelection)
            {
                Console.WriteLine("Do you want to deal with this claim now? (y/n)");
                string input = Console.ReadLine();
                if(input == "y")
                {
                    _repo.DeleteClaim(nextClaim);
                    validSelection = true;
                }
                else if (input == "n")
                {
                    validSelection = true;
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
        }

        public void AddClaim()
        {
            Console.Clear();
            Challenge2Claims claim = new Challenge2Claims();
            bool validAccidentDate = false;
            bool validClaimDate = false;
            bool validID = false;
            int id;
            while (!validID)
            {
                Console.WriteLine("Enter the claim id: ");
                if(int.TryParse(Console.ReadLine(), out id))
                {
                    claim.ClaimID = id;
                    validID = true;
                }
            }

            List<int> validTypes = new List<int> { 1, 2, 3 };
            int typeSelection = -1;
            while (!validTypes.Contains(typeSelection))
            {
                Console.WriteLine($"Enter the Claim Type: Enter 1 for {ClaimType.Car}, 2 for {ClaimType.Home}," + $"3 for{ClaimType.Theft}:");
                int.TryParse(Console.ReadLine(), out typeSelection);
            }
            claim.ClaimType = (ClaimType)typeSelection;
            Console.WriteLine("\nEnter a claim description: " );
            claim.Description = Console.ReadLine();
            bool validAmount = false;
            decimal amount;
            while (!validAmount)
            {
                Console.WriteLine("\nEnter Amount of Damage: ");
                if(decimal.TryParse(Console.ReadLine(), out amount))
                {
                    claim.ClaimAmount = amount;
                    validAmount = true;
                }
            }

            while (!validAccidentDate)
            {
                Console.WriteLine("\n Enter date of incident in yyyy-mm-dd: ");
                string dateInput = Console.ReadLine();
                DateTime dateofAccident;
                if (DateTime.TryParse(dateInput,out dateofAccident))
                {
                    claim.DateofAccident = dateofAccident;
                    validAccidentDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please use yyyy-mm-dd");
                }
            }

            while (!validClaimDate)
            {
                Console.WriteLine("\nEnter Claim Date in yyyy-mm-dd:");
                string dateInput = Console.ReadLine();
                DateTime dateofClaim;
                if(DateTime.TryParse(dateInput, out dateofClaim))
                {
                    claim.DateofClaim = dateofClaim;
                    validClaimDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please use yyyy-mm-dd");
                }
            }
            Console.WriteLine($"\nThis claim is: " + $"{(claim.IsValid? "Valid" : "Not Valid")}");
            Console.ReadKey();
        }
        public void Seed()
        {
            Challenge2Claims claim1 = new Challenge2Claims(1, ClaimType.Car, "Car accident on 465 ", 400m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _repo.AddClaim(claim1);
            Challenge2Claims claim2 = new Challenge2Claims(2, ClaimType.Home, "House fire in kitchen", 4000m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            _repo.AddClaim(claim2);
            Challenge2Claims claim3 = new Challenge2Claims(3, ClaimType.Theft, "Stolen pancakes", 4m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            _repo.AddClaim(claim3);
        }
    }
}
