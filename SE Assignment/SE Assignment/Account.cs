using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Account
    {
        private int userId;
        private string password;
        private string loginStatus;
        public string test;

        public Account(int userId, string password, string loginStatus)
        {
            this.userId = userId;
            this.password = password;
            this.loginStatus = loginStatus;
        }

        public string getPassword()
        {
            return password;
        }

        public bool verifyLogin()
        {
            return true;
        }
    }
}
