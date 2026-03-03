using System.Text.RegularExpressions;

namespace CheckPass
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.WriteLine(CheckPassword("Strong@123"));  // Strong
			Console.WriteLine(CheckPassword("weakpass"));    // Weak
			Console.WriteLine(CheckPassword("Strong123"));   // Weak
			Console.WriteLine(CheckPassword("STRONG@123"));  // Weak
		}

		static string CheckPassword(string password)
		{
			string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";

			if (Regex.IsMatch(password, pattern))
				return "Strong";
			else
				return "Weak";
		}
	}
}
