using System.Text;

static void Write(string path, string text)
{
    using(StreamWriter sw = new StreamWriter(path, true))
    {
        sw.WriteLine();
        sw.WriteLine(text);
    }
}

static void DeleteOldFile(string path)
{
    using(StreamWriter sw = new StreamWriter(path))
    {
        sw.Write("");
    }
}

static string Rectangle(int x, int y)
{
    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < y; i++) // Rechteck
    {
        for (int j = 0; j < x; j++)
        {
            sb.Append("*");
        }
        if(i != y - 1)
            sb.AppendLine();
    }

    return sb.ToString();
}

static string Square(int size)
{
    return Rectangle(size, size); // Quadrat hat gleiche Breite wie Länge
}

static string RectangleEmpty(int x, int y, int edge)
{
    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < edge; i++) // oberer Rand
    {
        for (int j = 0; j < x; j++)
        {
            sb.Append("*");
        }
        if (i != y - 1)
            sb.AppendLine();
    }

    for (int i = 0; i < y - 2 * edge; i++) // mittlerer Teil (zuerst Rand, dann leer, dann Rand)
    {
        for (int j = 0; j < x; j++)
        {
            if (j < edge || j >= x - edge)
                sb.Append("*");
            else sb.Append(" ");
        }
        if (i != y - 1)
            sb.AppendLine();
    }

    for (int i = 0; i < edge; i++) // unterer Rand
    {
        for (int j = 0; j < x; j++)
        {
            sb.Append("*");
        }
        if (i != edge - 1)
            sb.AppendLine();
    }

    return sb.ToString();
}

static string SquareEmpty(int size, int edge)
{
    return RectangleEmpty(size, size, edge); // Quadrat hat gleiche Breite wie Länge
}

DeleteOldFile("rectangles.txt");

Write("rectangles.txt", Rectangle(3, 4));

Write("rectangles.txt", "----------------------------------");

Write("rectangles.txt", Square(5));

Write("rectangles.txt", "----------------------------------");

Write("rectangles.txt", RectangleEmpty(10, 6, 1));

Write("rectangles.txt", "----------------------------------");

Write("rectangles.txt", SquareEmpty(10, 2));