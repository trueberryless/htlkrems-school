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

static string Triangle(int size)
{
    StringBuilder sb = new StringBuilder();

    if (size % 2 == 0) // size muss ungerade sein
        size++;

    int b = 1; // b = Anzahl an Zeichen (*) in einer Zeile

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size - (b / 2); j++)
        {
            sb.Append(" ");
        }

        for (int j = 0; j < b; j++)
        {
            sb.Append("*");
        }

        b += 2;

        sb.AppendLine();
    }

    return sb.ToString();
}

static string TriangleEmpty(int size, int edge)
{
    StringBuilder sb = new StringBuilder();

    if (size % 2 == 0)
        size++;

    int b = 1;

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size - (b / 2); j++)
        {
            sb.Append(" ");
        }

        for (int j = 0; j < edge - 1; j++)
        {
            sb.Append(" ");
        }

        for (int j = 0; j < b; j++)
        {
            if (j < edge || j >= b - edge)
                sb.Append("*");
            else sb.Append(" ");
        }        

        b += 2;

        sb.AppendLine();
    }

    for (int i = 0; i < edge; i++)
    {
        for (int j = 0; j < edge - i - 1; j++)
        {
            sb.Append(" ");
        }

        for (int j = 0; j < b; j++)
        {
            sb.Append("*");
        }

        b += 2;

        sb.AppendLine();
    }
    

    return sb.ToString();
}

DeleteOldFile("triangles.txt");

Write("triangles.txt", Triangle(11));

Write("triangles.txt", "----------------------------------");

Write("triangles.txt", TriangleEmpty(11, 3));

Write("triangles.txt", "----------------------------------");