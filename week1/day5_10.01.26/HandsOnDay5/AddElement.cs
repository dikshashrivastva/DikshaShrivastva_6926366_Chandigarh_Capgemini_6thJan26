using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay5
{
    internal class AddElement
    {
        static void Main(string[] args)
        {
            //			Add the first element of the array input1 with the last element of the array input2..Input3 is size of the array
            //	Input1[]= { 21, 23, 41, 4 }
            //	Input2[]= { 3, 4, 1, 5 }
            //	Input3 = 4;
            //			OUTPUT[]= { 26, 24, 45, 7 }
            //BR
            //	1.Store - 1 to the first position of the output array if any input array elements contains negative
            //				value
            //	2.Store - 2  to the first position of the output array if array size is negative

            int[] arr = { 21, 23, 41, 4 };
            int[] arr2 = { 3, 4, 1, 5 };
            int[] output = new int[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                output[i] = arr[i] + arr2[arr.Length - i - 1];
            }
            foreach(int val in output)
            {
                Console.WriteLine(val);
            }


		}
	}
}
