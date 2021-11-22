using _03_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    class ProgramUI
    {
        //new repo
        private BadgeRepository _badgesRepo = new BadgeRepository();
        public void Run()
        {
            BeginnerBadges();
            BadgesMenu();
        }

        private void BadgesMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. List all Badges\n" +
                    "3. Edit a badge\n" +
                    "4. Exit\n");
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "3":
                        EditBadge();
                        break;
                    case "2":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Good Bye");
                        keepRunning = false;
                        break;
                    
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        
        private void BeginnerBadges()
        {
            List<string> starterDoors = new List<string>() { "A1", "A7" }; 
            Badge Badge = new Badge(12345, starterDoors);
            _badgesRepo.AddBadgeToDictionary(beginnerBadge);

            List<string> secondDoor = new List<string>() { "B4", "U-Exit", "C2", "GR8-Doors" };
            Badge secondStarter = new Badge(6789, secondDoor);
            _badgesRepo.AddBadgeToDictionary(secondStarter);
        }
        //1. Create a new badge
        private void CreateBadge() //1
        {
            Badge badge = new Badge();

            Console.WriteLine("Badge number?");
            int id = int.Parse(Console.ReadLine());
            badge.BadgeID = id; 

            List<string> newDoors = new List<string>();
            bool allDoorsAdded = false;
            while (allDoorsAdded == false)
            {
                Console.WriteLine("List a door it need access to:");
                string door = Console.ReadLine();
                newDoors.Add(door);

                Console.WriteLine("Any other doors(y/n)?");
                string yesNo = Console.ReadLine();
                if (yesNo == "y") { allDoorsAdded = false; }
                else if (yesNo == "n") { allDoorsAdded = true; }
            }
            badge.DoorNames = newDoors;
            _badgesRepo.AddBadgeToDictionary(badge);
        }

        //2. Edit a badge
        private void EditBadge()
        {
            ListAllBadges();
            Console.WriteLine("What is the badge you want to update? Please enter Badge #");
            int input = int.Parse(Console.ReadLine());
            Badge badgeToUpdate = _badgesRepo.GetBadgeByID(input);
            if (badgeToUpdate != null)
            {
                //continue to edit
                string doorsToPrint = ListDoorsToString(badgeToUpdate.DoorNames);
                Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to {doorsToPrint}");
                Console.WriteLine("What would you like to do?\n" +
                //1 to remove door
                    "1. Remove a Door\n" +
                //2 to add door
                    "2. Add a Door\n");

                string doorInput = Console.ReadLine();
                if (doorInput == "1")
                {
                    //REMOVE DOOR
                    Console.WriteLine("Delete which door?");
                    string removeDoor = Console.ReadLine();
                    if (badgeToUpdate.DoorNames.Contains(removeDoor))
                        badgeToUpdate.DoorNames.Remove(removeDoor);
                    else
                        Console.WriteLine("Nope");
                }
                else if (doorInput == "3")
                {
                    // ADD DOOR
                    Console.WriteLine("Door Name");
                    string newDoor = Console.ReadLine();
                    badgeToUpdate.DoorNames.Add(newDoor);
                }
                else
                {
                    Console.WriteLine("wrong input");
                }

            }
            else
            {
                Console.WriteLine("Invalid input...");
            }
            Console.Clear();
            ListAllBadges();


        }

        //3. List all Badges
        private void ListAllBadges()
        {
            Dictionary<int, Badge> currentBadges = _badgesRepo.DisplayAllBadges();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (KeyValuePair<int, Badge> keyValuePair in currentBadges)
            {
                int badgeID = keyValuePair.Key;
                Badge badge = keyValuePair.Value;
                List<string> doors = badge.DoorNames;
                string doorsToPrint = ListDoorsToString(doors);
                
            }
        }

        private static string ListDoorsToString(List<string> doors)
        {
            string doorsPrint = "";
            foreach (string door in doors)
            {
                
            }

            return doorsPrint;
        }
    }
}
