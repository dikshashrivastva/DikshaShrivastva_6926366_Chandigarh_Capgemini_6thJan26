using System.Text.RegularExpressions;

namespace InvoiceNum
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.WriteLine(UpdateInvoice("CAP-123", 7));   
			Console.WriteLine(UpdateInvoice("CAP-999", 1));   
		}

		static string UpdateInvoice(string invoice, int increment)
		{
			string pattern = @"^(CAP-)(\d+)$";

			Match match = Regex.Match(invoice, pattern);

			if (match.Success)
			{
				string prefix = match.Groups[1].Value;   
				int number = int.Parse(match.Groups[2].Value);

				int newNumber = number + increment;

				return prefix + newNumber;
			}
			else
			{
				return "Invalid Invoice Format";
			}
		}
	}
}
