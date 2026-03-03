using System.Text.RegularExpressions;

namespace VAT
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.WriteLine(CalculateVAT("D", 100));  // 6
			Console.WriteLine(CalculateVAT("M", 200));  // 10
			Console.WriteLine(CalculateVAT("V", 100));  // 12
			Console.WriteLine(CalculateVAT("C", 100));  // 6.25
		}

		static double CalculateVAT(string product, int amount)
		{
			string pattern = @"^[MVCD]$";

			if (!Regex.IsMatch(product, pattern))
				return -1;   // Invalid product

			double vatPercent = 0;

			switch (product)
			{
				case "M":
					vatPercent = 5;
					break;
				case "V":
					vatPercent = 12;
					break;
				case "C":
					vatPercent = 6.25;
					break;
				case "D":
					vatPercent = 6;
					break;
			}

			return (amount * vatPercent) / 100;
		}
	}
}
