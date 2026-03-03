namespace DigitSum
{
    internal class Program
    {
        static void Main(string[] args)
		{
			Console.Write("Enter a positive integer: ");
			long number = Convert.ToInt64(Console.ReadLine());

			if (number <= 0)
			{
				Console.WriteLine("Please enter a positive integer.");
				return;
			}

			int sum = 0;

			while (number > 0)
			{
				sum += (int)(number % 10);
				number /= 10;
			}

			Console.WriteLine("Sum of digits = " + sum);
		}
	}
}
