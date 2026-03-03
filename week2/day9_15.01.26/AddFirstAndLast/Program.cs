namespace AddFirstAndLast
{
    internal class Program
    {
        static void Main(string[] args)
        {


			int[] arr = { 1,2,3,4};
			int[] arr2 = { 4,3,2,1 };
			int[] output = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				output[i] = arr[i] + arr2[arr.Length - i - 1];
			}
			foreach (int val in output)
			{
				Console.WriteLine(val);
			}
			
        }
    }
}
