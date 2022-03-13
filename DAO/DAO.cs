using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StaffManagement
{
    public class DAO
    {
        protected string connectionString;

        public DAO()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

    }
}
