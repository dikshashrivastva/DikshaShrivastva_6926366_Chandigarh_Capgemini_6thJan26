namespace MaxDeletion
{
    internal class Program
    {
		public static int MaxConsecutivePairDeletions(string s)
		{
			if (string.IsNullOrEmpty(s))
				return 0;

			int count = 0;
			int i = 0;

			while (i < s.Length - 1)
			{
				if (s[i] == s[i + 1])
				{
					count++;
					i += 2;
				}
				else
				{
					i++;
				}
			}

			return count;
		}

		public static void Main()
		{
			string s = "aabbcc";
			Console.WriteLine(MaxConsecutivePairDeletions(s));
		}
	}
}
