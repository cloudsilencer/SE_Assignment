using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Order
    {
        private string orderNumber;
        private DateTime dateTimeOfOrder;
        private DateTime dateTimeReady;
        private List<OrderItem> orderItems;
        private DateTime dateTimeDelivery;
        private double deliveryCharge;
        private string deliveryType;
        private string deliveryStatus;
        private double totalAmt;
        private string status;
        private double subTotal;
        private string gst;
        private Payment payment;

        public Order(string orderNumber, DateTime dateTimeOfOrder)
        {
            this.orderNumber = orderNumber;
            this.dateTimeOfOrder = dateTimeOfOrder;
        }

        public void addItem(ItemMenu item)
        {
            orderItems.Add(item);
        }

        public void cancelOrder()
        {

        }

        public void archiveOrder()
        {

        }
    }
}
