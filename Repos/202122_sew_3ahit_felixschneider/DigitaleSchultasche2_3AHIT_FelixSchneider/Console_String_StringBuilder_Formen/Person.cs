using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_String_StringBuilder_Formen
{
    public class Person
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(string name):this(name, 0) { }

        public Person():this(null, 0) { }
    }
}
