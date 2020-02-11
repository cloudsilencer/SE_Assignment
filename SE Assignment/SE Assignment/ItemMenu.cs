using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class ItemMenu
    {
        private int itemID;
        private string name;
        private string description;
        private double price;
        private int unit; // How much stock left
        private string status;
        private Category category;
        private SetMenu setMenu;
        private List<OrderItem> orderItems;

        public ItemMenu(int itemID, string name, string description, double price, int unit, string status, Category category, SetMenu setMenu)
        {
            this.itemID = itemID;
            this.name = name;
            this.description = description;
            this.price = price;
            this.unit = unit;
            this.status = status;
            this.category = category;
            this.setMenu = setMenu;
            this.orderItems = new List<OrderItem>();

            // Add Item To The Set Menu
            this.setMenu.addItem(this);
        }

        public int getItemID()
        {
            return itemID;
        }

        public void setItemID(int itemID)
        {
            this.itemID = itemID;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public double getPrice()
        {
            return price;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public double getUnit()
        {
            return unit;
        }

        public void setUnit(int unit)
        {
            this.unit = unit;
        }

        public string getStatus()
        {
            return status;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public Category getCategory()
        {
            return category;
        }

        public void setCategory(Category category)
        {
            this.category = category;
        }

        public SetMenu getSetMenu()
        {
            return setMenu;
        }

        public void setSetMenu(SetMenu setMenu)
        {
            this.setMenu = setMenu;
        }

        public List<OrderItem> getOrderItems()
        {
            return orderItems;
        }

        public void setOrderItems(List<OrderItem> orderItems)
        {
            this.orderItems = orderItems;
        }

        public override string ToString()
        {
            
            return $"Name: {getName()}\n" +
                   $"Description: {getDescription()}\n" +
                   $"Price: {getPrice()}\n" +
                   $"Unit: {getUnit()}\n" +
                   $"Status: {getStatus()}\n" +
                   $"Category: {getCategory().GetCategoryName()}\n" +
                   $"Set Menu: {getSetMenu().getSetMenuItem()}\n";
        }
    }
}