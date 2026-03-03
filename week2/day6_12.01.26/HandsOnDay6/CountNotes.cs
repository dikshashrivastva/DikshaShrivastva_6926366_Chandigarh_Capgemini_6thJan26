using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay6
{
    internal class CountNotes
    {
		static void Main()
		{
			int amount = 689;
			int output1 = 0;

			int count500 = amount / 500;
			amount = amount % 500;

			int count100 = amount / 100;
			amount = amount % 100;

			int count50 = amount / 50;
			amount = amount % 50;

			int count10 = amount / 10;
			amount = amount % 10;

			int count1 = amount;

			output1 = count500 + count100 + count50 + count10 + count1;

			Console.WriteLine("500 - " + count500);
			Console.WriteLine("100 - " + count100);
			Console.WriteLine("50  - " + count50);
			Console.WriteLine("10  - " + count10);
			Console.WriteLine("1   - " + count1);

			Console.WriteLine("Output1 = " + output1);
		}
	}
}
