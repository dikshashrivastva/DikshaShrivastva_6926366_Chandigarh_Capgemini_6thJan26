using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay3
{
    internal class KeyPress
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Ques 3:");
			string key;
			Console.Write("Enter a key: ");
			key = Console.ReadLine();
			char k = Convert.ToChar(key);
			if (k >= '0' && k <= '9')
			{
				Console.WriteLine(k + "\n");
			}
			else
			{
				Console.WriteLine("Not allowed!\n");
			}
		}
    }
}
