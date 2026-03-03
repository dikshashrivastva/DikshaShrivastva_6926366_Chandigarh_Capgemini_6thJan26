using System.Globalization;
using System.Text.RegularExpressions;

namespace DiffrenceOfDate
{
    internal class Program
    {
        static void Main(string[] args)
		{
			string input1 = "12/02/2014";
			string input2 = "27/02/2014";

			Console.WriteLine(DateDifference(input1, input2));
		}

		static string DateDifference(string date1, string date2)
		{
			string pattern = @"^\d{2}/\d{2}/\d{4}$";

		
			if (!Regex.IsMatch(date1, pattern) || !Regex.IsMatch(date2, pattern))
				return "Invalid Date Format";

			
			DateTime d1 = DateTime.ParseExact(date1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
			DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);

			
			int days = Math.Abs((d2 - d1).Days);

			return days + " days";
		}
	}
}
