using System;
using System.Collections.Generic;
using System.Text;

namespace EccomerceProduct
{
	class Cart
	{
		private List<Product> items = new List<Product>();

		public void AddProduct(Product p)
		{
			if (p.IsAvailable())
			{
				items.Add(p);
				p.ReduceStock();
				Console.WriteLine("Product added to cart");
			}
			else
			{
				Console.WriteLine("Out of stock");
			}
		}

		public void ViewCart()
		{
			Console.WriteLine("Cart Items:");
			foreach (var item in items)
			{
				item.Display();
			}
		}
	}
}
