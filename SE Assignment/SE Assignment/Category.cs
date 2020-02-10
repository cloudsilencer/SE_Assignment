using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Category
    {
        private int categoryID;
        private string categoryName;

        public Category(int categoryID, string categoryName)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }

        public int GetCategoryID()
        {
            return categoryID;
        }
        public string GetCategoryName()
        {
            return categoryName;
        }

    }
}
