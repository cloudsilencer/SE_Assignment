using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class FoodItem
    {
        private int itemID;
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private int unit;
        public int Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private Category category;
        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        private SetMenu setMenu;
        public SetMenu SetMenu
        {
            get { return setMenu; }
            set { setMenu = value; }
        }

        private List<OrderItem> orderItems;
        public List<OrderItem> OrderItems
        {
            get { return orderItems; }
            set { orderItems = value; }
        }


        public FoodItem(int itemID, string name, string description, double price, int unit, string status, Category category, SetMenu setMenu)
        {
            ItemID = itemID;
            Name = name;
            Description = description;
            Price = price;
            Unit = unit;
            Status = status;
            Category = category;
            SetMenu = setMenu;
            OrderItems = new List<OrderItem>();

            // Add Item To The Set Menu
            SetMenu.AddItem(this);
        }

        public override string ToString()
        {
            
            return $"Name: {Name}\n" +
                   $"Description: {Description}\n" +
                   $"Price: {Price}\n" +
                   $"Unit: {Unit}\n" +
                   $"Status: {Status}\n" +
                   $"Category: {Category.CategoryName}\n" +
                   $"Set Menu: {SetMenu.SetMenuName}\n";
        }
    }
}