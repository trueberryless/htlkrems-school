using System;
using System.Collections.Generic;
using System.Text;

namespace P20201120_BankHaus
{
    class Bank
    {
        List<Konto> kontoList;

        public Bank()
        {
            kontoList = new List<Konto>();
        }

        public void HinzuSparbuch(string name, double zs)
        {
            kontoList.Add(new Sparbuch(name, zs));
        }

        public void HinzuSparbuch(string name, double zs, double stand)
        {
            kontoList.Add(new Sparbuch(name, zs, stand));
        }

        public void HinzuGirokonto(string name, double ueR, double ueZ)
        {
            kontoList.Add(new GiroKonto(name, ueR, ueZ));
        }

        public void HinzuGirokonto(string name, double ueR, double ueZ, double stand)
        {
            kontoList.Add(new GiroKonto(name, ueR, ueZ, stand));
        }

        public void Auflistung()
        {
            for (int i = 0; i < kontoList.Count; i++)
            {                
                Console.Write(kontoList[i].GetType() + " / ");
                kontoList[i].Show();
            }
        }

        public void TagesAbschlussAll()
        {
            for (int i = 0; i < kontoList.Count; i++)
            {
                kontoList[i].TagesAbschluss();
            }
        }

        public void Weltspartag()
        {
            Sparbuch s;
            for (int i = 0; i < kontoList.Count; i++)
            {
                if(Convert.ToString(kontoList[i].GetType()) == "P20201120_BankHaus.Sparbuch") 
                {
                    s = (Sparbuch)kontoList[i];
                    s.Weltspartag();
                }
            }
        }
    }
}
