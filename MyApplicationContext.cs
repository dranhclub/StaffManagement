using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagement
{
    class MyApplicationContext : ApplicationContext
    {
        public User user;
        public int numberOpeningForm = 0;
        
        public MyApplicationContext()
        {
            ShowLoginForm();
        }

        public void ShowLoginForm()
        {
            ShowFormAndAddClosedEvent(new LoginForm());
        }

        public void ShowMainForm()
        {
            ShowFormAndAddClosedEvent(new MainForm());
        }

        private void ShowFormAndAddClosedEvent(Form form)
        {
            form.Show();
            numberOpeningForm++;
            form.FormClosed += (s, e) =>
            {
                numberOpeningForm -= 1;
                if (numberOpeningForm == 0)
                {
                    Application.Exit();
                }
            };
        }
    }
}
