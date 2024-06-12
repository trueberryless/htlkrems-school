using System.Text;

static void Write(string path, string text)
{
    using (StreamWriter sw = new StreamWriter(path, true))
    {
        sw.WriteLine();
        sw.WriteLine(text);
    }
}

static void DeleteOldFile(string path)
{
    using (StreamWriter sw = new StreamWriter(path))
    {
        sw.Write("");
    }
}

static string Triangle(int von, int bis, int max)
{
    StringBuilder sb = new StringBuilder();

    // von & bis müssen entweder beide gerade oder ungerade sein, weil b immer um 2 erhöht wird
    if (von % 2 == 0) // Fall 1: von & bis sind gerade
    {
        if (bis % 2 != 0) bis++;
    }
    else if (bis % 2 == 0) bis++; // Fall 2: von & bis sind ungerade

    int size = (bis - von) / 2 + 1;
    int b = von; // b = Anzahl an Zeichen (*) in einer Zeile

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < (max - bis) / 2; j++)   // Damit oberen Dreiecke mittig in Bezug auf unterstem Dreieck sind.
                                                    // Ansonsten wäre die letzte Zeile des ersten Dreiecks des Baumes ganz am linken Rand...
        {
            sb.Append(" ");
        }

        for (int j = 0; j < (bis - b) / 2; j++) // Leerzeichen links von Baum
        {
            sb.Append(" ");
        }

        for (int j = 0; j < b; j++) // eigentlicher Baum
        {
            sb.Append("*");
        }

        b += 2; // 2, weil links und rechts, ansonsten nicht symmetrisch

        sb.AppendLine();
    }

    return sb.ToString();
}

static string Tree(int size, int x) //x = Anzahl_wie_viele_b_plus_pro_Fluegel
{
    StringBuilder sb = new StringBuilder();

    while (size % x != 0) size++;

    int b = 1;

    int max = 1 + (size / x - 1) * 2 + (x-1) * 2;

    for (int i = 0; i < size / x; i++)
    {
        sb.Append(Triangle(b, b + (x-1) * 2, max));
        b += 2;
    }

    for (int i = 0; i < size / 6; i++)
    {
        for (int j = 0; j < max/3; j++)
        {
            sb.Append(" ");
        }
        int dicke = max / 3;
        if (max % 3 != 0) dicke++;
        for (int j = 0; j < dicke; j++)
        {
            sb.Append("#");
        }
        sb.AppendLine();
    }

    return sb.ToString();
}

DeleteOldFile("trees.txt");

Write("trees.txt", Tree(38, 7));

Write("trees.txt", "--------------------------------------------------------------");

Write("trees.txt", Tree(16, 5));

Write("trees.txt", "--------------------------------------------------------------");

Write("trees.txt", Tree(14, 8));

Write("trees.txt", "--------------------------------------------------------------");

Write("trees.txt", Tree(69, 3));

Write("trees.txt", "--------------------------------------------------------------");

Write("trees.txt", Tree(20, 2));

Write("trees.txt", "--------------------------------------------------------------");

Write("trees.txt", Tree(11, 1));

Write("trees.txt", "--------------------------------------------------------------");
