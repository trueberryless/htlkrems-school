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

static string Star(int size)
{
    StringBuilder sb = new StringBuilder();

    if (size < 10) size = 10;

    double max = -8 * size / 2 + 100;

    for (int i = 0; i < size; i++)
    {
        double b = 0;
        if (i >= 0 && i < size * 2 / 5)
            b = i / 2;
        else if (i >= size * 2 / 5 && i < size / 2)
            b = 8 * i - 60;
        else if (i >= size / 2 && i < size * 3 / 5)
            b = -8 * i + 100;
        else if (i >= size * 3 / 5 && i <= size)
            b = -i / 2 + 10;

        Console.WriteLine(b);

        for (int j = 0; j < (max - b) / 2; j++) // Leerzeichen
        {
            sb.Append(" ");
        }

        for (int j = 0; j < b; j++) // eigentlicher Stern
        {
            sb.Append("#");
        }

        sb.AppendLine();
    }

    return sb.ToString();
}

DeleteOldFile("stars.txt");

Write("stars.txt", Star(40));

Write("stars.txt", "--------------------------------------------------------------");

Write("stars.txt", Star(100));

Write("stars.txt", "--------------------------------------------------------------");

Write("stars.txt", Star(15));

Write("stars.txt", "--------------------------------------------------------------");

Write("stars.txt", Star(5));

Write("stars.txt", "--------------------------------------------------------------");

Write("stars.txt", Star(1));

Write("stars.txt", "--------------------------------------------------------------");

Write("stars.txt", Star(77));

Write("stars.txt", "--------------------------------------------------------------");