namespace MaxMinProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxEl = int.MinValue;
            int minEl = int.MaxValue;
            int[] arr = { 2, 3, 6, 8, 4 };
            for(int i = 0; i < arr.Length; i++)
            {
                maxEl=Math.Max(maxEl, arr[i]);
                minEl=Math.Min(minEl, arr[i]);
            }

            Console.WriteLine("Product=" + maxEl*minEl);
        }
    }
}
