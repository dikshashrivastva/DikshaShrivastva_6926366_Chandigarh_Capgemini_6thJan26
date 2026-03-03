using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay4
{
    internal class factorial
    {
		static void Main(string[] args)
		{
			int num, fact = 1, output = 0;
			Console.Write("Enter a num: ");
			num = int.Parse(Console.ReadLine());

			if (num < 0) output = -1;
			else if (num > 7) output = -2;
			else
			{
				for (int i = 1; i <= num; i++)
				{
					fact *= i;
				}
				Console.WriteLine("Factorial=" + fact);

			}
			Console.WriteLine("output1= " + output);

		}
	}
}
