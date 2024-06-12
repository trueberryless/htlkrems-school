using System;
using System.Collections.Generic;
using System.Text;

namespace P20200918_EinfuehrungOOP2
{
    class SVNR
    {
        private int lfnr;
        private DateTime geb;
        private int pz = -1;

        public int Lfnr
        {
            set
            {
                if (value >= 100 && value < 1000)
                    this.lfnr = value;
                else
                {
                    throw new Exception("Die Laufzahl ist nicht im erlaubten Bereich!");
                }
            }
        }

        public DateTime Geb
        {
            set
            {
                if(value.Year > DateTime.Now.Year)
                {
                    throw new Exception("Back from the future?");
                } 
                if(value.Month > DateTime.Now.Month && value.Year == DateTime.Now.Year)
                {
                    throw new Exception("Back from the future?");
                }
                if(value.Day > DateTime.Now.Month && value.Month == DateTime.Now.Month && value.Year == DateTime.Now.Year)
                {
                    throw new Exception("Back from the future?");
                }
                this.geb = value;
            }
        }

        public void Pz()
        {
            int sum = 0;
            sum += (this.lfnr / 100) * 3;
            sum += ((this.lfnr / 10) % 10) * 7;
            sum += (this.lfnr % 10) * 9;
            sum += (this.geb.Day / 10) * 5;
            sum += (this.geb.Day % 10) * 8;
            sum += (this.geb.Month / 10) * 4;
            sum += (this.geb.Month % 10) * 2;
            sum += ((this.geb.Year / 10) % 10);
            sum += (this.geb.Year % 10) * 6;
            sum = sum % 11;

            if(sum == 10)
            {
                this.lfnr++;
                this.pz = -1;
                if (this.lfnr == 1000)
                    this.lfnr = 100;
            }
            else
                this.pz = sum;
        }

        public string GetSVNR
        {
            get
            {
                while (pz == -1)
                {
                    Pz();
                }

                return  lfnr.ToString() + 
                        pz.ToString() + "-" +
                        geb.ToString("ddMMyy");
            }            
        }
    }
}
