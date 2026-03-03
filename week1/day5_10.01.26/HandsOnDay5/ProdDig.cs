using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace HandsOnDay5
{
    internal class ProdDig
    {
        static void Main(string[] args)
        {
            //			12.Find the product of the digits of the given no and if product is divisible by 3 or 5 store 1 to the

            //			  output variable
            //	Input1 = 56
            //	Output = 1
            //Input2 is the array size.
            //BR
            //	1.If the given input is negative store - 1 to the output
            //	2.If the given no itself is divided by 3 or 5 store - 2 to the output
            int num = 56;
            int product = 1,output=0;
            while (num > 0)
            {
                int dig = num % 10;
                product *= dig;
                num /= 10;
            }
            if (product % 3==0 || product%5==0)
            {
                output = 1;
            }
            Console.WriteLine("Product=" + product + "\nOutput= " + output);

		}
	}
}
