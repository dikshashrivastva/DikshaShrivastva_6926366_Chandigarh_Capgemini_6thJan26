using System;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PasswordOfPlots
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //			10.a person owns some plots plot numbers are even and odd numbers, he want to keep average of 
            //“sum of odd numbers and sum of even  numbers “ as his password,,..What is his password
            //Input is an array and output is an integer

            //Business rule if any number in array is negative store - 1 in output1

            //Business rule if array size is negative store - 2 in output1

            int[] arr = { 1, 65, 32, 99, 73 };
            int oddSum = 0;
            int evenSum = 0;
            foreach(int val in arr)
            {
                if (val % 2 == 0)
                {
                    evenSum += val;
                }
                else
                {
                    oddSum += val;
                }
            }
            int pass = oddSum + evenSum / 2;

			Console.WriteLine("Password=" + pass);
        }
    }
}
