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
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}");
            }

            void DeleteFoodItem()
            {
                string functionTitle = "Delete Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}");
            }

            void UpdateFoodItem()
            {
                string functionTitle = "Update Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}");
            }

            // Other functions
            string MultiplyString(string s, int value)
            {
                return String.Concat(Enumerable.Repeat(s, value));
            }
        }
    }
}
