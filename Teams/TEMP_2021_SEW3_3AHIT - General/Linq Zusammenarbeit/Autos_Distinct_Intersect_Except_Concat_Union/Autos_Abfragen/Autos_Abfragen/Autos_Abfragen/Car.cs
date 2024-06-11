using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos_Abfragen
{
    public enum EInsurance { FULLYCOMPREHENSIVE, PARTIALCOMPREHENSIVE, LIABILITY}
    public class Car
    {
        string modell;
        public string Modell { get { return modell; } set { modell = value; } }

        int ps;
        public int PS { get { return ps; } set { ps = value; } }

        int kilometers;
        public int Kilometers { get { return kilometers; } set { kilometers = value; } }

        string fuel;
        public string Fuel { get { return fuel; } set { fuel = value; } }

        int price;
        public int Price { get { return price; } set { price = value; } }

        bool manualTransmission;
        public bool ManualTransmission { get { return manualTransmission; } set { manualTransmission = value; } }

        DateTime firstRegistration;
        public DateTime FirstRegistration { get { return firstRegistration; } set { firstRegistration = value; } }

        string color;
        public string Color { get { return color; } set { color = value; } }

        int tareWeight;
        public int TareWeight { get { return tareWeight; } set { tareWeight = value; } }

        bool accidentFree;
        public bool AccidentFree { get { return accidentFree; } set { accidentFree = value; } }

        EInsurance insurance;
        public EInsurance Insurance { get { return insurance; } set { insurance = value; } }

        bool addBlue;
        public bool AddBlue { get { return addBlue; } set { addBlue = value; } }

        int countWheels;
        public int CountWheels { get { return countWheels; } set { countWheels = value; } }

        bool leasing;
        public bool Leasing { get { return leasing; } set { leasing = value; } }

        string seatCover;
        public string SeatCover { get { return seatCover; } set { seatCover = value; } }

        public Car() { }
        public Car(string modell, int ps, int kilometers, string fuel, int price, bool manualTransmission, 
            DateTime firstRegistration, string color, int tareWeight, bool accidentFree, EInsurance insurance, bool addBlue,
            int countWheels, bool leasing, string seatCover)
        {
            this.modell = modell;
            this.ps = ps;
            this.kilometers = kilometers;
            this.fuel = fuel;
            this.price = price;
            this.manualTransmission = manualTransmission;
            this.firstRegistration = firstRegistration;
            this.color = color;
            this.tareWeight = tareWeight;
            this.accidentFree = accidentFree;
            this.insurance = insurance;
            this.addBlue = addBlue;
            this.countWheels = countWheels;
            this.leasing = leasing;
            this.seatCover = seatCover;
        }

        public override string ToString()
        {
            return  Modell + "; " + PS + "; "+ Kilometers + "; "+ Fuel + "; " +Price +"; " + ManualTransmission+"; "
                + FirstRegistration+"; " + Color +"; " + TareWeight+"; " +AccidentFree +"; " + Insurance+"; " + AddBlue+"; " + CountWheels +"; "
                + Leasing+"; " +SeatCover +"; ";
        }
    }
}
