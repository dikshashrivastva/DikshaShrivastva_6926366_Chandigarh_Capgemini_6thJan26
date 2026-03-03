using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay4
{
    internal class SearchElement
    {
		static void Main(string[] args)
		{
			//9.Write a program to search an element in an array and if it is found store the location into
			//	 Output variable
			//	Br:
			//                 1) if it is not found store 1 into the output variable

			//		2) if any element in an input array is negative store - 1 into output variable

			//		3) if the size of an array is negative store - 2 into the output variable

			int[] arr = { 1, 4, 2, 8, 5, 85, 3 };
			int output1 = 1;
			int tar = 5;
			if (arr.Length < 0) output1 = -2;
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] < 0) output1 = -1;
				if (arr[i] == tar)
				{
					output1 = i;
					break;
				}
			}
			Console.WriteLine(output1);
		}
	}
}
