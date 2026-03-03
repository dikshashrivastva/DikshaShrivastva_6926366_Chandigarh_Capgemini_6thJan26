using System.ComponentModel;
using System.Timers;

namespace spiralMatrix
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//You’re given an array of integers, print the number of times each integer has
			//occurred in the array.
			//Example
			//Input :
			//10
			//1 2 3 3 4 1 4 5 1 2
			//Output:
			//1 occurs 3 times
			//2 occurs 2 times
			//3 occurs 2 times
			//4 occurs 2 times
			//5 occurs 1 times

			int n = int.Parse(Console.ReadLine());
			int[] array = new int[n];
			for(int i = 0; i < n; i++)
			{
				array[i] = int.Parse(Console.ReadLine());
			}

			Array.Sort(array);
			int count = 1;
			for (int i = 1; i < n; i++)
			{
				if (array[i] == array[i - 1]) count++;
				else
				{
					Console.WriteLine(array[i - 1] + " occurs " + count + " times");
					count = 1;
				}
			}

			Console.WriteLine(array[array.Length - 1] + " occurs " + count + " times");
		}
	}
}
