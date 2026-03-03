namespace StringCompress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string str = Console.ReadLine();
            string result = "";
            int i=0;

            while (i < str.Length)
            {
                char current = str[i];
                int count= 1;
                while(i+1<str.Length && str[i] == str[i + 1])
                {
                    count++;
                    i++;
                }

                result += current + count.ToString();
                i++;
            }

            Console.WriteLine(result);
        }
    }
}
