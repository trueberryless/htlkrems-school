using System;
using System.Collections;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Friends friends = new Friends();
            friends.Add(new Person { Id = 1, Name = "Hugo", Birth = new DateTime(2005, 1, 1), SVN = 1234 });
            friends.Add(new Person { Id = 2, Name = "Susi", Birth = new DateTime(2005, 2, 2), SVN = 2345 });
            friends.Add(new Person { Id = 3, Name = "Felix", Birth = new DateTime(2005, 3, 3), SVN = 3456 });

            List<Result> lr = friends.FilterByMonth(2);
            foreach (var item in lr)
                Console.WriteLine(item.Name + "/" + item.SVN);

            var erg = friends.Where(x => x.Birth.Month == 2)
                .Select((x) => new { x.Name, x.SVN });
            foreach (var item in erg)
                Console.WriteLine(item.Name + "/" + item.SVN);
        }
    }

    class Friends : List<Person>
    {
        public List<Result> FilterByMonth(int month)
        {
            List<Result> lr = new List<Result>();
            foreach (var item in this)
            {
                if(month == item.Birth.Month)
                {
                    lr.Add(new Result { Name = item.Name, SVN = item.SVN });
                }
            }
            return lr;
        }
    }

    class Result
    {
        public string Name { get; set; }
        public int SVN { get; set; }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public int SVN { get; set; }
    }
}