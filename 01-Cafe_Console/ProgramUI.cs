using _01_Restaurant_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Restaurant_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            Cafe();
        }
        private void Cafe()
        {
            bool isRunning = true;
            while (isRunning)
            {

                Console.WriteLine("Menu Editor\n" +
                    "What would you like to do? \n" +
                    "1. Browse menu \n" +
                    "2. Add a new (item) \n" +
                    "3. Delete (item) \n" +
                    "4. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": //Look at the menu
                        DisplayMenu();
                        break;
                    case "2": //Add
                        CreateNewItem();
                        break;
                    case "3": //Delete
                        DeleteMenuItem();
                        break;
                    case "4": //Exit Menu Editor
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Enter number");
                        break;

                }

                Console.WriteLine("Click any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        //Read
        private void DisplayMenu()
        {
            Console.Clear();

            List<Menu> listOfitems = _menuRepo.AllItems();

            foreach (Menu menu in listOfitems)
            {
                string itemPrint = $"#{menu.MealNumber} {menu.MealName}      ${menu.Price}\n" +
                    $"{menu.Description}\n" +
                    $"Ingredients:";

                foreach (string ingredient in menu.Ingredients)
                {
                    itemPrint += "\n" + ingredient;
                }
                Console.WriteLine(itemPrint);
            }
        }

        //Creat


        private void CreateNewItem()
        {
            Console.Clear();

            Menu newMenu = new Menu();

           
            Console.WriteLine("Enter meal number");

            newMenu.MealNumber = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Enter meal name");
            newMenu.MealName = Console.ReadLine();

            
            Console.WriteLine("Enter meal desciption");
            newMenu.Description = Console.ReadLine();

           
            List<string> newIngredients = new List<string>();
            bool ingredientsAdded = false;
            while (ingredientsAdded == false)
            {
                Console.WriteLine("Enter ingredients");
                string newIngredient = Console.ReadLine();
                newIngredients.Add(newIngredient);
            }
            newMenu.Ingredients = newIngredients;

            
            Console.WriteLine("Enter a price");
            newMenu.Price = double.Parse(Console.ReadLine());

            _menuRepo.AddItem(newMenu);

        }

        //Delete
        //allow user to be able to delete by selection
        //output some type of response when action is submitted

        private void DeleteMenuItem()
        {
            DisplayMenu();
            Console.WriteLine("What do you want to delete?");
            string input = Console.ReadLine();
            bool wasDeleted = _menuRepo.RemoveItem(input);
            if (wasDeleted)
            {
                Console.WriteLine("Good job this item was terrible anyway!");
                Console.WriteLine("Item deleted");
            }
            else
            {
                Console.WriteLine("Could not delete");
                Console.WriteLine("Did you fat finger key or something?");
            }
        }
        


    }
}
