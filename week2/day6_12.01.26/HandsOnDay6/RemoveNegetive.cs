using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay6
{
    internal class RemoveNegetive
    {
		static void Main()
		{
			int[] arr = { 20, -10, 4, 78 };
			int[] temp = new int[arr.Length];
			int count = 0;

			
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] >= 0)
				{
					temp[count] = arr[i];
					count++;
				}
			}

			
			Array.Sort(temp, 0, count);

			
			Console.Write("Output: ");
			for (int i = 0; i < count; i++)
			{
				Console.Write(temp[i] + " ");
			}
		}
	}
}
