using System;
using System.Collections.Generic;
using System.Text;

namespace T20201111_Computerspiele
{
    class Computerspiel
    {
        protected string name;
        protected int preis;

        public Computerspiel()
        {
            name = "";
            preis = 0;
        }

        public Computerspiel(string name)
        {
            this.name = name;
        }

        public Computerspiel(string name, int preis) :this(name)
        {
            this.preis = preis;
            Console.WriteLine("Konstruktor von Computerspiel");
        }

        protected string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected int Preis
        {
            get { return preis; }
            set { preis = value; }
        }

        public virtual void Print()
        {
            Console.WriteLine("Computerspiel: " + name + " " + preis);
        }
    }
}