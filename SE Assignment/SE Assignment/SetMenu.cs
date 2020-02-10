using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class SetMenu
    {
        private int setMenuID;
        private string setMenuItem;
        private List<ItemMenu> itemMenuList;
        private int size;

        public SetMenu(int setMenuID, string setMenuItem)
        {
            this.setMenuID = setMenuID;
            this.setMenuItem = setMenuItem;
            this.itemMenuList = new List<ItemMenu>();
            this.size = this.itemMenuList.Count();
        }

        public int getSetMenuID()
        {
            return setMenuID;
        }

        public string getSetMenuItem()
        {
            return setMenuItem;
        }

        public void setSetMenuItem(string setMenuItem)
        {
            this.setMenuItem = setMenuItem;
        }

        public void addItem(ItemMenu menu)
        {
            itemMenuList.Add(menu);
        }

        public void removeItem(ItemMenu menu)
        {
            itemMenuList.Remove(menu);
        }
        public void updateItem(ItemMenu menu)
        {

        }

        public override string ToString()
        {
            return $"ID: {getSetMenuID()}\n" +
                   $"Name: {getSetMenuItem()}\n";
        }
    }
}
