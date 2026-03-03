using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;

namespace HandsOnDay5
{
    internal class CubeSum
    {
		//		find the sum of cube of prime numbers upto n natural numbers(case study type)
		//BR- 
		//1)	if the limit(n) is negative, store -1 to output
		//2)	if the n value is greater than 7, store -1 to output

		static bool IsPrime(int num)
		{
			if (num <= 1)
				return false;

			for (int i = 2; i < num; i++)
			{
				if (num % i == 0)
					return false;
			}
			return true;
		}

		static void Main()
		{
			Console.Write("Enter n: ");
			int n = Convert.ToInt32(Console.ReadLine());

			int sum = 0;

			for (int i = 2; i <= n; i++)
			{
				if (IsPrime(i))
				{
					sum += i * i * i;   
				}
			}

			Console.WriteLine("Sum of cubes of prime numbers = " + sum);
		}
	}
}
