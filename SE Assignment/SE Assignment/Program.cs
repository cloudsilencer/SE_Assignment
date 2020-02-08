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

            manageFoodItems();

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Login as Customer");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();
            Console.WriteLine("Press 1 to create a new Order");
            string choice = Console.ReadLine();

            var numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(7);
            List<ItemMenu> foodList = new List<ItemMenu>();
            foodList.Add(new ItemMenu("Food 1", "", 1, 2, "", 2, new Category(1, ""), new SetMenu(1, "")));
            foodList.Add(new ItemMenu("Food 2", "", 1, 2, "", 2, new Category(2, ""), new SetMenu(2, "")));

            //Display food items
            foreach (ItemMenu food in foodList)
            {
                Console.WriteLine(food.getName());
            }
               
            string foodchoice = Console.ReadLine();

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 


            // Manager Functions
            void manageFoodItems()
            {
                string functionTitle = "Manage Food Items";
                List<String> options = new List<string> { "Add Food Item", "Delete Food Item", "Update Food Item", "Exit"};
                Console.WriteLine($"{functionTitle}\n{String.Concat(Enumerable.Repeat("-", functionTitle.Length))}");
                for (int i = 0; i < options.Count; i++)
                {
                    if(((i + 1) % 4) == 0)
                        Console.WriteLine($"\n[{(i + 1) % 4}] {options[i]}");
                    else
                        Console.WriteLine($"[{(i + 1) % 4}] {options[i]}");
                }
                Console.Write("\nSelect an option: ");
                String selectedOption = Console.ReadLine();
                Console.WriteLine("You have selected " + selectedOption + ".");
            }
        }
    }
}
