namespace RomanToDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a roman  number");
            string str = Console.ReadLine();
            int result = UserProgramCode.conversion(str);
            Console.WriteLine(str+" in Decimal number= " + result);
        }
    }
}
