using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderDispatchedState : OrderState
    {
        private Order order;

        public OrderDispatchedState(Order order)
        {
            this.order = order;
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order cannot be archived as it is dispatched");
        }

        public void cancelOrder()
        {
            if (DateTime.Now >= order.getDateTimeDelivery())
            {
                order.setState(new OrderCancelledState(order));
                Console.WriteLine("Order has been cancelled.");
                // Implementation to refund customer
            }
            else
                Console.WriteLine("Order cannot be cancelled as the time now has not exceeded the estimated delivery time.");
        }

        public void cookFinish()
        {
            Console.WriteLine("Order cannot be cooked finish as it is already dispatched");
        }

        public void delivered()
        {
            order.setState(new OrderDeliveredState(order));
            Console.WriteLine("Order is now delivered.");
        }

        public void dispatch()
        {
            Console.WriteLine("Order cannot be dispatched as it is already dispatched");
        }

        public void payment(Customer customer, List<Payment> payments)
        {
            Console.WriteLine("Order cannot be paid as it is already dispatched");
        }

        public void prepare()
        {
            Console.WriteLine("Order cannot be prepared as it is already dispatched");
        }
    }
}
