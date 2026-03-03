using System;
using System.Collections.Generic;
using System.Text;

namespace EccomerceProduct
{
    internal class Product
    {
		private int id;
		private string name;
		private double price;
		private int stock;

		public Product(int id, string name, double price, int stock)
		{
			this.id = id;
			this.name = name;
			this.price = price;
			this.stock = stock;
		}

		public bool IsAvailable()
		{
			return stock > 0;
		}

		public void ReduceStock()
		{
			stock--;
		}

		public virtual void Display()
		{
			Console.WriteLine($"ID:{id}  Name:{name}  Price:{price}  Stock:{stock}");
		}
	}
}
