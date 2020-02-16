using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderDeliveredState : OrderState
    {
        private Order order;

        public OrderDeliveredState(Order order)
        {
            this.order = order;
        }

        public void archiveOrder()
        {
            if ((DateTime.Now.Year - order.getOrderDate().Year) >= 1)
            {
                order.setState(new OrderArchivedState(order));
                Console.WriteLine("Order was archived");
            }
            else
                Console.WriteLine("Order cannot be archived as it has not been kept for at least 1 year.");
        }

        public void cancelOrder()
        {
            Console.WriteLine("Order cannot be cancelled as it is delivered.");
        }

        public void cookFinish()
        {
            Console.WriteLine("Order cannot be cooked finish as it is delivered.");
        }

        public void delivered()
        {
            Console.WriteLine("Order cannot be delivered as it is delivered.");
        }

        public void dispatch()
        {
            Console.WriteLine("Order cannot be dispatched as it is delivered.");
        }

        public void payment(Customer customer, List<Payment> payments)
        {
            Console.WriteLine("Order cannot be paid as it is delivered.");
        }

        public void prepare()
        {
            Console.WriteLine("Order cannot be prepared as it is delivered.");
        }
    }
}
