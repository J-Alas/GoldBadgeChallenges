using _02_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    public class ProgramUI
    {
        private ClaimsRepository _claimRepo = new ClaimsRepository();
        public void Run()
        {
            NewClaims();
            ClaimsMenu();
        }
        private void ClaimsMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Hello, Bill\n" +
                    "Select on option from below? \n" +
                    "1. See all claims \n" +
                    "2. Next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit Claims App");

                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        HandleAClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Thanks for wasting my time");
                        isRunning = false;
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void NewClaims()
        {
            Claim claim2 = new Claim(2, Claim.Type.Stolen, "Gnome was taken by hoodlums", 1.00, new DateTime(2020, 10, 01), new DateTime(2021, 10, 03));
            _claimRepo.AddNewClaim(claim2);
            Claim claim1 = new Claim(1, Claim.Type.Vehicle, "Yamaha R1", 1000000.00, new DateTime(2020, 12, 18), new DateTime(2020, 12, 20));
            _claimRepo.AddNewClaim(claim1);
            Claim claim3 = new Claim(3, Claim.Type.Home, "House was stolen by a Magician", 6.00, new DateTime(2019, 01, 01), new DateTime(2019, 01, 04));
        }

        //1
        private void SeeAllClaims()
        {
            Queue<Claim> currentClaims = _claimRepo.DisplayCurrentClaims();
            foreach (Claim claim in currentClaims)
            {
                Console.WriteLine("ID\tType\tDescription\t\tAmount\tDateOfIncident\t\tDateOfClaim\t\tIsValid\n" +
                    $"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}\t${claim.Amount}\t{claim.DateOfIncident}\t{claim.DateOfClaim}\t{claim.IsValid}\n");
            }
        }

        //2
        private void HandleAClaim()
        {
            Claim firstClaim = _claimRepo.DisplayCurrentClaims().Peek();
            Console.WriteLine("ID\tType\tDescription\t\tAmount\tDateOfIncident\t\tDateOfClaim\t\tIsValid\n" +
                $"{firstClaim.ClaimID}\t{firstClaim.ClaimType}\t{firstClaim.Description}\t${firstClaim.Amount}\t{firstClaim.DateOfIncident}\t{firstClaim.DateOfClaim}\t{firstClaim.IsValid}\n");
            Console.WriteLine("Do you want to handle this claim? y/n");
            string input = Console.ReadLine();

            // if yes, 
            if (input == "y")
            {
                _claimRepo.HandleAClaim(firstClaim.ClaimID);
            }
            else if (input != "n")
            {
                Console.WriteLine("Please enter a valid selection. Try again.");
            }
        }
        private void EnterNewClaim() //3
        {
            
            // set claim id
            Console.WriteLine("Please enter the claim id: ");
            int id = int.Parse(Console.ReadLine());

            // set type
            Console.WriteLine("Please enter the type of claim (Car, Home, Theft): ");
            string typeInput = Console.ReadLine();
            Claim.Type type =
                typeInput == "Car" ? Claim.Type.Vehicle : 
                typeInput == "Home" ? Claim.Type.Home :
                typeInput == "Stolen" ? Claim.Type.Stolen :
                Claim.Type.Vehicle;

            // set description
            Console.WriteLine("Please enter the description of claim: ");
            string description = Console.ReadLine();

            // set amount
            Console.WriteLine("Please enter the amount of claim: ");
            double amount = double.Parse(Console.ReadLine());

            // date of incident
            Console.WriteLine("Please enter the date of the incident (mm/dd/yyyy): ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            // date of claim
            Console.WriteLine("Please enter the date of claim (mm/dd/yyyy): ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            
            Claim claim = new Claim(id, type, description, amount, dateOfIncident, dateOfClaim);
          
            _claimRepo.AddNewClaim(claim);

        }

    }
}
