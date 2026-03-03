namespace InsertAtPos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 9, 3, 2, 4, 1, 6 };
            Array.Sort(arr);
            int ele;
            Console.WriteLine("Enter the element:");
            ele = int.Parse(Console.ReadLine());
            int[] output = new int[arr.Length + 1];

            int i = 0, j = 0;
            while(i<arr.Length && arr[i] < ele)
            {
                output[j++] = arr[i++];
            }
            output[j++] = ele;

            while (i < arr.Length)
            {
                output[j++] = arr[i++];
            }

            Console.WriteLine("Output=");
            foreach(int val in output)
            {
                Console.WriteLine(val);
            }
        }
    }
}
