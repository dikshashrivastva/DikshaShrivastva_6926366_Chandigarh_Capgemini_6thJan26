using System;
using System.Collections.Generic;
using System.Text;

namespace EccomerceProduct
{
	class Order
	{
		public void PlaceOrder(Customer c)
		{
			Console.WriteLine("Order placed by " + c.Name);
		}
	}

}
