using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay5
{
    internal class ReplaceElement
    {
        static void Main(string[] args)
        {
            //			First element of the array is replaced with last element of the array.Input2 is the array size.
            //For example
            //	Input1[]= { 12, 34, 56, 17, 2 }
            //	Input2 = 5
            //	Output1[]= { 2, 17, 56, 34, 12 }
            //	Take mid = input2 / 2;
            //			BR
            //	1.If array contain any negative elements store -1 to the first position of the output array
            //	2.Sto re - 2 if the given array size is negative
            //	3.Store - 3 to the first position of the output array if the given array size is even

            int[] arr = { 12, 34, 56, 17, 2 };
            int st = 0, end = arr.Length - 1;
            while (st < end)
            {
                int temp;
                temp = arr[st];
                arr[st] = arr[end];
                arr[end] = temp;
                st++;end--;
            }
            foreach(int i in arr)
            {
                Console.Write(i+" ");
            }
		}
	}
}
