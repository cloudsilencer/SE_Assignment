using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class ShoppingCart
    {
        private int cartId;
        private List<CartProduct> products;
        private DateTime dateAdded;

        public ShoppingCart(int cartId, List<CartProduct> products, DateTime dateAdded)
        {
            this.cartId = cartId;
            this.products = products;
            this.dateAdded = dateAdded;
        }

        public void placeOrder()
        {

        }

        public void addCartItem()
        {

        }

        public void updateQuantity()
        {

        }

        public void viewCartDetails()
        {

        }

        public void checkout()
        {

        }
    }
}
