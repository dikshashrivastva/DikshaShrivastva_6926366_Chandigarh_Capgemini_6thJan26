namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Originalnum;
            Console.WriteLine("Enter a number:");
            Originalnum = int.Parse(Console.ReadLine());
            int num = Originalnum;
            int rev = 0;
            while (num > 0)
            {
                int digit = num % 10;
                rev = rev * 10 + digit;
                num /= 10;
            }
            if (rev == Originalnum)
            {
                Console.WriteLine("Number is Plaindrome");
            }
            else
            {
                Console.WriteLine("not palindrome");
            }
        }
    }
}
