namespace ValidParantheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            Stack<char> st = new Stack<char>();
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{' || str[i] == '[' || str[i] == '(')
                {
                    st.Push(str[i]);
                }
                else if (str[i] == '}' && st.Peek() == '{') st.Pop();
				else if (str[i] == ']' && st.Peek() == '[') st.Pop();
				else if (str[i] == ')' && st.Peek() == '(') st.Pop();
			}
            if (st.Count == 0) Console.WriteLine("Valid");

            else Console.WriteLine("Invalid");
        }
    }
}
