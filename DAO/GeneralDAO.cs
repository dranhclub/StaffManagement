using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement
{
    class GeneralDAO : DAO
    {
        public General GetGeneral(int year, int month)
        {
            General general = null;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                SqlCommand sqlCommand = new SqlCommand("select * from General where y=@year and m=@month", sqlCon);
                sqlCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
                sqlCommand.Parameters.Add("@month", SqlDbType.Int).Value = month;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    general = new General();
                    int y = (int)reader["y"];
                    int m = (int)reader["m"];
                    general.Date = new DateTime(y, m, 1);
                    general.PostSubsidy = (int)reader["post_subsidy"];
                    general.HouseAllowance = (int)reader["house_allowance"];
                    general.TransportAllowace = (int)reader["transport_allowance"];
                    general.AttendanceBonus = (int)reader["attendance_bonus"];
                    general.OvertimeRate = (int)reader["overtime_rate"];
                    general.SocialSecurity = (int)reader["social_security"];
                    general.ProvidentFund = (int)reader["provident_fund"];
                    general.Pension = (int)reader["pension"];
                    general.InjuryInsurance = (int)reader["injury_insurance"];
                }

                sqlCon.Close();
            }

            return general;
        }

        public int UpdateGeneral(General general)
        {
            int affectedRow = 0;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = @"Update General set 
                                     post_subsidy=@post_subsidy,
                                     house_allowance=@house_allowance,
                                     transport_allowance=@transport_allowance,
                                     attendance_bonus=@attendance_bonus,
                                     overtime_rate=@overtime_rate,
                                     social_security=@social_security,
                                     provident_fund=@provident_fund,
                                     pension=@pension,
                                     injury_insurance=@injury_insurance
                                where y=@year and m=@month";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.Add("@year", SqlDbType.Int).Value = general.Date.Year;
                sqlCommand.Parameters.Add("@month", SqlDbType.Int).Value = general.Date.Month;
                sqlCommand.Parameters.Add("@post_subsidy", SqlDbType.Int).Value = general.PostSubsidy;
                sqlCommand.Parameters.Add("@house_allowance", SqlDbType.Int).Value = general.HouseAllowance;
                sqlCommand.Parameters.Add("@transport_allowance", SqlDbType.Int).Value = general.TransportAllowace;
                sqlCommand.Parameters.Add("@attendance_bonus", SqlDbType.Int).Value = general.AttendanceBonus;
                sqlCommand.Parameters.Add("@overtime_rate", SqlDbType.Int).Value = general.OvertimeRate;
                sqlCommand.Parameters.Add("@social_security", SqlDbType.Int).Value = general.SocialSecurity;
                sqlCommand.Parameters.Add("@provident_fund", SqlDbType.Int).Value = general.ProvidentFund;
                sqlCommand.Parameters.Add("@pension", SqlDbType.Int).Value = general.Pension;
                sqlCommand.Parameters.Add("@injury_insurance", SqlDbType.Int).Value = general.InjuryInsurance;

                affectedRow = sqlCommand.ExecuteNonQuery();

                sqlCon.Close();
            }

            return affectedRow;
        }
    }
}
