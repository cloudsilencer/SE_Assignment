using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>();
            List<SetMenu> setMenus = new List<SetMenu>();
            List<ItemMenu> itemMenus = new List<ItemMenu>();
            InitializeData();
            // ManageItemMenu();

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Login as Customer");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();
            Console.WriteLine("1. Create a new Order");
            string choice = Console.ReadLine();

            var numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(7);
            List<ItemMenu> foodList = new List<ItemMenu>();
            foodList.Add(new ItemMenu("Food 1", "", 1, 2, "", 2, new Category(1, ""), new SetMenu(1, "")));
            foodList.Add(new ItemMenu("Food 2", "", 1, 2, "", 2, new Category(2, ""), new SetMenu(2, "")));

            Console.WriteLine("Available Item");
            //Display food items
            foreach (ItemMenu food in foodList)
            {
                Console.WriteLine(food.getName());
            }
               
            string foodchoice = Console.ReadLine();
            int orderNo = 1;
            Order newOrder = new Order(orderNo.ToString(), DateTime.Now);
            newOrder


            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 

            // Initialize Data Function
            void InitializeData()
            {
                Category category1 = new Category(1, "Chicken");
                Category category2 = new Category(2, "Fish");
                Category category3 = new Category(3, "Beef");
                Category category4 = new Category(4, "Others");
                categories.Add(category1);
                categories.Add(category2);
                categories.Add(category3);
                categories.Add(category4);

                SetMenu breakfastSetMenu = new SetMenu(1, "Breakfast");
                SetMenu lunchSetMenu = new SetMenu(2, "Lunch");
                SetMenu dinnerSetMenu = new SetMenu(3, "Dinner");
                setMenus.Add(breakfastSetMenu);
                setMenus.Add(lunchSetMenu);
                setMenus.Add(dinnerSetMenu);

                ItemMenu itemMenu1 = new ItemMenu("French Toast", "Sliced bread soaked in eggs and milk, then fried.", 3.00, 1, "Available", 1, category4, breakfastSetMenu);
                ItemMenu itemMenu2 = new ItemMenu("Grilled Chicken Sandwich", "Juicy grilled chicken wrapped within 2 slices of bread.", 5.60, 1, "Available", 1, category1, breakfastSetMenu);
                ItemMenu itemMenu3 = new ItemMenu("Fish Congee", "Congee with red grouper slices", 5.80, 1, "Available", 1, category1, breakfastSetMenu);
                ItemMenu itemMenu4 = new ItemMenu("Chicken Wrap", "Tortilla wrap with bits of chicken", 12.00, 1, "Available", 1, category1, breakfastSetMenu);
                ItemMenu itemMenu5 = new ItemMenu("Signature Southern Style Fried Chicken", "The taste of Texas", 12.90, 1, "Available", 1, category1, lunchSetMenu);
                ItemMenu itemMenu6 = new ItemMenu("Steak with baked potatoes", "Sirloin steak served with baked potatoes", 17.90, 1, "Available", 1, category3, lunchSetMenu);
                ItemMenu itemMenu7 = new ItemMenu("Poke Bowl", "Diced raw salmon served with salad", 12.60, 1, "Available", 1, category2, lunchSetMenu);
                ItemMenu itemMenu8 = new ItemMenu("Seafood Spaghetti", "Tomato based spaghetti with shrimp and clams", 10.70, 1, "Available", 1, category4, lunchSetMenu);
                ItemMenu itemMenu9 = new ItemMenu("Roasted Chicken with Herbs", "Quarter Roasted Chicken with 2 sides", 14.90, 1, "Available", 1, category1, dinnerSetMenu);
                ItemMenu itemMenu10 = new ItemMenu("Fried Wild Mushrooms", "Wild Mushrooms fresh from Australia", 8.20, 1, "Available", 1, category4, dinnerSetMenu);
                ItemMenu itemMenu11 = new ItemMenu("Beef Stew", "Beef stew with bread", 14.20, 1, "Available", 1, category3, dinnerSetMenu);
                ItemMenu itemMenu12 = new ItemMenu("Fish and Chips", "Fried cod in batter served with chips", 11.90, 1, "Available", 1, category3, dinnerSetMenu);
                itemMenus.Add(itemMenu1);
                itemMenus.Add(itemMenu2);
                itemMenus.Add(itemMenu3);
                itemMenus.Add(itemMenu4);
                itemMenus.Add(itemMenu5);
                itemMenus.Add(itemMenu6);
                itemMenus.Add(itemMenu7);
                itemMenus.Add(itemMenu8);
                itemMenus.Add(itemMenu9);
                itemMenus.Add(itemMenu10);
                itemMenus.Add(itemMenu11);
                itemMenus.Add(itemMenu12);
            }

            // Manager Functions
            void ManageItemMenu()
            {
                string functionTitle = "Manage Item Menu";
                List<String> options = new List<string> { "Add Food Item", "Delete Food Item", "Update Food Item", "Exit"};
                String selectedOption = "";
                do
                {
                    Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}");
                    for (int i = 0; i < options.Count; i++)
                    {
                        if (((i + 1) % 4) == 0)
                            Console.WriteLine($"\n[{(i + 1) % 4}] {options[i]}");
                        else
                            Console.WriteLine($"[{(i + 1) % 4}] {options[i]}");
                    }
                    Console.Write("\nSelect an option: ");
                    selectedOption = Console.ReadLine();
                    Console.WriteLine("");


                    switch (selectedOption)
                    {
                        case "0":
                            Console.WriteLine("Exiting From Manage Item Menu...\n");
                            break;
                        case "1":
                            AddFoodItem();
                            break;
                        case "2":
                            DeleteFoodItem();
                            break;
                        case "3":
                            UpdateFoodItem();
                            break;
                        default:
                            Console.WriteLine("Invalid option selected");
                            break;
                    }
                }
                while (selectedOption != "0");
            }

            void AddFoodItem()
            {
                string functionTitle = "Add Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
                Console.Write("Name of Food Item: ");
                string foodName = Console.ReadLine();
                Console.Write("\nDescription of Food Item: ");
                string description = Console.ReadLine();
            }

            void DeleteFoodItem()
            {
                string functionTitle = "Delete Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
            }

            void UpdateFoodItem()
            {
                string functionTitle = "Update Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
            }

            // Other functions
            string MultiplyString(string s, int value)
            {
                return String.Concat(Enumerable.Repeat(s, value));
            }
        }
    }
}
