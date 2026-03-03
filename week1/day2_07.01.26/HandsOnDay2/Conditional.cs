using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay2
{
    internal class Conditional
    {
		static void Main()
		{
			int i;
			int[] arr = new int[5];
			arr[0] = 10;
			arr[1] = 20;
			arr[2] = 30;
			arr[3] = 40;
			for (i = 0; i < 5; i++)
				Console.WriteLine(arr[i] + " ");
			Console.WriteLine();

			foreach (int x in arr)
			{
				Console.Write(x + " ");
			}
			Console.ReadLine();

		}
	}
}
