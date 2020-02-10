using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class ItemMenu
    {
        private string name;
        private string description;
        private double price;
        private int unit; // How much stock left
        private string status;
        private Category category;
        private List<OrderItem> orderitems;
        private SetMenu setmenu;

        public ItemMenu(string name, string description, double price, int unit, string status, Category category, SetMenu setmenu)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.unit = unit;
            this.status = status;
            this.category = category;
            this.setmenu = setmenu;
            orderitems = new List<OrderItem>();
        }

        public string getName()
        {
            return name;
        }

        public double getPrice()
        {
            return price;
        }

        

        public void addItem()
        {

        }

        public void removeItem()
        {

     
        }

        public void updateItem()
        {

        }



    }
}
