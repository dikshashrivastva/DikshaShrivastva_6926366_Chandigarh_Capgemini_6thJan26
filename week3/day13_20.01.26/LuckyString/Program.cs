namespace LuckyString
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int n = int.Parse(Console.ReadLine());
			string str = Console.ReadLine();

			if (n > str.Length)
			{
				Console.WriteLine("Invalid");
				return;
			}

			int required = n / 2;

			for (int i = 0; i <= str.Length - n; i++)
			{
				string sub = str.Substring(i, n);

				// Check only P, S, G
				bool validChars = true;
				foreach (char c in sub)
				{
					if (c != 'P' && c != 'S' && c != 'G')
					{
						validChars = false;
						break;
					}
				}

				if (!validChars)
					continue;

				// Check consecutive characters
				int count = 1;
				int maxCount = 1;

				for (int j = 1; j < sub.Length; j++)
				{
					if (sub[j] == sub[j - 1])
						count++;
					else
						count = 1;

					maxCount = Math.Max(maxCount, count);
				}

				if (maxCount >= required)
				{
					Console.WriteLine("Yes");
					return;
				}
			}

			Console.WriteLine("No");
		}
    }
}
