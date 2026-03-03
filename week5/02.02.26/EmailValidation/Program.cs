using System.Text.RegularExpressions;

namespace EmailValidation
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.WriteLine(ValidateEmail("user.name@example.com")); // Valid
			Console.WriteLine(ValidateEmail("user@domain"));           // Invalid
			Console.WriteLine(ValidateEmail("user@.com"));             // Invalid
			Console.WriteLine(ValidateEmail("user#mail.com"));         // Invalid
		}

		static string ValidateEmail(string email)
		{
			string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

			if (Regex.IsMatch(email, pattern))
				return "Valid";
			else
				return "Invalid";
		}
	}
}
