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
        private int unit;
        private string status;
        private int size;
        private Category category;
        private SetMenu setmenu;

        public ItemMenu(string name, string description, double price, int unit, string status, int size, Category category, SetMenu setmenu)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.unit = unit;
            this.status = status;
            this.size = size;
            this.category = category;
            this.setmenu = setmenu;
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
