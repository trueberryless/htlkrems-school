using System;
using System.Linq;

namespace LINQ_Abfragen
{
    public class Program
    {
        static readonly List<Building> buildings = Initialize.GetBuildings01();

        static void Main(string[] args)
        {
            Console.WriteLine();
            AvgWindowAmountOfBuildings();
            Console.WriteLine();
            AvgHightOfSkyscrapers();
            Console.WriteLine();
            CountPostalCode3000();
            Console.WriteLine();
            CountBuildingBefore1920();
            Console.WriteLine();
            MinWindowsOfBuilding();
            Console.WriteLine();
            MaxHouseNumber();
            Console.WriteLine();
            SumHeightsOfSkyScrapers();
            Console.WriteLine();
            SumApartmentsWithGarage();
            Console.WriteLine();
            SortAndFirstHeight();
            Console.WriteLine();
            SortAndLastHeight();
            Console.WriteLine();
            SingleWhereStreet();
            Console.WriteLine();
            ConcatBuildings();
            Console.WriteLine();
            DistinctMaterials();
            Console.WriteLine();
        }

        static public void AvgWindowAmountOfBuildings()
        {
            //Gib die durchschnittliche Fenster Anzahl der Gebäudeliste aus - average

            var erg = buildings.Average(x => x.WindowCount);
            Console.WriteLine("AvgWindowAmountOfBuildings: " + erg);
        }

        static public void AvgHightOfSkyscrapers()
        {
            //Gib die durchschnittlich Höhe derer Gebäube aus, welche Wolkenkratzer sind

            var erg = buildings.OfType<Skyscraper>().Average(x => x.Height);
            Console.WriteLine("AvgHightOfSkyscrapers: " + erg);
        }

        static public void CountPostalCode3000()
        {
            //Geben Sie die Anzahl aller Addressen aus, dessen Postleitzahl im 3000 - Bereich liegt

            var erg = buildings.Count(x => x.Address.PostalCode >= 3000 && x.Address.PostalCode < 4000);
            Console.WriteLine("CountPostalCode3000: " + erg);
        }

        static public void CountBuildingBefore1920()
        {
            //Gib die Anzahl der Gebäude aus, welche vor 1920 gebaut wurden (DateOfBuilding) -> count

            var erg = buildings.Count(x => x.DateOfBuilding.Year < 1920);
            Console.WriteLine("CountBuildingBefore1920: " + erg);
        }

        static public void MinWindowsOfBuilding()
        {
            //Gib die Anzahl die minimale Stockwerk-Anzahl aller Wolkenkratzer aus.

            var erg = buildings.OfType<Skyscraper>().Min(x => x.WindowCount);
            Console.WriteLine("MinWindowsOfBuilding: " + erg);
        }

        static public void MaxHouseNumber()
        {
            //Gib die größte Hausnummer von den Adressen aus, deren PLZ zw 3200 und 3600 liegen

            var erg = buildings.Where(x => x.Address.PostalCode > 3200 && x.Address.PostalCode < 3600).Max(x => x.Address.HouseNumber);
            Console.WriteLine("MaxHouseNumber: " + erg);
        }

        static public void SumHeightsOfSkyScrapers()
        {
            //Gib die summierte Höhe aller Wolkenkratzer aus!

            var erg = buildings.OfType<Skyscraper>().Sum(x => x.Height);
            Console.WriteLine("SumHeightsOfSkyScrapers: " + erg);
        }

        static public void SumApartmentsWithGarage()
        {
            //Gib die Summe aller Apartments aus, deren Hochhaus eine Tiefgargae hat.

            var erg = buildings.OfType<Skyscraper>().Where(x => x.HasUndergroundParking == true).Sum(x => x.AmountOfApartments);
            Console.WriteLine("SumApartmentsWithGarage: " + erg);
        }

        static public void SortAndFirstHeight()
        {
            //Sortiere eine Liste von Wolkenkratzern nach ihrer Höhe und gib das Erste Element aus.

            var erg = buildings.OfType<Skyscraper>().OrderBy(x => x.Height).First();
            Console.WriteLine("SortAndFirstHeight: " + erg);
        }

        static public void SortAndLastHeight()
        {
            //Sortiere eine Liste von Wolkenkratzern nach ihrer Höhe und gib das Letzte Element aus.

            var erg = buildings.OfType<Skyscraper>().OrderBy(x => x.Height).Last();
            Console.WriteLine("SortAndLastHeight: " + erg);
        }

        static public void SingleWhereStreet()
        {
            //Gib das einzige Gebäude aus welches sich auf der Straße "Handelskai" befindet.

            var erg = buildings.Where(x => x.Address.Street == "Handelskai").Single();
            Console.WriteLine("SingleWhereStreet: " + erg);
        }

        static public void ConcatBuildings()
        {
            //Geben Sie in einem Datensatz sowohl alle Gebäude aus, die aus Bricks gebaut sind,
            //wie auch alle Gebäude, die die Farbe "Yellow" haben. (Verbindung mit concat)

            var erg = buildings.Where(x => x.Material == "Bricks");
            var erg2 = buildings.Where(x => x.Color == "Yellow");


            Console.Write("ConcatBuildings: ");
            foreach (var item in erg.Concat(erg2))
            {
                Console.WriteLine(item);
            }
        }

        static public void DistinctMaterials()
        {
            //Geben Sie alle Materialien aus, die bei den Häusern verwendet wurden.
            //Geben Sie dabei jedes Material nur einmal aus!

            var erg = buildings.Select(x => x.Material).Distinct();
            Console.Write("DistinctMaterials: ");
            foreach (var item in erg)
            {
                Console.WriteLine(item);
            };
        }
    }
}