
static void Write(string text, StreamWriter sw)
{
    try
    {
        sw.WriteLine(text);        
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        sw.Close();
    }
}

static string Read(StreamReader sr)
{
    string text = "";
    try
    {
        while (sr.Peek() != -1)
        {
            text += sr.ReadLine();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        sr.Close();
    }
    return text;
}

Write("1, 2, 3, 4, 5, 6, 7, 8, 9, 10", new StreamWriter("text.txt", false));
Console.WriteLine(Read(new StreamReader("text.txt")));

