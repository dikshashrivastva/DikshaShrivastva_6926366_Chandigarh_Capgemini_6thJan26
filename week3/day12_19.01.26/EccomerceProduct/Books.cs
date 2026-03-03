using System;
using System.Collections.Generic;
using System.Text;

namespace EccomerceProduct
{
	class Books : Product
	{
		public Books(int id, string name, double price, int stock)
			: base(id, name, price, stock)
		{
		}
	}

}
