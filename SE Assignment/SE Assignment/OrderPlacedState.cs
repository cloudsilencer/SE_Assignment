using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class OrderPlacedState : OrderState
    {
        private Order order;

        public OrderPlacedState(Order order)
        {
            this.order = order;
        }

        public void archiveOrder()
        {
            throw new NotImplementedException();
        }

        public void cancelOrder()
        {
            throw new NotImplementedException();
        }

        public void cookFinish()
        {
            throw new NotImplementedException();
        }

        public void delivered()
        {
            throw new NotImplementedException();
        }

        public void dispatch()
        {
            throw new NotImplementedException();
        }

        public void payment()
        {
            throw new NotImplementedException();
        }

        public void prepare()
        {
            throw new NotImplementedException();
        }
    }
}
