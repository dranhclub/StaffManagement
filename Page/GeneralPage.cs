using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagement
{
    public partial class GeneralPage : UserControl
    {
        public GeneralPage()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            GeneralDAO generalDAO = new GeneralDAO();
            General general = generalDAO.GetGeneral(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            if (general != null)
            {
                postSubsidyTxb.Text = general.PostSubsidy.ToString();
                houseAllowanceTxb.Text = general.HouseAllowance.ToString();
                transportAllowanceTxb.Text = general.HouseAllowance.ToString();
                attendanceBonusTxb.Text = general.AttendanceBonus.ToString();
                overtimeRateTxb.Text = general.OvertimeRate.ToString();
                socialSecurityTxb.Text = general.SocialSecurity.ToString();
                providentFundTxb.Text = general.ProvidentFund.ToString();
                pensionTxb.Text = general.Pension.ToString();
                injuryInsuranceTxb.Text = general.InjuryInsurance.ToString();
            } else
            {
                postSubsidyTxb.Text = "";
                houseAllowanceTxb.Text = "";
                transportAllowanceTxb.Text = "";
                attendanceBonusTxb.Text = "";
                overtimeRateTxb.Text = "";
                socialSecurityTxb.Text = "";
                providentFundTxb.Text = "";
                pensionTxb.Text = "";
                injuryInsuranceTxb.Text = "";
            }
        }

        private void GeneralPage_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";

            Reload();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void saveTxb_Click(object sender, EventArgs e)
        {
            try
            {
                General general = new General();
                general.Date = dateTimePicker1.Value;
                general.PostSubsidy = int.Parse(postSubsidyTxb.Text);
                general.HouseAllowance = int.Parse(houseAllowanceTxb.Text);
                general.TransportAllowace = int.Parse(transportAllowanceTxb.Text);
                general.AttendanceBonus = int.Parse(attendanceBonusTxb.Text);
                general.OvertimeRate = int.Parse(overtimeRateTxb.Text);
                general.SocialSecurity = int.Parse(socialSecurityTxb.Text);
                general.ProvidentFund = int.Parse(providentFundTxb.Text);
                general.Pension = int.Parse(pensionTxb.Text);
                general.InjuryInsurance = int.Parse(injuryInsuranceTxb.Text);

                GeneralDAO generalDAO = new GeneralDAO();
                generalDAO.UpdateGeneral(general);
                MessageBox.Show("OK");
            } 
            catch
            {
                MessageBox.Show("Invalid");
            }
        }
    }
}
