namespace FirstNonRepeatingChar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string:");
            string str = Console.ReadLine();
            char ans='\0';
            
            for(int i = 0; i < str.Length; i++)
            {
				int count = 0;
				for (int j = 0; j < str.Length; j++)
                {
                    if (str[i] == str[j]) count++;
                }
                if(count==1)
                {
                    ans = str[i];
                    break;
                    
                }
            }
            if (ans == '\0')
            {
                Console.WriteLine("No non repeating char");
            }
            else
            {
                Console.WriteLine("First non repeatoing char: " + ans);
            }
        }
    }
}
