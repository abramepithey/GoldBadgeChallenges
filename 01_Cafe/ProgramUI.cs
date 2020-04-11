using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    class ProgramUI
    {
        private readonly MenuItemRepo _repo = new MenuItemRepo();

        public void SeedMenuItems()
        {
            List<string> ingredientsOne = new List<string>() { "water", "wheat", "egg", "salt" };
            List<string> ingredientsTwo = new List<string>() { "macaroni", "cheese", "milk", "salt", "water" };
            List<string> ingredientsThree = new List<string>() { "peanut butter", "jelly", "bread" };

            MenuItem itemOne = new MenuItem(1, "spaghett", "tasty italian", ingredientsOne, 12.6742);
            MenuItem itemTwo = new MenuItem(2, "Mac and Cheese", "Cheesy goodness", ingredientsTwo, 9.0874);
            MenuItem itemThree = new MenuItem(3, "PB&J", "classic", ingredientsThree, 6.62945);

            _repo.AddMenuItem(itemOne);
            _repo.AddMenuItem(itemTwo);
            _repo.AddMenuItem(itemThree);
        }

        public void Run()
        {
            SeedMenuItems();
            MainMenu();
        }

        public void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:\n" +
                    "1. Show all meals\n" +
                    "2. Add a meal\n" +
                    "3. Erase a meal\n" +
                    "4. Exit");
                string userResponse = Console.ReadLine().ToLower();
                switch (userResponse)
                {
                    case "1":
                        ShowAllMenuItems();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Goodbye!\n" +
                            "Press any key to close...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        break;
                }
            }
        }

        public void ShowAllMenuItems()
        {
            List<MenuItem> items = _repo.ListAllMenuItems();
            foreach (MenuItem item in items)
            {
                Console.WriteLine($"{item.MealNumber}. {item.MealName} - ${item.MealPrice}");
            }
            Console.ReadLine();
        }

        public void AddMenuItem()
        {
            int itemNumber = _repo.MenuItemNumber();

            Console.WriteLine("Enter a name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter a description:");
            string description = Console.ReadLine();

            List<string> ingredients = new List<string>();
            bool enteringIngredients = true;
            Console.WriteLine("Enter each ingredient and press enter, and then enter 'done' to move on:");
            while (enteringIngredients)
            {
                string ingredient = Console.ReadLine();
                if (ingredient == "done")
                {
                    enteringIngredients = false;
                }
                else
                {
                    ingredients.Add(ingredient);
                }
            }

            Console.WriteLine("Enter the digit price:");
            double price = Convert.ToDouble(Console.ReadLine());
            double roundedPrice = Math.Round(price, 2, MidpointRounding.AwayFromZero);

            MenuItem item = new MenuItem(itemNumber, name, description, ingredients, roundedPrice);
            _repo.AddMenuItem(item);
        }

        public void DeleteMenuItem()
        {
            Console.WriteLine("Enter the name of the Menu Item you would like to delete:");
            string response = Console.ReadLine().ToLower();
            _repo.DeleteMenuItemByName(response);
        }
    }
}
