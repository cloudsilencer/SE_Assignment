using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderCancelledState : OrderState
    {
        private Order order;

        public OrderCancelledState(Order order)
        {
            this.order = order;
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order cannot be archived as it is already cancelled.");
        }

        public void cancelOrder()
        {
            Console.WriteLine("Order cannot be cancelled as it is already cancelled.");
        }

        public void cookFinish()
        {
            Console.WriteLine("Order cannot be cooked finish as it is already cancelled.");
        }

        public void delivered()
        {
            Console.WriteLine("Order cannot be delivered as it is already cancelled.");
        }

        public void dispatch()
        {
            Console.WriteLine("Order cannot be dispatched as it is already cancelled.");
        }

        public void payment(Customer customer, List<Payment> payments)
        {
            Console.WriteLine("Order cannot be paid as it is already cancelled.");
        }

        public void prepare()
        {
            Console.WriteLine("Order cannot be prepared as it is already cancelled.");
        }
    }
}
