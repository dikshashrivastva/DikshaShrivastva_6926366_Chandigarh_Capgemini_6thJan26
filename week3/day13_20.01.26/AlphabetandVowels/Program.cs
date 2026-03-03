using System.Text;

namespace AlphabetandVowels
{
    internal class Program
    {
        static void Main(string[] args)
        {
			string first = Console.ReadLine();
			string second = Console.ReadLine();

			// Store characters of second string (case-insensitive)
			HashSet<char> secondSet = new HashSet<char>();
			foreach (char c in second)
				secondSet.Add(char.ToLower(c));

			StringBuilder filtered = new StringBuilder();

			// Step 1: Remove common consonants
			foreach (char c in first)
			{
				char lower = char.ToLower(c);

				if (IsVowel(lower) || !secondSet.Contains(lower))
				{
					filtered.Append(c);
				}
			}

			// Step 2: Remove consecutive duplicates
			StringBuilder result = new StringBuilder();

			for (int i = 0; i < filtered.Length; i++)
			{
				if (i == 0 || filtered[i] != filtered[i - 1])
				{
					result.Append(filtered[i]);
				}
			}

			Console.WriteLine(result.ToString());
		}

		static bool IsVowel(char c)
		{
			return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
		}
	}
    
}
