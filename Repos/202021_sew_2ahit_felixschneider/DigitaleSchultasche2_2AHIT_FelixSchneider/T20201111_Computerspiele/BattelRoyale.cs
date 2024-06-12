using System;
using System.Collections.Generic;
using System.Text;

namespace T20201111_Computerspiele
{
    class BattelRoyale : Computerspiel
    {
        int zeitlimit;
        public BattelRoyale(string name, int preis) :base(name, preis) 
        {
            Console.WriteLine("Konstruktor von BattelRoyale");
        }

        public BattelRoyale(string name, int preis, int zeitlimit) :this(name, preis)
        {
            this.zeitlimit = zeitlimit;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Zeitlimit für BattleRoyale Spiele: " + zeitlimit);
        }
    }
}
