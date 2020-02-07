using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Manager:Employee
    {

        public Manager(int employeeNo, string employeeNRIC, string employeeGender, string employeeStatus, DateTime employeeDateJoin, Branch branch): base(employeeNo, employeeNRIC, employeeGender, employeeStatus, employeeDateJoin, branch)
        {
            base.employeeNo = employeeNo;
            this.employeeNRIC = employeeNRIC;
            this.employeeGender = employeeGender;
            this.employeeStatus = employeeStatus;
            this.employeeDateJoin = employeeDateJoin;
            this.branch = branch;
        }
        
        public void manageFoodItem()
        {

        }

        public void manageSetMenu()
        {

        }
    }
}
