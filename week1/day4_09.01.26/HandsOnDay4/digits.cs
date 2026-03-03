using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay4
{
    internal class digits
    {
		//   3.Write a program to find number of digits in a given number(ex: for 345 no of digits is 3)
		//1) if number is negative store -1 into the output1 variable

		static void Main(string[] args)
		{
			int num, dig = 0, count = 0, output = 0;
			Console.Write("Enter a num: ");
			num = int.Parse(Console.ReadLine());
			if (num < 0)
			{
				output = -1;
			}
			else
			{
				while (num > 0)
				{
					dig = num % 10;
					count++;
					num = num / 10;
				}
				Console.WriteLine("No. of digits= " + count);
			}
			Console.WriteLine("output1= " + output);
		}

	}
}
