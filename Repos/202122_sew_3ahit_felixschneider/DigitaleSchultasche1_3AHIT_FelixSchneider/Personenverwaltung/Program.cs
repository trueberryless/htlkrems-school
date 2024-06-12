using System;
using libperson;

namespace Personenverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            while(p.Firstname == null || p.Surname == null || p.Age == 0 || p.Phonenumber == null || p.Email == null || p.Eyecolor == EEyecolor.none)
            {
                try
                {
                    if (p.Firstname == null)
                    {
                        Console.Write("Firstname: ");
                        p.Firstname = Console.ReadLine();
                    }
                    if (p.Surname == null)
                    {
                        Console.Write("Surname: ");
                        p.Surname = Console.ReadLine();
                    }
                    if (p.Age == 0)
                    {
                        Console.Write("Age: ");
                        p.Age = Convert.ToInt32(Console.ReadLine());
                    }
                    if (p.Phonenumber == null)
                    {
                        Console.Write("Phonenumber: ");
                        p.Phonenumber = Console.ReadLine();
                    }
                    if (p.Email == null)
                    {
                        Console.Write("Email: ");
                        p.Email = Console.ReadLine();
                    }
                    if (p.Eyecolor == EEyecolor.none)
                    {
                        Console.Write("Eyecolor (brown/blue/green): ");
                        p.Eyecolor = (EEyecolor)Enum.Parse(typeof(EEyecolor), Console.ReadLine(), true);
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong input!");
                }  
            }
            

            Console.WriteLine(p);

        }
    }
}
