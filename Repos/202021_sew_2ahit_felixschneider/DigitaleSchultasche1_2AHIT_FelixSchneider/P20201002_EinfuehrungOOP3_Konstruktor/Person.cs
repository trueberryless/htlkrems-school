using System;
using System.Collections.Generic;
using System.Text;

namespace P20201002_EinfuehrungOOP3_Konstruktor
{
    class Person
    {
        private string firstname;
        private string surname;

        public Person(string f, string s)
        {
            if (CheckName(f))
                this.firstname = f + " ";
            if (CheckName(s))
                this.surname = s;
        }

        private bool CheckName(string name)
        {
            name = name.ToUpper();
            if (name.Length < 3)
                return false;
            for (int i = 0; i < name.Length; i++)
            {
                if ((char)name[i] < 65)
                    return false;
                if ((char)name[i] > 90)
                    return false;
            }
            return true;
        }

        public void WritePerson()
        {
            Console.WriteLine(this.firstname + this.surname);
        }
    }
}
