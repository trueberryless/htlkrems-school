using Operatoren;
using System;



Fraction f1 = new Fraction(1, 3);
Fraction f2 = new Fraction(1, 4);
Fraction f3 = f1 * f2;

Console.WriteLine(f3.Numerator + ", " + f3.Denominator);