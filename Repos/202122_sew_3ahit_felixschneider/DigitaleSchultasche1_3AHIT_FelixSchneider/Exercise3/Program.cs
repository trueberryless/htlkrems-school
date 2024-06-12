using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Personmanager pm = new Personmanager(10);

            pm[8] = new Person();

            Person s = new Student();
            s.WriteType();
        }
    }
}
