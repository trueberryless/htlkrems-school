using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autos_Abfragen;

namespace Autos_Abfragen
{
    public class Abfragen
    {
        InitializerClass i = new InitializerClass();
        public void Where()
        {
            // WHERE
            Console.WriteLine("WHERE");

            var Result1 = from x in i.m where x.PS > 200 && x.PS < 400 select x.Modell;
                // var Result1 = i.m.Where(x => x.PS > 200 && x.PS < 400).Select(x => x.Modell);
            foreach (var item in Result1)
                Console.WriteLine(item);
            Console.WriteLine();

            // finden Sie alle Mercedes welche mit Diesel fahren und Vollkompensiv Versichert sind    
            var Result2 = i.m.Where(x => x.Fuel == "Diesel" && x.Insurance == EInsurance.FULLYCOMPREHENSIVE);
                //var Result2 = from x in i.m where x.Fuel == "Diesel" where x.Insurance == EInsurance.FULLYCOMPREHENSIVE select x;
            foreach (var item in Result2)
                Console.WriteLine(item);
            Console.WriteLine();

            // finden Sie alle Audis und Volkswagen welche 0 Kilometer haben, keine Handschaltung, über 200 PS und Elektisch oder Hybrid
            var Result3 = i.a.Where(x => x.Kilometers == 0 && x.ManualTransmission == true && x.PS > 200 && (x.Fuel == "Hybrid" || x.Fuel == "Electric"));
                //var Result3 = from x in i.a where x.Kilometers == 0 && x.ManualTransmission == true && x.PS > 200 && (x.Fuel == "Hybrid" || x.Fuel == "Electric") select x;
            foreach (var item in Result3)
                Console.WriteLine(item);
            Console.WriteLine();

            var Result4 = i.vw.Where(x => x.Price > 3000 && x.PS < 4000).Where(x => x.SeatCover == "Leather").Select(x => x.Modell);
                //var Result4 = from x in i.vw where x.Price > 3000 && x.PS < 4000 where x.SeatCover == "Leather" select x.Modell;
            foreach (var item in Result4)
                Console.WriteLine("Volkswagen: " + item);
            Console.WriteLine();
        }
        public void Oftype()
        {
            // OFTYPE
            Console.WriteLine("OFTYPE");
            List<Mercedes> cars = i.m;
            
            // Grund OfType
            var Result1 = i.vw.OfType<Volkswagen>();
          //  Result1 = from x in i.vw ofType<Volkswagen>;
            foreach (var item in Result1)
                Console.WriteLine(item);
            Console.WriteLine();

            // Gebe alle Volkswagen aus der Car List welche 0 Kilometer haben, gebe die Modellnamen und die erste registration
            var Result2 = i.cars.OfType<Volkswagen>().Where(x => x.Kilometers == 0).Select(x => x.Modell + " " + x.FirstRegistration);
            foreach (var item in Result2)
                Console.WriteLine(item);
            Console.WriteLine();

            // Gebe alle Volkswagen aus der Car Liste aus welche eine Gangschaltung haben und gruppiere diese danach ob ihrere Versicherung
            var Result3 = i.cars.OfType<Volkswagen>().Where(x => x.ManualTransmission == true).GroupBy(x => x.Insurance);
            foreach (var item in Result3)
            {
                Console.WriteLine(item.Key);
                foreach (Volkswagen x in item)
                    Console.WriteLine("   " + x.Modell);
            }
            Console.WriteLine();
        }
        public void Orderby()
        {
            // ORDERBY
            Console.WriteLine("ORDERBY");

            // Gebe alle Mercedes und dordne sie nach Kilometer und dann nach PS
            var Result1 = from x in i.m orderby x.Kilometers orderby x.PS select x.Kilometers + ";  " + x.PS;            
            // var Result8 = from x in i.m orderby x.PS descending select x.PS + "; " + x.Modell;       //absteigend
            foreach (var item in Result1)
                Console.WriteLine("Mercedes: " + item);
            Console.WriteLine();

            var Result22 = i.m.OrderBy(x => x.Kilometers).OrderBy(x=>x.PS).Select(x=> x.Kilometers + ";      " + x.PS);
            var Result2e2 = i.m.OrderByDescending(x => x.Kilometers).OrderByDescending(x => x.PS).Select(x => x.Kilometers + ";      " + x.PS);
            foreach (var item in Result22)
                Console.WriteLine("Mercedes: " + item);
            Console.WriteLine();

            // Ordne alle Cars welche als Seatcover Polyester haben nach Kilometer und dann nach preise
            var Result2 = i.a.Where(x => x.SeatCover == "Polyester").OrderBy(x => x.Price).OrderBy(x => x.Kilometers).Select(x => x.Modell + " " + x.Kilometers + " " + x.Price);
            foreach (var item in Result2) 
                Console.WriteLine(item); 
            Console.WriteLine();
        }
        public void Thenby()
        {
            //THEMBY        ThenBy & ThenByDescending 
            // Ordne nach den Kilometern und danach nach dem Preis
            var Result1 = i.a.OrderBy(x => x.Kilometers).ThenBy(x => x.Price).Select(x => x.Kilometers + " " + x.Price);
            foreach (var item in Result1)
                Console.WriteLine(item);
            Console.WriteLine();

                //   Unterschied !!!!

            var Result33 = i.a.OrderBy(x => x.Kilometers).OrderBy(x => x.Price).Select(x => x.Kilometers + " " + x.Price);
            foreach (var item in Result33)
                Console.WriteLine(item);
            Console.WriteLine();



            // Ordne anfangs die Mercedes danach ob sie noch keinen Unfall hatten und danach absteigend nach ihren Preis
            var Result2 = i.a.OrderBy(x => x.AccidentFree).ThenByDescending(x => x.Price).Select(x => x.AccidentFree + " " + x.Price);
            foreach (var item in Result2)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        public void Groupby()
        {
            //GROUPBY

            // Gruppiere nach Fuel und ordne es nach dem Price
            var Result1 = from x in i.m orderby x.Price group x by x.Fuel;
            //var Result1 = i.vw.OrderBy(x => x.Price).GroupBy(x => x.Fuel);
            foreach (var item in Result1)
            {
                Console.WriteLine(item.Key);
                foreach (var x in item)
                    Console.WriteLine("   " + x.Modell);
            }
            Console.WriteLine();

            //Gruppiere nach ManualTransmission und Sortiere es dach Datum absteigend
            var Result2 = from x in i.m orderby x.FirstRegistration group x by x.ManualTransmission;
            foreach (var item in Result2)
            {
                Console.WriteLine(item.Key);
                foreach (Mercedes x in item)
                    Console.WriteLine("   " + x.Modell);
            }
            Console.WriteLine();
        }
        public void Tolookup()
        {
            // TOLOOUP
            // Grupiere die Audis nach Ihrer Versicherungsart 
            var Result1 = i.a.ToLookup(x => x.Insurance);
            foreach (var item in Result1)
            {
                Console.WriteLine( item.Key);  
                foreach (Audi x in item)  
                    Console.WriteLine("    " + x.Modell);
            }
            Console.WriteLine();

            // Gebe alle Volkswagen aus Car aus und Gruppiere diese nach ihrer dem Kraftstoff
            var Result2 = i.cars.OfType<Volkswagen>().ToLookup(x => x.Fuel);
            foreach (var item in Result2)
            {
                Console.WriteLine(item.Key);
                foreach (Volkswagen x in item)
                    Console.WriteLine("    " + x.Modell);
            }
        }
        public void Select()
        {
            //SELECT
            var Result1 = from x in i.vw select x.Kilometers;
            var Result2 = i.vw.Select(x => x.PS);
            var Result3 = from x in i.vw select new { Data = " " + x.Modell, Age = x.Price };
            var Result4 = i.vw.Select(x => new { Data = x.Modell + " " + x.Price });
        }
        public void Mixed()
        {
            //• Where / Select
            // Finde alle Mercedes, welche über 300 PS haben, noch keinen Unfall hatten und entweder
            // vermietet werden können und oder noch keine Kilometer haben und stellen sie dies mit entsprechenden Text dar
            var Result1 = i.m.Where(x => x.PS > 300 && x.AccidentFree == true && (x.Leasing == true || x.Kilometers == 0)).Select (x => "Der Mercedes hat ist ein " + x.Modell + " mit " + x.PS + " PS, hatte noch keinen Unfalle und kann entweder geliehen werden oder hat " + x.Kilometers + " Kilometer");
            foreach (var item in Result1)
                Console.WriteLine(item);
            Console.WriteLine();

            //• OfType / Select
            // Gebe alle Mercedes aus welche ein Mercedes sind und die Farbe weiß haben
            var Result2 = i.m.OfType<Mercedes>().Where(x=> x.Color == "white").Select(x=>x.Modell);
            foreach (var item in Result2)
                Console.WriteLine(item);
            Console.WriteLine();

            //• Oderby - Thenby
            // ordnen sie die Volkswagen nach Preise und danach nach Kilometer
            var Result31 = i.vw.OrderBy(x => x.Price).ThenBy(x => x.Kilometers).Select(x => x.Price + " " + x.Kilometers);
            foreach (var item in Result31)
                Console.WriteLine(item);
            Console.WriteLine();

            //var Result32 = i.vw.OrderBy(x => x.Price).OrderBy(x => x.Kilometers).Select(x => x.Price + " " + x.Kilometers); ;
            //foreach (var item in Result32)
            //    Console.WriteLine(item);
            //Console.WriteLine();

            //• Groupby / ToLookup / Select
            // Grupiere alle Audis nach ihrem Kraftstoff und ordne es nach der Anzahl der Kilometer und gebe die Modellnamen der Audis aus
            var Result4 = i.a.GroupBy(x => x.Fuel);
            //var Result6 = i.a.GroupBy(x => x.Kilometers);
            var Result6 = i.a.OrderBy(x => x.Kilometers); 
            foreach (var item in Result4)
            {
                Console.WriteLine(item.Key);
                foreach (var x in item)
                {
                    Console.WriteLine("  " + x.Modell);
                }
            }
           
        }

        public void Count()
        {
            var result = (from x in i.a select x).Count();
            //var result = i.a.Count();
            Console.WriteLine(result);
        }
        public void Average()
        {
            var resutl = i.a.Select(x => x.Price).Average();
            Console.WriteLine(resutl);
        }
        public void Sum()
        {
            var resutl = i.a.Select(x => x.Price).Sum();
            Console.WriteLine(resutl);
        }
        public void MinMax()
        {
            var resutl1 = i.a.Select(x => x.Price).Min();
            Console.WriteLine(resutl1);
            var resutl2 = i.a.Select(x => x.Price).Max();
            Console.WriteLine(resutl2);
        }
        public void First()
        {
            //var resutl = (from x in i.a select x.Modell).First();
            var resutl = i.a.Select(x=> x.Modell).First();
            Console.WriteLine( resutl);
        }
        public void Last()
        {
            //var resutl = (from x in i.a select x.Modell).Last();
            var resutl = i.a.Select(x => x.Modell).Last();
            Console.WriteLine(resutl);
        }
        public void Single()
        {
            //var resutl = (from x in i.a select x.Modell).Single();
            var resutl = i.a.Where(x=>x.Modell== "S8 TFSI quattro").Select(x => x.Modell).Single();  
            Console.WriteLine(resutl);
        }

        public void Concat()
        {
            var result = i.a1.Concat(i.a2).Select(x=>x.Modell);
            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        public void Distinct()
        {
            var result = i.a1.Concat(i.a2).Select(x => x.Modell);
            result = result.Distinct();
            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        public void Exept()
        {
            var result = i.a1.Select(x => x.Modell).Except(i.a2.Select(x => x.Modell));
            //var result = i.a1.Except(i.a2).Select(x => x.Modell);  // not working man muss genau angeben, nach welchem Wert Verglichen werden soll
            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        public void Intersect()
        {
            var result = i.a1.Select(x => x.Modell).Intersect(i.a2.Select(x => x.Modell));
            //var result = i.a1.Intersect(i.a2).Select(x => x.Modell); // not working
            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        public void Union()
        {
            var result = i.a1.Select(x => x.Modell).Union(i.a2.Select(x => x.Modell));
            //var result = i.a1.Union(i.a2).Select(x => x.Modell); // not working
            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine();
        }

        public void Partitioning()
        {
            // Skip, SkipWhile, Take, TakeWhile
        

        }
        public void SequenceEqual()
        {
            // 

        }
        public void Generation()
        {
            // DefaultEmpty, Empty, Range, Repeat

        }
        public void Conversion()
        {
            // AsEnumerable, AsQueryable, Cast, ToArray, ToDictionary, ToList

        }
        public void Join()
        {
            // GroupJoin, Join

        }
        public void Quantifiers()
        {
            // All, Any, Contains

        }
    }
}
