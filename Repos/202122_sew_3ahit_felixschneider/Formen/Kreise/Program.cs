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

static string Circle(int size)
{
    StringBuilder sb = new StringBuilder();

    if(size < 10) size = 10;

    double max = Math.Round(Math.Sqrt(Math.Pow(size / 2, 2) - Math.Pow(size / 2 - size / 2, 2)) * 4.4);

    for (int i = 0; i < size + 1; i++)
    {
        double b = Math.Round(Math.Sqrt(Math.Pow(size / 2, 2) - Math.Pow(i - size / 2, 2)) * 4.4);

        for (int j = 0; j < (max - b) / 2; j++) // Leerzeichen
        {
            sb.Append(" ");
        }

        for (int j = 0; j < b; j++) // eigentlicher Kreis
        {
            sb.Append("#"); 
        }



        sb.AppendLine();
    }

    return sb.ToString();
}

static string CircleMax(int size, double biggestsize)
{
    StringBuilder sb = new StringBuilder();

    if (size < 10) size = 10;

    double max = Math.Round(Math.Sqrt(Math.Pow(size / 2, 2) - Math.Pow(size / 2 - size / 2, 2)) * 4.4);

    for (int i = 0; i < size + 1; i++)
    {
        double b = Math.Round(Math.Sqrt(Math.Pow(size / 2, 2) - Math.Pow(i - size / 2, 2)) * 4.4);

        for (int j = 0; j < biggestsize - size; j++) // Damit oberster und mittlerer Kreis zentriert
        {
            sb.Append(" ");
        }

        for (int j = 0; j < (max - b) / 2; j++) // Leerzeichen
        {
            sb.Append(" ");
        }

        for (int j = 0; j < b; j++) // eigentlicher Kreis
        {
            sb.Append("#");
        }


        if(i < size - 2) // Damit Schneemannkugeln zusammenkleben
            sb.AppendLine();
    }

    return sb.ToString();
}

static string Snowman(int size)
{
    StringBuilder sb = new StringBuilder();

    double max = Math.Round(Math.Sqrt(Math.Pow(size / 3 * 1.4 / 2, 2) - Math.Pow(size / 3 * 1.4 / 2 - size / 3 * 1.4 / 2, 2)) * 4.4) - 5;

    // Hut
    for (int i = 0; i < size / 6; i++)
    {
        for (int j = 0; j < (max - (size / 3 * 0.5)) / 2; j++) // Damit Hut zentriert
        {
            sb.Append(" ");
        }

        for (int j = 0; j < size / 3 * 0.5; j++)
        {
            sb.Append("#");
        }
        sb.AppendLine();
    }

    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < (max - (size / 3 * 1.2)) / 2; j++) // Damit Hut zentriert
        {
            sb.Append(" ");
        }

        for (int j = 0; j < size / 3 * 1.2; j++)
        {
            sb.Append("#");
        }
        if(i < 1)
            sb.AppendLine();
    }

    max = size / 3 * 1.4;

    // eigentlicher Schneeman
    for (double i = 0.6; i <= 1.4 ; i+=.4)
    {
        sb.Append(CircleMax((int)Math.Round(size / 3 * i), max));
    }

    return sb.ToString();
}

DeleteOldFile("circles.txt");
DeleteOldFile("snowmans.txt");

Write("circles.txt", Circle(40));

Write("circles.txt", "--------------------------------------------------------------");

Write("circles.txt", Circle(100));

Write("circles.txt", "--------------------------------------------------------------");

Write("circles.txt", Circle(15));

Write("circles.txt", "--------------------------------------------------------------");

Write("circles.txt", Circle(5));

Write("circles.txt", "--------------------------------------------------------------");

Write("circles.txt", Circle(1));

Write("circles.txt", "--------------------------------------------------------------");

Write("circles.txt", Circle(77));

Write("circles.txt", "--------------------------------------------------------------");

Write("snowmans.txt", Snowman(20));

Write("snowmans.txt", "--------------------------------------------------------------");

Write("snowmans.txt", Snowman(50));

Write("snowmans.txt", "--------------------------------------------------------------");

Write("snowmans.txt", Snowman(77));

Write("snowmans.txt", "--------------------------------------------------------------");

Write("snowmans.txt", Snowman(100));

Write("snowmans.txt", "--------------------------------------------------------------");

Write("snowmans.txt", Snowman(200));

Write("snowmans.txt", "--------------------------------------------------------------");