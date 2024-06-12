using System;

namespace T20201111_Computerspiele
{
    class Program
    {
        static void Main(string[] args)
        {
            Computerspiel cs = new Computerspiel("Minecraft", 24);

            BattelRoyale br = new BattelRoyale("Fortnite", 10);
            BattelRoyale br2 = new BattelRoyale("PAPG", 10, zeitlimit: 10);

            RPG rpg1 = new RPG();

            Computerspiel[] spiele = new Computerspiel[3];
            spiele[0] = br;
            spiele[1] = cs;
            spiele[2] = rpg1;

            br.Print();
            cs.Print();
            rpg1.Print();

            //for (int i = 0; i < spiele.Length; i++)
            //{
            //    spiele[i].Print();
            //}

            foreach (Computerspiel item in spiele)
            {
                item.Print();
                Console.WriteLine(item.ToString());
            }
        }
    }
}