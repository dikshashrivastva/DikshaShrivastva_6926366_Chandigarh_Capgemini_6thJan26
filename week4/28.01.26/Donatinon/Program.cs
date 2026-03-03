namespace Donatinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int n = Convert.ToInt32(Console.ReadLine());
			string[] arr = new string[n];

			for (int i = 0; i < n; i++)
			{
				arr[i] = Console.ReadLine();
			}

			int locationCode = Convert.ToInt32(Console.ReadLine());

			int result = UserProgramCode.getDonation(arr, locationCode);
			Console.WriteLine(result);
		}
    }
}
