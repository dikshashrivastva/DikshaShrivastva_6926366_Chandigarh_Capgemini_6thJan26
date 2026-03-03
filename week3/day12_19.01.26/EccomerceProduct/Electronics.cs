using System;
using System.Collections.Generic;
using System.Text;

namespace EccomerceProduct
{
	class Electronics : Product
	{
		public Electronics(int id, string name, double price, int stock)
			: base(id, name, price, stock)
		{
		}
	}

}
