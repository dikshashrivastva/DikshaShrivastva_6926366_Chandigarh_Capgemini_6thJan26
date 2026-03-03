namespace CountOFElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the element:");
            
            string[] str=new string[n];
            for(int i = 0; i < n; i++)
            {
                str[i] = Console.ReadLine();
            }

			Console.WriteLine("Enter a char: ");
            char ch = Convert.ToChar(Console.ReadLine());
            int result = UserProgramCode.GetCount(str, ch);
            if (result == -1)
            {
                Console.WriteLine("No elements Found");
            }
            else if (result == -2)
            {
                Console.WriteLine(" Only alphabets should be given ");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
