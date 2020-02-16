using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Customer
    {
        private string customerName;
        private string address;
        private string email;
        private string contactNumber;
        private string creditCardInfo;
        private Account account;
        private List<Order> orders;

        public Customer(string customerName, string address, string email, string contactNumber, string creditCardInfo, Account account)
        {
            this.customerName = customerName;
            this.address = address;
            this.email = email;
            this.contactNumber = contactNumber;
            this.creditCardInfo = creditCardInfo;
            this.account = account;
            orders = new List<Order>();
        }

        public Customer()
        {
            
        }

        public void addOrder(Order order)
        {
            orders.Add(order);
        }

        public string getCreditCardInfo()
        {
            return creditCardInfo;
        }


        public string getEmail()
        {
            return email;
        }

        public Account getAccount()
        {
            return account;
        }

        public void register()
        {

        }

        public void login()
        {

        }

        public void viewOrder()
        {
            //return orders;
        }

        public void payOrder()
        {

        }

        public string getAddress()
        {
            return address;
        }
    }
}
