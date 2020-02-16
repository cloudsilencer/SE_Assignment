using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderPlacedState : OrderState
    {
        private Order order;

        public OrderPlacedState(Order order)
        {
            this.order = order;
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order cannot be archived as it is not delivered.");
        }

        public void cancelOrder()
        {
            Console.WriteLine("Order cannot be cancelled as it has not been paid.");
        }

        public void cookFinish()
        {
            Console.WriteLine("Order cannot be cooked finish as it is not prepared.");
        }

        public void delivered()
        {
            Console.WriteLine("Order cannot be delivered as it is not dispatched.");
        }

        public void dispatch()
        {
            Console.WriteLine("Order cannot be dispatched as it is not cooked finish.");
        }

        public void payment(Customer customer, List<Payment> payments)
        {
            Console.WriteLine("\nHow would you like to make your payment?\n1. Credit Card\n2. Online Means");
            string paymentType = "";
            string paymentChoice = "";
            while (true)
            {
                paymentChoice = Console.ReadLine();

                if (paymentChoice == "1")
                {
                    paymentType = "Credit Card";
                    Console.WriteLine("Please enter credit card number");
                    string creditCardNo = "";
                    while (true)
                    {
                        creditCardNo = Console.ReadLine();
                        if (creditCardNo == customer.getCreditCardInfo())
                        {
                            Console.WriteLine("Payment Successful! Thank you for ordering with HungryEatNow...");
                            break;
                        }
                        else
                            Console.WriteLine("Payment Failed! Please try again");
                    }
                    break;
                }

                else if (paymentChoice == "2")
                {
                    paymentType = "Online Means";
                    System.Diagnostics.Process.Start("https://www.paypal.com/us/home");
                    break;
                }
                else
                    Console.WriteLine("Please select a valid option");
            }
            Payment newPayment = new Payment(payments.Count.ToString(), order, order.getTotalAmt(), DateTime.Now, paymentType);
            Random random = new Random();
            int receiptNo = random.Next(1, 1000);
            Receipt newReceipt = new Receipt(receiptNo, DateTime.Now, order.getBranch(), newPayment);
            newReceipt.sendConfirmation();
        }

        public void prepare()
        {
            Console.WriteLine("Order cannot be prepared as it is not paid.");
        }
    }
}
