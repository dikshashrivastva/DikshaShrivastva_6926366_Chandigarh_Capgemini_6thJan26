using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay7
{
    internal class PrimeCubeSum
    {
        static void Main(string[] args)
        {
//			5.sum of cube of prime numbers upto a limit
//Business Rule:1.if input1 < 0, store - 1 into the output variable
//		2.if input1 > 32767,store - 2 into the output variable

            bool isPrime(int n)
            {
                for(int i = 2; i < n; i++)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }
            int sum = 0, limit;
            Console.WriteLine("Enter the limit: ");
            limit = int.Parse(Console.ReadLine());
            for(int i = 2; i <= limit; i++)
            {
                if (isPrime(i))
                {
                    sum += i * i * i;
                }
            }
            Console.WriteLine("Sum= " + sum);
		}
	}
}
