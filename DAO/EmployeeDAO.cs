using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace StaffManagement
{
    public class EmployeeDAO : DAO
    {
        public DataTable GetEmployees()
        {
            DataTable ret;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"select e.id as ID, e.name as Name, gender as Gender, id_number as [ID Number], photo as [Photo], birth as [Date of birth], addr as Address, email as Email, phone as Phone, married as Married, d.name as Department, p.name as Position
                                from Employee e, Department d, Position p
                                where e.department_id = d.id
                                and e.position_id = p.id";

                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                ret = new DataTable();
                sqlDa.Fill(ret);
                sqlCon.Close();
            }

            return ret;
        }

        public void AddNewEmployee(Employee em)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"insert into Employee(name, gender, id_number, birth, addr, email, phone, married, department_id, position_id) values
                                (@name, @gender, @id_number, @birth, @addr, @email, @phone, @married, @department_id, @position_id)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@name", em.Name);
                sqlCommand.Parameters.AddWithValue("@gender", em.Gender);
                sqlCommand.Parameters.AddWithValue("@id_number", em.IdNumber);
                sqlCommand.Parameters.AddWithValue("@birth", em.Birth);
                sqlCommand.Parameters.AddWithValue("@addr", em.Address);
                sqlCommand.Parameters.AddWithValue("@email", em.Email);
                sqlCommand.Parameters.AddWithValue("@phone", em.Phone);
                sqlCommand.Parameters.AddWithValue("@married", em.Married);
                sqlCommand.Parameters.AddWithValue("@department_id", em.DepartmentId);
                sqlCommand.Parameters.AddWithValue("@position_id", em.PositionId);

                sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
            }
        }

        public int UpdateEmployee(Employee em)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"update Employee
                                set name=@name, 
                                gender=@gender, 
                                id_number=@id_number,
                                photo=@photo,
                                birth=@birth,
                                addr=@addr,
                                email=@email,
                                phone=@phone,
                                married=@married,
                                department_id=@department_id,
                                position_id=@position_id
                                where id=@id";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", em.Id);
                sqlCommand.Parameters.AddWithValue("@name", em.Name);
                sqlCommand.Parameters.AddWithValue("@gender", em.Gender);
                sqlCommand.Parameters.AddWithValue("@id_number", em.IdNumber);
                if (em.Photo == null)
                {
                    sqlCommand.Parameters.AddWithValue("@photo", DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@photo", em.Photo);
                }
                sqlCommand.Parameters.AddWithValue("@birth", em.Birth);
                sqlCommand.Parameters.AddWithValue("@addr", em.Address);
                sqlCommand.Parameters.AddWithValue("@email", em.Email);
                sqlCommand.Parameters.AddWithValue("@phone", em.Phone);
                sqlCommand.Parameters.AddWithValue("@married", em.Married);
                sqlCommand.Parameters.AddWithValue("@department_id", em.DepartmentId);
                sqlCommand.Parameters.AddWithValue("@position_id", em.PositionId);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdateName(int id, string name)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set name=@name where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@name", name);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdateGender(int id, string gender)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set gender=@gender where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@gender", gender);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdateIdNumber(int id, string idNumber)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set id_number=@id_number where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@id_number", idNumber);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdatePhoto(int id, string photoFileName)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set photo=@photo where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@photo", photoFileName);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdateDateOfBirth(int id, DateTime dob)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set dob=@dob where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@dob", dob);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdateAddress(int id, string address)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set address=@address where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@address", address);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdateEmail(int id, string email)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set email=@email where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@email", email);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdatePhone(int id, string phone)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set phone=@phone where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@phone", phone);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdateMarried(int id, bool married)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set married=@married where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@married", married);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdateDepartment(int id, int departmentId)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set department_id=@department_id where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@department_id", departmentId);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int UpdatePosition(int id, int positionId)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "update Employee set position_id=@position_id where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@position_id", positionId);

                int ret = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
                return ret;
            }
        }

        public int GetLastestId()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT IDENT_CURRENT('Employee')", sqlCon);
                object result = sqlCommand.ExecuteScalar();
                sqlCon.Close();
                return (int)(decimal) result;
            }
        }

        public Employee GetById(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"select e.id, e.name, gender, id_number, photo, birth, addr, email, phone, married, d.name, p.name, e.department_id, e.position_id
                                from Employee e, Department d, Position p
                                where e.department_id = d.id
                                and e.position_id = p.id
                                and e.id=@id";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Employee em = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    IDataRecord row = (IDataRecord)reader;
                    em = new Employee();
                    em.Id = id;
                    em.Name = (string)row[1];
                    em.Gender = (string)row["gender"];
                    em.IdNumber = (string)row["id_number"];
                    em.Photo = row["photo"] as string;
                    em.Birth = (DateTime)row["birth"];
                    em.Address = (string)row["addr"];
                    em.Email = (string)row["email"];
                    em.Phone = (string)row["phone"];
                    em.Married = (bool)row["married"];
                    em.DepartmentId = (int)row["department_id"];
                    em.PositionId = (int)row["position_id"];
                }

                sqlCon.Close();

                return em;
            }
        }

        public int DeleteById(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("delete from Employee where id=@id", sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", id);
                int numRowAffected = sqlCommand.ExecuteNonQuery();
                sqlCon.Close();
                return numRowAffected;
            }
        }

        public DataTable GetDepartments()
        {
            DataTable ret;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = @"select * from Department";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                ret = new DataTable();
                sqlDa.Fill(ret);
                sqlCon.Close();
            }
            return ret;
        }

        public DataTable GetPositions()
        {
            DataTable ret;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = @"select * from Position";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                ret = new DataTable();
                sqlDa.Fill(ret);
                sqlCon.Close();
            }
            return ret;
        }

        public string GetDepartmentNameById(int departmentId)
        {
            string ret = null;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = @"select name from Department where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", departmentId);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                
                if (reader.HasRows)
                {
                    reader.Read();
                    ret = (string)reader[0];
                }

                sqlCon.Close();
            }
            return ret;
        }

        public string GetPositionNameById(int departmentId)
        {
            string ret = null;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = @"select name from Position where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", departmentId);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    ret = (string)reader[0];
                }

                sqlCon.Close();
            }
            return ret;
        }
    }
}
