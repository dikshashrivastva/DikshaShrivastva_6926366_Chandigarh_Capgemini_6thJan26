using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandsOnDay7
{
    internal class ElementSearch
    {
        static void Main(string[] args)
		{
            //            .         search for an element in an array
            //Business Rule:1.if the element is found, store 1 into the output variable,
            //4.if the array contanis -ve elements store 1 - into the output variable,
            //3.if the array size is -ve, store - 2 into the array,
            //		4.if the element not found, store - 3 into the array,

            int[] arr = { 11, 2, 3, 99, 32, 98 };
            int tar = 21;
            bool ifFound = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == tar)
                {
                    Console.WriteLine(tar + " Found at " + i);
                    ifFound = true;
                    break;
                }
            }
            if (!ifFound)
            {
                Console.WriteLine("Not found");
            }


        }
	}
}
