using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HandsOnDay4
{
    internal class ArrSort
    {
        static void Main(string[] args) {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 2, 1, 4, 3, 6 };
            int[] output = new int[arr1.Length];

            if (arr1.Length < 0 || arr2.Length < 0)
            {
                output[0] = -2;
            }
            else
            {
                bool negetive = false;

                for(int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i]<0 || arr2[i] < 0)
                    {
                        negetive = true;
                        break;
                    } 
                }
                if (negetive) output[0] = -1;
                else
                {
                    Array.Sort(arr1);
                    Array.Sort(arr2);
                    Array.Reverse(arr2);
                    int st = 0, end = arr2.Length - 1;
                    for(int i = 0; i < arr2.Length; i++)
                    {
                        output[i] = arr1[st] * arr2[end];
                        st++;end--;
                    }
                }
                //output Array
                foreach(int val in output)
                {
                    Console.WriteLine(val);
                }
            }
        }
    }
}
