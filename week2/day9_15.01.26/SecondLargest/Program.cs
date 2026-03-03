namespace SecondLargest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 1, 9 };

			int largest = int.MinValue;
			int secondLargest = int.MinValue;

			for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > largest)
                {
                    secondLargest = largest;
                    largest = arr[i];
                }
                else if (arr[i]>secondLargest && arr[i] != largest)
                {
                    secondLargest = arr[i];
                }
            }

			Console.WriteLine("Second Largest=" + secondLargest);
        }
    }
}
