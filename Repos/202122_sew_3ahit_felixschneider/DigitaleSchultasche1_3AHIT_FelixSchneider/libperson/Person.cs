using System;

namespace libperson
{
    public enum EEyecolor { none, brown, blue, green }
    public class Person
    {
        private string firstname;
        private string surname;
        private int age;
        private string email;
        private string phonenumber;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if(!(value >= 0 && value <= 150))
                {
                    throw new Exception("Invalid age!");
                }
                else age = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (!value.Contains("@"))
                {
                    throw new Exception("Email needs @!");
                }
                else email = value;
            }
        }

        public string Phonenumber
        {
            get
            {
                return phonenumber;
            }
            set
            {
                foreach (char item in value)
                {
                    if (!((item >= 0x30 && item <= 0x39) || item == 0x2b || item == 0x20))
                    {
                        throw new Exception("Phonenumber is invalid");
                    }
                    else phonenumber = value;
                }
            }
        }

        public EEyecolor Eyecolor { get; set; }

        public string Firstname
        {
            get { return firstname; }
            set
            {
                foreach (char item in value)
                {
                    if (item >= 0x30 && item <= 0x39)
                        throw new Exception("Name can not contain numbers!");
                    else firstname = value;
                }
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                foreach (char item in value)
                {
                    if (item >= 0x30 && item <= 0x39)
                        throw new Exception("Name can not contain numbers!");
                    else surname = value;
                }
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("Person:  Name: {0} {1}, ", this.Firstname, this.Surname);
            sb.AppendFormat("Age: {0}, ", this.Age);
            sb.AppendFormat("Email: {0}, ", this.Email);
            sb.AppendFormat("Phonenumber: {0}", this.Phonenumber);
            sb.AppendFormat("Eyecolor: {0}, ", this.Eyecolor);

            return sb.ToString();
        }
    }
}
