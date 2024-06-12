using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Abfragen
{
    public class Skyscraper : Building
    {
        public int FloorAmount { get; set; }
        public int AmountOfApartments { get; set; }
        public double Height { get; set; }
        public bool HasUndergroundParking { get; set; }

        public override string ToString()
        {
            return base.ToString() +
            $"\n Stockwerke: {FloorAmount}, Wohneinheiten: {AmountOfApartments}, Height: {Height}, Parkgarage: { HasUndergroundParking}";
        }
    }
}
