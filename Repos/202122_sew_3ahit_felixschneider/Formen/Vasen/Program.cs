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

static string Vase(int size)
{
    StringBuilder sb = new StringBuilder();

    if (size < 10) size = 10;

    double max = 0;

    for (int i = 0; i < size; i++)
    {
        double b = Math.Abs(Math.Round(-9.31 / (Math.Pow(size, 2)) * Math.Pow(i, 3) + 12.883 / size * Math.Pow(i, 2) - 3.723 * i + 0.5 * size));
        max = Math.Max(max, b);
    }

    for (int i = 0; i < size; i++)
    {
        double b = Math.Abs(Math.Round(-9.31 / (Math.Pow(size, 2)) * Math.Pow(i, 3) + 12.883 / size * Math.Pow(i, 2) - 3.723 * i + 0.5 * size));

        Console.WriteLine(b);

        for (int j = 0; j < (max - b) / 2; j++) // Leerzeichen
        {
            sb.Append(" ");
        }

        for (int j = 0; j < b; j++) // eigentlicher Stern
        {
            sb.Append("=");
        }

        sb.AppendLine();
    }

    return sb.ToString();
}

DeleteOldFile("vases.txt");

Write("vases.txt", Vase(40));

Write("vases.txt", "--------------------------------------------------------------");

Write("vases.txt", Vase(100));

Write("vases.txt", "--------------------------------------------------------------");

Write("vases.txt", Vase(15));

Write("vases.txt", "--------------------------------------------------------------");

Write("vases.txt", Vase(5));

Write("vases.txt", "--------------------------------------------------------------");

Write("vases.txt", Vase(1));

Write("vases.txt", "--------------------------------------------------------------");

Write("vases.txt", Vase(77));

Write("vases.txt", "--------------------------------------------------------------");