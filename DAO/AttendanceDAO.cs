using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement
{
    public class AttendanceDAO : DAO
    {
        public DataTable GetAbsenceTable(int year, int month)
        {
            DataTable ret = new DataTable();
            DataTable absence = GetAbsence(year, month);
            
            EmployeeDAO employeeDAO = new EmployeeDAO();
            DataTable employees = employeeDAO.GetEmployees();

            ret.Columns.Add(new DataColumn("ID"));
            ret.Columns.Add(new DataColumn("EmployeeName"));
            for (int i = 0; i < Utils.getDays(month, year); i++)
            {
                ret.Columns.Add(new DataColumn((i+1).ToString()));
            }

            foreach (DataRow employee in employees.Rows)
            {
                int id = (int)employee["id"];
                string name = (string)employee["name"];
                ret.Rows.Add(id, name);
                DataRow lastRow = ret.Rows[ret.Rows.Count - 1];
                for (int i = 0; i < Utils.getDays(month, year); i++)
                {
                    lastRow[(i + 1).ToString()] = false;
                }
                foreach (DataRow absen in absence.Rows)
                {
                    int aid = (int)absen["eid"];
                    if (aid == id)
                    {
                        DateTime date = (DateTime)absen["date"];
                        lastRow[date.Day.ToString()] = true;
                    }
                }
            }

            return ret;
        }
        
        public DataTable GetAbsence(int year, int month)
        {
            DataTable ret;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"select * from Absence where YEAR(date)=@year and MONTH(date)=@month";
                SqlCommand command = new SqlCommand(query, sqlCon);
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@month", month);

                SqlDataAdapter sqlDa = new SqlDataAdapter(command);
                ret = new DataTable();
                sqlDa.Fill(ret);
                sqlCon.Close();
            }

            return ret;
        }

        public int UpdateAbsence(int year, int month, int day, int id, bool check)
        {
            int affectedRow = 0;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query;
                if (check)
                {
                    query = @"insert into Absence values (@id, @date)";
                } 
                else
                {
                    query = @"delete from Absence where eid=@id and date=@date";
                }
                SqlCommand command = new SqlCommand(query, sqlCon);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@date", new DateTime(year, month, day));
                affectedRow = command.ExecuteNonQuery();

                sqlCon.Close();
            }

            return affectedRow;
        }
    }
}
