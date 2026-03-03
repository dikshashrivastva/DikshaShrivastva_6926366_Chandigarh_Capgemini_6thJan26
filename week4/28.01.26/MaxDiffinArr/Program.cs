namespace MaxDiffinArr
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Enter the number of elements in array");
			int n = Convert.ToInt32(Console.ReadLine());
			int[] arr = new int[n];

			for (int i = 0; i < n; i++)
			{
				arr[i] = Convert.ToInt32(Console.ReadLine());
			}

			int result = UserProgramCode.diffIntArray(arr);
			Console.WriteLine(result);
		}
    }
}
