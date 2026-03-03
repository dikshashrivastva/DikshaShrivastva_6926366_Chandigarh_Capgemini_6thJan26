namespace TotalMarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int X = int.Parse(Console.ReadLine());
			int Y = int.Parse(Console.ReadLine());
			int N1 = int.Parse(Console.ReadLine());
			int N2 = int.Parse(Console.ReadLine());
			int M = int.Parse(Console.ReadLine());

			bool isValid = false;
			int type1Marks = 0;
			int type2Marks = 0;

			// Try maximum Type 1 questions first
			for (int i = N1; i >= 0; i--)
			{
				int remainingMarks = M - (i * X);

				if (remainingMarks < 0)
					continue;

				if (remainingMarks % Y == 0)
				{
					int j = remainingMarks / Y;

					if (j >= 0 && j <= N2)
					{
						isValid = true;
						type1Marks = i * X;
						type2Marks = j * Y;
						break;
					}
				}
			}

			if (isValid)
			{
				Console.WriteLine("Valid");
				Console.WriteLine(type1Marks + " " + type2Marks);
			}
			else
			{
				Console.WriteLine("Invalid");
			}
		}
	}
    
}
