using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay6
{
    internal class MultipleOfFive
    {
		static void Main()
		{
			int[] arr = { 10, 12, 5, 7, 20, 3 };

			int sum = 0;
			int count = 0;

			//sum of multiples of 5
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] % 5 == 0)
				{
					sum += arr[i];
					count++;
				}
			}

			// avg
			if (count > 0)
			{
				double avg = (double)sum / count;
				Console.WriteLine("Sum = " + sum);
				Console.WriteLine("Average = " + avg);
			}
			else
			{
				Console.WriteLine("No multiples of 5 found");
			}
		}
	}
}
