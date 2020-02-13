using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SE_Assignment
{
    class Clock: Subject
    {
        private static Clock uniqueInstance = null;
        private List<Observer> observers;
        private Timer timer;
        public Timer Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        private int timeRemaining;
        public int TimeRemaining
        {
            get { return timeRemaining; }
            set { timeRemaining = value; }
        }


        private Clock()
        {
            // Private Constructor
            observers = new List<Observer>();
            Timer = new Timer(1000);
            InitializeTimeRemaining();
            SetTimer();
        }

        public static Clock getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Clock();
            }
            return uniqueInstance;
        }

        public void InitializeTimeRemaining()
        {
            DateTime now = DateTime.Now;
            DateTime startOfNextMonth = new DateTime(now.AddMonths(1).Year, now.AddMonths(1).Month, 1);
            TimeSpan span = startOfNextMonth - now;
            TimeRemaining = (int)span.TotalSeconds;
            //TimeRemaining = 10;
        }

        public void SetTimer()
        {
            // Hook up the Elapsed event for the timer. 
            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        public void StartTimer()
        {
            InitializeTimeRemaining();
            Timer.Start();
        }

        public void StopTimer()
        {
            Timer.Stop();
        }

        public void DisposeTimer()
        {
            Timer.Dispose();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            TimeRemaining -= 1;
            Console.WriteLine($"Time Remaining: {TimeRemaining}s ");
            if (TimeRemaining == 0)
            {
                StopTimer();
                notifyObservers();
                StartTimer();
            }
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
            observers.Remove(o);
        }

        public void notifyObservers()
        {
            foreach (Observer o in observers)
            {
                o.update();
            }
        }

    }
}
