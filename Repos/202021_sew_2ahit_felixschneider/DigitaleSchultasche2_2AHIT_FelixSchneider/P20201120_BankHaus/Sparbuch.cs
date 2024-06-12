using System;
using System.Collections.Generic;
using System.Text;

namespace P20201120_BankHaus
{
    class Sparbuch:Konto
    {
        public double SparZinsen { get; set; }
        public Sparbuch(string name, double sz):base(name)
        {
            SparZinsen = sz;
        }

        public Sparbuch(string name, double sz, double stand) : this(name, sz)
        {
            Stand = stand;
        }
        public override double Abheben(double betrag)
        {
            double abhebeBetrag = betrag;
            if ((Stand - betrag) < 0)
            {
                abhebeBetrag = Stand;
                Console.WriteLine("Betrag übersteigt Sparbucheinlage");
            }

            Stand -= abhebeBetrag;
            return abhebeBetrag;
        }

        public override string ToString()
        {
            return " / Sparzinsen: " + SparZinsen + base.ToString();
        }

        public override void TagesAbschluss()
        {
            Stand += (Stand * (SparZinsen / 100)) / 360;
        }

        public void Weltspartag()
        {
            Console.WriteLine("Geschenk!");
        }
    }
}
