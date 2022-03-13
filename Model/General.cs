using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement
{
    public class General
    {
        private DateTime date;
        private int postSubsidy;
        private int houseAllowance;
        private int transportAllowace;
        private int attendanceBonus;
        private int overtimeRate;
        private int socialSecurity;
        private int providentFund;
        private int pension;
        private int injuryInsurance;

        public DateTime Date { get => date; set => date = value; }
        public int PostSubsidy { get => postSubsidy; set => postSubsidy = value; }
        public int HouseAllowance { get => houseAllowance; set => houseAllowance = value; }
        public int TransportAllowace { get => transportAllowace; set => transportAllowace = value; }
        public int AttendanceBonus { get => attendanceBonus; set => attendanceBonus = value; }
        public int SocialSecurity { get => socialSecurity; set => socialSecurity = value; }
        public int ProvidentFund { get => providentFund; set => providentFund = value; }
        public int Pension { get => pension; set => pension = value; }
        public int InjuryInsurance { get => injuryInsurance; set => injuryInsurance = value; }
        public int OvertimeRate { get => overtimeRate; set => overtimeRate = value; }
    }
}
