namespace PalindromeCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string:");
            string str = Console.ReadLine();

            bool isPalindrome = true;
            int st = 0, end = str.Length - 1;
            while (st < end)
            {
                if (str[st] == str[end])
                {
                    st++;end--;
                }
                else
                {
                    isPalindrome = false;
                    break;
                }

            }
            if (isPalindrome)
            {
				Console.WriteLine(str+ " is palindrome");
			}
            else
            {
				Console.WriteLine(str + " is not palindrome");
			}
            
        }
    }
}
