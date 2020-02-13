using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderStateIterator
    {
        private OrderState state;
        private int position = 0;
        public List<Order> orders;

        public OrderStateIterator(List<Order> orders, OrderState state)
        {
            this.orders = orders;
            this.state = state;
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
            while ((position < orders.Count) && (orders[position].getState() != state))
                ++position;
            return order;
        }
    }
}
