using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Receipt
    {
        private int receiptNumber;
        private DateTime date;
        private Branch branch;
        private Payment payment;

        public Receipt(int receiptNumber, DateTime date, Branch branch, Payment payment)
        {
            this.receiptNumber = receiptNumber;
            this.date = date;
            this.branch = branch;
            this.payment = payment;
        }

        public void sendConfirmation()
        {
            Order order = payment.getOrder();
            string email = order.getCust().getEmail();
            string orderNo = order.getOrderNum();
            DateTime estDateTimeDelivery = order.getDateTimeDelivery();
            string deliveryAddress = order.getCust().getAddress();

            Console.WriteLine("Email sent to: " + email);
            Console.WriteLine("Email Preview\n");

            Console.WriteLine("Thank you for ordering with HungryEatNow");
            Console.WriteLine("Order Receipt\n");
            Console.WriteLine("Order Number: " + orderNo);
            Console.WriteLine("Order Delivered to: " + deliveryAddress);
            order.displayOrderSummary();
        }
    }
}
