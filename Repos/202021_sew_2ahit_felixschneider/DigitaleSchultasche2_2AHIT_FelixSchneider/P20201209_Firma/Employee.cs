using System;
using System.Collections.Generic;
using System.Text;

namespace P20201209_Firma
{
    class Employee:Person
    {
        int salary_per_hour;

        public Employee(int salary_per_hour, string firstname, string surname):base(firstname, surname)
        {
            this.salary_per_hour = salary_per_hour;
        }

        public Employee(int salary_per_hour, string firstname):this(salary_per_hour, firstname, "(unbekannt)") { }

        //Methodenüberladung
        public int GetMonthlySalary(int hours_worked)
        {
            return hours_worked * salary_per_hour;
        }
        public int GetMonthlySalary(int hours_worked, int bonus)
        {
            //return hours_worked * salary_per_hour + bonus;
            return GetMonthlySalary(hours_worked) + bonus;
        }


        public void Pointless_Method()
        {
            //inerhalb einer Mathode kann ich auf alle Variablen
            //der eigenen Klasse zugreifen
            //egal, ob public, protected oder private

            //aber nur auf jene Variablen der Basisklasse,
            //die public oder protected sind
            Console.WriteLine(firstname);
            //Console.WriteLine(surname);
        }
    }
}
