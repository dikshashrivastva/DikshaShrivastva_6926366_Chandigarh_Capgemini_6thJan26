using System.ComponentModel;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Equation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//			4.Problem Statement –
			//Write a function to solve the following equation a3 + a2b + 2a2b + 2ab2 +
			//ab2 + b3.
			//Write a program to accept three values in order of a, b and c and get the result
			//of the above equation

			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());
			int c = int.Parse(Console.ReadLine());

			Console.WriteLine("a3 + a2b + 2a2b + 2ab2 +ab2 + b3= " + (a*a*a+ a*a*b + 2*a*a*b+2*a*b*b+a*b*b+b*b*b));
		}
	}
}
