using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Clock: Subject
    {
        private List<Observer> observers;
        private DateTime currentDateTime;

        public Clock()
        {
            observers = new List<Observer>();
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
// observers.Remove(item);
        }

        public void notifyObservers()
        {
            foreach (Observer o in observers)
            {
                o.resetComission();
            }
        }


            
    }
}
