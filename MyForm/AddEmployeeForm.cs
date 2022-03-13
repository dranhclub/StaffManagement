using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagement
{
    public partial class AddEmployeeForm : Form
    {
        private EmployeePage employeePage;
        private int id;
        private string photoFileName;

        public AddEmployeeForm(EmployeePage employeePage)
        {
            InitializeComponent();
            this.employeePage = employeePage;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxb.Text;
            string gender = genderCbx.Text;
            string idnumber = idnumberCbx.Text;
            DateTime birth = dobTimePicker.Value;
            string address = addressTxb.Text;
            string email = emailTxb.Text;
            string phone = phoneTxb.Text;
            string married = marriedCbx.Text;

            if (name.Length == 0 || idnumber.Length == 0)
            {
                MessageBox.Show("Invalid");
                return;
            }

            EmployeeDAO employeeDAO = new EmployeeDAO();

            Employee em = new Employee();
            em.Name = name;
            em.Gender = gender;
            em.IdNumber = idnumber;
            em.Birth = birth;
            em.Photo = photoFileName;
            em.Address = address;
            em.Email = email;
            em.Phone = phone;
            em.Married = married.Equals("True");
            em.DepartmentId = (int)departmentCbx.SelectedValue;
            em.PositionId = (int)positionCbx.SelectedValue;

            employeeDAO.AddNewEmployee(em);

            employeePage.LoadData();
            Close();
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            id = (employeeDAO.GetLastestId() + 1);
            idTbx.Text = id.ToString();

            genderCbx.SelectedIndex = 0;
            marriedCbx.SelectedIndex = 0;

            DataTable departmentTable = employeeDAO.GetDepartments();
            departmentCbx.DataSource = departmentTable;
            departmentCbx.DisplayMember = "name";
            departmentCbx.ValueMember = "id";
            departmentCbx.SelectedIndex = 0;

            DataTable positionTable = employeeDAO.GetPositions();
            positionCbx.DataSource = positionTable;
            positionCbx.DisplayMember = "name";
            positionCbx.ValueMember = "id";
            departmentCbx.SelectedIndex = 0;

            photoPtb.Image = new Bitmap(Utils.photoFolderPath + ".\\avatar.png");
        }

        private void choosePhotoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string source = open.FileName;
                photoFileName = id + DateTime.Now.ToString("HHmmss") + ".jpg";
                string dest = Path.Combine(Utils.photoFolderPath, photoFileName);
                File.Copy(source, dest, true);
                photoPtb.Image = new Bitmap(open.FileName);
            }
        }
    }
}
