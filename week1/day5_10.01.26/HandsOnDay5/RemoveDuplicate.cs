using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay5
{
    internal class RemoveDuplicate
    {
        static void Main(string[] args)
        {
			//			16.Remove the duplicate elements store it into the output array.Input2 is size of the array
			//	Input1[]= { 1, 2, 2, 3, 3 }
			//	Input2[]= 5;
			//			Outp ut[] = { 1, 2, 3 }
			//BR
			//	1.Store - 1 to the first position of the output array if any input array elements contains negative
			//			   value
			//2.Store - 2  to the first position of the output array if array size is negative

			int[] arr = { 1, 2, 2, 3, 3 };

			int[] output = new int[arr.Length];
			int index = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				bool isDuplicate = false;

				for (int j = 0; j < index; j++)
				{
					if (arr[i] == output[j])
					{
						isDuplicate = true;
						break;
					}
				}

				if (!isDuplicate)
				{
					output[index] = arr[i];
					index++;
				}
			}

			Console.Write("Output = ");
			for (int i = 0; i < index; i++)
			{
				Console.Write(output[i] + " ");
			}
		}
	}
}
