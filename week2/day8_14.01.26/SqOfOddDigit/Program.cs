namespace SqOfOddDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //			2.sum of squres of odd digits in a number.
            //Business Rule:if input1 < 0, store - 1 into the output variable

            int num,sum=0;
            Console.WriteLine("Enter a number: ");
            num=int.Parse(Console.ReadLine());

            while (num > 0)
            {
                int dig = num % 10;
                if (dig % 2 != 0)
                {
                    sum += dig * dig;
                }
                num = num / 10;
            }
			Console.WriteLine("Sum of Square of Odd Digits= " +sum);
        }
    }
}
