using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    interface OrderState
    {
        void payment();
        void prepare();
        void cookFinish();
        void dispatch();
        void delivered();
        void archiveOrder();
        void cancelOrder();
    }
}
