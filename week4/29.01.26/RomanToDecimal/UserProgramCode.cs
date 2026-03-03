using System;
using System.Collections.Generic;
using System.Text;

namespace RomanToDecimal
{
    internal class UserProgramCode
    {
        public static int conversion(string str)
        {
            str = str.ToUpper();
            int num = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'I') num += 1;
                else if (str[i] == 'V') num += 5;
                else if (str[i] == 'X') num += 10;
                else if (str[i] == 'L') num += 50;
                else if (str[i] == 'C') num += 100;
                else if (str[i] == 'D') num += 500;
                else if (str[i] == 'M') num += 1000;
                else return -1;
			}

            return num;
        }
    }
}
