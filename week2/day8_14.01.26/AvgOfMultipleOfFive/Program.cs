using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AvgOfMultipleOfFive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //			1.average of the numbers divisible by 5 upto a limit.
            //Business Rule:if input1 < 0, store - 1 into the output variable

            int limit,sum=0;
            int output = 0;
            
            Console.WriteLine("Enter a limit: ");
            limit = int.Parse(Console.ReadLine());

			if (limit < 0) output = -1;

			for (int i = 0; i <= limit; i++)
            {
                if (i % 5 == 0) sum += i;
            }
            float avg = sum / (limit / 5);

            Console.WriteLine("Avg = "+ avg);
            Console.WriteLine("Output= " + output);

        }
    }
}
