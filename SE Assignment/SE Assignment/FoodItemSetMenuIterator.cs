using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class FoodItemSetMenuIterator : Iterator
    {
        private SetMenu setMenu;
        private int position = 0;
        private List<FoodItem> foodItems;

        public FoodItemSetMenuIterator(List<FoodItem> foodItems, SetMenu setMenu)
        {
            this.foodItems = foodItems;
            this.setMenu = setMenu;
            // move position to first food item with the specific set menu.
            while ((position < foodItems.Count) &&
                   (foodItems[position].SetMenu != setMenu))
                ++position;
        }

        public bool hasNext()
        {
            if (position < foodItems.Count)
                return true;
            return false;
        }

        public object next()
        {
            FoodItem foodItem = foodItems[position];
            ++position;
            while ((position < foodItems.Count) && (foodItems[position].SetMenu != setMenu))
                ++position;
            return foodItem;
        }

        public void remove()
        {
            // Not Implemented
        }
    }
}
