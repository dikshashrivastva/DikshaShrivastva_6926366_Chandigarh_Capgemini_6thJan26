using System.Text.RegularExpressions;

namespace HashtagExtract
{
    internal class Program
    {
        static void Main(string[] args)
		{
			string input = "Loving the vibes! #Travel #Adventure #2026Goals";

			ExtractHashtags(input);
		}

		static void ExtractHashtags(string text)
		{
			string pattern = @"#\w+";

			MatchCollection matches = Regex.Matches(text, pattern);

			foreach (Match match in matches)
			{
				Console.WriteLine(match.Value);
			}
		}
	}
}
