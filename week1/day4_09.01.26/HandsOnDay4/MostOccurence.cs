using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay4
{
    internal class MostOccurence
    {
        static void Main(string[] args)
        {
			//10.Given an input array, if an element in an array is repeated most no of times store that
			//   element   into an output array


			//	 ex: input1{ 2,2,2,2,3,3,3,3,4}
			//then output = { 2, 3 }

			//		  input{ 2,2,2,3,3,4}
			//then output = { 2 }
			int[] arr = { 2, 2, 2, 2, 3, 3, 3, 3, 4 };
			int maxCount = 0;


			for (int i = 0; i < arr.Length; i++)
			{
				int count = 0;

				for (int j = 0; j < arr.Length; j++)
				{
					if (arr[i] == arr[j])
						count++;
				}

				if (count > maxCount)
					maxCount = count;
			}

			Console.Write("Output: ");
			for (int i = 0; i < arr.Length; i++)
			{
				int count = 0;

				for (int j = 0; j < arr.Length; j++)
				{
					if (arr[i] == arr[j])
						count++;
				}


				bool printed = false;
				for (int k = 0; k < i; k++)
				{
					if (arr[i] == arr[k])
					{
						printed = true;
						break;
					}
				}

				if (count == maxCount && !printed)
					Console.Write(arr[i] + " ");
			}

		}
	}
}
