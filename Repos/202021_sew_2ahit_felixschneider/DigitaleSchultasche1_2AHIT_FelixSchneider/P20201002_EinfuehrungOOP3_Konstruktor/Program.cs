using System;

namespace P20201002_EinfuehrungOOP3_Konstruktor
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Felix", "Schneider");
            p1.WritePerson();

            Person p2 = new Person("Felix353", "Schneider");
            p2.WritePerson();

            Person p3 = new Person("Felix", "#Schneider");
            p3.WritePerson();
        }
    }
}
