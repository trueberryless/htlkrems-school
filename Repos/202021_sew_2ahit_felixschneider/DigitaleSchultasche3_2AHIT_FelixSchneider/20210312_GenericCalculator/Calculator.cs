using System;
using System.Collections.Generic;
using System.Text;

namespace _20210312_GenericCalculator
{
    class Calculator<T>
    {
        public T Sum(T t1, T t2)
        {
            if (typeof(T) == typeof(int))
            {
                int res = Convert.ToInt32(t1) + Convert.ToInt32(t2);
                object resO = res;
                T resT = (T)resO;
                return resT;
            }
            return default(T);
        }
    }
}
