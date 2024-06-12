using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Unterklasse:Oberklasse
    {
        public int[] Array { get; set; }

        public Unterklasse() : base()
        {
            Array = new int[] { 0 };
        }

        public Unterklasse(int[] array) : base()
        {
            Array = new int[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                Array[i] = array[i];
            }
        }

        public Unterklasse(int[] array, string name) : this(array)
        {
            Name = name;
        }

        public Unterklasse(int[] array, string name, int number) : this(array, name)
        {
            Number = number;
        }

        public override string ToString()
        {
            string array_string = "";
            for (int i = 0; i < Array.Length; i++)
            {
                array_string += Array[i] + ", ";
            }
            array_string = array_string.Substring(0, Array.Length * 3 - 2); // letztes ", " gelöscht
            return base.ToString() + String.Format($" / Array: {array_string}");
        }
    }
}
