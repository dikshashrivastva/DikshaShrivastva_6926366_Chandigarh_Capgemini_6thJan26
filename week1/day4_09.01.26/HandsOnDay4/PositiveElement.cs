using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay4
{
    internal class PositiveElement
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, -4, 7, 9, -34, -5 };
            int product = 1 , output=0;
            if (arr.Length < 0) output = -2;
            foreach(int val in arr)
            {
                if (val > 0)
                {
                    product *= val;
                }
            }
            Console.WriteLine("Product=" + product);
            Console.WriteLine("Output" + output);
        }
    }
}
