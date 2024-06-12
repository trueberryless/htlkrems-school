using System;
using System.Linq;
using System.Collections.Generic;
namespace PersonMitUndOhneLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFriends mf = new MyFriends();
            mf.Add(new Person { Id = 1, Name = "Hugo", Geboren = new DateTime(2005, 1, 1), SVNr=1234 });
            mf.Add(new Person { Id = 2, Name = "Susi", Geboren = new DateTime(2005, 2, 2),SVNr=2345 });
            mf.Add(new Person { Id = 3, Name = "Felix", Geboren = new DateTime(2005, 3, 3),SVNr=3456 });

            //Lösung ohne LINQ
            List<Result> lr = mf.FilterByMonth(2);
            foreach (var item in lr)
                Console.WriteLine(item.Name + "/" + item.SVNr);

            // Lösung mit LINQ
            var erg = mf.Where((x) => x.Geboren.Month == 2)
                        .Select((x)=>new { x.Name, x.SVNr });//"result"
            foreach (var item in erg)
                Console.WriteLine(item.Name + "/" + item.SVNr);
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Geboren { get; set; }
        public int SVNr { get; set; }
    }
    class Result {
        public string Name { get; set; }
        public int SVNr { get; set; }
    }
    class MyFriends : List<Person>
    {
        public List<Result> FilterByMonth(int m) {
            List<Result> lr = new List<Result>();
            foreach (var item in this)
            {
                if (item.Geboren.Month==m)
                {
                    Result r = new Result();
                    r.Name = item.Name;
                    r.SVNr = item.SVNr;
                    lr.Add(r);
                }
            }
            return lr;
        }
    }
}
