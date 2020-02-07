using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class StoreAssistant: Manager
    {
        public StoreAssistant(int employeeNo, string employeeNRIC, string employeeGender, string employeeStatus, DateTime employeeDateJoin) : base(employeeNo, employeeNRIC, employeeGender, employeeStatus, employeeDateJoin)
        {
            base.employeeNo = employeeNo;
            this.employeeNRIC = employeeNRIC;
            this.employeeGender = employeeGender;
            this.employeeStatus = employeeStatus;
            this.employeeDateJoin = employeeDateJoin;
        }
    }
}
