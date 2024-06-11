using System;
using System.Collections.Generic;
using System.Text;

namespace SortierenUndSuchen
{
    class macho
    {
        // ich weiß, nicht auf englisch ;)
        static bool binaere_suche(int wert, int[] daten)
        {
            // Hilfsvariablen setzen
            int von = 0;
            int bis = daten.Length - 1;
            int mitte;

            while (bis - von > 1)
            {
                // Mitte ermitteln
                mitte = (bis + von) / 2;
                Console.WriteLine($"suche {wert} von {von} bis {bis} bei {mitte}");

                // gefunden!
                if (daten[mitte] == wert)
                    return true;

                // wenn nicht, dann Grenzen neu setzen
                if (wert > daten[mitte])
                    von = mitte;
                else
                    bis = mitte;
            }
            // jetzt kann es nur noch an diesen 2 Positionen sein
            Console.WriteLine($"dann bei {von} oder {bis}");
            if (daten[bis] == wert)
                return true;
            if (daten[von] == wert)
                return true;

            //dann halt nicht!
            return false;
        }
    }
}
