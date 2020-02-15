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
            throw new NotImplementedException();
        }

        public void cancelOrder()
        {
            throw new NotImplementedException();
        }

        public void cookFinish()
        {
            throw new NotImplementedException();
        }

        public void delivered()
        {
            throw new NotImplementedException();
        }

        public void dispatch()
        {
            throw new NotImplementedException();
        }

        public void payment(Customer customer, List<Payment> payments)
        {
            Console.WriteLine("\nHow would you like to make your payment?\n1. Credit Card\n2. Online Means");
            string paymentType = "";
            string paymentChoice = Console.ReadLine();
            while (true)
            {
                if (paymentChoice == "1")
                {
                    paymentType = "Credit Card";
                    Console.WriteLine("Please enter credit card number");
                    string creditCardNo = Console.ReadLine();
                    while (true)
                    {
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
        }

        public void prepare()
        {
            throw new NotImplementedException();
        }
    }
}
