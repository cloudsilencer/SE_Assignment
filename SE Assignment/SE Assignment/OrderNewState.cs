using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderNewState : OrderState
    {
        private Order order;

        public OrderNewState(Order order)
        {
            this.order = order;
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order cannot be archived as it is not delivered");
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
            Console.WriteLine("Order cannot be cooked finish as it is has not been prepared.");
        }

        public void delivered()
        {
            Console.WriteLine("Order cannot be delivered as it is has not been dispatched.");
        }

        public void dispatch()
        {
            Console.WriteLine("Order cannot be dispatched as it is not ready.");
        }

        public void payment(Customer customer, List<Payment> payments)
        {
            Console.WriteLine("Order cannot be paid as it has already been paid.");
        }

        public void prepare()
        {
            order.setState(new OrderPreparingState(order));
            Console.WriteLine("Order is now being prepared.");
        }
    }
}
