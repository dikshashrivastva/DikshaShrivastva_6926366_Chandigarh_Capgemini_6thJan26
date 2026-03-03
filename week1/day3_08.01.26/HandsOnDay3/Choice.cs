using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay3
{
    internal class Choice
    {
        static void Main(string[] args)
        {
			string ch;
			Console.Write("Enter your ans:");
			ch = Console.ReadLine();
			char choice = Convert.ToChar(ch);
			switch (choice)
			{
				case 'a':
					Console.WriteLine("Incorrect choice!\n");
					break;
				case 'b':
					Console.WriteLine("Correct choice!\n");
					break;
				case 'c':
					Console.WriteLine("Incorrect Choice!\n");
					break;
				case 'd':
					Console.WriteLine("Incorrect Choice!\n");
					break;
				default:
					Console.WriteLine("Invalid Choice!\n");
					break;
			}
    }
}
