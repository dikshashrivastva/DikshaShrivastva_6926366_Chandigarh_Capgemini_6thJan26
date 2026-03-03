using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay3
{
    internal class Pattern
    {
        static void Main(string[] args)
        {
			Console.WriteLine("enter n:");
			int n = int.Parse(Console.ReadLine());
			for (int i = n; i > 0; i--)
			{
				for (int j = 0; j < i; j++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}
		}
    }
}
