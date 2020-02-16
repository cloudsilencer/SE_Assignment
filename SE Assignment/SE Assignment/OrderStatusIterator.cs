using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderStatusIterator
    {
        private string orderStatus;
        private int position = 0;
        public List<Order> orders;

        public OrderStatusIterator(List<Order> orders, string orderStatus)
        {
            this.orders = orders;
            this.orderStatus = orderStatus;
            // move position to first order with the order status
            while ((position < orders.Count) &&
                   (orders[position].getOrderStatus() != orderStatus))
                ++position;
        }

        public bool hasNext()
        {
            if (position < orders.Count)
                return true;
            return false;
        }

        public object next()
        {
            Order order = orders[position];
            ++position;
            while ((position < orders.Count) && (orders[position].getOrderStatus() != orderStatus))
                ++position;
            return order;
        }
    }
}
