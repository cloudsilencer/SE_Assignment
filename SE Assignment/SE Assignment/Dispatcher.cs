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

        public Dispatcher(int employeeNo, string employeeNRIC, string employeeGender, string employeeStatus, DateTime employeeDateJoin, Branch branch) : base(employeeNo, employeeNRIC, employeeGender, employeeStatus, employeeDateJoin, branch)
        {
            base.employeeNo = employeeNo;
            this.employeeNRIC = employeeNRIC;
            this.employeeGender = employeeGender;
            this.employeeStatus = employeeStatus;
            this.employeeDateJoin = employeeDateJoin;
            this.branch = branch;
            TotalCommission = 0;
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
