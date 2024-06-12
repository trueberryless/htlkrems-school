using System;
using System.Collections.Generic;
using System.Text;

namespace P20201120_BankHaus
{
    class GiroKonto:Konto
    {
        //double ueberziehungsRahmen; //Maximum im negativen Bereich
        //double ueberziehungsZinsen; //ca. 7 - 13 % p.a. per Anno (pro Jahr)

        public double UeberziehungsRahmen { get; set; }
        public double UeberziehungsZinsen { get; set; }

        public GiroKonto(string name) : base(name) { }
        public GiroKonto(string name, double rahmen) : base(name)
        {
            UeberziehungsRahmen = rahmen;
        }
        public GiroKonto(string name, double rahmen, double zinsen) : this(name, rahmen)
        {
            UeberziehungsZinsen = zinsen;
        }
        public GiroKonto(string name, double rahmen, double zinsen, double stand) : this(name, rahmen, zinsen)
        {
            Stand = stand;
        }

        public override double Abheben(double betrag)
        {
            //überlegen wir uns später
            //if(Stand < 0)
            //    Stand -= Stand / 100 * 10 / 365 * 5;

            double abhebeBetrag = betrag; //300€
            if ((Stand - betrag) < (UeberziehungsRahmen * -1)) //Stand: 100€; Rahmen: 100€
            {
                abhebeBetrag = Stand + UeberziehungsRahmen;
                Console.WriteLine("Betrag übersteigt Rahmen");
            }

            Stand -= abhebeBetrag;
            return abhebeBetrag;
        }

        public override void Show()
        {
            Console.Write("Besitzer: " + Besitzer + " / Zinsen: " + UeberziehungsZinsen + " / Stand: ");
            if (Stand < 0)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Math.Abs(Stand));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public override string ToString()
        {
            Console.Write("Rahmen: " + UeberziehungsRahmen + " / ");
            return base.ToString();
        }

        public override void TagesAbschluss()
        {
            if (Stand > 0)
                Stand += (Stand * 0.2) / 365;
            else
                Stand += (Stand * (UeberziehungsZinsen /100) / 365);
        }
    }
}
