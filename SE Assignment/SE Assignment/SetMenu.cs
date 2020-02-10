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

        public string getSetMenuItem()
        {
            return setMenuItem;
        }

        public void addItem(ItemMenu menu)
        {

        }

        public void removeItem(ItemMenu menu)
        {

        }
        public void updateItem(ItemMenu menu)
        {

        }
    }
}
