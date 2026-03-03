using System.Text.RegularExpressions;

namespace LocationCode
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.WriteLine(UpdateLocation("CAP-HYD-1234", "BAN"));
			// CAP-BAN-1234
		}

		static string UpdateLocation(string invoice, string newLocation)
		{
			string pattern = @"^(CAP-)([A-Z]{3})(-\d+)$";

			Match match = Regex.Match(invoice, pattern);

			if (match.Success)
			{
				string prefix = match.Groups[1].Value;   
				string numberPart = match.Groups[3].Value; 

				return prefix + newLocation + numberPart;
			}
			else
			{
				return "Invalid Invoice Format";
			}
		}
	}
}
