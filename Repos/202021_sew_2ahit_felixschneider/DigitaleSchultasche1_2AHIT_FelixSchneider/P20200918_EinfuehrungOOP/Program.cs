using System;

namespace P20200918_EinfuehrungOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Person one = new Person();
            one.Firstname = "Clemens";
            one.Secondname = "Schlipfinger";

            Person two = new Person();
            two.Firstname = "Matthias";
            two.Secondname = "Swatek";

            Person three = new Person();
            three.Firstname = "Lorenz";
            three.Secondname = "Toifl";


            Person[] friends = new Person[5];

            friends[0] = one;
            friends[1] = two;
            friends[2] = three;
            friends[3] = new Person();
            friends[3].Firstname = "Anton Xaver";
            friends[3].Secondname = "Edlinger";

            friends[4] = new Person { Firstname = "Lukas", Secondname = "Flickentanz" };

            for (int i = 0; i < friends.Length; i++)
            {
                Console.WriteLine($"{i + 1}.: {friends[i].Firstname} {friends[i].Secondname}");
            }
            Console.WriteLine("--------------------");
            foreach(var item in friends)
            {
                Console.WriteLine($"{item.Firstname} {item.Secondname}");
            }
        }
    }
}
