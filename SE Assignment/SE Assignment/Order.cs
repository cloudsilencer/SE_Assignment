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
        private int gst;
        private Payment payment;
        private Branch branch;

        public Order(string orderNumber, DateTime dateTimeOfOrder)
        {
            this.orderNumber = orderNumber;
            this.dateTimeOfOrder = dateTimeOfOrder;
            orderItems = new List<OrderItem>();
            deliveryType = "Default";
            deliveryCharge = 0;
            gst = 7;
            subTotal = 0;
            totalAmt = 0;
        }

        public int getGST()
        {
            return gst;
        }

        public double getDeliveryCharge()
        {
            return deliveryCharge;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public void setDateTimeReady(DateTime ready)
        {
            dateTimeReady = ready;
        }

        public void setDeliveryCharge(double deliveryCharge)
        {
            this.deliveryCharge = deliveryCharge;
        }

        public void setBranch(Branch branch)
        {
            this.branch = branch;
        }

        public void setDeliveryType(string type)
        {
            deliveryType = type;
        }

        public void addItem(OrderItem item)
        {
            orderItems.Add(item);
        }

        public void cancelOrder()
        {

        }

        public void archiveOrder()
        {

        }

        public void setTotalAmt(double totalAmt)
        {
            this.totalAmt = totalAmt;
        }

        public double getSubTotal()
        {
            return subTotal;
        }

        public void setSubTotal(double subTotal)
        {
            this.subTotal = subTotal;
        }

        public List<OrderItem> getOrderItems()
        {
            return orderItems;
        }

        public void ToString()
        {
            foreach (OrderItem item in orderItems)
            {
                Console.WriteLine(item.getItem().getName() + ", " + item.getItem().getPrice() + ", x" + item.getQuantity());
            }
            Console.WriteLine("Subtotal: $" + subTotal);
            Console.WriteLine("GST: " + gst + "%");
            Console.WriteLine("Total: $" + totalAmt);
            //Console.WriteLine("\nEstimated Ready Time: " + dateTimeReady);
            //Console.WriteLine("Estimated Delivery Time: " + dateTimeDelivery);

        }
    }
}
