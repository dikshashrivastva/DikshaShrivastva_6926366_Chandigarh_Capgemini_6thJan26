using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay4
{
    internal class Armstrong
    {

		//		Write a program to check for Armstrong number
		//1)	If number is negative store -1 into the output1 variable
		//2)	If number is greater than 3 digit store -2 into the output1 variable
		//3)	If it is Armstrong number store 1 into the output1 variable
		//4)	If it is not store store 0 into the output1 variable


		static void Main(string[] args)
		{
			int num, output = 0;
			Console.WriteLine("Enter a number: ");
			num = int.Parse(Console.ReadLine());

			if (num < 0)
			{
				output = -1;
			}
			else if (num > 999)
			{
				output = -2;
			}
			else
			{
				int temp = num, sum = 0;
				while (temp != 0)
				{
					int dig = temp % 10;
					sum += dig * dig * dig;
					temp /= 10;
				}
				if (sum == num) output = 1;
				else output = 0;
			}
			Console.WriteLine("Output=" + output);
		}
	}
}
