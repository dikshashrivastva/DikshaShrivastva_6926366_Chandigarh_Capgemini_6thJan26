using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SumOfFactors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //			Find the sum of factors from a given number upto ‘N’ like input1:3,input2: 15
            //output1 = 3 + 6 + 9 + 12 + 15 = 45)

            //(Business rule: Store - 1 in output variable if ‘input1’ is negative and - 2 in output variable if ‘input2’ is
            //> 32627)

            int num,lim,sum = 0;
            Console.WriteLine("Enter a number:");
            num = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the limit:");
            lim= int.Parse(Console.ReadLine());

            int i = num;
            while (i <= lim)
            {
                sum += i;
                i = i + num;
            }

            Console.WriteLine("Sum of Factors=" + sum);
        }
    }
}
