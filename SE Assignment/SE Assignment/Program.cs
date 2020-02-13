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
            List<FoodItem> foodItems = new List<FoodItem>();
            List<Customer> customers = new List<Customer>();
            List<Employee> employees = new List<Employee>();
            List<Branch> branches = new List<Branch>();
            List<Order> orders = new List<Order>();
            List<Payment> payments = new List<Payment>();
            InitializeData();

            bool login = false;
            Customer currentCust = new Customer();

            Console.WriteLine("Who are you?\n1. Customer\n2. Employee");
            Console.Write("Select an option: ");
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

            }

            else if (user == "2")
            {
                //Implementation
                Console.WriteLine();
                DisplayEmployeeMenu();
            }

            if (login == true)
            {
                Console.WriteLine("\nLogin Successful");
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("1. Create a new Order");
                Console.WriteLine("2. View all Orders");
                string choice = Console.ReadLine();
                if (choice == "1")
                    placeOrder(currentCust);
                if (choice == "2")
                    viewOrders(currentCust);
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
                    for (int i = 0; i < foodItems.Count; i++)
                        Console.WriteLine((i + 1) + ". " + foodItems[i].Name);

                    int foodchoice = Convert.ToInt32(Console.ReadLine());
                    Console.Write("How many would you like? ");
                    string quantity = Console.ReadLine();
                    OrderItem selected = new OrderItem(foodItems[foodchoice - 1], Convert.ToInt32(quantity), newOrder);
                    newOrder.addItem(selected);
                    Console.WriteLine("Would you like to add more items? (Y/N)");
                    string option = Console.ReadLine();
                    if (option == "N")
                        checkOut(newOrder, cust);
                }
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
                    subTotal += (item.getItem().Price * item.getQuantity()) + pOrder.getDeliveryCharge();
                }
                pOrder.setSubTotal(subTotal);
                pOrder.setTotalAmt((subTotal * pOrder.getGST() / 100) + subTotal);
            }

            // View all Orders (Li Yun)
             void viewOrders(Customer cust)
             {
                Console.WriteLine("Your Orders:");

                foreach(Order o in orders)
                {
                    if (cust == o.getCust())
                    {
                        Console.WriteLine("\n" + $"Order Number {o.getOrderNum()} placed on {o.getOrderDate()}");

                        foreach (OrderItem item in o.getOrderItems())
                        {
                            Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                        }

                        // Console.WriteLine($"Total amount paid: {o.getTotalAmt()}");

                    }

                   
                }

                Console.WriteLine("\n");
                Console.WriteLine("Select Current or Past order(s):");
                Console.WriteLine(" 1. Current order(s)");
                Console.WriteLine(" 2. Past order(s)");

                string choice = Console.ReadLine();


                if (choice == "1")
                {
                    foreach (Order o in orders)
                    {
                        if (cust == o.getCust() && o.getOrderDate() == DateTime.Now)
                        {
                            Console.WriteLine("\n" + $"Order Number: {o.getOrderNum()} at {o.getOrderDate()}");

                            foreach (OrderItem item in o.getOrderItems())
                            {
                                Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                            }

                        }
                    }      
                }

                if (choice == "2")
                {
                    foreach (Order o in orders)
                    {
                        if (cust == o.getCust())
                        {
                            Console.WriteLine($"Order Number: {o.getOrderNum()} at {o.getOrderDate()}");

                            foreach (OrderItem item in o.getOrderItems())
                            {
                                Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                            }

                        }

                    }
                        
                }

                Console.ReadKey();

             }

            // Manage Menu and Manage Item (Kevin)

            // Use Case 5 - Manage Menu (Kevin)
            void ManageSetMenu()
            {
                string functionTitle = "Manage Set Menu";
                List<String> options = new List<string> { "Create Set Menu", "Remove Set Menu", "Update Set Menu", "Exit" };
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
                            Console.WriteLine("Exiting From Manage Set Menu...\n");
                            break;
                        case "1":
                            CreateSetMenu();
                            break;
                        case "2":
                            RemoveSetMenu();
                            break;
                        case "3":
                            UpdateSetMenu();
                            break;
                        default:
                            Console.WriteLine("Invalid option selected");
                            break;
                    }
                }
                while (selectedOption != "0");
            }

            // Use Case 6 - Create Set Menu (Kevin)
            void CreateSetMenu()
            {
                string functionTitle = "Create Set Menu";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");

                string setMenuName = "";
                bool isSetMenuNameValid = false;

                DisplayAllSetMenus(setMenus);
                while (!isSetMenuNameValid)
                {
                    Console.Write("Please enter the Set Menu ID to be removed: ");
                    setMenuName = Console.ReadLine();
                    if (setMenuName == "")
                        Console.WriteLine("Set Menu name cannot be empty!");
                    else
                    {
                        if (CheckSetMenuNameExists(GetAllSetMenuName(setMenus), setMenuName))
                            Console.WriteLine($"Set Menu: {setMenuName} already exists! Please enter another different name!");
                        else
                        {
                            SetMenu setMenu = new SetMenu(LatestAvailableSetMenuID(setMenus), setMenuName);
                            setMenus.Add(setMenu);
                        }
                    }
                }
            }

            // Use Case 7 - Remove Set Menu (Kevin)
            void RemoveSetMenu()
            {
                string functionTitle = "Remove Set Menu";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
                DisplayAllSetMenus(setMenus);

                string setMenuID = "";
                bool isSetMenuIDValid = false;
                while (!isSetMenuIDValid)
                {
                    Console.Write("Please enter the Set Menu ID: ");
                    setMenuID = Console.ReadLine();
                    if (setMenuID == "")
                        Console.WriteLine($"Set Menu ID: {setMenuID} cannot be empty");
                    else
                    {
                        try
                        {
                            int parsedSetMenuID = int.Parse(setMenuID);
                            if (GetSetMenuByID(setMenus, parsedSetMenuID) == null)
                                Console.WriteLine($"Set Menu ID: {parsedSetMenuID} does not exist");
                            else
                            {
                                Console.WriteLine($"The Set Menu: {GetSetMenuByID(setMenus, parsedSetMenuID).SetMenuName} was removed.");
                                setMenus.Remove(GetSetMenuByID(setMenus, parsedSetMenuID));
                                isSetMenuIDValid = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, Set Menu ID is a number. \t Example: 1");
                        }
                    }
                }
            }

            // Use Case 8 - Update Set Menu (Kevin)
            void UpdateSetMenu()
            {
                string functionTitle = "Update Set Menu";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");

                string setMenuID = "";
                bool isSetMenuIDValid = false;
                while (!isSetMenuIDValid)
                {
                    Console.Write("Please enter the Set Menu ID to be updated: ");
                    setMenuID = Console.ReadLine();
                    if (setMenuID == "")
                        Console.WriteLine($"Set Menu ID: {setMenuID} cannot be empty");
                    else
                    {
                        try
                        {
                            int parsedSetMenuID = int.Parse(setMenuID);
                            if (GetSetMenuByID(setMenus, parsedSetMenuID) == null)
                                Console.WriteLine($"Set Menu ID: {parsedSetMenuID} does not exist");
                            else
                            {
                                Console.WriteLine($"The Set Menu: {GetSetMenuByID(setMenus, parsedSetMenuID).SetMenuName} was removed.");
                                isSetMenuIDValid = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, Set Menu ID is a number. \t Example: 1");
                        }
                    }
                }

                SetMenu setMenuToBeUpdated = GetSetMenuByID(setMenus, int.Parse(setMenuID));
                Console.WriteLine($"\nSelected Item:\n");
                Console.WriteLine(setMenuToBeUpdated.ToString());

                string setMenuNameToUpdate = "";
                bool isUpdatedSetMenuNameValid = false;
                while(!isUpdatedSetMenuNameValid)
                {
                    Console.Write("Enter a new name for the Set Menu: ");
                    setMenuNameToUpdate = Console.ReadLine();
                    if (setMenuNameToUpdate == "")
                        Console.WriteLine("New name for Set Menu cannot be empty");
                    else
                    {
                        if (CheckSetMenuNameExists(GetAllSetMenuName(setMenus), setMenuNameToUpdate))
                        {
                            Console.WriteLine("Name for Set Menu already exists");
                        }
                        else
                        {
                            setMenuToBeUpdated.SetMenuName = setMenuNameToUpdate;
                            Console.WriteLine("Set Menu has been successfully updated.");
                        }
                    }
                }
            }

            // Use Case 9 - Manage Item (Kevin)
            void ManageItem()
            {
                string functionTitle = "Manage Food Items";
                List<String> options = new List<string> { "Create Food Item", "Remove Food Item", "Update Food Item", "Exit"};
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
                            CreateFoodItem();
                            break;
                        case "2":
                            RemoveFoodItem();
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

            // Use Case 10 - Add Food Item (Kevin)
            void CreateFoodItem()
            {
                // Title For Option
                string functionTitle = "Create Food Item";
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
                    else if (CheckFoodNameExists(GetAllFoodItemName(foodItems), foodName))
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
                    Console.Write("Please enter the Category ID: ");
                    category = Console.ReadLine();
                    if (category == "")
                        Console.WriteLine($"Category ID: {foodName} cannot be empty");
                    else
                    {
                        try
                        {
                            int convertedCategory = int.Parse(category);
                            if(GetCategoryByID(categories, convertedCategory)==null)
                                Console.WriteLine($"Category ID: {category} does not exist");
                            else
                                isCategoryValid = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, Category ID is a number. \t Example: 1");
                        }
                    }
                }

                DisplayAllSetMenus(setMenus);
                while (!isSetMenuValid)
                {
                    Console.Write("Please enter the Set Menu ID: ");
                    setMenu = Console.ReadLine();
                    if (setMenu == "")
                        Console.WriteLine($"Set Menu ID: {setMenu} cannot be empty");
                    else
                    {
                        try
                        {
                            int convertedSetMenu = int.Parse(setMenu);
                            if (GetSetMenuByID(setMenus, convertedSetMenu) == null)
                                Console.WriteLine($"Set Menu ID: {setMenu} does not exist");
                            else
                                isSetMenuValid = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, set Menu ID is a number. \t Example: 1");
                        }
                    }
                }

                FoodItem newItem = new FoodItem(LatestAvailableItemID(foodItems), 
                                                foodName, description, double.Parse(price), 
                                                int.Parse(unit), status, 
                                                GetCategoryByID(categories, int.Parse(category)), 
                                                GetSetMenuByID(setMenus, int.Parse(setMenu)));
                foodItems.Add(newItem);
                Console.WriteLine($"Food Item: {foodName} successfully added.\n");

            }

            // Use Case 11 - Remove Food Item (Kevin)
            void RemoveFoodItem()
            {
                string functionTitle = "Delete Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
                DisplayAllItemMenu(foodItems);

                string itemID = "";
                string confirmation = "";
                bool isItemIDValid = false;
                bool isConfirmationValid = false;
                while(!isItemIDValid)
                {
                    Console.Write("Please enter the ID of the Food Item to be deleted: ");
                    itemID = Console.ReadLine();
                    if (itemID == "")
                    {
                        Console.WriteLine("Food Item ID cannot be empty");
                    }
                    else
                    {
                        try
                        {
                            int parsedItemID = int.Parse(itemID);
                            if (GetFoodItemByID(foodItems, parsedItemID) == null)
                                Console.WriteLine($"Food Item with ID: {parsedItemID} does not exists");
                            else
                                isItemIDValid = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, Food Item ID is a number. \t Example: 1");
                        }
                    }
                }
                Console.WriteLine();
                while (!isConfirmationValid)
                {
                    Console.Write($"Confirm the removal of Food Item: {GetFoodItemByID(foodItems, int.Parse(itemID)).Name}? (Y/N) :");
                    confirmation = Console.ReadLine();
                    switch(confirmation)
                    {
                        case "Y":
                            Console.WriteLine($"Food Item: {GetFoodItemByID(foodItems, int.Parse(itemID)).Name} was removed.\n");
                            foodItems.Remove(GetFoodItemByID(foodItems, int.Parse(itemID)));
                            isConfirmationValid = true;
                            break;
                        case "N":
                            isConfirmationValid = true;
                            break;
                        default:
                            Console.WriteLine("Invalid response. Please enter 'Y' for Yes or 'N' for No");
                            break;
                    }
                }
            }

            // Use Case 12 - Update Food Item
            void UpdateFoodItem()
            {
                string functionTitle = "Update Food Item";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
                DisplayAllItemMenu(foodItems);
                
                string itemID = "";
                bool isItemIDValid = false;

                while (!isItemIDValid)
                {
                    Console.Write("Please enter the ID of the Food Item to be updated: ");
                    itemID = Console.ReadLine();
                    if (itemID == "")
                    {
                        Console.WriteLine("Food Item ID cannot be empty");
                    }
                    else
                    {
                        try
                        {
                            int parsedItemID = int.Parse(itemID);
                            if (GetFoodItemByID(foodItems, parsedItemID) == null)
                                Console.WriteLine($"Food Item with ID: {parsedItemID} does not exists");
                            else
                                isItemIDValid = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, Food Item ID is a number. \t Example: 1");
                        }
                    }
                }

                FoodItem itemToBeUpdated = GetFoodItemByID(foodItems, int.Parse(itemID));
                Console.WriteLine($"\nSelected Item:\n");
                Console.WriteLine(itemToBeUpdated.ToString());

                string fieldToUpdate = "";
                //bool isFieldValid = false;

                //while (!isFieldValid)
                //{
                Console.Write("Please enter the field to be updated: ");
                fieldToUpdate = Console.ReadLine();
                switch(fieldToUpdate)
                {
                    case "Name":
                        Console.Write("Updated Name: ");
                        string updatedname = Console.ReadLine();
                        itemToBeUpdated.Name = updatedname;
                        break;
                    case "Description":
                        Console.Write("Updated Description: ");
                        string updatedDescription = Console.ReadLine();
                        itemToBeUpdated.Description = updatedDescription;
                        break;
                    case "Price":
                        Console.Write("Updated Price: ");
                        string updatedPrice = Console.ReadLine();
                        itemToBeUpdated.Price = double.Parse(updatedPrice);
                        break;
                    case "Unit":
                        Console.Write("Updated Unit: ");
                        string updatedUnit = Console.ReadLine();
                        itemToBeUpdated.Unit = int.Parse(updatedUnit);
                        break;
                    case "Status":
                        Console.Write("Updated Status: ");
                        string updatedStatus = Console.ReadLine();
                        itemToBeUpdated.Status = updatedStatus;
                        break;
                    case "Category":
                        DisplayAllCategories(categories);
                        Console.Write("Updated Category (Enter the ID): ");
                        string updatedCategoryID = Console.ReadLine();
                        itemToBeUpdated.Category = GetCategoryByID(categories, int.Parse(updatedCategoryID));
                        break;
                    case "SetMenu":
                        DisplayAllSetMenus(setMenus);
                        Console.Write("Updated Set Menu (Enter the ID): ");
                        string updatedSetMenuID = Console.ReadLine();
                        itemToBeUpdated.SetMenu = GetSetMenuByID(setMenus, int.Parse(updatedSetMenuID));
                        break;
                    default:
                        break;
                }           
                //}

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

                FoodItem itemMenu1 = new FoodItem(1, "French Toast", "Sliced bread soaked in eggs and milk, then fried.", 3.00, 100, "Available", category4, breakfastSetMenu);
                FoodItem itemMenu2 = new FoodItem(2, "Grilled Chicken Sandwich", "Juicy grilled chicken wrapped within 2 slices of bread.", 5.60, 100, "Available", category1, breakfastSetMenu);
                FoodItem itemMenu3 = new FoodItem(3, "Fish Congee", "Congee with red grouper slices", 5.80, 100, "Available", category1, breakfastSetMenu);
                FoodItem itemMenu4 = new FoodItem(4, "Chicken Wrap", "Tortilla wrap with bits of chicken", 12.00, 100, "Available", category1, breakfastSetMenu);
                FoodItem itemMenu5 = new FoodItem(5, "Signature Southern Style Fried Chicken", "The taste of Texas", 12.90, 100, "Available", category1, lunchSetMenu);
                FoodItem itemMenu6 = new FoodItem(6, "Steak with baked potatoes", "Sirloin steak served with baked potatoes", 17.90, 100, "Available", category3, lunchSetMenu);
                FoodItem itemMenu7 = new FoodItem(7, "Poke Bowl", "Diced raw salmon served with salad", 12.60, 100, "Available", category2, lunchSetMenu);
                FoodItem itemMenu8 = new FoodItem(8, "Seafood Spaghetti", "Tomato based spaghetti with shrimp and clams", 10.70, 100, "Available", category4, lunchSetMenu);
                FoodItem itemMenu9 = new FoodItem(9, "Roasted Chicken with Herbs", "Quarter Roasted Chicken with 2 sides", 14.90, 100, "Available", category1, dinnerSetMenu);
                FoodItem itemMenu10 = new FoodItem(10, "Fried Wild Mushrooms", "Wild Mushrooms fresh from Australia", 8.20, 100, "Available", category4, dinnerSetMenu);
                FoodItem itemMenu11 = new FoodItem(11, "Beef Stew", "Beef stew with bread", 14.20, 100, "Available", category3, dinnerSetMenu);
                FoodItem itemMenu12 = new FoodItem(12, "Fish and Chips", "Fried cod in batter served with chips", 11.90, 100, "Available", category3, dinnerSetMenu);
                foodItems.Add(itemMenu1);
                foodItems.Add(itemMenu2);
                foodItems.Add(itemMenu3);
                foodItems.Add(itemMenu4);
                foodItems.Add(itemMenu5);
                foodItems.Add(itemMenu6);
                foodItems.Add(itemMenu7);
                foodItems.Add(itemMenu8);
                foodItems.Add(itemMenu9);
                foodItems.Add(itemMenu10);
                foodItems.Add(itemMenu11);
                foodItems.Add(itemMenu12);

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

                Order order3 = new Order("3", cust3, DateTime.Now);
                order3.addItem(new OrderItem(itemMenu1, 1, order3));

                Order order4 = new Order("4", cust3, DateTime.Now.AddDays(-1));
                order4.addItem(new OrderItem(itemMenu2, 5, order4));


                orders.Add(order1);
                orders.Add(order2);
                orders.Add(order3);
                orders.Add(order4);

                Payment payment1 = new Payment("1", order1, 100.00, DateTime.Now, "Online");
                Payment payment2 = new Payment("2", order2, 200.00, DateTime.Now, "Online");
                Payment payment3 = new Payment("3", order3, 10.00, DateTime.Now, "Online");

                payments.Add(payment1);
                payments.Add(payment2);
                payments.Add(payment3);

                // Start The Clock
                Clock clock = Clock.getInstance();

                Dispatcher dispatcher1 = new Dispatcher(50, "S9213724G", "Male", "Employed", new DateTime(2017, 10, 19), branch1, clock);
                Dispatcher dispatcher2 = new Dispatcher(51, "S9605134B", "Female", "Employed", new DateTime(2018, 2, 25), branch1, clock);

                employees.Add(dispatcher1);
                employees.Add(dispatcher2);

            }

            // Other useful functions

            // Employee Menu
            void DisplayEmployeeMenu()
            {
                string functionTitle = "Employee Portal";
                List<String> employeeMenuOptions = new List<String>() {"Manager", "Chef", "Dispatcher", "Exit"};
                String selectedOption = "";
                do
                {
                    Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}");
                    for (int i = 0; i < employeeMenuOptions.Count; i++)
                    {
                        if (((i + 1) % 4) == 0)
                            Console.WriteLine($"\n[{(i + 1) % 4}] {employeeMenuOptions[i]}");
                        else
                            Console.WriteLine($"[{(i + 1) % 4}] {employeeMenuOptions[i]}");
                    }
                    Console.Write("\nSelect an option: ");
                    selectedOption = Console.ReadLine();
                    Console.WriteLine();
                    switch (selectedOption)
                    {
                        case "0":
                            Console.WriteLine($"Exiting From {functionTitle}...\n");
                            break;
                        case "1":
                            DisplayManagerMenu();
                            break;
                        case "2":
                            // DisplayChefMenu();
                            break;
                        case "3":
                            // DisplayDispatcherMenu()
                            break;
                        default:
                            Console.WriteLine("Invalid option selected");
                            break;
                    }
                }
                while (selectedOption != "0");
            }

            // Manager Menu
            void DisplayManagerMenu()
            {
                string functionTitle = "Manager Menu";
                List<String> managerMenuOptions = new List<String>() { "Manage Menu", "Manage Item", "View Orders", "Exit"};
                String selectedOption = "";
                do
                {
                    Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}");
                    for (int i = 0; i < managerMenuOptions.Count; i++)
                    {
                        if (((i + 1) % 4) == 0)
                            Console.WriteLine($"\n[{(i + 1) % 4}] {managerMenuOptions[i]}");
                        else
                            Console.WriteLine($"[{(i + 1) % 4}] {managerMenuOptions[i]}");
                    }
                    Console.Write("\nSelect an option: ");
                    selectedOption = Console.ReadLine();
                    Console.WriteLine();
                    switch (selectedOption)
                    {
                        case "0":
                            Console.WriteLine($"Exiting From {functionTitle}...\n");
                            break;
                        case "1":
                            ManageSetMenu();
                            break;
                        case "2":
                            ManageItem();
                            break;
                        case "3":
                            // DisplayDispatcherMenu()
                            break;
                        default:
                            Console.WriteLine("Invalid option selected");
                            break;
                    }
                }
                while (selectedOption != "0");
            }


            string MultiplyString(string s, int value)
            {
                return String.Concat(Enumerable.Repeat(s, value));
            }

            List<string> GetAllSetMenuName(List<SetMenu> setMenuList)
            {
                List<string> SetMenuNameList = new List<string>();
                foreach (SetMenu setMenu in setMenuList)
                {
                    SetMenuNameList.Add(setMenu.SetMenuName);
                }
                return SetMenuNameList;
            }

            bool CheckSetMenuNameExists(List<String> nameList, string nameToCheck)
            {
                bool exists = false;
                foreach (String name in nameList)
                {
                    if (name == nameToCheck)
                    {
                        exists = true;
                        break;
                    }
                }
                return exists;
            }

            int LatestAvailableSetMenuID(List<SetMenu> setMenuList)
            {
                if (setMenuList.Count == 0)
                    return 1;
                else
                    return setMenuList[setMenuList.Count - 1].SetMenuID + 1;
            }

            List<string> GetAllFoodItemName(List<FoodItem> itemList)
            {
                List<string> FoodNameList = new List<string>();
                foreach(FoodItem itemMenu in itemList)
                {
                    FoodNameList.Add(itemMenu.Name);
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
                Console.WriteLine();
                Console.WriteLine("Categories:");
                foreach(Category category in categoryList)
                {
                    Console.WriteLine($"ID: {category.CategoryID}\tName: {category.CategoryName}");
                }
                Console.WriteLine();
            }

            Category GetCategoryByID(List<Category> categoryList, int categoryID)
            {
                Category foundCategory = null;
                foreach (Category category in categoryList)
                {
                    if (category.CategoryID == categoryID)
                    {
                        foundCategory = category;
                        break;
                    }
                }
                return foundCategory;
            }

            void DisplayAllSetMenus(List<SetMenu> setMenusList)
            {
                Console.WriteLine();
                Console.WriteLine("Set Menus:");
                foreach(SetMenu setMenu in setMenusList)
                {
                    Console.WriteLine($"ID: {setMenu.SetMenuID}\tName: {setMenu.SetMenuName}");
                }
                Console.WriteLine();
            }

            SetMenu GetSetMenuByID(List<SetMenu> setMenuList, int setMenuID)
            {
                SetMenu foundSetMenu = null;
                foreach (SetMenu setMenu in setMenuList)
                {
                    if (setMenu.SetMenuID == setMenuID)
                    {
                        foundSetMenu = setMenu;
                        break;
                    }
                }
                return foundSetMenu;
            }

            void DisplayAllItemMenu(List<FoodItem> foodItemList)
            {
                Console.WriteLine();
                Console.WriteLine("Food Items:");
                foreach (FoodItem foodItem in foodItemList)
                {
                    Console.WriteLine($"ID: {foodItem.ItemID}\tName: {foodItem.Name}");
                }
                Console.WriteLine();
            }

            FoodItem GetFoodItemByID(List<FoodItem> foodItemList, int itemID)
            {
                FoodItem foundFoodItem = null;
                foreach(FoodItem foodItem in foodItemList)
                {
                    if (foodItem.ItemID == itemID)
                    {
                        foundFoodItem = foodItem;
                        break;
                    }
                }
                return foundFoodItem;
            }

            int LatestAvailableItemID(List<FoodItem> foodItemList)
            {
                if (foodItemList.Count == 0)
                    return 1;
                else
                    return foodItemList[foodItemList.Count - 1].ItemID + 1;
            }
        }
    }
}
// Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 