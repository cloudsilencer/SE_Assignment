using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    interface OrderState
    {
        void offer(Buyer b);
        void signContract(Buyer b);
        void buyerPullout();
        void vendorPullOut();
        void payPrice();
    }
}
