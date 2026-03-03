using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay7
{
    internal class CountRepeatedElement
    {
        static void Main(string[] args)
        {
            //			1.search the given input and Count how many times it repeating  from the given array
            //Eg:
            //			Input1 -{ 1,2,2,3,3}
            //			Input2 - 5
            //Input3 - 2

            //Output - 2

            //Business Rule:
            //Store - 1 into output variable if any of the array value is negative
            //Store - 2 into output variable if input2(array size) is negative
            //Store - 3 into output variable if input3(Search value) is negative
            int[] arr = { 1, 2, 2, 3, 3 };
            int tar,count=0;
            Console.WriteLine("Enter the Element: ");
            tar = Convert.ToInt32(Console.ReadLine());
            foreach(int val in arr)
            {
                if (val == tar) count++;
            }
            Console.WriteLine("Count= " + count);

		}
	}
}
