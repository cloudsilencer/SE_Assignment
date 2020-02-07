using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Chef:Manager
    {
        public Chef(int employeeNo, string employeeNRIC, string employeeGender, string employeeStatus, DateTime employeeDateJoin) : base(employeeNo, employeeNRIC, employeeGender, employeeStatus, employeeDateJoin)
        {
            base.employeeNo = employeeNo;
            this.employeeNRIC = employeeNRIC;
            this.employeeGender = employeeGender;
            this.employeeStatus = employeeStatus;
            this.employeeDateJoin = employeeDateJoin;
        }
        
        public void prepareOrder()
        {

        }

        public void completeOrder()
        {

        }
    }
}
