using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay6
{
    internal class RemoveRepeated
    {
		static void Main(string[] args)
		{
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
