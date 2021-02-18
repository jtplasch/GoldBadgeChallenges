using Challenge3.Challenge3Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Challenge3Program
{
    public class Challenge3UI
    {
        private readonly Challenge3Repo _repo = new Challenge3Repo();
        public void Run()
        {
            Seed();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Select what you would like to do:\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        AddBadge();
                        break;
                    case "2":
                        Console.Clear();
                        EditBadge();
                        break;
                    case "3":
                        Console.Clear();
                        ListBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge?");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            List<string> doorlist = new List<string>();
            Console.WriteLine("List a door that it needs access to:\n");
            doorlist.Add(Console.ReadLine());
            bool addAnother = true;
            while (addAnother)
            {
                Console.WriteLine("Any other doors? Y/N:");
                char response = Console.ReadKey().KeyChar;

                if (response == 'y')
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("List a door it needs access to:");
                    doorlist.Add(Console.ReadLine());
                    Console.Clear();
                }
                else
                {
                    addAnother = false;
                }
            }

            Challenge3Badges newBadge = new Challenge3Badges(badgeNumber, doorlist);
            _repo.AddBadgeToDictionary(newBadge);
        }

        public void DeleteDoor(int badgeNumber)
        {
            Console.WriteLine("What door would you like removed?");
            string doorDeleted = Console.ReadLine();

            _repo.DeleteDoorFromBadge(badgeNumber, doorDeleted);
        }

        public void DeleteAllDoors(int badgeNumber)
        {
            Console.WriteLine($"Would you like to remove all doors for badge {badgeNumber}? (y/n)");
            char input = Console.ReadKey().KeyChar;
            if (input == 'y')
            {
                Console.WriteLine("\n");
                _repo.DeleteAllDoorsFromBadge(badgeNumber);
                Console.WriteLine("All doors have been removed from this badge.");
                Console.ReadKey();
            }
            else
            {
                EditBadge();
            }
        }

        public void AddDoor(int badgeNumber)
        {
            Dictionary<int, List<string>> badgeDictionary = _repo.ShowBadges();
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                if (badge.Key == badgeNumber)
                {
                    Console.WriteLine("Which door would you like to add?");
                    string newDoor = Console.ReadLine();
                    badge.Value.Add(newDoor);
                }

            }
        }

        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            int badgeNumberEdit = Convert.ToInt32(Console.ReadLine());
            List<string> currentDoors = _repo.ShowBadges()[badgeNumberEdit];
            string doorString = string.Join(",", currentDoors);

            Console.WriteLine($"{badgeNumberEdit} has access to the following doors: {doorString}");
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n");
            string edit = Console.ReadLine();
            switch (edit)
            {
                case "1":
                    DeleteDoor(badgeNumberEdit);
                    break;
                case "2":
                    AddDoor(badgeNumberEdit);
                    break;
                default:
                    break;
            }
        }

        public void ListBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeList = _repo.ShowBadges();
            foreach (int badgeNumber in badgeList.Keys)
            {
                string doors = string.Join(",", badgeList[badgeNumber]);
                Console.WriteLine($"Badge ID: {badgeNumber}\tDoor Access: {doors}");
            }
            Console.WriteLine("Press a button to continue");
            Console.ReadKey();
        }

        public void Seed()
        { 
            Challenge3Badges badgeOne = new Challenge3Badges(12345, new List<string> { "A7" });
            Challenge3Badges badgeTwo = new Challenge3Badges(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Challenge3Badges badgeThree = new Challenge3Badges(32345, new List<string> { "A4", "A5" });

            _repo.AddBadgeToDictionary(badgeOne);
            _repo.AddBadgeToDictionary(badgeTwo);
            _repo.AddBadgeToDictionary(badgeThree);
        } 
    }
}
