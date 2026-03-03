using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay4
{
    internal class EvenDigitSum
    {
        static void Main(string[] args)
        {
            //			8.Write a program to find the sum of the even digits in a given number
            //				  Br:
            //1)	If number is negative store - 1 into the output variable
            //2)	If number is greater than 32767 store - 2 into the output variable

            int num = 12345;
            int output = 0;
            if (num < 0) output = -1;
            else if (num > 32767) output = -2;
                int sum = 0;
            while(num > 0)
            {
                int dig = num % 10;
                if (dig % 2 == 0)
                {
                    sum += dig;
                }
                num /= 10;
            }
            Console.WriteLine("Sum=" + sum);
            Console.WriteLine("Output= " + output);
            

		}
	}
}
