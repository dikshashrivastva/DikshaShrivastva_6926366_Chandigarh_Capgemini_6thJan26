using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay5
{
    internal class PerfectNum
    {
        static void Main(string[] args)
		{
			//            .      Check whether the given number is perfect or not
			//BR -
			//1)	if the number is perfect number, store 1 to output
			//2)	If the number is not negative, store - 1 to output
			//3)	If the number is negative, store - 2 to output
			int num;
			Console.WriteLine("Enter a number:");
			num = Convert.ToInt32(Console.ReadLine());
			int sum = 0;

			
			for (int i = 1; i < num; i++)
			{
				if (num % i == 0)
				{
					sum += i;
				}
			}

			
			if (sum == num)
				Console.WriteLine(num + " is a Perfect number.");
			else
				Console.WriteLine(num + " is NOT a Perfect number.");


		}
	}
}
