using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatoren
{
    public class Fraction
    {
        public int Numerator { get; private set; } // Zähler

        int denominator;  // Nenner
        public int Denominator
        {
            get { return denominator; }
            private set
            {
                if (value == 0)
                    throw new Exception("Nenner darf nicht 0 sein!");
                denominator = value;
            }
        }

        public Fraction() { }

        public Fraction(int num, int den)
        {
            Numerator = num;
            if (den == 0)
                throw new Exception("Nenner darf nicht 0 sein!");
            Denominator = den;
            Cancel(this);
        }

        public void Cancel()
        {
            Cancel(this);
        }

        static public Fraction Cancel(Fraction f)
        {
            Fraction cancelf = new Fraction();

            cancelf = f;

            return cancelf;
        }

        static public Fraction operator +(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();

            f.Denominator = f1.Denominator * f2.Denominator;
            f.Numerator = (f1.Numerator * f2.Denominator) + (f2.Numerator * f1.Denominator);

            return Cancel(f);
        }

        static public Fraction operator -(Fraction f)
        {
            return new Fraction(-f.Numerator, f.Denominator);
        }

        static public Fraction operator -(Fraction f1, Fraction f2)
        {
            return f1 + (-f2);
        }

        static public Fraction operator *(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();

            f.Denominator = f1.Denominator * f2.Denominator;
            f.Numerator = (f1.Numerator * f2.Denominator) / (f2.Numerator * f1.Denominator);

            return Cancel(f);
        }

        static public Fraction operator /(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();

            f.Denominator = f1.Denominator * f2.Denominator;
            f.Numerator = (f1.Numerator * f2.Denominator) * (f2.Numerator * f1.Denominator);

            return Cancel(f);
        }
    }
}
