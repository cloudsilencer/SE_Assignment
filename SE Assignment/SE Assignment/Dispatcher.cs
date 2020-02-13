using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Dispatcher: Employee, Observer    
    {
        private double totalCommission;

        public double TotalCommission
        {
            get { return totalCommission; }
            set { totalCommission = value; }
        }

        private Subject clock;

        public Subject Clock
        {
            get { return clock; }
            set { clock = value; }
        }


        public Dispatcher(int employeeNo, string employeeNRIC, string employeeGender, string employeeStatus, DateTime employeeDateJoin, Branch branch, Subject clock) : base(employeeNo, employeeNRIC, employeeGender, employeeStatus, employeeDateJoin, branch)
        {
            base.employeeNo = employeeNo;
            base.employeeNRIC = employeeNRIC;
            base.employeeGender = employeeGender;
            base.employeeStatus = employeeStatus;
            base.employeeDateJoin = employeeDateJoin;
            base.branch = branch;
            TotalCommission = 0;
            Clock = clock;
        }

        public void deliverOrder()
        {
            addComission(5);
        }

        public void addComission(double amount)
        {
            TotalCommission += amount;
        }

        public void resetCommission()
        {
            TotalCommission = 0;
        }

        public void update()
        {
            resetCommission();
        }
    }
}
