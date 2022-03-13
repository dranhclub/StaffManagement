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
    public partial class MyAccountPage : UserControl
    {
        private int id;
        private string photoFilename;
        private string source;

        public MyAccountPage()
        {
            InitializeComponent();
        }

        private void MyAccountPage_Load(object sender, EventArgs e)
        {
            User user = Program.appCtx.user;
            if (user.Privilege == Privilege.Admin)
            {
                browseAvatarBtn.Enabled = false;
                nameTxb.Enabled = false;
                IDNumberTxb.Enabled = false;
                genderCbx.Enabled = false;  
                dobDTPicker.Enabled = false;
                emailTxb.Enabled = false;
                addressTxb.Enabled = false;
                phoneNumberTxb.Enabled = false;
                marriedCbx.Enabled = false;
                departmentCbx.Enabled = false;
                positionCbx.Enabled = false;
                UpdateProfileBtn.Enabled = false;
            } 
            else
            {
                EmployeeDAO employeeDAO = new EmployeeDAO();
                Employee employee = employeeDAO.GetById(user.Eid);

                id = user.Eid;

                avatarPicturebox.Image = employee.PhotoImage;
                photoFilename = employee.Photo;
                nameTxb.Text = employee.Name;
                IDNumberTxb.Text = employee.IdNumber;
                genderCbx.SelectedIndex = employee.Gender == "Male" ? 0 : 1;
                dobDTPicker.Value = employee.Birth;
                emailTxb.Text = employee.Email;
                addressTxb.Text = employee.Address;
                phoneNumberTxb.Text = employee.Phone;
                marriedCbx.SelectedIndex = employee.Married ? 0 : 1;

                DataTable departments = employeeDAO.GetDepartments();
                departmentCbx.DataSource = departments;
                departmentCbx.DisplayMember = "name";
                departmentCbx.ValueMember = "id";
                departmentCbx.SelectedValue = employee.DepartmentId;

                DataTable positions = employeeDAO.GetPositions();
                positionCbx.DataSource = positions;
                positionCbx.DisplayMember = "name";
                positionCbx.ValueMember = "id";
                positionCbx.SelectedValue = employee.PositionId;
            }

        }

        private void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee em = new Employee();
            em.Id = id;

            if (source != null)
            {
                photoFilename = id + DateTime.Now.ToString("HHmmss") + ".jpg";
                string dest = Path.Combine(Utils.photoFolderPath, photoFilename);
                File.Copy(source, dest, true);
            }
            em.Photo = photoFilename;
            
            em.Name = nameTxb.Text;
            em.IdNumber = IDNumberTxb.Text;
            em.Gender = (string)genderCbx.SelectedItem;
            em.Birth = dobDTPicker.Value;
            em.Email = emailTxb.Text;
            em.Address = addressTxb.Text;
            em.Phone = phoneNumberTxb.Text;
            em.Married = marriedCbx.SelectedIndex == 0 ? true : false;
            em.DepartmentId = (int) departmentCbx.SelectedValue;
            em.PositionId = (int)positionCbx.SelectedValue;

            employeeDAO.UpdateEmployee(em);

            MessageBox.Show("Update successfully. Please re-login");
        }

        private void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            string username = Program.appCtx.user.Username;
            string oldPassword = oldPasswordTxb.Text;
            string newPassword = newPasswordTxb.Text;

            if (oldPassword.Length == 0 || newPassword.Length == 0)
            {
                MessageBox.Show("Invalid");
                return;
            }

            UserDAO userDAO = new UserDAO();
            bool successful = userDAO.ChangePassword(username, oldPassword, newPassword);
            if (successful)
            {
                MessageBox.Show("Change password successfully");
                oldPasswordTxb.Text = "";
                newPasswordTxb.Text = "";
            } 
            else
            {
                MessageBox.Show("Old password is incorrect");
            }
        }

        private void browseAvatarBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                source = open.FileName;
                avatarPicturebox.Image = new Bitmap(open.FileName);
            }
        }
    }
}
