using Microsoft.VisualStudio.TestTools.UnitTesting;
using Operatoren;
using System;

namespace UT_Operatoren
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethodException()
        {
            Fraction f = new Fraction(1, 0);

        }
        [TestMethod]
        public void TestOperatorPlus()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(1, 4);
            Fraction f3 = f1 + f2;
            Assert.AreEqual(f3.Numerator, 7);
            Assert.AreEqual(f3.Denominator, 12);
        }
        [TestMethod]
        public void TestOperatorMinus()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = -f1;
            Assert.AreEqual(f2.Numerator, -1);
            Assert.AreEqual(f2.Denominator, 3);
            Fraction f3 = f1 - f2;
            Assert.AreEqual(f3.Numerator, 2);
            Assert.AreEqual(f3.Denominator, 3);
        }
        [TestMethod]
        public void TestOperatorMultiply()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(1, 4);
            Fraction f3 = f1 * f2;
            Assert.AreEqual(f3.Numerator, 1);
            Assert.AreEqual(f3.Denominator, 12);
        }
        [TestMethod]
        public void TestOperatorDivide()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(1, 4);
            Fraction f3 = f1 / f2;
            Assert.AreEqual(f3.Numerator, 4);
            Assert.AreEqual(f3.Denominator, 3);
        }
        [TestMethod]
        public void TestShorten()
        {
            Fraction f1 = new Fraction(3, 6);
            Assert.AreEqual(f1.Numerator, 1);
            Assert.AreEqual(f1.Denominator, 2);
            f1 = new Fraction(2, 6);
            Assert.AreEqual(f1.Numerator, 1);
            Assert.AreEqual(f1.Denominator, 3);
            f1 = new Fraction(2, 4);
            Assert.AreEqual(f1.Numerator, 1);
            Assert.AreEqual(f1.Denominator, 2);
            f1 = new Fraction(30, 90);
            Assert.AreEqual(f1.Numerator, 1);
            Assert.AreEqual(f1.Denominator, 3);
        }
    }
}