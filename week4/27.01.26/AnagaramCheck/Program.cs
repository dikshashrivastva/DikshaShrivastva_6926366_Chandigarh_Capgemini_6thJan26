namespace AnagaramCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String 1: ");
            string str1 = Console.ReadLine();
			Console.Write("Enter String 2: ");
			string str2 = Console.ReadLine();

            char[] arr1 = str1.ToCharArray();
            Array.Sort(arr1);

			char[] arr2 = str1.ToCharArray();
			Array.Sort(arr2);

            string s1 = new string(arr1);
            string s2= new string(arr2);
            if (s1.Equals(s2))
            {
                Console.WriteLine("Strings are anagram");
            }
            else
            {
                Console.WriteLine("strings are not anagram ");
            }
        }
    }
}
