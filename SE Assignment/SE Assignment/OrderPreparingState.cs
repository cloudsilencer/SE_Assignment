using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderPreparingState : OrderState
    {
        private Order order;

        public OrderPreparingState(Order order)
        {
            this.order = order;
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order cannot be archived because it is still being prepared.");
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
            order.setState(new OrderReadyState(order));
            Console.WriteLine("Order is cooked finish and now ready.");
        }

        public void delivered()
        {
            Console.WriteLine("Order cannot be delivered because it is still preparing.");
        }

        public void dispatch()
        {
            Console.WriteLine("Order cannot be dispatched because it is still preparing.");
        }

        public void payment(Customer customer, List<Payment> payments)
        {
            Console.WriteLine("Order cannot be paid because it is being prepared.");
        }

        public void prepare()
        {
            Console.WriteLine("Order cannot be prepared because it is being prepared.");
        }
    }
}
