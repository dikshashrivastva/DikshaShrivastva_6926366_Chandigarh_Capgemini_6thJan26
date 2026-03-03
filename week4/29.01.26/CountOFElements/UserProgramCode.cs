using System;
using System.Collections.Generic;
using System.Text;

namespace CountOFElements
{
    internal class UserProgramCode
    {
        public static int GetCount(string [] str,char ch)
        {
            int count = 0;
            bool isFound = false;
            for(int i = 0; i < str.Length; i++)
            {
                for(int j = 0; j < str[i].Length; j++)
                {
                    if (!((str[i][j]>='A' && str[i][j]<='Z')||
                        (str[i][j]>='a' && str[i][j] <= 'z')))
                    {
                        return -2;
                    }
                }
                if (str[i][0] == ch)
                {
                    isFound = true;
                    count++;
                }
            }
            if (isFound)
            {
                return count;
            }
            else
            {
				return -1;
			}

                

        }
    }
}
