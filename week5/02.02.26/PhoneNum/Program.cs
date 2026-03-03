using System.Text.RegularExpressions;

namespace PhoneNum
{
    internal class Program
    {
        static void Main(string[] args)
		{
			string input = "Call me at 9876543210 or 9123456789.";

			ExtractPhoneNumbers(input);
		}

		static void ExtractPhoneNumbers(string text)
		{
			string pattern = @"\b\d{10}\b";

			MatchCollection matches = Regex.Matches(text, pattern);

			foreach (Match match in matches)
			{
				Console.WriteLine(match.Value);
			}
		}

	}
}
