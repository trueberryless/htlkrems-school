static bool binary_search(int value, int[] daten)
{
    int from = 0;
    int to = daten.Length;
    int middle;

    while (to - from > 0)
    {
        middle = (to + from) / 2;    //findet die Mitte bei von bis heraus
        Console.WriteLine($"Suche {value} von {from} bis {to} bei {middle}");
        if (daten[middle] == value)      //ist die gesuchte Zahl schon bei der Mitte
        {
            return true;
        }

        if (from == to - 1)      //sollte die Zahl nicht vorhanden sein, wird aus der Schleife gesprungen
        {
            break;
        }

        if (value > daten[middle]) //ist der Wert der Zahl größer als die Mitte, wird nach "rechts" gewandert
        {
            from = middle;
        }
        else
        {//andernfalls nach "links"
            to = middle;
        }
    }
    return false;
}