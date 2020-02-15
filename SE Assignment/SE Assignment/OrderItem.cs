using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderItem
    {
        private Order order;
        private FoodItem item;
        private int quantity;

        public OrderItem(FoodItem item, int quantity, Order order)
        {
            this.order = order;
            this.quantity = quantity;
            this.item = item;
        }

        public OrderItem()
        {

        }

        public FoodItem getItem()
        {
            return item;
        }

        public int getQuantity()
        {
            return quantity;
        }
    }
}
