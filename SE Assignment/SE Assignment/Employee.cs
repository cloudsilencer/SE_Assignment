using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Employee
    {
        protected int employeeNo;
        protected string employeeNRIC;
        protected string employeeGender;
        protected string employeeStatus;
        protected DateTime employeeDateJoin;
        private Branch branch;

        public Employee(int employeeNo, string employeeNRIC, string employeeGender, string employeeStatus, DateTime employeeDateJoin, Branch branch)
        {
            this.employeeNo = employeeNo;
            this.employeeNRIC = employeeNRIC;
            this.employeeGender = employeeGender;
            this.employeeStatus = employeeStatus;
            this.employeeDateJoin = employeeDateJoin;
            this.branch = branch;
        }


    }
}
