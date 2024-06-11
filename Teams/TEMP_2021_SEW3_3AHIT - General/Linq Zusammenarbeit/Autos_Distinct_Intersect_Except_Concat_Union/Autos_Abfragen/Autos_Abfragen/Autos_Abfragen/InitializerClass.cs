using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos_Abfragen
{
    public class InitializerClass
    {
        public List<Volkswagen> vw = new List<Volkswagen>()
        {
            new Volkswagen(){Modell="Taigo", PS = 110, Kilometers = 0, Fuel = "Gasoline", Price = 35023,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 04, 24), Color = "black",
                TareWeight = 1220, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Leather"},

            new Volkswagen(){Modell="ID5", PS = 299, Kilometers = 0, Fuel = "Electric", Price = 59900,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 04, 28), Color = "red",
                TareWeight = 2242, AccidentFree = true,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Art Velour"},

            new Volkswagen(){Modell="UP!", PS = 115, Kilometers = 20000, Fuel = "Gasoline", Price = 19590,
                ManualTransmission = true, FirstRegistration = new DateTime(2020, 01, 01), Color = "yellow",
                TareWeight = 1070, AccidentFree = false, Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Polyester"},

            new Volkswagen(){Modell="Golf", PS = 110, Kilometers = 120000, Fuel = "Natural Gas", Price = 21660,
                ManualTransmission = false, FirstRegistration = new DateTime(2018, 05, 09), Color = "blue",
                TareWeight = 1005, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Faux leather"},

            new Volkswagen(){Modell="ID3", PS = 204, Kilometers = 0, Fuel = "Electric", Price = 44290,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 04, 25), Color = "white",
                TareWeight = 1934, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Leather"},

            new Volkswagen(){Modell="T-Roc Cabriolet", PS = 150, Kilometers = 0, Fuel = "Gasoline", Price = 44480,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 04, 24), Color = "cyan",
                TareWeight = 1524, AccidentFree = true,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Faux leather"},

            new Volkswagen(){Modell="Tiguan Allspace", PS = 150, Kilometers = 12000, Fuel = "Diesel", Price = 44840,
                ManualTransmission = false, FirstRegistration = new DateTime(2018, 04, 11), Color = "darkgrey",
                TareWeight = 1715, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = true,
                CountWheels = 8, Leasing = false, SeatCover ="Leather"},

            new Volkswagen(){Modell="Touareg", PS = 462, Kilometers = 0, Fuel = "Hybrid", Price = 92120,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 04, 28), Color = "darkred",
                TareWeight = 3010, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Art Velour"},

            new Volkswagen(){Modell="Caddy", PS = 122, Kilometers = 85621, Fuel = "Diesel", Price = 30951,
                ManualTransmission = true, FirstRegistration = new DateTime(2019, 03, 15), Color = "gold",
                TareWeight = 1423, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = true,
                CountWheels = 4, Leasing = true, SeatCover ="Polyester"},

            new Volkswagen(){Modell="Arteon", PS = 150, Kilometers = 500, Fuel = "Diesel", Price = 52890,
                ManualTransmission = true, FirstRegistration = new DateTime(2021, 12, 03), Color = "black",
                TareWeight = 1828, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = true,
                CountWheels = 8, Leasing = false, SeatCover ="Leather"}
        };
        public List<Volkswagen> vw1 = new List<Volkswagen>()
        {
            new Volkswagen(){Modell="Taigo", PS = 110, Kilometers = 0, Fuel = "Gasoline", Price = 35023,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 04, 24), Color = "black",
                TareWeight = 1220, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Leather"},

            new Volkswagen(){Modell="ID5", PS = 299, Kilometers = 0, Fuel = "Electric", Price = 59900,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 04, 28), Color = "red",
                TareWeight = 2242, AccidentFree = true,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Art Velour"},

            new Volkswagen(){Modell="UP!", PS = 115, Kilometers = 20000, Fuel = "Gasoline", Price = 19590,
                ManualTransmission = true, FirstRegistration = new DateTime(2020, 01, 01), Color = "yellow",
                TareWeight = 1070, AccidentFree = false, Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Polyester"},

            new Volkswagen(){Modell="Golf", PS = 110, Kilometers = 120000, Fuel = "Natural Gas", Price = 21660,
                ManualTransmission = false, FirstRegistration = new DateTime(2018, 05, 09), Color = "blue",
                TareWeight = 1005, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Faux leather"},

            new Volkswagen(){Modell="ID3", PS = 204, Kilometers = 0, Fuel = "Electric", Price = 44290,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 04, 25), Color = "white",
                TareWeight = 1934, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Leather"},

            new Volkswagen(){Modell="T-Roc Cabriolet", PS = 150, Kilometers = 0, Fuel = "Gasoline", Price = 44480,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 04, 24), Color = "cyan",
                TareWeight = 1524, AccidentFree = true,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Faux leather"},

            new Volkswagen(){Modell="Tiguan Allspace", PS = 150, Kilometers = 12000, Fuel = "Diesel", Price = 44840,
                ManualTransmission = false, FirstRegistration = new DateTime(2018, 04, 11), Color = "darkgrey",
                TareWeight = 1715, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = true,
                CountWheels = 8, Leasing = false, SeatCover ="Leather"},

            new Volkswagen(){Modell="Touareg", PS = 462, Kilometers = 0, Fuel = "Hybrid", Price = 92120,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 04, 28), Color = "darkred",
                TareWeight = 3010, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Art Velour"},

            new Volkswagen(){Modell="Caddy", PS = 122, Kilometers = 85621, Fuel = "Diesel", Price = 30951,
                ManualTransmission = true, FirstRegistration = new DateTime(2019, 03, 15), Color = "gold",
                TareWeight = 1423, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = true,
                CountWheels = 4, Leasing = true, SeatCover ="Polyester"},

            new Volkswagen(){Modell="Arteon", PS = 150, Kilometers = 500, Fuel = "Diesel", Price = 52890,
                ManualTransmission = true, FirstRegistration = new DateTime(2021, 12, 03), Color = "black",
                TareWeight = 1828, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = true,
                CountWheels = 8, Leasing = false, SeatCover ="Leather"}
        };
        public List<Mercedes> m = new List<Mercedes>()
        {
            new Mercedes(){Modell="G-Klasse", PS = 330, Kilometers = 0, Fuel = "Diesel", Price = 174862,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 01, 08), Color = "black",
                TareWeight = 2472, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Leather"},

            new Mercedes(){Modell="B-Klasse", PS = 160, Kilometers = 88880, Fuel = "Hybrid", Price = 43343,
                ManualTransmission = false, FirstRegistration = new DateTime(2020, 01, 08), Color = "grey",
                TareWeight = 1359, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Mercedes(){Modell="S-Klasse Limousine", PS = 330, Kilometers = 111, Fuel = "Diesel", Price = 132380,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 10, 18), Color = "red",
                TareWeight = 2215, AccidentFree = true, Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = true,
                CountWheels = 8, Leasing = true, SeatCover ="Polyester"},

            new Mercedes(){Modell="AMG A 35 4MATIC", PS = 306, Kilometers = 0, Fuel = "Gasoline", Price = 75083,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 12, 09), Color = "yellow",
                TareWeight = 1555, AccidentFree = true, Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Art Velour"},

            new Mercedes(){Modell="AMG CLS 53 4MATIC+", PS = 435, Kilometers = 1000, Fuel = "Gasoline", Price = 128696,
                ManualTransmission = false, FirstRegistration = new DateTime(2021, 12, 08), Color = "silver",
                TareWeight = 1905, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Faux leather"},

            new Mercedes(){Modell="A 250 E Kompaktlimousine", PS = 160, Kilometers = 20200, Fuel = "Gasoline", Price = 47964,
                ManualTransmission = false, FirstRegistration = new DateTime(2018, 02, 14), Color = "white",
                TareWeight = 1359, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Mercedes(){Modell="A 180 d Kompaktlimousine", PS = 116, Kilometers = 0, Fuel = "Diesel", Price = 41763,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 04, 29), Color = "white",
                TareWeight = 1680, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = true,
                CountWheels = 4, Leasing = true, SeatCover ="Leather"},

            new Mercedes(){Modell="AMG GT C Roaster", PS = 557, Kilometers = 0, Fuel = "Gasoline", Price = 277236,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 07, 04), Color = "black",
                TareWeight = 1735, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Leather"},

            new Mercedes(){Modell="C 220 d T-Modell", PS = 200, Kilometers = 200, Fuel = "Diesel", Price = 58257,
                ManualTransmission = false, FirstRegistration = new DateTime(2021, 11, 05), Color = "silver",
                TareWeight = 1720, AccidentFree = true,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = true,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Mercedes(){Modell="AMG GT 43 4MATIC+ Coupé", PS = 367, Kilometers = 80452, Fuel = "Gasoline", Price = 161207,
                ManualTransmission = false, FirstRegistration = new DateTime(2019, 04, 07), Color = "gold",
                TareWeight = 1840, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 4, Leasing = true, SeatCover ="Faux leather"}
        };

        public List<Mercedes> m1 = new List<Mercedes>()
        {
            new Mercedes(){Modell="C-Klasse", PS = 330, Kilometers = 0, Fuel = "Diesel", Price = 174862,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 01, 08), Color = "black",
                TareWeight = 2472, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Leather"},

            new Mercedes(){Modell="B-Klasse", PS = 160, Kilometers = 88880, Fuel = "Hybrid", Price = 43343,
                ManualTransmission = false, FirstRegistration = new DateTime(2020, 01, 08), Color = "grey",
                TareWeight = 1359, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Mercedes(){Modell="S-Klasse Limousine", PS = 330, Kilometers = 111, Fuel = "Diesel", Price = 132380,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 10, 18), Color = "red",
                TareWeight = 2215, AccidentFree = true, Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = true,
                CountWheels = 8, Leasing = true, SeatCover ="Polyester"},

            new Mercedes(){Modell="AMG A 35 ", PS = 306, Kilometers = 0, Fuel = "Gasoline", Price = 75083,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 12, 09), Color = "yellow",
                TareWeight = 1555, AccidentFree = true, Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Art Velour"},

            new Mercedes(){Modell="AMG CLS 53", PS = 435, Kilometers = 1000, Fuel = "Gasoline", Price = 128696,
                ManualTransmission = false, FirstRegistration = new DateTime(2021, 12, 08), Color = "silver",
                TareWeight = 1905, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Faux leather"},

            new Mercedes(){Modell="A 250 ", PS = 160, Kilometers = 20200, Fuel = "Gasoline", Price = 47964,
                ManualTransmission = false, FirstRegistration = new DateTime(2018, 02, 14), Color = "white",
                TareWeight = 1359, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Mercedes(){Modell="A 180 d ", PS = 116, Kilometers = 0, Fuel = "Diesel", Price = 41763,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 04, 29), Color = "white",
                TareWeight = 1680, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = true,
                CountWheels = 4, Leasing = true, SeatCover ="Leather"},

            new Mercedes(){Modell="AMG GT C ", PS = 557, Kilometers = 0, Fuel = "Gasoline", Price = 277236,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 07, 04), Color = "black",
                TareWeight = 1735, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Leather"},

            new Mercedes(){Modell="C 220 d ", PS = 200, Kilometers = 200, Fuel = "Diesel", Price = 58257,
                ManualTransmission = false, FirstRegistration = new DateTime(2021, 11, 05), Color = "silver",
                TareWeight = 1720, AccidentFree = true,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = true,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Mercedes(){Modell="AMG GT 43  Coupé", PS = 367, Kilometers = 80452, Fuel = "Gasoline", Price = 161207,
                ManualTransmission = false, FirstRegistration = new DateTime(2019, 04, 07), Color = "gold",
                TareWeight = 1840, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 4, Leasing = true, SeatCover ="Faux leather"}
        };



        public List<Audi> a = new List<Audi>()
        {
            new Audi(){Modell="A4 allroad quattro", PS = 204, Kilometers = 0, Fuel = "Hybrid", Price = 57279,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 03, 01), Color = "black",
                TareWeight = 1720, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Faux leather"},

            new Audi(){Modell="S8 TFSI quattro", PS = 571, Kilometers = 100, Fuel = "Gasoline", Price = 179000,
                ManualTransmission = false, FirstRegistration = new DateTime(2021, 12, 31), Color = "white",
                TareWeight = 2295, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Leather"},

            new Audi(){Modell="RS Q8", PS = 600, Kilometers = 0, Fuel = "Gasoline", Price = 189988,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 05, 30), Color = "cyan",
                TareWeight = 2390, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="TTS Roadster quattro", PS = 320, Kilometers = 74621, Fuel = "Hybrid", Price = 74814,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 05, 30), Color = "gold",
                TareWeight = 1585, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="Q4 40 e-tron", PS = 95, Kilometers = 0, Fuel = "Electric", Price = 50243,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 05, 30), Color = "black",
                TareWeight = 1965, AccidentFree = false,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="A5 allroad quattro", PS = 188, Kilometers = 56231, Fuel = "Hybrid", Price = 85149,
                ManualTransmission = true, FirstRegistration = new DateTime(2018, 03, 01), Color = "gold",
                TareWeight = 2145, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 4, Leasing = true, SeatCover ="Leather"},

            new Audi(){Modell="S7 TFSI", PS = 451, Kilometers = 0, Fuel = "Diesel", Price = 150346,
                ManualTransmission = false, FirstRegistration = new DateTime(2021, 12, 31), Color = "white",
                TareWeight = 1235, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = true,
                CountWheels = 4, Leasing = false, SeatCover ="Leather"},

            new Audi(){Modell="RS Q2", PS = 250, Kilometers = 0, Fuel = "Hybrid", Price = 105236,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 05, 30), Color = "cyan",
                TareWeight = 2390, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="TTS Roadster", PS = 150, Kilometers = 856924, Fuel = "Hybrid", Price = 85621,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 03, 16), Color = "gold",
                TareWeight = 1585, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="Q5", PS = 510, Kilometers = 0, Fuel = "Gasoline", Price = 86292,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 11, 25), Color = "cyan",
                TareWeight = 1462, AccidentFree = false,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Art Velour"},
        };

        public List<Audi> a1 = new List<Audi>()
        {
            new Audi(){Modell="A4 allroad quattro", PS = 204, Kilometers = 0, Fuel = "Hybrid", Price = 57279,
                ManualTransmission = false, FirstRegistration = new DateTime(2022, 12, 01), Color = "black",
                TareWeight = 1720, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 8, Leasing = true, SeatCover ="Faux leather"},

            new Audi(){Modell="S8 TFSI quattro", PS = 571, Kilometers = 100, Fuel = "Gasoline", Price = 179000,
                ManualTransmission = false, FirstRegistration = new DateTime(2021, 05, 31), Color = "white",
                TareWeight = 2295, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 4, Leasing = false, SeatCover ="Leather"},

            new Audi(){Modell="RS Q8", PS = 600, Kilometers = 0, Fuel = "Gasoline", Price = 189988,
                ManualTransmission = false, FirstRegistration = new DateTime(2020, 05, 12), Color = "cyan",
                TareWeight = 2390, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="TTS Roadster quattro", PS = 320, Kilometers = 74621, Fuel = "Hybrid", Price = 74814,
                ManualTransmission = false, FirstRegistration = new DateTime(2015, 05, 10), Color = "gold",
                TareWeight = 1585, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="Q4 40 e-tron", PS = 95, Kilometers = 0, Fuel = "Electric", Price = 50243,
                ManualTransmission = false, FirstRegistration = new DateTime(2017, 05, 20), Color = "black",
                TareWeight = 1965, AccidentFree = false,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="A5 allroad quattro", PS = 188, Kilometers = 56231, Fuel = "Hybrid", Price = 85149,
                ManualTransmission = true, FirstRegistration = new DateTime(2017, 05, 01), Color = "gold",
                TareWeight = 2145, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 4, Leasing = true, SeatCover ="Leather"},

            new Audi(){Modell="S7 TFSI", PS = 451, Kilometers = 0, Fuel = "Diesel", Price = 150346,
                ManualTransmission = false, FirstRegistration = new DateTime(2021, 08, 31), Color = "white",
                TareWeight = 1235, AccidentFree = true,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = true,
                CountWheels = 4, Leasing = false, SeatCover ="Leather"},

            new Audi(){Modell="Q2", PS = 250, Kilometers = 0, Fuel = "Hybrid", Price = 105236,
                ManualTransmission = true, FirstRegistration = new DateTime(2016, 09, 30), Color = "cyan",
                TareWeight = 2390, AccidentFree = false,Insurance = EInsurance.PARTIALCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="TTS", PS = 150, Kilometers = 856924, Fuel = "Hybrid", Price = 85621,
                ManualTransmission = false, FirstRegistration = new DateTime(2013, 03, 19), Color = "gold",
                TareWeight = 1585, AccidentFree = true,Insurance = EInsurance.LIABILITY, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Polyester"},

            new Audi(){Modell="Q5", PS = 510, Kilometers = 0, Fuel = "Gasoline", Price = 86292,
                ManualTransmission = true, FirstRegistration = new DateTime(2022, 8, 25), Color = "cyan",
                TareWeight = 1462, AccidentFree = false,Insurance = EInsurance.FULLYCOMPREHENSIVE, AddBlue = false,
                CountWheels = 8, Leasing = false, SeatCover ="Art Velour"},
        };
    }
}
