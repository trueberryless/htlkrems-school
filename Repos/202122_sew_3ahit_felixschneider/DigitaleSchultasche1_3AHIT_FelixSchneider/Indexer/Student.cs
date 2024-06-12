using System;
using System.Collections.Generic;
using System.Text;

namespace Indexer
{
    class Student
    {
        private DateTime birth;

        public DateTime Birth
        {
            get { return birth; }
        }

        public Student(DateTime birth)
        {
            if (DateTime.Now < birth)
                throw new Exception("Back from the Future?");
            this.birth = birth;
        }

        public int Age
        {
            get {
                var dif = DateTime.Now.Year - birth.Year;
                if (DateTime.Now.Month < birth.Month)
                    return --dif;
                if (DateTime.Now.Month == birth.Month)
                    if (DateTime.Now.Day < birth.Day)
                        return --dif;
                return dif;
            }
        }
    }

    class Stundentmanager : List<Student>
    {
        public Student this [DateTime dt]
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.Birth == dt)
                        return item;
                }
                return null;
            }
        }

        public Student this[int m, int d]
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.Birth.Month == m && item.Birth.Day == d)
                        return item;
                }
                return null;
            }
        }
    }
}
