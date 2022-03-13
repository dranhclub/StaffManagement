using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement
{
    public class UserDAO : DAO
    {
        public User GetAdminUser()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"select username, password from Users where privilege='admin'";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                User user = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    IDataRecord row = (IDataRecord)reader;
                    user = new User();
                    user.Username = (string)row["username"];
                    user.Password = (string)row["password"];
                    user.Privilege = Privilege.Admin;
                }

                sqlCon.Close();

                return user;
            }
        }

        public User GetRandomEmployeeUser()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"SELECT TOP 1 * FROM Users where privilege='employee' ORDER BY NEWID()";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                User user = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    IDataRecord row = (IDataRecord)reader;
                    user = new User();
                    user.Username = (string)row["username"];
                    user.Password = (string)row["password"];
                    user.Privilege = Privilege.Employee;
                    user.Eid = (int)row["eid"];
                }

                sqlCon.Close();

                return user;
            }
        }

        public User Login(string username, string password)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"select * from Users where username=@username and password=@password";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                User user = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    IDataRecord row = (IDataRecord)reader;
                    user = new User();
                    user.Username = (string)row["username"];
                    user.Password = (string)row["password"];
                    string privilege = (string)row["privilege"];
                    if (privilege.Equals("admin"))
                    {
                        user.Privilege = Privilege.Admin;
                    } 
                    else if (privilege.Equals("employee"))
                    {
                        user.Privilege = Privilege.Employee;
                        user.Eid = (int)row["eid"];
                    } else
                    {
                        throw new Exception("Invalid privilege string");
                    }
                }

                sqlCon.Close();

                return user;
            }
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"update Users set password=@new_password where username=@username and password=@old_password";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@new_password", newPassword);
                sqlCommand.Parameters.AddWithValue("@old_password", oldPassword);
                int affectedRow = sqlCommand.ExecuteNonQuery();
                sqlCon.Close();

                return affectedRow > 0;
            }
        }
    }
}
