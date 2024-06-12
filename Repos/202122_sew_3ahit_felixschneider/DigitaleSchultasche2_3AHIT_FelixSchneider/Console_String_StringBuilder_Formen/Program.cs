
using Console_String_StringBuilder_Formen;
using System.Text;

string text = "some text";
StringBuilder sb = new StringBuilder();
sb.Append("This is a ");
sb.Append("StringBuilder");
sb.Append("I can append text...");

Console.WriteLine($"text is \t {text}");
Console.WriteLine($"StringBuilder is \t {sb}");

using (StreamWriter sw = new StreamWriter("test.txt"))
{
    sw.WriteLine($"text is \t {text}");
    sw.WriteLine($"StringBuilder is \t {sb}");
}

//zum Vergleichen
Console.WriteLine();
Console.WriteLine("Vergleichen".ToUpper().PadRight(20, '-').PadLeft(30, '-'));
Person p1 = new Person("Kurt");
Person p2 = new Person("Kurt");
Console.WriteLine($"Person.Equals: {p1.Equals(p2)}");

string s1 = "Kurt";
string s2 = "Kurt";
Console.WriteLine($"String.Equals: {s1.Equals(s2)}");

//zum Ersetzen
Console.WriteLine();
Console.WriteLine("Ersetzen".ToUpper().PadRight(20, '-').PadLeft(30, '-'));
Console.WriteLine(s1);
s1 = s1.Replace('K', 'C');
s1 = s1.Replace('u', 'a');
Console.WriteLine(s1);

Console.WriteLine(s2);
s2 = s2.PadLeft(s2.Length + 10, '*');
s2 = s2.PadRight(s2.Length + 10, '*');
Console.WriteLine(s2);

Console.WriteLine(s1);
Console.WriteLine(s2);
s1 = s1.ToUpper();
s2 = s2.ToLower();
Console.WriteLine(s1);
Console.WriteLine(s2);

//zum Suchen
Console.WriteLine();
Console.WriteLine("Suchen".ToUpper().PadRight(20, '-').PadLeft(30, '-'));
if (s1.Contains('C'))
    Console.WriteLine(s1);
else s1 = s1.Insert(0, "C");

int x = s2.Length + s2.IndexOf('t');
if(x < 8)
    Console.WriteLine(x);
else Console.WriteLine(s2.Length);
