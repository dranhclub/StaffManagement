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
    public partial class AttendancePage : UserControl
    {
        public AttendancePage()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
        }

        private void Reload()
        {
            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int numDays = Utils.getDays(month, year);

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID";
            idColumn.HeaderText = "ID";
            idColumn.DataPropertyName = "ID";

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Employee Name";
            nameColumn.HeaderText = "Name";
            nameColumn.DataPropertyName = "EmployeeName";

            dataGridView1.Columns.AddRange(idColumn, nameColumn);
            DataGridViewCheckBoxColumn[] dayColumns = new DataGridViewCheckBoxColumn[numDays];
            for (int i = 0; i < numDays; i++)
            {
                dayColumns[i] = new DataGridViewCheckBoxColumn();
                string name = (i + 1).ToString();
                dayColumns[i].Name = name;
                dayColumns[i].HeaderText = name;
                dayColumns[i].Width = 32;
                dayColumns[i].DataPropertyName = name;
            }

            dataGridView1.Columns.AddRange(dayColumns);

            AttendanceDAO atDAO = new AttendanceDAO();
            DataTable dataTable = atDAO.GetAbsenceTable(year, month);
            dataGridView1.DataSource = dataTable;
        }

        private void AttendancePage_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Reload();   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int day = int.Parse(dataGridView1.Columns[e.ColumnIndex].Name);
            int id = int.Parse((string)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            bool check = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string == null ? false : true;

            AttendanceDAO attendanceDAO = new AttendanceDAO();
            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int numDays = Utils.getDays(month, year);
            attendanceDAO.UpdateAbsence(year, month, day, id, check);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
