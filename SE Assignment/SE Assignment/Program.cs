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
            List<Customer> customers = new List<Customer>();
            List<Branch> branches = new List<Branch>();
            List<Order> orders = new List<Order>();
            List<Payment> payments = new List<Payment>();
            InitializeData();
            //Console.WriteLine($"Number of food items: {itemMenus.Count}");
            //ManageItemMenu();
            //Console.WriteLine($"Number of food items: {itemMenus.Count}");

            bool login = false;
            Customer currentCust = new Customer();

            // ManageItemMenu();
            Console.WriteLine("Who are you?\n1. Customer\n2. Employee");
            string user = Console.ReadLine();
            if (user == "1")
            {
                Console.WriteLine("Login as Customer");
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();
                foreach (Customer c in customers)
                {
                    if (email == c.getEmail() && pass == c.getAccount().getPassword())
                    {
                        login = true;
                        currentCust = c;
                    }
                }

                if (login == true)
                {
                    Console.WriteLine("\nLogin Successful");
                    Console.WriteLine("What would you like to do today?");
                    Console.WriteLine("1. Create a new Order");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                        placeOrder(currentCust);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Wrong acc");
                    Console.ReadKey();
                }

                // Place Order (Dominic)

                void placeOrder(Customer cust)
                {
                    Order newOrder = new Order(orders.Count.ToString(), currentCust, DateTime.Now);
                    currentCust.addOrder(newOrder);
                    Console.WriteLine("Please select an outlet from below");
                    for (int i = 0; i < branches.Count; i++)
                        Console.WriteLine((i + 1) + ". " + branches[i].getBranchName());
                    newOrder.setBranch(branches[Convert.ToInt32(Console.ReadLine()) - 1]);

                    while (true)
                    {
                        Console.WriteLine("Please select an item from below");
                        for (int i = 0; i < itemMenus.Count; i++)
                            Console.WriteLine((i + 1) + ". " + itemMenus[i].getName());

                        int foodchoice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("How many would you like? ");
                        string quantity = Console.ReadLine();
                        OrderItem selected = new OrderItem(itemMenus[foodchoice - 1], Convert.ToInt32(quantity), newOrder);
                        newOrder.addItem(selected);
                        Console.WriteLine("Would you like to add more items? (Y/N)");
                        string option = Console.ReadLine();
                        if (option == "N")
                            checkOut(newOrder, cust);
                    }
                }
            }
            else if (user == "2")
            {
                //Implementation
            }

            // Place Order (Dominic)

            void checkOut(Order coOrder, Customer cust)
            {
                processOrder(coOrder);
                Console.WriteLine("\n Order Summary");
                coOrder.ToString();
                Console.WriteLine("\n Would you like express delivery? (Y/N)");
                string delivery = Console.ReadLine();
                Console.WriteLine("\n Order Summary");
                if (delivery == "Y") //if "N", already set to Default and 0
                    coOrder.expressDelivery();
                else if (delivery == "N")
                    coOrder.normalDelivery();
                else
                    Console.WriteLine("Please enter a valid option");
                coOrder.displayReceipt();
                coOrder.makePayment(payments);
            }

            // Place Order (Dominic)

            void processOrder(Order pOrder)
            {
                double subTotal = pOrder.getSubTotal();
                foreach (OrderItem item in pOrder.getOrderItems())
                {
                    subTotal += (item.getItem().getPrice() * item.getQuantity()) + pOrder.getDeliveryCharge();
                }
                pOrder.setSubTotal(subTotal);
                pOrder.setTotalAmt((subTotal * pOrder.getGST() / 100) + subTotal);
            }

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

                ItemMenu itemMenu1 = new ItemMenu("French Toast", "Sliced bread soaked in eggs and milk, then fried.", 3.00, 100, "Available", category4, breakfastSetMenu);
                ItemMenu itemMenu2 = new ItemMenu("Grilled Chicken Sandwich", "Juicy grilled chicken wrapped within 2 slices of bread.", 5.60, 100, "Available", category1, breakfastSetMenu);
                ItemMenu itemMenu3 = new ItemMenu("Fish Congee", "Congee with red grouper slices", 5.80, 100, "Available", category1, breakfastSetMenu);
                ItemMenu itemMenu4 = new ItemMenu("Chicken Wrap", "Tortilla wrap with bits of chicken", 12.00, 100, "Available", category1, breakfastSetMenu);
                ItemMenu itemMenu5 = new ItemMenu("Signature Southern Style Fried Chicken", "The taste of Texas", 12.90, 100, "Available", category1, lunchSetMenu);
                ItemMenu itemMenu6 = new ItemMenu("Steak with baked potatoes", "Sirloin steak served with baked potatoes", 17.90, 100, "Available", category3, lunchSetMenu);
                ItemMenu itemMenu7 = new ItemMenu("Poke Bowl", "Diced raw salmon served with salad", 12.60, 100, "Available", category2, lunchSetMenu);
                ItemMenu itemMenu8 = new ItemMenu("Seafood Spaghetti", "Tomato based spaghetti with shrimp and clams", 10.70, 100, "Available", category4, lunchSetMenu);
                ItemMenu itemMenu9 = new ItemMenu("Roasted Chicken with Herbs", "Quarter Roasted Chicken with 2 sides", 14.90, 100, "Available", category1, dinnerSetMenu);
                ItemMenu itemMenu10 = new ItemMenu("Fried Wild Mushrooms", "Wild Mushrooms fresh from Australia", 8.20, 100, "Available", category4, dinnerSetMenu);
                ItemMenu itemMenu11 = new ItemMenu("Beef Stew", "Beef stew with bread", 14.20, 100, "Available", category3, dinnerSetMenu);
                ItemMenu itemMenu12 = new ItemMenu("Fish and Chips", "Fried cod in batter served with chips", 11.90, 100, "Available", category3, dinnerSetMenu);
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

                Account acc1 = new Account(1, "password", "Logged Out");
                Account acc2 = new Account(2, "password", "Logged Out");
                Account acc3 = new Account(3, "password", "Logged Out");
                Account acc4 = new Account(4, "password", "Logged Out");
                Account acc5 = new Account(5, "password", "Logged Out");

                Customer cust1 = new Customer("Dominic", "Sengkang", "dominic8281@gmail.com", "97828840", "123123", acc1);
                Customer cust2 = new Customer("Kevin", "Hougang", "kevin8281@gmail.com", "97828841", "123124", acc2);
                Customer cust3 = new Customer("Li Yun", "Punggol", "liyun8281@gmail.com", "97828842", "123125", acc3);
                customers.Add(cust1);
                customers.Add(cust2);
                customers.Add(cust3);

                Branch branch1 = new Branch(1, "Sengkang");
                Branch branch2 = new Branch(1, "Hougang");
                Branch branch3 = new Branch(1, "Punggol");
                branches.Add(branch1);
                branches.Add(branch2);
                branches.Add(branch3);

                Order order1 = new Order("1", cust1, DateTime.Now);
                Order order2 = new Order("2", cust2, DateTime.Now);
                Order order3= new Order("3", cust3, DateTime.Now);
                orders.Add(order1);
                orders.Add(order2);
                orders.Add(order3);

                Payment payment1 = new Payment("1", order1, 100.00, DateTime.Now, "Online");
                Payment payment2 = new Payment("2", order2, 200.00, DateTime.Now, "Online");
                Payment payment3 = new Payment("3", order3, 10.00, DateTime.Now, "Online");

                payments.Add(payment1);
                payments.Add(payment2);
                payments.Add(payment3);


            }

            // Manager Functions (Kevin)
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

            // Use Case 1 
            void AddFoodItem()
            {
                // Title For Option
                string functionTitle = "Add Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
                // Form Variables
                string foodName = "";
                string description = "";
                string price = "";
                string unit = "";
                string status = "";
                string category = "";
                string setMenu = "";

                // Boolean Variables
                bool isFoodNameValid = false;
                bool isDescriptionValid = false;
                bool isPriceValid = false;
                bool isUnitValid = false;
                bool isStatusValid = false;
                bool isCategoryValid = false;
                bool isSetMenuValid = false;


                while(!isFoodNameValid)
                {
                    Console.Write("Name of Food Item: ");
                    foodName = Console.ReadLine();
                    if (foodName == "")
                        Console.WriteLine("Name of Food Item cannot be empty");
                    else if (CheckFoodNameExists(GetAllFoodItemName(itemMenus), foodName))
                        Console.WriteLine($"The food name {foodName} already exists.");
                    else
                        isFoodNameValid = true;
                }

                while (!isDescriptionValid)
                {
                    Console.Write("Description: ");
                    description = Console.ReadLine();
                    if (description == "")
                        Console.WriteLine($"Description for Food Item: {foodName} cannot be empty.");
                    else
                        isDescriptionValid = true;
                }

                while(!isPriceValid)
                {
                    Console.Write("Price ($): ");
                    price = Console.ReadLine();
                    if (price == "")
                        Console.WriteLine($"Price for Food Item: {foodName} cannot be empty");
                    else
                    {
                        try
                        {
                            double convertedPrice = double.Parse(price);
                            if (convertedPrice <= 0.00)
                                Console.WriteLine("Price cannot be $0.00 or less.");
                            else
                                isPriceValid = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, price should be in the format of X.XX\t Example: 4.90");
                        }
                    }
                }

                while(!isUnitValid)
                {
                    Console.Write("Unit (Stock Level): ");
                    unit = Console.ReadLine();
                    if (unit == "")
                        Console.WriteLine($"Unit for Food Item: {foodName} cannot be empty");
                    else
                    {
                        try
                        {
                            int convertedUnit = int.Parse(unit);
                            if (convertedUnit < 0)
                                Console.WriteLine("Unit cannot be less than 0.");
                            else
                                isUnitValid = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, unit should be a number\t Example: 100");
                        }
                    }
                }

                while(!isStatusValid)
                {
                    Console.Write("Status ('Available' or 'Unavailable'): ");
                    status = Console.ReadLine();
                    if(status=="")
                        Console.WriteLine($"Status for Food Item: {foodName} cannot be empty");
                    else
                    {
                        if (isAValidStatus(status))
                            isStatusValid = true;
                        else
                            Console.WriteLine($"Status can be either 'Available' or 'Unavailable'");
                    }
                }

                DisplayAllCategories(categories);
                while (!isCategoryValid)
                {
                    Console.Write("Select a category (Enter the name): ");
                    category = Console.ReadLine();
                    if (category == "")
                        Console.WriteLine($"Category for Food Item: {foodName} cannot be empty");
                    else
                    {
                        if (GetCategoryByName(categories, category) == null)
                            Console.WriteLine($"The category {category} does not exist");
                        else
                            isCategoryValid = true;
                    }
                }

                DisplayAllSetMenus(setMenus);
                while (!isSetMenuValid)
                {
                    Console.Write("Select a Set Menu (Enter the name): ");
                    setMenu = Console.ReadLine();
                    if (setMenu == "")
                        Console.WriteLine($"Set Menu for Food Item: {foodName} cannot be empty");
                    else
                    {
                        if (GetSetMenuByName(setMenus, setMenu) == null)
                            Console.WriteLine($"The Set Menu {setMenu} does not exist");
                        else
                            isSetMenuValid = true;
                    }
                }

                ItemMenu newItem = new ItemMenu(foodName, description, double.Parse(price), int.Parse(unit), status, GetCategoryByName(categories, category), GetSetMenuByName(setMenus, setMenu));
                itemMenus.Add(newItem);

            }

            // Use Case 2
            void DeleteFoodItem()
            {
                string functionTitle = "Delete Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
            }

            // Use Case 3
            void UpdateFoodItem()
            {
                string functionTitle = "Update Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
            }

            // Other useful functions
            string MultiplyString(string s, int value)
            {
                return String.Concat(Enumerable.Repeat(s, value));
            }

            List<string> GetAllFoodItemName(List<ItemMenu> itemList)
            {
                List<string> FoodNameList = new List<string>();
                foreach(ItemMenu itemMenu in itemList)
                {
                    FoodNameList.Add(itemMenu.getName());
                }
                return FoodNameList;
            }

            bool CheckFoodNameExists(List<String> nameList, string nameToCheck)
            {
                bool exists = false;
                foreach(String name in nameList)
                {
                    if(name==nameToCheck)
                    {
                        exists = true;
                        break;
                    }
                }
                return exists;
            }

            bool isAValidStatus(string status)
            {
                if (status == "Available" || status == "Unavailable")
                    return true;
                else
                    return false;
            }

            void DisplayAllCategories(List<Category> categoryList)
            {
                Console.WriteLine("Categories:");
                for(int i = 0; i < categoryList.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}]\t{categoryList[i].GetCategoryName()}");
                }
                Console.WriteLine();
            }

            Category GetCategoryByName(List<Category> categoryList, string categoryName)
            {
                Category foundCategory = null;
                foreach (Category category in categoryList)
                {
                    if (category.GetCategoryName() == categoryName)
                    {
                        foundCategory = category;
                        break;
                    }
                }
                return foundCategory;
            }

            void DisplayAllSetMenus(List<SetMenu> setMenusList)
            {
                Console.WriteLine("Set Menus:");
                for (int i = 0; i < setMenusList.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}]\t{setMenusList[i].getSetMenuItem()}");
                }
                Console.WriteLine();
            }


            SetMenu GetSetMenuByName(List<SetMenu> setMenuList, string setMenuName)
            {
                SetMenu foundSetMenu = null;
                foreach (SetMenu setMenu in setMenuList)
                {
                    if (setMenu.getSetMenuItem() == setMenuName)
                    {
                        foundSetMenu = setMenu;
                        break;
                    }
                }
                return foundSetMenu;
            }
        }
    }
}
// Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 