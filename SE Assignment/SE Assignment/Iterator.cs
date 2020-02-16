using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    interface Iterator
    {
        bool hasNext();
        object next();
        void remove();
    }
}
