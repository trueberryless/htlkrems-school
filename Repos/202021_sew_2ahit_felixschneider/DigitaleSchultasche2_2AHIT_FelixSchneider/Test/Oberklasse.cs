using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Oberklasse
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public Oberklasse()
        {
            Number = 123;
            Name = "_";
        }
        public Oberklasse(string name) : this()
        {
            Name = name;
        }
        public Oberklasse(int number) : this()
        {
            Number = number;
        }
        public Oberklasse(string name, int number) : this(name)
        {
            //Number = number;
        }

        public override string ToString()
        {
            return String.Format($"Name: {Name} / Number: {Number}");
        }
    }
}
