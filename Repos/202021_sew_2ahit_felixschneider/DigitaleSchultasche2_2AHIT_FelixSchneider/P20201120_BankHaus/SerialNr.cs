using System;
using System.Collections.Generic;
using System.Text;

namespace P20201120_BankHaus
{
    static class SerialNr
    {
        static int nr = 1;

        static public int NextNr()
        {
            return nr++;
        }
    }
}
