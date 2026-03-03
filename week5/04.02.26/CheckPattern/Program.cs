using System.Text.RegularExpressions;

namespace CheckPattern
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.WriteLine(CheckPattern("hi-how-are-you-Dear DikshaShrivastva")); // Valid
			Console.WriteLine(CheckPattern("hi-how-are-you-Dear Aryan")); // Invalid
		}

		static string CheckPattern(string input)
		{
			string pattern = @"^hi-how-are-you-Dear\s[A-Za-z]{16,}$";

			if (Regex.IsMatch(input, pattern))
				return "Valid";
			else
				return "Invalid";
		}
	}
}
