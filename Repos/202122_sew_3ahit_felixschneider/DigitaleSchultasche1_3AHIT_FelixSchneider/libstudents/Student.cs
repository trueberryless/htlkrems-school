using System;
using libperson;

namespace libstudents
{
    public class Student : Person
    {
        private int grade;
        private int id;
        public string Classname { get; set; }

        public int Grade
        {
            get { return grade; }
            set
            {
                if (!(value >= 9 && value <= 14))
                    throw new Exception("Grade can only between 9 and 14!");
                else grade = value;
            }
        }

        public int ID
        {
            get { return id; }
            set
            {
                if (!(value >= 100000 && value <= 999999))
                    throw new Exception("ID has to have 6 characters!");
                else id = value;
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("Name: {0} {1}, ", this.Firstname, this.Surname);
            sb.AppendFormat("Age: {0}, ", this.Age);
            sb.AppendFormat("Email: {0}, ", this.Email);
            sb.AppendFormat("Classname: {0}, ", this.Classname);
            sb.AppendFormat("Grade: {0}, ", this.Grade);
            sb.AppendFormat("ID: #{0}", this.ID);
            return sb.ToString();
        }
    }
}
