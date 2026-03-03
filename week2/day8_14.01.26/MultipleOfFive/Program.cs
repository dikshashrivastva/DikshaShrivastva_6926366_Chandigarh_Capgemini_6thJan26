namespace MultipleOfFive
{
    internal class Program
    {
        static void Main(string[] args)
		{
			//Find the average of multiples of five up to N natural number. Consider input1 is the N value.

			//Eg:
			//	Input1 = 15
			//	Output1 = 10

			//Business Rules:
			//i)	If the input1 is negative store - 1 in to the output variable.
			//ii)	If input1 is greater than 500 store - 2 in to the output variable.

			int limit, sum = 0;
			int output = 0;

			Console.WriteLine("Enter a limit: ");
			limit = int.Parse(Console.ReadLine());

			if (limit < 0) output = -1;
			else if (limit > 500) output = -2;

				for (int i = 1; i <= limit; i++)
				{
					if (i % 5 == 0) sum += i;
				}
			float avg = sum / (limit / 5);

			Console.WriteLine("Avg = " + avg);
			Console.WriteLine("Output= " + output);

        }
    }
}
