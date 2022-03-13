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
    public partial class MainForm : Form
    {
        private bool isSidebarExpanded = true;
        private bool isSalarySubmenuExpanded = false;
        private bool isRegulationSubmenuExpanded = false;
        public MainForm()
        {
            InitializeComponent();
            salarySubmenu.Height = 0;
            regulationSubmenu.Height = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            User user = Program.appCtx.user;
            if (user.Privilege == Privilege.Admin)
            {
                usernameLabel.Text = user.Username;
                nameLabel.Text = "Administrator";
            }
            else
            {
                EmployeeDAO employeeDAO = new EmployeeDAO();
                Employee employee = employeeDAO.GetById(user.Eid);
                usernameLabel.Text = user.Username;
                nameLabel.Text = employee.Name;
                photoPicturebox.Image = employee.PhotoImage;
                regulationBtn.Enabled = false;
            }
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            AddUserControl(homePage);
        }


        private void EmployeesBtn_Click(object sender, EventArgs e)
        {
            EmployeePage manageStaffPage = new EmployeePage();
            AddUserControl(manageStaffPage);
        }

        private void MenuBtn_Click(object sender, EventArgs e)
        {
            slidebarTimer.Start();    
        }

        private void slidebarTimer_Tick(object sender, EventArgs e)
        {
            if (!isSidebarExpanded)
            {
                menuContainer.Width += 10;
                if (menuContainer.Width >= menuContainer.MaximumSize.Width)
                {
                    isSidebarExpanded = true;
                    slidebarTimer.Stop();
                }
            } 
            else
            {
                menuContainer.Width -= 10;
                if (menuContainer.Width <= menuContainer.MinimumSize.Width)
                {
                    isSidebarExpanded = false;
                    slidebarTimer.Stop();
                }
            }
        }

        private void salarySubmenuTimer_Tick(object sender, EventArgs e)
        {
            if (!isSalarySubmenuExpanded)
            {
                salarySubmenu.Height += 10;
                if (salarySubmenu.Height >= salarySubmenu.MaximumSize.Height)
                {
                    isSalarySubmenuExpanded = true;
                    salarySubmenuTimer.Stop();
                }
            } else
            {
                salarySubmenu.Height -= 10;
                if (salarySubmenu.Height <= salarySubmenu.MinimumSize.Height)
                {
                    isSalarySubmenuExpanded = false;
                    salarySubmenuTimer.Stop();
                }
            }
        }

        private void salaryBtn_Click(object sender, EventArgs e)
        {
            salarySubmenuTimer.Start();
        }

        private void regulationBtn_Click(object sender, EventArgs e)
        {
            regulationSubmenuTimer.Start();
        }

        private void regulationSubmenuTimer_Tick(object sender, EventArgs e)
        {
            if (!isRegulationSubmenuExpanded)
            {
                regulationSubmenu.Height += 10;
                if (regulationSubmenu.Height >= regulationSubmenu.MaximumSize.Height)
                {
                    isRegulationSubmenuExpanded = true;
                    regulationSubmenuTimer.Stop();
                }
            }
            else
            {
                regulationSubmenu.Height -= 10;
                if (regulationSubmenu.Height <= regulationSubmenu.MinimumSize.Height)
                {
                    isRegulationSubmenuExpanded = false;
                    regulationSubmenuTimer.Stop();
                }
            }
        }

        private void EmployeesBtn_Click_1(object sender, EventArgs e)
        {
            AddUserControl(new EmployeePage());
        }

        private void myaccountBtn_Click(object sender, EventArgs e)
        {
            AddUserControl(new MyAccountPage());
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            AddUserControl(new HelpPage());
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Program.appCtx.ShowLoginForm();
            Close();
        }

        private void payrollBtn_Click(object sender, EventArgs e)
        {
            AddUserControl(new PayrollPage());
        }

        private void allowanceBonusBtn_Click(object sender, EventArgs e)
        {
            AddUserControl(new AllowanceBonusPage());
        }

        private void deductionBtn_Click(object sender, EventArgs e)
        {
            AddUserControl(new DeductionPage());
        }

        private void generalBtn_Click(object sender, EventArgs e)
        {
            AddUserControl(new GeneralPage());
        }

        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            AddUserControl(new AttendancePage());
        }

        private void overtimeBtn_Click(object sender, EventArgs e)
        {
            AddUserControl(new OvertimePage());
        }

        private void HelpBtn_Click_1(object sender, EventArgs e)
        {
            AddUserControl(new HelpPage());
        }

        private void MyAccountBtn_Click_1(object sender, EventArgs e)
        {
            AddUserControl(new MyAccountPage());
        }
    }
}
