using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Abfragen
{
    public class Address
    {
        public int? PostalCode { get; set; }
        public string? Town { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? Floor { get; set; }
        public string? District { get; set; }

        public override string ToString()
        {
            return
            $"Adresse: {Street} {HouseNumber}/{Floor}, {PostalCode} {Town}";
        }
    }

}
