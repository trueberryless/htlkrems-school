using System;
using System.Collections.Generic;
using System.Text;

namespace P20210226_Vererbung_override_
{
    class Bankkonto
    {
        protected int betrag;

        public void Einzahlen(int betrag)
        {
            this.betrag += betrag;
        }

        public virtual void Auszahlen(int betrag)
        {
            this.betrag -= betrag;
        }

        public void Ausgabe()
        {
            Console.WriteLine("Bankkonto mit " + betrag + " Betrag");
        }
    }

    class Sparkonto:Bankkonto
    {
        public override void Auszahlen(int betrag)
        {
            if(this.betrag > betrag)
            {
                base.Auszahlen(betrag);
            }
        }

        public new void Ausgabe()
        {
            Console.WriteLine("Sparkonto mit " + betrag + " Betrag");
        }
    }

    class Geschaeftskonto : Bankkonto
    {

    }
}
