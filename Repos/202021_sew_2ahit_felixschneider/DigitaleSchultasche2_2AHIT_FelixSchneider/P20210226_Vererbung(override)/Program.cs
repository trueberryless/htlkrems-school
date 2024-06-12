using System;

namespace P20210226_Vererbung_override_
{
    class Program
    {
        static void Main(string[] args)
        {
            Bankkonto b1 = new Bankkonto();
            b1.Auszahlen(100);  //obere

            Sparkonto s1 = new Sparkonto();
            s1.Auszahlen(123); //untere

            Bankkonto b2 = new Sparkonto();   //Barkonto
            b2.Auszahlen(345); //untere

            Bankkonto[] raika = new Bankkonto[10];
            raika[0] = b1;
            raika[1] = s1;
            raika[2] = b2; //Sparkonto

            b1.Ausgabe(); //obere
            s1.Ausgabe(); //untere
            b2.Ausgabe(); //obere

            Bankkonto g1 = new Geschaeftskonto();
            //Sparkonto s2 = (Sparkonto)g1; --> liefert Exception

            raika[3] = g1;

            foreach (var item in raika)
            {
                if (item is Sparkonto)
                {

                }
            }

            //ähnlich: Bankkonto=Tier
            //Hund=Sparkonto, Katze=Geschäftskonto

            // => somit wäre der Hund (s2) eine Katze (g1)
        }
    }
}
