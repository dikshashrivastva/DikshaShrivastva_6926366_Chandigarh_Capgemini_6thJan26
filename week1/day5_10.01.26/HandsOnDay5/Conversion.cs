using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay5
{
    internal class Conversion
    {
        static void Main(string[] args)
		{
			//            .Fahrenheit to Celsius conversion
			//BR -
			//1) if the number is negative, store - 1 to output

			Console.Write("Enter temp in Fahrenheit: ");
			double fahrenheit = Convert.ToDouble(Console.ReadLine());

			double celsius = (5.0 / 9) * (fahrenheit - 32);

			Console.WriteLine("Temp in Celsius: " + celsius);

		}
	}
}
