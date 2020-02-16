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
    }
}
