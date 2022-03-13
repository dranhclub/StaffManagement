using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement
{
    class PayrollDAO : DAO
    {
        public DataTable GetPayrolls(int year, int month, int departmentId)
        {
            DataTable ret;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"select e.id as [ID], 
	                                e.name as [Name], 
	                                d.name as [Department],
	                                p.basic_salary as [Basic salary], 
	                                p.allowance as [Allowance],
	                                p.deduction as [Deduction],
	                                p.salary as [Salary]
                                from Payroll p, 
	                                Employee e, 
	                                Department d
                                where p.id = e.id and 
	                                e.department_id = d.id and 
	                                y=@year and 
	                                m=@month and
                                    d.id=@department_id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@year", year);
                sqlCommand.Parameters.AddWithValue("@month", month);
                sqlCommand.Parameters.AddWithValue("@department_id", departmentId);

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand);
                ret = new DataTable();
                sqlDa.Fill(ret);

                sqlCon.Close();
            }

            return ret;
        }
    
        public DataTable GetAllowances(int year, int month, int departmentId)
        {
            DataTable ret;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"select e.id as [ID],
                                    e.name as [Name],
	                                d.name as [Department],
	                                attendance_bonus as [Attendance bonus],
	                                overtime_pay as [Late overtime pay],
	                                post_subsidy as [Post subsidy],
	                                house_allowance as [Housing allowance],
	                                transport_allowance as [Transport allowance],
	                                total as [Total]
                                from Allowance a, 
	                                Employee e, 
	                                Department d
                                where a.id = e.id 
	                                and e.department_id = d.id
	                                and a.y = @year 
	                                and a.m = @month
                                    and d.id = @department_id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@year", year);
                sqlCommand.Parameters.AddWithValue("@month", month);
                sqlCommand.Parameters.AddWithValue("@department_id", departmentId);

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand);
                ret = new DataTable();
                sqlDa.Fill(ret);

                sqlCon.Close();
            }

            return ret;
        }

        public DataTable GetDeductions(int year, int month, int departmentId)
        {
            DataTable ret;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"select e.id as [ID],
                                    e.name as [Name],
	                                d.name as [Department],
	                                absence as [Absence],
	                                social_security as [Social security],
	                                provident_fund as [Provident fund],
	                                pension as [Pension],
	                                injury_insurance as [Injury Insurance], 
	                                total as [Total]
                                from Deduction ddt, 
	                                Employee e, 
	                                Department d
                                where ddt.id = e.id 
	                                and e.department_id = d.id
	                                and ddt.y = @year 
	                                and ddt.m = @month
                                    and d.id = @department_id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@year", year);
                sqlCommand.Parameters.AddWithValue("@month", month);
                sqlCommand.Parameters.AddWithValue("@department_id", departmentId);

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand);
                ret = new DataTable();
                sqlDa.Fill(ret);

                sqlCon.Close();
            }

            return ret;
        }

    }
}
