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
        protected Branch branch;
        protected string employeetype;
        private Account account;
        private string email;

        public Employee(int employeeNo, string employeeNRIC, string employeeGender, string employeeStatus, DateTime employeeDateJoin, Branch branch, Account account, string email, string employeetype)
        {
            this.employeeNo = employeeNo;
            this.employeeNRIC = employeeNRIC;
            this.employeeGender = employeeGender;
            this.employeeStatus = employeeStatus;
            this.employeeDateJoin = employeeDateJoin;
            this.branch = branch;
            this.account = account;
            this.email = email;
            this.employeetype = employeetype;
        }

        public Employee()
        {

        }

        public string getEmail()
        {
            return email;
        }

        public string getEmployeeType()
        {
            return employeetype;
        }
        public Account getAccount()
        {
            return account;
        }

    }
}
