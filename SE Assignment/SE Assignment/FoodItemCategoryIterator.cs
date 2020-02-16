using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class FoodItemCategoryIterator : Iterator
    {
        private Category category;
        private int position = 0;
        private List<FoodItem> foodItems;

        public FoodItemCategoryIterator(List<FoodItem> foodItems, Category category)
        {
            this.foodItems = foodItems;
            this.category= category;
            // move position to first food item with the specific category.
            while ((position < foodItems.Count) &&
                   (foodItems[position].Category != category))
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
            while ((position < foodItems.Count) && (foodItems[position].Category != category))
                ++position;
            return foodItem;
        }

        public void remove()
        {
            // Not implemented
        }
    }
}
