
static void WriteTabelle(string filename)
{
    using (StreamWriter sw = new StreamWriter(filename))
    {
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                sw.Write(i + "x");
                sw.Write(j + "=");
                sw.WriteLine(i * j);
            }
            sw.WriteLine("=========");
        }
    }
}

static void ReadFile(string filename)
{
    using(StreamReader sr = new StreamReader(filename))
    {
        while(sr.Peek() != -1)
        {
            Console.WriteLine(sr.ReadLine());
        }
    }
}

WriteTabelle("tabelle.txt");
ReadFile("tabelle.txt");
