using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay7
{
    internal class RemoveNegative
    {
        static void Main(string[] args)
        {
            //			2.Remove the negative elements from array and sort the remaining elements
            //Business Rule:if array size is negative store - 1 into the array.
            
            int arrSize;
            Console.WriteLine("Enter array size: ");
            arrSize = int.Parse(Console.ReadLine());
			int[] arr = new int[arrSize];

            Console.WriteLine("Enter array element:");
            for(int i = 0; i < arrSize; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            //sort element
            Array.Sort(arr);

            //negetive element remove
            int index = 0;
            foreach(int val in arr)
            {
                if (val < 0)
                {
                    index++;
                }
            }
            int[] output1 = new int[arrSize - index];
			int j = 0;
			for (int i = index; i < arrSize; i++)
			{
				output1[j] = arr[i];
				j++;
			}

            Console.WriteLine("Output: ");
			foreach (int val in output1)
            {
                Console.WriteLine(val);
            }

		}
	}
}
