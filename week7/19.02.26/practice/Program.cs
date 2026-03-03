using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;

namespace practice
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//			Capgemini in its online written test have a coding question, wherein the
			//students are given a string with multiple characters that are repeated
			//consecutively.You’re supposed to reduce the size of this string using
			//mathematical logic given as in the example below:
			//		Input:aabbbbeeeeffggg
			//			
			//	    Output:a2b4e4f2g3
			string str = "aabbbeeeeffggg";
			string res = "";
			int count = 1;
			for (int i = 0; i < str.Length-1; i++)
			{
				
				if (str[i] == str[i + 1]) count++;
				else
				{
					res += str[i] + count.ToString();
					count = 1;
				}
				
			}
			res += str[str.Length - 1] + count.ToString();


			Console.WriteLine(res);

		}
	}
}
