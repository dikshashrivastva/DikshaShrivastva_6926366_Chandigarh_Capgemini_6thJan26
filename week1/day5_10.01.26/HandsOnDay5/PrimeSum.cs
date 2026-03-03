using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay5
{
    internal class PrimeSum
    {
        public static bool isPrime(int n)
        {
            if (n == 0) return false;
            if (n == 1) return false;
            for(int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                    break;
                }
            }
			return true;

		}
        static void Main(string[] args)
        {
            //			13.Find the sum of prime nos in an array  and store it into output variable
            //Note: 1 is not a prime no
            //	Input1[] = { 1, 2, 3, 4, 5 }
            //	Input2 = 5
            //	Output1 = 10
            //BR
            //	1.If the given input array contain any negative no store - 1 to the output1
            //	2.if the given input array size is negative store - 2 to the output1
            //	3.If the input array does not contain any prime nos store -3 to the output1

            int[] arr = { 1, 2, 3, 4, 5 };
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (isPrime(arr[i])) sum += arr[i];
            }
            Console.WriteLine(sum);


		}
	}
}
