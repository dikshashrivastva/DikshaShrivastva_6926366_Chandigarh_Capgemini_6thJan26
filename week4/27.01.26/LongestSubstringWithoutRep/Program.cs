using System.Runtime.CompilerServices;

namespace LongestSubstringWithoutRep
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Enter a string:");
			string str = Console.ReadLine();

			int maxLen = 0;

			for (int i = 0; i < str.Length; i++)
			{
				string current = "";

				for (int j = i; j < str.Length; j++)
				{
					if (current.Contains(str[j]))
						break;

					current += str[j];
				}

				if (current.Length > maxLen)
					maxLen = current.Length;
			}

			Console.WriteLine("Length of longest substring: " + maxLen);

		}
	}
}
