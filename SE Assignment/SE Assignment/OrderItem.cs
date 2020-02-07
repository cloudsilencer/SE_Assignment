using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderItem
    {
        private string orderNumber;
        private int quantity;

        public OrderItem(string orderNumber, int quantity)
        {
            this.orderNumber = orderNumber;
            this.quantity = quantity;
        }
    }
}
