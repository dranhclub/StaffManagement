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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void EnterMainForm(User user)
        {
            Program.appCtx.user = user;
            Program.appCtx.ShowMainForm();
            Close();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            string username = username_tb.Text;
            string password = password_tb.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Invalid");
                return;
            }

            UserDAO userDAO = new UserDAO();
            User user = userDAO.Login(username, password);
            if (user != null)
            {
                EnterMainForm(user);
            } 
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void QuickLoginAsAdminBtn_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            User admin = userDAO.GetAdminUser();
            username_tb.Text = admin.Username;
            password_tb.Text = admin.Password;
        }

        private void QuickLoginAsEmployeeBtn_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            User user = userDAO.GetRandomEmployeeUser();
            username_tb.Text = user.Username;
            password_tb.Text = user.Password;
        }
    }
}
