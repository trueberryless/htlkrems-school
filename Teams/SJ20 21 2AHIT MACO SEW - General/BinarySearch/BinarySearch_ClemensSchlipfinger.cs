using System;

namespace BinäreSuche_15012021
{
	class Program
	{
		static void Main(string[] args)
		{				//  0  1  2   3   4   5   6   7   8   9   10  11  12  13  14  15  
			int[] daten = { 3, 7, 23, 27, 31, 44, 45, 56, 65, 77, 79, 81, 93, 96, 97, 99 };
			
			for(int i = -1; i < 101; i++)
			{
				Console.WriteLine(i);
				binarysearch(i, daten);
				Console.WriteLine("\n");
			}
		}

		static bool binarysearch(int wert, int[] daten)
		{
			int start = 0;
			int end = daten.Length - 1;
			int counter = 0;

			while (true)
			{
				int middle = (end + start) / 2;
				Console.WriteLine(start + " " + end + " : " + middle);

				if (daten[middle] < wert)
				{
					start = middle+1;
					if(start > end)
					{
						//not included 100 - unendlich
						Console.WriteLine("L2: not included");
						return false;
					}
				}
				else if (daten[middle] > wert)
				{
					end = middle;
				}
				
				if(daten[middle] == wert)
				{
					Console.WriteLine("L0: " + daten[middle] +" "+ wert);
					return true;
				}
				else if (start == end && counter == 0)
				{
					counter = 1;
				}
				else if(start == end && counter == 1)
				{
					//not included 0-99
					Console.WriteLine("L1: not included");
					return false;
				}
			}

		}
	}
}
