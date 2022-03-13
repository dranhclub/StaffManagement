using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement
{
    public class User
    {
        private string username;
        private string password;
        private Privilege privilege;
        private int eid;

        public User()
        {
        }


        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public Privilege Privilege { get => privilege; set => privilege = value; }
        public int Eid { get => eid; set => eid = value; }
    }

    public enum Privilege
    {
        Admin,
        Employee
    }
}
