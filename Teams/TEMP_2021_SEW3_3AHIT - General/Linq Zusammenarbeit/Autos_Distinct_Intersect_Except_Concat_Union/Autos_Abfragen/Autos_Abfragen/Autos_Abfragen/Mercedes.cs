using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos_Abfragen
{
    public class Mercedes : Car
    {
        public Mercedes() { }
        public Mercedes(string modell, int ps, int kilometers, string fuel, int price, bool manualTransmission,
            DateTime firstRegistration, string color, int tareWeight, bool accidentFree, EInsurance insurance, bool addBlue,
            int countWheels, bool leasing, string seatCover) : base(modell, ps, kilometers, fuel, price, manualTransmission, firstRegistration, color, tareWeight, accidentFree,
            insurance, addBlue, countWheels, leasing, seatCover)
        {

        }

        
    }
}
