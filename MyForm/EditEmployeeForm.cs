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
    public partial class EditEmployeeForm : Form
    {
        private EmployeePage employeePage;
        private int id;
        private string photoFileName;

        public EditEmployeeForm(EmployeePage employeePage, int id)
        {
            InitializeComponent();
            this.employeePage = employeePage;
            this.id = id;
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
            
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee employee = new Employee();

            employee.Id = id;
            employee.Name = name;
            employee.Gender = gender;
            employee.IdNumber = idnumber;
            employee.Photo = photoFileName;
            employee.Birth = birth;
            employee.Address = address;
            employee.Email = email;
            employee.Phone = phone;
            employee.Married = married.Equals("True");
            employee.DepartmentId = (int)departmentCbx.SelectedValue;
            employee.PositionId = (int)positionCbx.SelectedValue;

            employeeDAO.UpdateEmployee(employee);

            employeePage.LoadData();
            Close();
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee em = employeeDAO.GetById(id);
            idTbx.Text = id.ToString();
            nameTxb.Text = em.Name;
            genderCbx.Text = em.Gender;
            idnumberCbx.Text = em.IdNumber;
            dobTimePicker.Value = em.Birth;
            addressTxb.Text = em.Address;
            emailTxb.Text = em.Email;
            phoneTxb.Text = em.Phone;
            marriedCbx.SelectedIndex = marriedCbx.FindString(em.Married ? "True" : "False");
            
            DataTable departmentTable = employeeDAO.GetDepartments();
            departmentCbx.DataSource = departmentTable;
            departmentCbx.DisplayMember = "name";
            departmentCbx.ValueMember = "id";
            departmentCbx.SelectedValue = em.DepartmentId;

            DataTable positionTable = employeeDAO.GetPositions();
            positionCbx.DataSource = positionTable;
            positionCbx.DisplayMember = "name";
            positionCbx.ValueMember = "id";
            positionCbx.SelectedValue = em.PositionId;
            
            photoPtb.Image = em.PhotoImage;
            photoFileName = em.Photo;
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
