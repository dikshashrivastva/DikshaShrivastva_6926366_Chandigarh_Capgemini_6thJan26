using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay3
{
    internal class GreatestNo
    {
        static void Main(string[] args)
        {
			int x, y, z;
			Console.Write("enter x: ");
			x = int.Parse(Console.ReadLine());
			Console.Write("enter y: ");
			y = int.Parse(Console.ReadLine());
			Console.Write("enter z: ");
			z = int.Parse(Console.ReadLine());

			if (x > y && x > z)
			{
				Console.WriteLine(x + " is greatest\n");
			}
			else if (y > x && y > z)
			{
				Console.WriteLine(y + " is greatest\n");
			}
			else
			{
				Console.WriteLine(z + " is greatest\n");
			}
		}
    }
}
