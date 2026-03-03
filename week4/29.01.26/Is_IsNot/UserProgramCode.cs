using System;
using System.Collections.Generic;
using System.Text;

namespace Is_IsNot
{
    internal class UserProgramCode
    {
        public static string negativeString(string str)
        {
            str = str.Replace(" is ", " is not ");
            return str;
        }
    }
}
