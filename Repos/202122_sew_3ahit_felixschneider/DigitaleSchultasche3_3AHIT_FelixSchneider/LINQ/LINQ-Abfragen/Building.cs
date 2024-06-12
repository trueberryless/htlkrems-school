using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Abfragen
{
    public class Building
    {
        public Address Address { get; set; }
        public DateTime DateOfBuilding { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public int WindowCount { get; set; }
        public override string ToString()
        {
            return  $"\n Adresse: {Address.Street} {Address.HouseNumber}/{Address.Floor}, {Address.PostalCode} {Address.Town}," +
                    $"\n Erbaut: {DateOfBuilding.Year}, Material: {Material}, Farbe: {Color}, Fenster: {WindowCount}";
        }
    }
}
