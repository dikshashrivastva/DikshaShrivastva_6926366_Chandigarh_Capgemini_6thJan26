using System.Xml.Linq;

namespace SearchAndRemove
{
    internal class Program
    {
        static void Main(string[] args)
		{
            //            .     Search and remove the element from the given input array and then sort the remaining array

            //		   elements, store that in to the output array. Consider input1 is array elements, input2 is array size
            //		   and input3 is the search element.

            //Eg:
            //	Input1 = { 54, 26, 78, 32, 55}
            //			Input2 = 5
            //	Input3 = 78

            //	Ouput1 = { 26, 32, 54, 55}

            //			Business Rules:
            //i)	If any of the array element(input1) is negative store - 1 into the output array.
            //ii)	If the array size(input2) is negative store - 2 into the output array.
            //iii)	If the search element(input3) is not present in the array(input1) store - 3 into the output array.

            int[] arr = { 54, 26, 78, 32, 55 };
            int[] result = new int[arr.Length-1];
            int element;
            Console.WriteLine("Enter the element to be searched: ");
            element = int.Parse(Console.ReadLine());
            int j = 0;
            bool found = false;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element && !found)
                {
                    found = true;
                    continue;
                }
                if (j < result.Length)
                {
                    result[j++] = arr[i];
                }
              
            }
            if (!found) Console.WriteLine("Element not found");
            Array.Sort(result);
           
			Console.WriteLine("Output= ");
            foreach(int val in result)
            {
                Console.WriteLine(val);
            }
        }
    }
}
