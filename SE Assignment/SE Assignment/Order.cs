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
        private Customer customer;

        // States for the Order Object
        private OrderState placedState;
        private OrderState orderNewState;
        private OrderState preparingState;
        private OrderState readyState;
        private OrderState dispatchedState;
        private OrderState deliveredState;
        private OrderState archivedState;
        private OrderState cancelledState;

        private OrderState state;

        public Order(string orderNumber, Customer customer, DateTime dateTimeOfOrder)
        {
            this.orderNumber = orderNumber;
            this.dateTimeOfOrder = dateTimeOfOrder;
            this.customer = customer;
            orderItems = new List<OrderItem>();
            deliveryType = "Default";
            deliveryCharge = 0;
            gst = 7;
            subTotal = 0;
            totalAmt = 0;

            // States
            this.placedState = new OrderPlacedState(this);
            this.orderNewState = new OrderNewState(this);
            this.preparingState = new OrderPreparingState(this);
            this.readyState = new OrderReadyState(this);
            this.dispatchedState = new OrderDispatchedState(this);

            this.state = placedState;
        }

        public void makePayment(List<Payment> payments)
        {
            state.payment(customer, payments);
        }
 
        public double getTotalAmt()
        {
            return totalAmt;
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

        public void setState(OrderState orderState)
        {
            state = orderState;
        }

        public void addItem(OrderItem item)
        {
            orderItems.Add(item);
        }

        public void cancelOrder()
        {
            state.cancelOrder();
        }

        public void archiveOrder()
        {
            state.archiveOrder();
        }

        public void setTotalAmt(double totalAmt)
        {
            this.totalAmt = totalAmt;
        }

        public void makeMayment(Customer customer, List<Payment> payments)
        {
            state.payment(customer, payments);
            //state.payment();
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

        public void expressDelivery()
        {
            deliveryType = "Express";
            deliveryCharge = 2;
            dateTimeReady = DateTime.Now.Add(new System.TimeSpan(0, 0, 15, 0));
            dateTimeDelivery = DateTime.Now.Add(new System.TimeSpan(0, 0, 30, 0));
            Console.WriteLine("Express Delivery :D");
        }

        public void normalDelivery()
        {
            dateTimeReady = DateTime.Now.Add(new System.TimeSpan(0, 0, 30, 0));
            dateTimeDelivery = DateTime.Now.Add(new System.TimeSpan(0, 0, 45, 0));
            Console.WriteLine("Default Delivery");
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

        public void displayReceipt()
        {
            foreach (OrderItem item in orderItems)
            {
                Console.WriteLine(item.getItem().getName() + ", " + item.getItem().getPrice() + ", x" + item.getQuantity());
            }
            Console.WriteLine("Subtotal: $" + subTotal);
            Console.WriteLine("GST: " + gst + "%");
            Console.WriteLine("Total: $" + totalAmt);
            Console.WriteLine("\nEstimated Ready Time: " + dateTimeReady);
            Console.WriteLine("Estimated Delivery Time: " + dateTimeDelivery);
        }
    }
}
