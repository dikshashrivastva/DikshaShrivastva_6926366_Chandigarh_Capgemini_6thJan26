using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay3
{
    internal class Grades
    {
        static void Main(string[] args)
        {
			int marks;
			Console.Write("enter marks:");
			marks = int.Parse(Console.ReadLine());
			if (marks >= 90)
			{
				Console.WriteLine("Congrats! You got A.\n");
			}
			else if (marks >= 80 && marks < 90)
			{
				Console.WriteLine("Congrats! You got B.\n");
			}
			else if (marks >= 70 && marks < 80)
			{
				Console.WriteLine("Congrats! You got C.\n");
			}
			else
			{
				Console.WriteLine("Sorry! You failed\n");
			}
		}
    }
}
