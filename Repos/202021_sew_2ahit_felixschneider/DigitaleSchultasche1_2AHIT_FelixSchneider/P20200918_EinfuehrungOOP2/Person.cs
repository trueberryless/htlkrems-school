using System;
using System.Collections.Generic;
using System.Text;

namespace P20200918_EinfuehrungOOP2
{
    class Person
    {
        // Datenkapselung
        private string firstname;
        private string surname;

        // öffentlichen Zugriff auf Daten über Methoden
        // Get"Variable" und Set"Variable" sind klassische Techniken dafür
        public void SetSurname(string value)
        {
            if (CheckIfName(value) == true)
                this.surname = value;
            else
                throw new Exception("Surname isn't properly formatted!");
        }
        public string GetSurname()
        {
            return this.surname;
        }

        // öffentlichen Zugriff auf Daten über Get / Set
        // in C# quase "state of the art" (Stand der Technik)
        public string Firstname
        {
            get { return this.firstname; }
            set {
                if (CheckIfName(value) == true)
                    this.firstname = value;
                else
                    throw new Exception("Firstname hasn't a valid format!");
            }
        }
        private bool CheckIfName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] < 'A')
                    return false;
                if (name[i] > 'Z' && name[i] < 'a')
                    return false;
                if (name[i] > 'z')
                    return false;
            }
            return true;
        }
    }
}
