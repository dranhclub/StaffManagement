using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagement
{
    public partial class Detail : Form
    {
        private int id;

        public Detail(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();

            Employee employee = employeeDAO.GetById(id);
            string department = employeeDAO.GetDepartmentNameById(employee.DepartmentId);
            string position = employeeDAO.GetPositionNameById(employee.PositionId);
            string photoUri = new Uri(Utils.photoFolderPath + "\\" + employee.Photo).AbsoluteUri;

            ReportParameter[] rParams = new ReportParameter[]
            {
                    new ReportParameter("id", id.ToString()),
                    new ReportParameter("name", employee.Name),
                    new ReportParameter("gender", employee.Gender),
                    new ReportParameter("id_number", employee.IdNumber),
                    new ReportParameter("photo", photoUri),
                    new ReportParameter("birth", employee.Birth.ToString()),
                    new ReportParameter("address", employee.Address),
                    new ReportParameter("email", employee.Email),
                    new ReportParameter("phone", employee.Phone),
                    new ReportParameter("married", employee.Married.ToString()),
                    new ReportParameter("department", department),
                    new ReportParameter("position", position),
            };
            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.SetParameters(rParams);


            this.reportViewer1.RefreshReport();
        }
    }
}
