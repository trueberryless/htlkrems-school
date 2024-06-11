// See https://aka.ms/new-console-template for more information
using Autos_Abfragen;
using System.Linq;

InitializerClass i = new InitializerClass();

Console.WriteLine("Distinct von vm Kilometers");
IEnumerable<int> query1 = i.vw.Select(one => one.Kilometers).Distinct();
foreach (var item1 in query1)
{
    Console.WriteLine(item1.ToString());
}

Console.WriteLine("Distinct von a1 Price");
IEnumerable<int> query11 = i.a1.Select(one => one.Price).Distinct();
foreach (var item1 in query11)
{
    Console.WriteLine(item1.ToString());
}

Console.WriteLine("Intersect von Seatcover von a und a1");
IEnumerable<string> query2 = i.a.Select(one => one.SeatCover).Intersect(i.a1.Select(two => two.SeatCover));
foreach (var item2 in query2)
{
    Console.WriteLine(item2.ToString());
}

Console.WriteLine("Intersect vw und vw1 Insurance");
IEnumerable<EInsurance> query22 = i.vw.Select(one => one.Insurance).Intersect(i.vw1.Select(two => two.Insurance));
foreach (var item2 in query22)
{
    Console.WriteLine(item2.ToString());
}

Console.WriteLine("Except m und m1 Modell");
IEnumerable<string> query3 = i.m.Select(one => one.Modell).Except(i.m1.Select(two => two.Modell));
foreach (var item3 in query3)
{ 
    Console.WriteLine(item3.ToString());
}

Console.WriteLine("Except a und a1 FirstRegistration");
IEnumerable<DateTime> query33 = i.m.Select(one => one.FirstRegistration).Except(i.m1.Select(two => two.FirstRegistration));
foreach (var item3 in query33)
{
    Console.WriteLine(item3.ToString());
}

Console.WriteLine("Concat von a und a1 Modell");
IEnumerable<string> query4 = i.a.Select(one => one.Modell).Concat(i.a1.Select(two => two.Modell));
foreach (var name in query4)
{
    Console.WriteLine(name);
}

Console.WriteLine("Concat von vw und vw1 TareWeight");
IEnumerable<int> query44 = i.vw.Select(one => one.TareWeight).Concat(i.vw1.Select(two => two.TareWeight));
foreach (var name in query44)
{
    Console.WriteLine(name);
}


Console.WriteLine("Union von vw und vw1 PS");
IEnumerable<int> query5 = i.vw.Select(one => one.PS).Union(i.vw1.Select(two => two.PS));
foreach (var item3 in query5)
{
    Console.WriteLine(item3.ToString());
}

Console.WriteLine("Union von m und m1 Color");
IEnumerable<string> query55 = i.vw.Select(one => one.Color).Union(i.vw1.Select(two => two.Color));
foreach (var item3 in query55)
{
    Console.WriteLine(item3.ToString());
}
