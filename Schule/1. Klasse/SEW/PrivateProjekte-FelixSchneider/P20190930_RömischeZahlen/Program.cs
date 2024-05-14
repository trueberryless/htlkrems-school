using System;

namespace P20190930_RömischeZahlen
{
    class Program
    {
        static void Main(string[] args)
        {
            string r, erg;
            int z;
            r = "";
            erg = "";
            z = 0;
            z = Convert.ToInt32(Console.ReadLine());
            while(true)
            {
                if (z == 1)
            {
                r = "I";
            }
            else
            {
                if (z == 5)
                {
                    r = "V";
                }
                else
                {
                    if (z == 10)
                    {
                        r = "X";
                    }
                    else
                    {
                        if (z == 50)
                        {
                            r = "L";
                        }
                        else
                        {
                            if (z == 100)
                            {
                                r = "C";
                            }
                            else
                            {
                                if (z == 500)
                                {
                                    r = "D";
                                }
                                else
                                {
                                    if (z == 1000)
                                    {
                                        r = "M";
                                    }
                                }
                            }
                        }
                    }
                }
            }
                      
                
                erg = r;
                Console.WriteLine("");
                Console.WriteLine(erg);
                break;
                
            }

            
        }
    }
}