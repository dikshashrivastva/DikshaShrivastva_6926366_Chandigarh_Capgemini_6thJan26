using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay5
{
    internal class MultiplesOfThree
    {
        static void Main(string[] args)
        {
            //			11.Count the multiples of  3 store it into the output variable
            //		Input1[]= { 1, 2, 3, 4, 5, 6 }
            //Input2 = 6
            //		Output = 2
            //Input2 is the array size
            //			   BR
            //	1.Store - 1 to the output variable if input array contains any negative elements
            //	2.Store - 2 to the output variable if given input array size is negative
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            int count = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 3 == 0) count++;
            }
            Console.WriteLine(count);
		}
	}
}
