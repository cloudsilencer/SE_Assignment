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

        public int SetMenuID
        {
            get { return setMenuID; }
            set { setMenuID = value; }
        }

        private string setMenuName;
        public string SetMenuName
        {
            get { return setMenuName; }
            set { setMenuName = value; }
        }

        private List<FoodItem> foodItemList;
        public List<FoodItem> FoodItemList
        {
            get { return foodItemList; }
            set { foodItemList = value; }
        }

        private int size;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public SetMenu(int setMenuID, string setMenuName)
        {
            SetMenuID = setMenuID;
            SetMenuName = setMenuName;
            FoodItemList = new List<FoodItem>();
            Size = FoodItemList.Count;
        }

        public void AddItem(FoodItem item)
        {
            FoodItemList.Add(item);
        }

        public void RemoveItem(FoodItem item)
        {
            FoodItemList.Remove(item);
        }

        public override string ToString()
        {
            return $"ID: {SetMenuID}\n" +
                   $"Name: {SetMenuName}\n";
        }
    }
}
