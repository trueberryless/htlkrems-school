using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual void WriteType()
        {
            Console.WriteLine("Person");
        }
    }

    class Student : Person
    {
        public override void WriteType()
        {
            Console.WriteLine("Student");
        }
    }

    class Personmanager
    {
        Person[] p;

        public Personmanager(int idx)
        {
            if (idx >= 0)
                p = new Person[idx];
            else throw new Exception("No positive integer.");
        }

        public Person this[int idx]
        {
            get
            {
                if (idx <= p.Length && idx >= 0)
                    return p[idx];
                else throw new Exception("Not so many persons in list.");
            }
            set
            {
                if (idx <= p.Length && idx >= 0)
                    p[idx] = value;
                else throw new Exception("Can not contain so many persons.");
            }
        }
    }
}
