using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    
    class Chef:Employee
    {
        private Account account;
        private string email;
        private string employeetype;
        public Chef(int employeeNo, string employeeNRIC, string employeeGender, string employeeStatus, DateTime employeeDateJoin, Branch branch, Account account, string email, string employeetype) : base(employeeNo, employeeNRIC, employeeGender, employeeStatus, employeeDateJoin, branch, account, email, employeetype)
        {
            base.employeeNo = employeeNo;
            this.employeeNRIC = employeeNRIC;
            this.employeeGender = employeeGender;
            this.employeeStatus = employeeStatus;
            this.employeeDateJoin = employeeDateJoin;
            this.branch = branch;
            this.employeetype = employeetype;

        }

        public string getEmployeeType()
        {
            return employeetype;
        }

        public void prepareOrder()
        {

        }

        public void completeOrder()
        {

        }
    }
}
