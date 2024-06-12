using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_DLL
{
    interface ICalc<T> where T : IComparable<T>
    {
        T Add(T x, T y);
        T Sub(T x, T y);
        T Mul(T x, T y);
        T Div(T x, T y);
    }
}
