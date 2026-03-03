namespace DecimalToBinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
//			9. decimal to binary.
//Hint: Output is an array

//If input1 is negative,store - 1

            int decNum;
            int[] output = new int[5];
            Console.WriteLine("Enter a number:");
            decNum = int.Parse(Console.ReadLine());
            int i = output.Length-1;
            while (decNum > 0)
            {
                output[i--] = decNum % 2;
                decNum /= 2;

            }
			Console.WriteLine("Binary Number=");
            foreach(int val in output)
            {
                Console.Write(val + " ");
            }
        }
    }
}
