using System;
using System.Collections.Generic;
using System.Text;

namespace HUE20200918_OOP_NotenEingabe
{
    class Note
    {
        private int wert;

        public int Wert
        {
            set
            {
                if(CheckValue(value) == true)
                    this.wert = value;
                else
                    throw new Exception("Notenwerte nur von 1 - 5!");
            }
        }

        public string GetWert()
        {
            string[] noten = { "Sehr gut", "Gut", "Befriedigend", "Genügend", "Nicht genügend" };
            return noten[wert - 1];
        }

        private bool CheckValue(int x)
        {
            if (x > 0 && x < 5) return true;
            else
                return false;
        }

        //private string note;

        //public string Note
        //{
        //    get { return this.note; }
        //    set
        //    {
        //        if (CheckIfNote(value) == true)
        //            this.note = IntinString(value);
        //        else
        //            throw new Exception("False Grade!");
                
        //    }
        //}

        //private bool CheckIfNote(string note)
        //{
        //    switch (note)
        //    {
        //        case "1": return true;
        //        case "2": return true;
        //        case "3": return true;
        //        case "4": return true;
        //        case "5": return true;
        //    }
        //    return false;
        //}

        //private string IntinString(string note)
        //{
        //    switch (note)
        //    {
        //        case "1": return " Sehr gut";
        //        case "2": return " Gut";
        //        case "3": return " Befriedigend";
        //        case "4": return " Genügend";
        //        case "5": return " Nicht genügend";
        //    }
        //    return "";
        //}
    }
}
