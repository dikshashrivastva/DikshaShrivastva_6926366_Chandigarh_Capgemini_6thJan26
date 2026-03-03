using System;
using System.Collections.Generic;
using System.Text;

namespace MaxDiffinArr
{
    internal class UserProgramCode
    {
        public static int diffIntArray(int[] input1)
        {
            if (input1.Length == 1 || input1.Length > 10) return -2;
            for(int i = 0; i < input1.Length; i++)
            {
                if (input1[i] < 0) return -1;
                for(int j = i + 1; j < input1.Length; j++)
                {
                    if (input1[i] == input1[j]) return -3;
                }
            }

			int min = input1[0];
			int maxDiff = 0;

			for (int i = 1; i < input1.Length; i++)
			{
				if (input1[i] > min)
				{
					int diff = input1[i] - min;
					if (diff > maxDiff)
						maxDiff = diff;
				}
				else
				{
					min = input1[i];
				}
			}

			return maxDiff;

			
        }
    }
}
