using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderReadyState : OrderState
    {
        private Order order;

        public OrderReadyState(Order order)
        {
            this.order = order;
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order cannot be archived as it is not yet delivered.");
        }

        public void cancelOrder()
        {
            order.setState(new OrderCancelledState(order));
            Console.WriteLine("Order has been cancelled.");
        }

        public void cookFinish()
        {
            Console.WriteLine("Order cannot be cooked finish as it is already ready to be dispatched.");
        }

        public void delivered()
        {
            Console.WriteLine("Order cannot be delivered as it is not yet dispatched.");
        }

        public void dispatch()
        {
            order.setState(new OrderDispatchedState(order));
            Console.WriteLine("Order has been dispatched.");
        }

        public void payment(Customer customer, List<Payment> payments)
        {
            Console.WriteLine("Order cannot be paid as it is ready to be dispatched.");
        }

        public void prepare()
        {
            Console.WriteLine("Order cannot be prepared as it is ready to be dispatched.");
        }
    }
}
