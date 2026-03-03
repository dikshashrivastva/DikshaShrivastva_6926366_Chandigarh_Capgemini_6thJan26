using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay7
{
    internal class HalfSorting
    {
        static void Main(string[] args)
        {
            //			28.Sort the half of the array in ascending order and the other half in descending order
            //Business Rule:if array size is negative store - 1 into the array.

            int[] arr = { 42, 22, 89, 53, 21, 3 };
            int size = arr.Length;
            int mid = size / 2;
            Array.Sort(arr);

            //reverse other half decending
            Array.Reverse(arr, mid, size - mid);

            Console.WriteLine("Output: ");
             foreach(int val in arr)
            {
                Console.WriteLine(val);
            }

		}
	}
}
