using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Payment
    {
        private string paymentID;
        private Order order;
        private double paymentAmount;
        private DateTime paymentDate;
        private string paymentType;

        public Payment(string paymentID, Order order, double paymentAmount, DateTime paymentDate, string paymentType)
        {
            this.paymentID = paymentID;
            this.order = order;
            this.paymentAmount = paymentAmount;
            this.paymentDate = paymentDate;
            this.paymentType = paymentType;
        }

        public void paymentApproved()
        {

        }

        public void paymentDeclined()
        {

        }

        public double paymentAmt()
        {
            return paymentAmount;
        }

        public Order getOrder()
        {
            return order;
        }
    }
}
