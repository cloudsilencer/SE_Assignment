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
        private List<ItemMenu> items;
        private int quantity;

        public OrderItem(Order order, int quantity)
        {
            this.order = order;
            this.quantity = quantity;
        }
    }
}
