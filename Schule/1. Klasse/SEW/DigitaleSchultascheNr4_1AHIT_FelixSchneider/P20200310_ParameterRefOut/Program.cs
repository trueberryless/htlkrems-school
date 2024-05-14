using System;

namespace P20200310_ParameterRefOut
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            Console.WriteLine("Main vorher: x = "+x);
            TuwasRef(ref x);
            Console.WriteLine("Main nachher: x = " + x);


            int y;
            TuwasOut(out y);
            Console.WriteLine("Main nachher y = "+y);


            //Eingabe stürzt bei falscher Eingabe eventuell ab
            int z1 = Convert.ToInt32(Console.ReadLine());

            int z2; //Bei Fehlereingabe ist z2 0
            Int32.TryParse(Console.ReadLine(), out z2);                         //WICHTIG!!!



        }
        static void TuwasRef(ref int x)
        {
            Console.WriteLine("Tuwas vorher: x = " + x);
            x++;
            Console.WriteLine("Tuwas nachher: x = " + x);
        }
        static void TuwasOut(out int y)
        {
            //Console.WriteLine("Tuwas vorher: x = " + y);
            //y++; geht nicht, weil y noch keinen Wert hat
            //out bedeutet: es wird außerhalb deklariert und hat vielleicht keinen Wert
            y = 99; //daher MUSS diese Methode einen Wert zuzuweisen
            Console.WriteLine("Tuwas vorher: y = " + y);
        }
    }
}

