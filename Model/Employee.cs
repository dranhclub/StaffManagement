using System;
using System.Drawing;
using System.IO;

namespace StaffManagement
{
    public class Employee
    {
        private int id;
        private string name;
        private string gender;
        private string idNumber;
        private string photo;
        private Image photoImage;
        private DateTime birth;
        private string address;
        private string email;
        private string phone;
        private bool married;
        private int departmentId;
        private int positionId;


        public Employee()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public string Photo {
            get => photo;
            set {
                photo = value;
                PhotoImage = Utils.getImageFromFileName(value);
            } 
        }
        public Image PhotoImage { get => photoImage; set => photoImage = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public bool Married { get => married; set => married = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
        public int PositionId { get => positionId; set => positionId = value; }
    }
}
