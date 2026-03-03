using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FindFactor
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//			Bela teaches her daughter to find the factors of a given number. When she
			//provides a number to her daughter, she should tell the factors of that number.
			//Help her to do this, by writing a program. Write a class FindFactor.java and
			//write the main method in it.
			//Note :
			//If the input provided is negative, ignore the sign and provide the output.If
			//the input is zero
			//If the input is zero the output should be “No Factors”.
			//Sample Input 1:
			//54
			//Sample Output 1:
			//1, 2, 3, 6, 9, 18, 27, 54

			int num = Convert.ToInt32(Console.ReadLine());
			if (num < 0) num = -num;
			if (num == 0) Console.WriteLine("No factors");

			List<int> ans = new List<int>();

			for(int i = 1; i <= num; i++)
			{
				if (num % i == 0) ans.Add(i);
			}
			foreach(int val in ans)
			{
				Console.WriteLine(val);
			}
			
		}
	}
}
