namespace Is_IsNot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a str:");
            string str = Console.ReadLine();

            string result =UserProgramCode.negativeString(str);
            Console.WriteLine(result);
        }
    }
}
