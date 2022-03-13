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
    public partial class DeductionPage : UserControl
    {
        public DeductionPage()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
        }

        private void Reload()
        {
            int departmentId = (int)departmentCbx.SelectedValue;
            PayrollDAO payrollDAO = new PayrollDAO();
            DataTable datatable = payrollDAO.GetDeductions(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, departmentId);
            dataGridView1.DataSource = datatable;
        }

        private void DeductionPage_Load(object sender, EventArgs e)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            DataTable departments = employeeDAO.GetDepartments();
            departmentCbx.DataSource = departments;
            departmentCbx.DisplayMember = "name";
            departmentCbx.ValueMember = "id";

            Reload();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int departmentId = (int)departmentCbx.SelectedValue;
            PayrollDAO payrollDAO = new PayrollDAO();
            DataTable datatable = payrollDAO.GetDeductions(year, month, departmentId);
            dataGridView1.DataSource = datatable;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private int departmentCbxChangeTimes = 0;
        private void departmentCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departmentCbxChangeTimes < 2)
            {
                departmentCbxChangeTimes++;
            }
            else
            {
                Reload();
            }
        }
    }
}
