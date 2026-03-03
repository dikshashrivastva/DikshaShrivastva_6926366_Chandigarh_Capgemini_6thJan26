using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace MaxMarks
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Sample Input 1:
			//Enter no of semester:3
			//Enter no of subjects in 1 semester: 3
			//Enter no of subjects in 2 semester: 4
			//Enter no of subjects in 3 semester: 2
			//Marks obtained in semester 1:506070
			//Marks obtained in semester 2:90987667
			//Marks obtained in semester 3:8976
			//Sample Output 1:
			//Maximum mark in 1 semester: 70
			//Maximum mark in 2 semester: 98
			//Maximum mark in 3 semester: 89

			Console.WriteLine("Enter no of semester:");
			int sem = int.Parse(Console.ReadLine());

			int[] sub = new int[sem];
			for(int i = 0; i < sem; i++)
			{
				Console.WriteLine($"Enter no of subjects in {i+1} semester:");
				sub[i] = int.Parse(Console.ReadLine());
			}

			for(int i = 0; i < sem; i++)
			{
				Console.WriteLine($"Marks obtained in semester{i + 1} :");
				string marksStr = Console.ReadLine();

				int maxMarks = int.MinValue;
				for(int j = 0; j < sub[i] * 2; j += 2)
				{
					int marks = Convert.ToInt32(marksStr.Substring(j, 2));
					if (marks > maxMarks) maxMarks = marks;

					
				}
				Console.WriteLine($"Maximum mark in {i + 1} semester: {maxMarks}");
				Console.WriteLine();
			}
			
		}
	}
}
