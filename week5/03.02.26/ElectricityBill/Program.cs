using System.Text.RegularExpressions;

namespace ElectricityBill
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.WriteLine(CalculateBill("AAAAA12345", "AAAAA23456", 4));
			
		}

		static int CalculateBill(string input1, string input2, int rate)
		{
			
			string pattern = @"\d+";

			string reading1 = Regex.Match(input1, pattern).Value;
			string reading2 = Regex.Match(input2, pattern).Value;

			
			int meter1 = int.Parse(reading1);
			int meter2 = int.Parse(reading2);

			
			int units = Math.Abs(meter2 - meter1);

			
			int bill = units * rate;

			return bill;
		}
	}
}
