using System;
using System.Collections.Generic;
using System.Text;

namespace Tierheimverwaltung
{
    class Dog:Animal
    {
        protected string bark;

        //Constructors
        public Dog():this("none") { }

        public Dog(string bark):this(bark, 0) { }

        public Dog(string bark, int weight):base(weight)
        {
            this.bark = bark;
        }

        //Get-Set

        public string Bark
        {
            get { return bark; }
            set { bark = value; }
        }

        public override string ToString()
        {
            return $"Weight: {weight}kg, Barks: {bark}, recording-Date: {recordingDate}";
        }
    }
}
