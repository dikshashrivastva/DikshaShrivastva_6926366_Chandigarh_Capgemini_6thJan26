using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay4
{
    internal class Avg
    {
		//        4.    Write a program to find sum of even numbers and odd numbers in an array and avg them
		//(ex: ar{ 1,2,3,4,5,6}
		//		output1=(12+9)/2
		//1)	If any of the array element is negative store -1 into the output1 variable
		//2)	If the size of an array is negative store -2 into the output1 variable

		static void Main(string[] args)
		{
			int[] arr = { 1, 2, 3, 4, 5, 6 };

			int output = 0, avg = 0, sumOdd = 0, sumEven = 0;

			if (arr.Length < 0) output = -2;

			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] < 0) output = -1;
				if (i % 2 == 0)
				{
					sumEven += arr[i];
				}
				else
				{
					sumOdd += arr[i];
				}
			}
			avg = (sumEven + sumOdd) / 2;
			Console.WriteLine("Avg= " + avg);
			Console.WriteLine("output1= " + output);
		}
	}
}
