static bool binaere_suche(int wert, int[] daten)
        {
            int von = 0;
            int bis = daten.Length;
            int mitte;
            while(true)
            {
                mitte = (bis + von) / 2; //sucht die mitte der beiden Enden (dezimalstelle wird abgeschnitten)
                Console.WriteLine($"suche {wert} von {von} bis {bis} bei {mitte}");

                if (daten[mitte] == wert)   //ist die momentane Mitte die gesuchte Zahl? 
                    return true;

                if (von == bis - 1)     //ist die Zahl nicht dabei, spring aus der Schleife
                {
                    break;
                }

                if (wert > daten[mitte])    //ist der Wert größer als die Mitte, wird rechts weit
                    von = mitte;
                else                        //andernfalls links
                    bis = mitte;
            }
            return false;       //Zahl ist nicht dabei
        }