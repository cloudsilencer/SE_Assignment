using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class CartProduct
    {
        private int quantity;
        private ShoppingCart shoppingcart;
        private Customer customer;

        public CartProduct(int quantity, ShoppingCart shoppingcart, Customer customer)
        {
            this.quantity = quantity;
            this.shoppingcart = shoppingcart;
            this.customer = customer;
        }
    }
}
