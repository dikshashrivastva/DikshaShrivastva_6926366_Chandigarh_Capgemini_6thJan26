using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay6
{
    internal class SumCube
    {
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
