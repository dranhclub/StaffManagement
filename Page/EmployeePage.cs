using System;
using System.IO;
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
    public partial class EmployeePage : UserControl
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        public void LoadData()
        {
            Refresh();
            Clear();
            EmployeeDAO employeeDAO = new EmployeeDAO();
            DataTable dataTable = employeeDAO.GetEmployees();
            dataGridView1.DataSource = dataTable;

            DataGridViewImageColumn column = new DataGridViewImageColumn();
            column.ImageLayout = DataGridViewImageCellLayout.Stretch;
            column.Name = "Image";
            column.HeaderText = "Photo";
            column.DefaultCellStyle.NullValue = null;
            dataGridView1.Columns.Insert(4, column);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;

            dataGridView1.Columns["Photo"].Visible = false;
        }

        private void EmployeePage_Load(object sender, EventArgs e)
        {
            if (Program.appCtx.user.Privilege == Privilege.Employee)
            {
                controlPanel.Visible = false;
            }
            LoadData();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm(this);
            addEmployeeForm.Show();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                int id = (int) row.Cells["ID"].Value;
                EditEmployeeForm addEmployeeForm = new EditEmployeeForm(this, id);
                addEmployeeForm.Show();
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                Console.WriteLine(dataGridView1.SelectedRows[0]);
                EmployeeDAO employeeDAO = new EmployeeDAO();
                int id = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
                employeeDAO.DeleteById(id);
            }
            LoadData();
        }

        private void DetailBtn_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;
                new Detail(id).Show();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if DGV has not initialized yet
            if (dataGridView1.Columns["Image"] == null) return;

            if (e.RowIndex > -1 && e.ColumnIndex == dataGridView1.Columns["Image"].Index)
            {
                if (dataGridView1["Photo", e.RowIndex].Value != null)
                {
                    string s = this.dataGridView1["Photo", e.RowIndex].Value.ToString();
                    if (s.Length == 0) return;
                    string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                    string ppPath = Path.GetFullPath(Path.Combine(RunningPath, @"..\..\"));
                    string FileName = string.Format("{0}res\\photo\\{1}", ppPath, s);
                    e.Value = new Bitmap(FileName);
                }
            }
        }
    }
}
