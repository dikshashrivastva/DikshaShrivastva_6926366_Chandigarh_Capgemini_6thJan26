using System.Text.RegularExpressions;

namespace DateExtract
{
    internal class Program
    {
        static void Main(string[] args)
		{
			string input = "Our trip is on 15/02/2026 and return on 25/02/2026.";

			ExtractDates(input);
		}

		static void ExtractDates(string text)
		{
			string pattern = @"\b(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}\b";

			MatchCollection matches = Regex.Matches(text, pattern);

			foreach (Match match in matches)
			{
				Console.WriteLine(match.Value);
			}
		}
	}
}
