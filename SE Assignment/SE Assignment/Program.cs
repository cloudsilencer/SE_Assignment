using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            List<Manager> managers = new List<Manager>();
            List<StoreAssistant> storeassistant = new List<StoreAssistant>();
            List<Chef> chef = new List<Chef>();
            List<Dispatcher> dispatcher = new List<Dispatcher>();

            List<Employee> employees = new List<Employee>();
            List<Branch> branches = new List<Branch>();
            List<Order> orders = new List<Order>();
            List<Payment> payments = new List<Payment>();
            InitializeData();

            //OrderStatusIterator orderStatusIterator = new OrderStatusIterator(orders, "New");
            //while (orderStatusIterator.hasNext())
            //{
                //Order order = (Order)orderStatusIterator.next();
                //Console.WriteLine($"Order ID: {order.getOrderNum()}");
                //Console.WriteLine();
                //order.ToString();
                //Console.WriteLine();
            //}

            bool login = false;
            Customer currentCust = new Customer();

            Employee currentEmployee = new Employee();

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
                // Create New Order Object
                Order newOrder = new Order(orders.Count.ToString(), currentCust, DateTime.Now, "New");
                currentCust.addOrder(newOrder);

                // Executes Select Restaurant Use case
                newOrder.setBranch(selectRestaurant());

                List<string> options = new List<string>(); // For validations

                // Selection of Filter and Displaying Food Items

                while (true) // To allow customers to add more items into Order
                {
                    List<FoodItem> displayList = new List<FoodItem>();
                    OrderItem selected = new OrderItem();
                    Console.WriteLine("How would you like to filter the menu?\n1. Categories\n2. Set Menu"); // System prompts

                    while (true) // Validation for invalid filter choice
                    {
                        string filterChoice = Console.ReadLine();
                        if (filterChoice == "1")
                        {
                            options = new List<string>(); // For validation
                            Console.WriteLine("Please select a Category");
                            for (int i = 1; i <= categories.Count; i++) // System retrieves and display categories
                            {
                                Console.WriteLine((i) + ". " + categories[i - 1].CategoryName);
                                options.Add(i.ToString());
                            }

                            string catChoice = "";
                            while (true) // Validation for invalid Category chice
                            {
                                catChoice = Console.ReadLine();
                                if (options.Contains(catChoice))
                                    break;
                                else
                                    Console.WriteLine("Error! Please select a valid category."); // System display error message
                            }

                            foreach (FoodItem item in foodItems) // System retrieve food item from selected category
                            {
                                if (item.Category == categories[Convert.ToInt32(catChoice)])
                                    displayList.Add(item);
                            }
                            break;
                        }

                        else if (filterChoice == "2")
                        {
                            options = new List<string>(); // For Validation
                            Console.WriteLine("Please select a Set Menu");
                            for (int i = 1; i <= setMenus.Count; i++) // System retrieve and display set menus
                            {
                                Console.WriteLine((i) + ". " + setMenus[i - 1].SetMenuName);
                                options.Add(i.ToString());
                            }

                            string setChoice = "";
                            while (true) // Validation for invalid set menu chocie
                            {
                                setChoice = Console.ReadLine();
                                if (options.Contains(setChoice))
                                    break;
                                else
                                    Console.WriteLine("Error! Please select a valid Set Menu."); // System display error message
                            }

                            foreach (FoodItem item in foodItems) // System retrieves food items from selected set menu
                            {
                                if (item.SetMenu == setMenus[Convert.ToInt32(setChoice)])
                                    displayList.Add(item);
                            }
                            break;
                        }
                        else
                            Console.WriteLine("Error! Please select a valid filter."); // System display error message
                    }

                    Console.WriteLine("Please select a food item");

                    options = new List<string>(); // For validation
                    for (int i = 1; i <= displayList.Count; i++) // System display all food items based on filter
                    {
                        Console.WriteLine((i) + ". " + displayList[i - 1].Name);
                        options.Add(i.ToString());
                    }

                    string foodchoice = "";
                    while (true) // Validation for invalid food item selected
                    {
                        foodchoice = Console.ReadLine();
                        if (options.Contains(foodchoice))
                            break;
                        else
                            Console.WriteLine("Error! Please select a valid food item."); // System display error message
                    }

                    Console.Write("How many would you like? ");
                    string quantity = "";

                    while (true) // Validation for invalid quantity selected 
                    {
                        quantity = Console.ReadLine();
                        if (int.TryParse(quantity, out _))
                        {
                            if (Convert.ToInt32(quantity) > 100)
                                Console.WriteLine("Error! We do not have enough stock! Please select another quantity"); // System display error message
                            else if (Convert.ToInt32(quantity) <= 0)
                                Console.WriteLine("Error! Please select a valid quantity."); // System display error message
                            else
                                break;
                        }
                        else
                            Console.WriteLine("Error! Please select a valid quantity."); // System display error message
                    }

                    FoodItem selectedFood = displayList[Convert.ToInt32(foodchoice) - 1];
                    int loopIndex = 0;
                    bool duplicatedFound = false;
                    foreach (OrderItem orderItems in newOrder.getOrderItems()) //Check if Food Item selected is already in Order
                    {
                        if (orderItems.getItem() == selectedFood)
                        {
                            int totalQty = orderItems.getQuantity() + Convert.ToInt32(quantity);
                            newOrder.getOrderItems()[loopIndex].setQuantity(totalQty); //If in order, update quantity
                            duplicatedFound = true;
                            break;
                        }
                        loopIndex++;
                    }
                    if (!duplicatedFound)
                    {
                        selected = new OrderItem(selectedFood, Convert.ToInt32(quantity), newOrder);
                        newOrder.addItem(selected);
                    }

                    Console.WriteLine("Would you like to add more items? (Y/N)");
                    while (true) // Validation for invalid option chosen
                    {
                        string option = Console.ReadLine();
                        if (option == "N")
                        {
                            checkOut(newOrder, cust);
                            break;
                        }
                        else if (option == "Y")
                            break;
                        else
                            Console.WriteLine("Error! Please select either Y or N."); // System display error message
                    }
                }
            }

            // Place Order (Dominic)

            Branch selectRestaurant()
            {
                // Executes Select Restaurant Use case
                List<string> options = new List<string>(); // For validation
                Console.WriteLine("Please select an outlet from below");
                for (int i = 1; i <= branches.Count; i++) // System retrieve all branches
                {
                    Console.WriteLine((i) + ". " + branches[i - 1].getBranchName());
                    options.Add(i.ToString());
                }

                string choice = "";
                while (true) // Validation for invalid outlet chosen
                {
                    choice = Console.ReadLine();
                    if (options.Contains(choice))
                        break;
                    else
                        Console.WriteLine("Error! Please select a valid outlet."); // System display error message
                }
                return branches[Convert.ToInt32(choice) - 1];
            }

            // Place Order (Dominic)

            void checkOut(Order coOrder, Customer cust)
            {
                processOrder(coOrder);
                Console.WriteLine("\n Order Summary");
                coOrder.ToString();
                Console.WriteLine("\nWould you like express delivery? (Y/N)");
                string delivery = "";
                while (true) // Validation for express delivery
                {
                    delivery = Console.ReadLine();
                    if (delivery == "Y") //if "N", already set to Default and 0
                    {
                        coOrder.expressDelivery(); // System executes express delivery use case
                        break;
                    }
                    else if (delivery == "N")
                    {
                        coOrder.normalDelivery();
                        break;
                    }
                    else
                        Console.WriteLine("Please enter a valid option"); // System display error message
                }

                Console.WriteLine("\n Order Summary");
                coOrder.displayReceipt();
                coOrder.makePayment(payments);
            }

            // Place Order (Dominic)

            void processOrder(Order pOrder) //Calculate the subtotal and total amount in Order
            {
                double subTotal = pOrder.getSubTotal();
                foreach (OrderItem item in pOrder.getOrderItems())
                {
                    subTotal += (item.getItem().Price * item.getQuantity()) + pOrder.getDeliveryCharge();
                }
                pOrder.setSubTotal(subTotal);
                pOrder.setTotalAmt((subTotal * pOrder.getGST() / 100) + subTotal);
                pOrder.setStatus("Process");
            }



            // View all Orders (Li Yun)
             void viewOrders(Customer cust)
             {
                Console.WriteLine("\n All Orders:");

                foreach (Order o in orders)
                {
                    if (cust == o.getCust())
                    {
                        if (o.getOrderItems().Count == 0)
                        {
                            Console.WriteLine("No Order Records Found!");
                        }
                        
                        else
                        {
                            String date = o.getOrderDate().ToString("dd/MM/yyy");
                            Console.WriteLine("\n" + $"Order Number {o.getOrderNum()} placed on {date}");

                            foreach (OrderItem item in o.getOrderItems())
                            {
                                Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                            }

                            // Console.WriteLine($"Total amount paid: {o.getTotalAmt()}");

                            // run view current or past orders method
                            CurrentOrPastOrder(currentCust);

                        }

                    }

                    
                }

             }

            void CurrentOrPastOrder(Customer cust)
            {
                Console.WriteLine("\n");
                Console.WriteLine("View Current or Past order(s):");
                Console.WriteLine(" 1. Current order(s)");
                Console.WriteLine(" 2. Past order(s)");

                string choice = Console.ReadLine();

                // current order selection
                if (choice == "1")
                {
                    foreach (Order o in orders)
                    {
                        if (cust == o.getCust())
                        {
                            if (o.getOrderDate() == DateTime.Today)
                            {
                                String date = DateTime.Today.ToString("dd/MM/yyy");

                                Console.WriteLine("\n" + "Your current order(s):");
                                Console.WriteLine("\n" + $"Order Number: {o.getOrderNum()} at {date}");

                                foreach (OrderItem item in o.getOrderItems())

                                {
                                    Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n" + "No Current Order Records Found!");
                            }

                            

                        }
                    }
                }

                // past order selection
                if (choice == "2")
                {

                    foreach (Order o in orders)
                    {
                        if (cust == o.getCust())
                        {
                            if(o.getOrderDate() != DateTime.Today)
                            {
                                String date = o.getOrderDate().ToString("dd/MM/yyy");

                                Console.WriteLine("\n" + "Your past order(s):");
                                Console.WriteLine($"Order Number: {o.getOrderNum()} at {date}");

                                foreach (OrderItem item in o.getOrderItems())
                                {
                                    Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                                }

                            }
                            else
                            {
                                Console.WriteLine("\n" + "No Past Order Records Found!");
                            }
                            

                        }

                    }

                }

                Console.ReadKey();

            }

            // Use Case 1 - Select and Prepare Order (Qi Quan)
            void SelectCustOrder()
            {
                List<Order> availOrders = new List<Order>();

                foreach (Order o in orders.Where(order => order.getState() is OrderPlacedState))
                {
                    availOrders.Add(o);

                    Console.WriteLine("\n" + $"Order Number {o.getOrderNum()} placed on {o.getOrderDate()}");

                    foreach (OrderItem item in o.getOrderItems())
                    {

                        Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                    }
                }

                if (availOrders.Count == 0)
                {
                    Console.WriteLine("No Orders Found\n");
                }

                else
                {
                    while (true)
                    {
                        Console.WriteLine("Select order: ");
                        string selectedOrderNumber = Console.ReadLine();
                        Order selectedOrder = availOrders.FirstOrDefault(order => order.getOrderNum() == selectedOrderNumber);

                        if (selectedOrder != null)
                        {
                            Console.WriteLine(String.Format("You have selected Order {0}, please confirm. (Yes / No)", selectedOrderNumber));
                            string confirmation = Console.ReadLine();

                            if (confirmation == "Yes" || confirmation == "yes")
                            {
                                OrderPreparingState orderPreparing = new OrderPreparingState(selectedOrder);
                                selectedOrder.setState(orderPreparing);

                                Console.WriteLine("Enter estimated time for preparation (Example 06:00 for 6 minutes or 00:30 for 30 seconds): ");
                                TimeSpan preparationTime = new TimeSpan();

                                while (true)
                                {
                                    try
                                    {
                                        preparationTime = TimeSpan.ParseExact(Console.ReadLine(), "mm':'ss", null);

                                        while (preparationTime != TimeSpan.Zero)
                                        {
                                            Console.WriteLine(String.Format("Remaining Time: {0:mm\\:ss}", preparationTime));
                                            preparationTime = preparationTime.Subtract(TimeSpan.FromSeconds(1));
                                            Thread.Sleep(1000);
                                        }

                                        Console.WriteLine("Remaining Time: 00:00");
                                        Console.WriteLine("Food has finished preparing.\n");
                                        for (int i = 0; i < 5; i++)
                                        {
                                            Console.Beep(1500, 200);
                                        }
                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\nInvalid format entered.");
                                        Console.WriteLine("Please re-enter estimated time for preparation (Example 06:00 for 6 minutes or 00:30 for 30 seconds): ");
                                        continue;
                                    }
                                }  
                            }
                            else
                            {
                                Console.WriteLine("Please select a different order to prepare.\n");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine(String.Format("No order with order number {0}, please enter a proper order number.\n", selectedOrderNumber));
                            continue;
                        }

                        break;
                    }                    
                }
            }

            // Use Case 2 - Update Order Status (Qi Quan)
            void UpdateCustOrder()
            {
                List<Order> preparingOrders = new List<Order>();

                foreach (Order o in orders.Where(order => order.getState() is OrderPreparingState))
                {
                    preparingOrders.Add(o);

                    Console.WriteLine("\n" + $"Order Number {o.getOrderNum()} placed on {o.getOrderDate()}");

                    foreach (OrderItem item in o.getOrderItems())
                    {
                        Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                    }
                }

                if (preparingOrders.Count == 0)
                {
                    Console.WriteLine("No orders being prepared now\n");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Select order that is ready for delivery.");
                        string selectedOrderNumber = Console.ReadLine();
                        Order selectedOrder = preparingOrders.FirstOrDefault(order => order.getOrderNum() == selectedOrderNumber);

                        if (selectedOrder != null)
                        {
                            Console.WriteLine(String.Format("You have selected Order {0}, please confirm. (Yes / No)", selectedOrderNumber));
                            string confirmation = Console.ReadLine();

                            if (confirmation == "Yes" || confirmation == "yes")
                            {
                                OrderReadyState orderReady = new OrderReadyState(selectedOrder);
                                selectedOrder.setState(orderReady);

                                Console.WriteLine(String.Format("Order {0} is ready for collection. Dispatcher has been notified.\n", selectedOrderNumber));
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please select a different order.\n");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine(String.Format("No order with order number {0}, please enter a proper order number.\n", selectedOrderNumber));
                            continue;
                        }
                    }                    
                }
            }

            // Use Case 3 - Dispatch Order (Qi Quan)
            void DispatchCustOrder()
            {
                List<Order> readyOrders = new List<Order>();

                foreach (Order o in orders.Where(order => order.getState() is OrderReadyState))
                {
                    readyOrders.Add(o);

                    Console.WriteLine("\n" + $"Order Number {o.getOrderNum()} placed on {o.getOrderDate()}");

                    foreach (OrderItem item in o.getOrderItems())
                    {
                        Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                    }
                }

                if (readyOrders.Count == 0)
                {
                    Console.WriteLine("No orders are ready for delivery now\n");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Select order to be dispatched.");
                        string selectedOrderNumber = Console.ReadLine();
                        Order selectedOrder = readyOrders.FirstOrDefault(order => order.getOrderNum() == selectedOrderNumber);

                        if (selectedOrder != null)
                        {
                            Console.WriteLine(String.Format("You have selected Order {0}, please confirm. (Yes / No)", selectedOrderNumber));
                            string confirmation = Console.ReadLine();

                            if (confirmation == "Yes" || confirmation == "yes")
                            {
                                OrderDispatchedState orderDispatched = new OrderDispatchedState(selectedOrder);
                                selectedOrder.setState(orderDispatched);

                                Console.WriteLine(String.Format("Order {0} has been dispatched for delivery.\n", selectedOrderNumber));
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please select a different order.\n");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine(String.Format("No order with order number {0}, please enter a proper order number.\n", selectedOrderNumber));
                            continue;
                        }
                    }
                }
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

                while (!isSetMenuNameValid)
                {
                    Console.Write("Please enter a name for the new Set Menu: ");
                    setMenuName = Console.ReadLine();
                    if (setMenuName == "")
                        Console.WriteLine("Set Menu name cannot be empty!");
                    else
                    {
                        if (CheckSetMenuNameExists(GetAllSetMenuName(setMenus), setMenuName))
                            Console.WriteLine($"Set Menu: {setMenuName} already exists! Please enter another different name!");
                        else
                        {
                            isSetMenuNameValid = true;
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
                string confirmation = "";
                bool isSetMenuIDValid = false;
                bool isConfirmationValid = false;
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
                                isSetMenuIDValid = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format, Set Menu ID is a number. \t Example: 1");
                        }
                    }
                }
                Console.WriteLine();
                while (!isConfirmationValid)
                {
                    Console.Write($"Confirm the removal of Set Menu: {GetSetMenuByID(setMenus, int.Parse(setMenuID)).SetMenuName}? (Y/N) :");
                    confirmation = Console.ReadLine();
                    switch (confirmation)
                    {
                        case "Y":
                            Console.WriteLine($"Set Menu: {GetSetMenuByID(setMenus, int.Parse(setMenuID)).SetMenuName} was removed.\n");
                            setMenus.Remove(GetSetMenuByID(setMenus, int.Parse(setMenuID)));
                            isConfirmationValid = true;
                            break;
                        case "N":
                            Console.WriteLine($"Removal of Set Menu: {GetSetMenuByID(setMenus, int.Parse(setMenuID)).SetMenuName} was cancelled.\n");
                            isConfirmationValid = true;
                            break;
                        default:
                            Console.WriteLine("Invalid response. Please enter 'Y' for Yes or 'N' for No");
                            break;
                    }
                }
            }

            // Use Case 8 - Update Set Menu (Kevin)
            void UpdateSetMenu()
            {
                string functionTitle = "Update Set Menu";
                Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}\n");
                DisplayAllSetMenus(setMenus);

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
                                isSetMenuIDValid = true;
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
                        if (CheckSetMenuNameExists(GetAllSetMenuName(setMenus), setMenuNameToUpdate) && (setMenuNameToUpdate != setMenuToBeUpdated.SetMenuName))
                        {
                            Console.WriteLine("Name for Set Menu already exists");
                        }
                        else
                        {
                            isUpdatedSetMenuNameValid = true;
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
                            Console.WriteLine($"Status can only be either 'Available' or 'Unavailable'");
                    }
                }

                DisplayAllCategories(categories);
                while (!isCategoryValid)
                {
                    Console.Write("Please enter the Category ID: ");
                    category = Console.ReadLine();
                    if (category == "")
                        Console.WriteLine($"Category ID for {foodName} cannot be empty");
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
                        Console.WriteLine($"Set Menu ID for {foodName} cannot be empty");
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
                            Console.WriteLine($"Removal of Food Item: {GetFoodItemByID(foodItems, int.Parse(itemID)).Name} was cancelled.\n");
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
                bool isFieldValid = false;

                while (!isFieldValid)
                {
                    Console.Write("Please enter the field to be updated: ");
                    fieldToUpdate = Console.ReadLine();
                    switch(fieldToUpdate)
                    {
                        case "Name":
                            isFieldValid = true;
                            bool isNameValid = false;
                            while (!isNameValid)
                            {
                                Console.WriteLine($"Current Name: {itemToBeUpdated.Name}");
                                Console.Write("Updated Name: ");
                                string updatedName = Console.ReadLine();
                                if (updatedName == "")
                                    Console.WriteLine("\nName cannot be empty!\n");
                                else if (CheckFoodNameExists(GetAllFoodItemName(foodItems), updatedName) && (updatedName != itemToBeUpdated.Name))
                                    Console.WriteLine("\nName entered is similar to another food item!\n");
                                else
                                {
                                    Console.WriteLine($"Name successfully updated from '{itemToBeUpdated.Name}' to '{updatedName}'.\n");
                                    isNameValid = true;
                                    itemToBeUpdated.Name = updatedName;
                                }
                            }
                            break;
                        case "Description":
                            isFieldValid = true;
                            bool isDescriptionValid = false;
                            while (!isDescriptionValid)
                            {
                                Console.WriteLine($"Current Description: {itemToBeUpdated.Description}");
                                Console.Write("Updated Description: ");
                                string updatedDescription = Console.ReadLine();
                                if (updatedDescription == "")
                                    Console.WriteLine("\nDescription entered cannot be empty!\n");
                                else
                                {
                                    Console.WriteLine($"Description successfully updated from '{itemToBeUpdated.Description}' to '{updatedDescription}'.\n");
                                    isDescriptionValid = true;
                                    itemToBeUpdated.Description = updatedDescription;
                                }
                            }
                            break;
                        case "Price":
                            isFieldValid = true;
                            bool isPriceValid = false;
                            while (!isPriceValid)
                            {
                                Console.WriteLine($"Current Price ($): {itemToBeUpdated.Price}");
                                Console.Write("Updated Price ($): ");
                                string updatedPrice = Console.ReadLine();
                                if (updatedPrice == "")
                                    Console.WriteLine("\nPrice entered cannot be empty!\n");
                                else
                                {
                                    try
                                    {
                                        double convertedPrice = double.Parse(updatedPrice);
                                        if (convertedPrice <= 0.00)
                                            Console.WriteLine("Price cannot be $0 or less.");
                                        else
                                        {
                                            Console.WriteLine($"Price successfully updated from ${itemToBeUpdated.Price} to ${double.Parse(updatedPrice)}.\n");
                                            isPriceValid = true;
                                            itemToBeUpdated.Price = double.Parse(updatedPrice);
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid format, price should be in the format of X.XX\t Example: 4.90");
                                    }
                                }
                            }
                            break;
                        case "Unit":
                            isFieldValid = true;
                            bool isUnitValid = false;
                            while (!isUnitValid)
                            {
                                Console.WriteLine($"Current Unit (Stock): {itemToBeUpdated.Unit}");
                                Console.Write("Updated Unit: ");
                                string updatedUnit = Console.ReadLine();
                                if (updatedUnit == "")
                                    Console.WriteLine("\nUnit entered cannot be empty!\n");
                                else
                                {
                                    try
                                    {
                                        int convertedUnit = int.Parse(updatedUnit);
                                        if (convertedUnit < 0)
                                            Console.WriteLine("Unit cannot be less than 0.");
                                        else
                                        {
                                            Console.WriteLine($"Unit successfully updated from {itemToBeUpdated.Unit} to {int.Parse(updatedUnit)}.\n");
                                            isUnitValid = true;
                                            itemToBeUpdated.Unit = int.Parse(updatedUnit);
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid format, unit should be an integer\t Example: 100");
                                    }
                                }
                            }                   
                            break;
                        case "Status":
                            isFieldValid = true;
                            bool isStatusValid = false;
                            while (!isStatusValid)
                            {
                                Console.WriteLine($"Current Status: {itemToBeUpdated.Status}");
                                Console.Write("Updated Status ('Available' or 'Unavailable'): ");
                                string updatedStatus = Console.ReadLine();
                                if (updatedStatus == "")
                                    Console.WriteLine($"Status for Food Item: {itemToBeUpdated.Name} cannot be empty");
                                else
                                {
                                    if (isAValidStatus(updatedStatus))
                                    {
                                        Console.WriteLine($"Status successfully updated from {itemToBeUpdated.Status} to {updatedStatus}.\n");
                                        isStatusValid = true;
                                        itemToBeUpdated.Status = updatedStatus;
                                    }
                                    else
                                        Console.WriteLine($"Status only can be either 'Available' or 'Unavailable'");
                                }
                            }
                            break;
                        case "Category":
                            isFieldValid = true;
                            bool isCategoryValid = false;
                            DisplayAllCategories(categories);
                            while (!isCategoryValid)
                            {
                                Console.WriteLine($"Current Category: {itemToBeUpdated.Category.CategoryName}");
                                Console.Write("Updated Category (Enter the ID): ");
                                string updatedCategoryID = Console.ReadLine();
                                if (updatedCategoryID == "")
                                    Console.WriteLine($"Updated Category ID for {itemToBeUpdated.Name} cannot be empty");
                                else
                                {
                                    try
                                    {
                                        int convertedCategory = int.Parse(updatedCategoryID);
                                        if (GetCategoryByID(categories, convertedCategory) == null)
                                            Console.WriteLine($"Category ID: {updatedCategoryID} does not exist");
                                        else
                                        {
                                            Console.WriteLine($"Category successfully updated from {itemToBeUpdated.Category.CategoryName} to {GetCategoryByID(categories, int.Parse(updatedCategoryID)).CategoryName}.\n");
                                            isCategoryValid = true;
                                            itemToBeUpdated.Category = GetCategoryByID(categories, int.Parse(updatedCategoryID));
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid format, Category ID is a number. \t Example: 1");
                                    }
                                }
                            }
                            break;
                        case "Set Menu":
                            isFieldValid = true;
                            bool isSetMenuValid = false;
                            DisplayAllSetMenus(setMenus);
                            while (!isSetMenuValid)
                            {
                                Console.WriteLine($"Current Set Menu: {itemToBeUpdated.SetMenu.SetMenuName}");
                                Console.Write("Updated Set Menu (Enter the ID): ");
                                string updatedSetMenuID = Console.ReadLine();
                                if (updatedSetMenuID == "")
                                    Console.WriteLine($"Set Menu ID for {itemToBeUpdated.Name} cannot be empty");
                                else
                                {
                                    try
                                    {
                                        int convertedSetMenu = int.Parse(updatedSetMenuID);
                                        if (GetSetMenuByID(setMenus, convertedSetMenu) == null)
                                            Console.WriteLine($"Set Menu ID: {updatedSetMenuID} does not exist");
                                        else
                                        {
                                            Console.WriteLine($"Set Menu successfully updated from {itemToBeUpdated.SetMenu.SetMenuName} to {GetSetMenuByID(setMenus, int.Parse(updatedSetMenuID)).SetMenuName}.\n");
                                            isSetMenuValid = true;
                                            itemToBeUpdated.SetMenu = GetSetMenuByID(setMenus, int.Parse(updatedSetMenuID));
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid format, set Menu ID is a number. \t Example: 1");
                                    }
                                }
                            }
                            break;
                        default:
                            Console.WriteLine($"{fieldToUpdate} is not a valid field!\n");
                            break;
                    }           
                }

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

                Order order1 = new Order("1", cust1, DateTime.Now, "Cancelled");
                OrderCancelledState cancelled1 = new OrderCancelledState(order1);
                order1.setState(cancelled1);
                Order order2 = new Order("2", cust2, DateTime.Now.AddDays(-2), "Delivered");
                OrderDeliveredState delivered1 = new OrderDeliveredState(order2);
                order2.setState(delivered1);
                Order order3 = new Order("3", cust3, DateTime.Now, "New");
                Order order4 = new Order("4", cust3, DateTime.Now.AddDays(-1), "New");
                Order order5 = new Order("5", cust3, DateTime.Now.AddDays(-4), "New");


                order1.addItem(new OrderItem(itemMenu3, 2, order1));
                order1.addItem(new OrderItem(itemMenu7, 2, order1));
                order2.addItem(new OrderItem(itemMenu1, 1, order2));
                order3.addItem(new OrderItem(itemMenu10, 2, order3));
                order3.addItem(new OrderItem(itemMenu8, 2, order3));
                order4.addItem(new OrderItem(itemMenu2, 5, order4));
                order5.addItem(new OrderItem(itemMenu6, 3, order5));
                order5.addItem(new OrderItem(itemMenu4, 1, order5));

                orders.Add(order1);
                orders.Add(order2);
                orders.Add(order3);
                orders.Add(order4);
                orders.Add(order5);

                Payment payment1 = new Payment("1", order1, 100.00, DateTime.Now, "Online");
                Payment payment2 = new Payment("2", order2, 200.00, DateTime.Now, "Online");
                Payment payment3 = new Payment("3", order3, 10.00, DateTime.Now, "Online");

                payments.Add(payment1);
                payments.Add(payment2);
                payments.Add(payment3);

                // Start The Clock
                Clock clock = Clock.getInstance();

                //Dispatcher dispatcher1 = new Dispatcher(50, "S9213724G", "Male", "Employed", new DateTime(2017, 10, 19), branch1, clock);
                //Dispatcher dispatcher2 = new Dispatcher(51, "S9605134B", "Female", "Employed", new DateTime(2018, 2, 25), branch1, clock);

                Manager manager1 = new Manager(52, "S9839890F", "Male", "Employed", new DateTime(2019, 3, 20), branch2, acc4, "ky@gmail.com", "Manager");



                StoreAssistant sa1 = new StoreAssistant(1001, "S9839890F", "Male", "Employed", new DateTime(2019, 3, 20), branch2, acc4, "virus@gmail.com", "StoreAssistant");

                Chef chf1 = new Chef(2001, "S9839889F", "Male", "Employed", new DateTime(2019, 3, 20), branch2, acc4, "corona@gmail.com", "Chef");

                Dispatcher d1 = new Dispatcher(3001, "S9899890F", "Female", "Employed", new DateTime(2019, 3, 20), branch2, acc4, "wuhan@gmail.com", "Dispatcher", clock);
                //employees.Add(dispatcher1);
                //employees.Add(dispatcher2);
                employees.Add(manager1);
                employees.Add(sa1);
                employees.Add(chf1);
                employees.Add(d1);


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
                            string employeetypem = "Manager";
                            Console.WriteLine("Login as Manager");
                            Console.Write("Email: ");
                            string emailm = Console.ReadLine();
                            Console.Write("Password: ");
                            string passm = Console.ReadLine();

                            foreach (Employee e in employees)
                            {
                       
                                if (emailm == e.getEmail() && passm == e.getAccount().getPassword() && employeetypem == e.getEmployeeType())
                                {
                                    login = true;
                                    currentEmployee = e;
                                    DisplayManagerMenu();
                                    break;
                                }
                            }
                            if(login != true)
                            {
                                Console.WriteLine("Invalid email and password!");
                            }
                            break;
                            
                            
                        case "2":
                            string employeetypec= "Chef";
                            Console.WriteLine("Login as Chef");
                            Console.Write("Email: ");
                            string emailc = Console.ReadLine();
                            Console.Write("Password: ");
                            string passc = Console.ReadLine();

                            foreach (Employee e in employees)
                            {
                          
                                if (emailc == e.getEmail() && passc == e.getAccount().getPassword() && employeetypec == e.getEmployeeType())
                                {
                                    login = true;
                                    currentEmployee = e;
                                    DisplayChefMenu();
                                    break;
                                }
                            }
                            if (login != true)
                            {
                                Console.WriteLine("Invalid email and password!");
                            }                                     
                            break;
                        case "3":
                            string employeetyped = "Dispatcher";
                            Console.WriteLine("Login as Dispatcher");
                            Console.Write("Email: ");
                            string emaild = Console.ReadLine();
                            Console.Write("Password: ");
                            string passd = Console.ReadLine();

                            foreach (Employee e in employees)
                            {

                                if (emaild == e.getEmail() && passd == e.getAccount().getPassword() && employeetyped == e.getEmployeeType())
                                {
                                    login = true;
                                    currentEmployee = e;
                                    // DisplayDispatcher();
                                    break;
                                }
                            }
                            if (login != true)
                            {
                                Console.WriteLine("Invalid email and password!");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid option selected");
                            break;
                    }
                }
                while (selectedOption != "0");
            }

            void ViewAllCustOrder()
            {
                Console.WriteLine("Please select order type: ");
                Console.WriteLine("[1] New");
                Console.WriteLine("[2] Cancelled");
                Console.WriteLine("[3] Delivered");

                //Console.WriteLine("Login as Customer");
                //Console.Write("Email: ");
                //string email = Console.ReadLine();
                //Console.Write("Password: ");
                //string pass = Console.ReadLine();


                string vieworderoption = Console.ReadLine();

                if(vieworderoption == "1")
                {
                    vieworderoption = "New";
                }
                else if (vieworderoption == "2")
                {
                    vieworderoption = "Cancelled";
                }
                else if (vieworderoption == "3")
                {
                    vieworderoption = "Delivered";
                }
                else if (vieworderoption == "4")
                {
                    vieworderoption = "Preparing";
                }
                else if (vieworderoption == "5")
                {
                    vieworderoption = "Ready";
                }
                else if (vieworderoption == "6")
                {
                    vieworderoption = "Dispatched";
                }
                else if (vieworderoption == "7")
                {
                    vieworderoption = "Archived";
                }

                OrderStatusIterator orderStatusIterator = new OrderStatusIterator(orders, vieworderoption);
                while (orderStatusIterator.hasNext())
                { 
                    Order o = (Order)orderStatusIterator.next();
                    Console.WriteLine("\n" + $"Order Number {o.getOrderNum()} placed on {o.getOrderDate()} status: {o.getOrderStatus()}");

                    foreach (OrderItem item in o.getOrderItems())
                    {

                        Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                    }
                    Console.WriteLine();
                }

                /*
                foreach (Order o in orders)
                {

                    if (o.getOrderStatus() == vieworderoption)
                    {
                        Console.WriteLine("\n" + $"Order Number {o.getOrderNum()} placed on {o.getOrderDate()} status: {o.getOrderStatus()}");

                        foreach (OrderItem item in o.getOrderItems())
                        {

                            Console.WriteLine($"{item.getQuantity()} qty of {item.getItem().Name}");
                        }
                    }
                }
                */
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
                            ViewAllCustOrder();
                            break;
                        default:
                            Console.WriteLine("Invalid option selected");
                            break;
                    }
                }

                while (selectedOption != "0");
            }

            void DisplayChefMenu()
            {
                string functionTitle = "Chef Menu";
                List<String> chefMenuOptions = new List<String>() { "Select Order to Prepare", "Update Order", "Dispatch Order", "Exit" };
                String selectedOption = "";
                do
                {
                    Console.WriteLine($"{functionTitle}\n{MultiplyString("-", functionTitle.Length)}");
                    for (int i = 0; i < chefMenuOptions.Count; i++)
                    {
                        if (((i + 1) % 4) == 0)
                            Console.WriteLine($"\n[{(i + 1) % 4}] {chefMenuOptions[i]}");
                        else
                            Console.WriteLine($"[{(i + 1) % 4}] {chefMenuOptions[i]}");
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
                            SelectCustOrder();
                            break;
                        case "2":
                            UpdateCustOrder();
                            break;
                        case "3":
                            DispatchCustOrder();
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