using System;
using System.Collections.Generic;
using System.Text;

namespace Tierheimverwaltung
{
    abstract class Animal
    {
        protected DateTime recordingDate;
        protected int weight;

        //Constructors
        public Animal() : this(0) { }

        public Animal(int weight)
        {
            recordingDate = DateTime.Now;
            if(weight > 0)
                this.weight = weight;
        }

        //Get-Set

        protected int Weight
        {
            get { return weight; }
            set { 
                if(weight > 0)
                    weight = value; 
            }
        }
    }
}
