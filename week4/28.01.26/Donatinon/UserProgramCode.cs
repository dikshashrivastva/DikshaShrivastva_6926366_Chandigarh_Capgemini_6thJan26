using System;
using System.Collections.Generic;
using System.Text;

namespace Donatinon
{
    internal class UserProgramCode
    {
        public static int getDonation(string[] input1, int input2)
        {
			int n = input1.Length;
			int sum = 0;

			for (int i = 0; i < n; i++)
			{
				for (int j = i + 1; j < n; j++)
				{
					if (input1[i] == input1[j])
						return -1;
				}
			}

			for (int i = 0; i < n; i++)
			{
				string s = input1[i];

				for (int j = 0; j < s.Length; j++)
				{
					if (!char.IsDigit(s[j]))
						return -2;
				}

				int location = Convert.ToInt32(s.Substring(3, 3));

				int donation = Convert.ToInt32(s.Substring(6, 3));

				if (location == input2)
				{
					sum = sum + donation;
				}
			}

			return sum;


		}

    }
}
