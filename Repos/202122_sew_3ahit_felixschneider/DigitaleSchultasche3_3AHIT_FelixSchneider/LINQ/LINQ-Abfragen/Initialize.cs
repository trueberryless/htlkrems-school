using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Abfragen
{
    public class Initialize
    {
        protected static List<Building> ListOfBuildings { get; set; } = new List<Building>() {
            new Building() {
                Address = new Address() {
                    District = "Krems Land",
                    PostalCode = 3485,
                    Town = "Sittendorf",
                    Street = "Neustift",
                    HouseNumber = 45,
                    Floor = 1
                },
                Color = "Yellow",
                DateOfBuilding = Convert.ToDateTime("19.10.2000"),
                Material = "Bricks",
                WindowCount = 7
            },
            new Building() {
                Address = new Address() {
                    District = "Krems Stadt",
                    PostalCode = 3500,
                    Town = "Krems",
                    Street = "Kasernstaße",
                    HouseNumber = 3,
                    Floor = 1
                },
                Color = "Green",
                DateOfBuilding = Convert.ToDateTime("05.08.1960"),
                Material = "Bricks",
                WindowCount = 50
            },
            new Building() {
                Address = new Address() {
                    District = "Wien",
                    PostalCode = 1010,
                    Town = "Wien-Semmering",
                    Street = "Maxmusterstarße",
                    HouseNumber = 6,
                    Floor = 1
                },
                Color = "White",
                DateOfBuilding = Convert.ToDateTime("19.10.2010"),
                Material = "Concrete",
                WindowCount = 100
            },
            new Skyscraper() {
                Address = new Address() {
                    District = "Wien",
                    PostalCode = 1200,
                    Town = "Wien",
                    Floor = 1,
                    Street = "Handelskai",
                    HouseNumber = 94
                },
                AmountOfApartments = 20,
                Color = "DarkGrey",
                DateOfBuilding = Convert.ToDateTime("01.01.1999"),
                FloorAmount = 50,
                HasUndergroundParking = false,
                Height = 202,
                Material = "Glass",
                WindowCount = 200
            },
            new Skyscraper() {
                Address = new Address() {
                    District = "Wien",
                    PostalCode = 1400,
                    Town = "Wien",
                    Floor = 1,
                    Street = "Linzer Straße",
                    HouseNumber = 20
                },
                AmountOfApartments = 20,
                Color = "Blue",
                DateOfBuilding = Convert.ToDateTime("15.04.1890"),
                FloorAmount = 5,
                HasUndergroundParking = true,
                Height = 100,
                Material = "Bricks",
                WindowCount = 60
            },
            new Building() {
                Address = new Address() {
                    District = "St Pölten Land",
                    PostalCode = 3124,
                    Town = "Oberwölbling",
                    Floor = 2,
                    Street = "Kirchengasse",
                    HouseNumber = 4
                },
                Color = "White",
                DateOfBuilding = Convert.ToDateTime("16.05.2010"),
                Material = "Bricks",
                WindowCount = 10
            },
            new Building() {
                Address = new Address() {
                    District = "St Pölten Land",
                    PostalCode = 3123,
                    Town = "Obritzberg",
                    Floor = 1,
                    Street = "Obritzberg",
                    HouseNumber = 8
                },
                Color = "Rose",
                DateOfBuilding = Convert.ToDateTime("16.05.1970"),
                Material = "Bricks",
                WindowCount = 11
            },
            new Skyscraper() {
                Address = new Address() {
                    District = "Innsbruck",
                    PostalCode = 6020,
                    Town = "Innsbruck",
                    Floor = 1,
                    Street = "Straße",
                    HouseNumber = 63
                },
                AmountOfApartments = 40,
                Color = "Blue",
                DateOfBuilding = Convert.ToDateTime("11.05.2000"),
                FloorAmount = 7,
                HasUndergroundParking = true,
                Height = 110,
                Material = "Bricks",
                WindowCount = 100
            },
            new Building() {
                Address = new Address() {
                    District = "Graz",
                    PostalCode = 8010,
                    Town = "Graz",
                    Floor = 1,
                    Street = "Rechbauerstraße",
                    HouseNumber = 12
                },
                Color = "White",
                DateOfBuilding = Convert.ToDateTime("01.04.1811"),
                Material = "Old Bricks",
                WindowCount = 50
            },
            new Building() {
                Address = new Address() {
                    District = "Klagenfurt",
                    PostalCode = 9020,
                    Town = "Klagenfut",
                    Floor = 1,
                    Street = "Universitätsstraße",
                    HouseNumber = 65
                },
                Color = "White",
                DateOfBuilding = Convert.ToDateTime("01.07.1970"),
                Material = "Metall",
                WindowCount = 140
            }
        };

        protected static Building[] ArrayOfBuildings { get; set; } = new Building[] {
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 18,
                    Street = "Panoramastraße",
                    District = "12",
                    Floor = 9,
                    Town = "Kottes",
                    PostalCode = 3623
                },
                Color = "Green",
                WindowCount = 500,
                DateOfBuilding = Convert.ToDateTime("19.10.2022")
            },
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 15,
                    Street = "Alauntalstraße",
                    District = "10",
                    Floor = 5,
                    Town = "Krems",
                    PostalCode = 3500
                },
                Color = "Red",
                WindowCount = 200,
                DateOfBuilding = Convert.ToDateTime("10.10.2022")
            },
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 12,
                    Street = "Sonnenweg",
                    District = "7",
                    Floor = 1,
                    Town = "Kottes",
                    PostalCode = 3623
                },
                Color = "Blue",
                WindowCount = 100,
                DateOfBuilding = Convert.ToDateTime("19.11.2022")
            },
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 10,
                    Street = "Kremstalstraße",
                    District = "1",
                    Floor = 1,
                    Town = "Wien",
                    PostalCode = 1010
                },
                Color = "Yellow",
                WindowCount = 120,
                DateOfBuilding = Convert.ToDateTime("13.10.2021")
            },
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 100,
                    Street = "Wienerstraße",
                    District = "5",
                    Floor = 2,
                    Town = "Wienerneustadt",
                    PostalCode = 2604
                },
                Color = "Purple",
                WindowCount = 600,
                DateOfBuilding = Convert.ToDateTime("18.10.2000")
            },
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 78,
                    Street = "Gföhlerstraße",
                    District = "2",
                    Floor = 3,
                    Town = "Gföhl",
                    PostalCode = 3521
                },
                Color = "Orange",
                WindowCount = 550,
                DateOfBuilding = Convert.ToDateTime("14.10.2012")
            },
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 69,
                    Street = "Lengelfelderstraße",
                    District = "1",
                    Floor = 6,
                    Town = "Lengenfeld",
                    PostalCode = 3552
                },
                Color = "Black",
                WindowCount = 350,
                DateOfBuilding = Convert.ToDateTime("14.08.2005")
            },
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 44,
                    Street = "Elserstraße",
                    District = "1",
                    Floor = 3,
                    Town = "Els",
                    PostalCode = 3613
                },
                Color = "White",
                WindowCount = 900,
                DateOfBuilding = Convert.ToDateTime("10.12.2022")
            },
            new Building()
            {
                Address = new Address()
                {
                    HouseNumber = 33,
                    Street = "Salingbergerstraße",
                    District = "3",
                    Floor = 1,
                    Town = "Salingberg",
                    PostalCode = 3525
                },
                Color = "Cyan",
                WindowCount = 700,
                DateOfBuilding = Convert.ToDateTime("16.06.2016")
            }
        };

        protected static List<Address> ListOfAdresses { get; set; } = new List<Address>() {
            new Address() {
                District = "Wien",
                PostalCode = 1200,
                Town = "Wien",
                Street = "Handelskai",
                HouseNumber = 45,
                Floor = 4
            },
            new Address() {
                District = "Krems Stadt",
                PostalCode = 3500,
                Town = "Krems",
                Street = "Minoritenplatz",
                HouseNumber = 10,
                Floor = 2
            },
            new Address() {
                District = "St Pölten Land",
                PostalCode = 3125,
                Town = "Statzendorf",
                Street = "Hauptstraße",
                HouseNumber = 44,
                Floor = 2
            },
            new Address() {
                District = "Melk",
                PostalCode = 3671,
                Town = "Marbach an der Donau",
                Street = "Straße",
                HouseNumber = 22,
                Floor = 1
            },
            new Address() {
                District = "Salzburg",
                PostalCode = 5020,
                Town = "Salzburg",
                Street = "Mönchsberg",
                HouseNumber = 34,
                Floor = 3
            },
            new Address() {
                District = "Wien",
                PostalCode = 1020,
                Town = "Wien",
                Street = "Welthandelspl.",
                HouseNumber = 1,
                Floor = 2
            },
            new Address() {
                District = "Tulln",
                PostalCode = 3470,
                Town = "Kirchberg am Wagram",
                Street = "Kremser Straße",
                HouseNumber = 2,
                Floor = 1
            },
            new Address() {
                District = "Bregenz",
                PostalCode = 6900,
                Town = "Bregenz",
                Street = "Blumenstraße",
                HouseNumber = 5,
                Floor = 2
            },
            new Address() {
                District = "Gmünd",
                PostalCode = 3950,
                Town = "Gmünd",
                Street = "Bahnhofsplatz",
                HouseNumber = 5,
                Floor = 3
            },
            new Address() {
                District = "Gmünd",
                PostalCode = 3871,
                Town = "Steinbach",
                Street = "Steinbach",
                HouseNumber = 128,
                Floor = 2
            }
        };

        public static List<Building> GetBuildings01()
        {
            List<Building> list = ListOfBuildings;
            return list;
        }
        public static Building[] GetBuildings02()
        {
            Building[] list = ArrayOfBuildings;
            return list;
        }
        public static List<Address> GetAdresses()
        {
            List<Address> list = ListOfAdresses;
            return list;
        }
    }
}
