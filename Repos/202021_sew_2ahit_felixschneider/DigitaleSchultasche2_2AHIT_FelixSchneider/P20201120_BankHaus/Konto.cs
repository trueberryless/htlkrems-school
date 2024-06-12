using System;
using System.Collections.Generic;
using System.Text;

namespace P20201120_BankHaus
{
    abstract class Konto
    {
        protected double Stand { get; set; }
        public int KontoNr { get; set; }
        public string Besitzer { get; set; }

        public Konto()
        {
            Besitzer = "";
            KontoNr = SerialNr.NextNr();
            Stand = 0;
        }
        public Konto(string besitzer) //"(string besitzer)" Signatur einer Methode
        {                
            Besitzer = besitzer;
            KontoNr = SerialNr.NextNr();
            Stand = 0;
        }
        public Konto(string besitzer, double stand):this(besitzer)
        {
            Stand = stand;
        }

        public virtual double Abheben(double betrag)
        {
            Stand -= betrag;
            return betrag;
        }

        public void Einzahlen(double betrag)
        {
            Stand += betrag;
        }

        public virtual void Show()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            Console.Write("Konto Nummer: " + KontoNr + " / Besitzer: " + Besitzer + " / Stand: ");
            if (Stand < 0)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Stand * -1);
            Console.ForegroundColor = ConsoleColor.Gray;
            return "";
        }

        public abstract void TagesAbschluss();
    }
}
