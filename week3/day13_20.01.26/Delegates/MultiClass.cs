using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public delegate void Math(int x, int y);
    internal class MultiClass
    {
        public void add(int x, int y)
        {
            Console.WriteLine("add:" + (x + y));
        }
        public void sub(int x, int y)
        {
            Console.WriteLine("sub:" + (x - y));
        }
		public void mul(int x, int y)
		{
			Console.WriteLine("mul:" + (x * y));
		}
		public void div(int x, int y)
		{
			Console.WriteLine("div:" + (x / y));
		}
	}
}
