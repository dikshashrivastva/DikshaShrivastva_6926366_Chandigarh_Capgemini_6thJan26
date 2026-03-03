namespace PerfectSquare
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.Write("Enter a positive integer: ");
			int number = Convert.ToInt32(Console.ReadLine());

			if (number <= 0)
			{
				Console.WriteLine("Please enter a positive integer.");
				return;
			}

			double root = Math.Sqrt(number);

			int lower = (int)Math.Floor(root);
			int upper = (int)Math.Ceiling(root);

			int lowerSquare = lower * lower;
			int upperSquare = upper * upper;

			int closest;

			if (number - lowerSquare <= upperSquare - number)
				closest = lowerSquare;
			else
				closest = upperSquare;

			Console.WriteLine("Closest perfect square = " + closest);
		}
	}
}
