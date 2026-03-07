namespace Product_Inventory_Management
{
	public interface IProduct
	{
		public string Name { get; set; }
		public string Category { get; set; }
		public int Stock { get; set; }
		public int Price { get; set; }

	}

	public interface IInventory
	{
		void AddProduct(IProduct product);
		void RemoveProduct(IProduct product);
		int CalculateTotalValue();
		List<IProduct> GetProductsByCategory(string category);
		List<IProduct> SearchProductsByName(string name);
		List<(string, int)> GetProductsByCategoryWithCount();
		List<(string, List<IProduct>)> GetAllProductsByCategory();

	}

	public class Product : IProduct
	{
		public string Name { get; set; }
		public string Category { get; set; }
		public int Stock { get; set; }
		public int Price { get; set; }

		public Product(string name, string category,int stock, int price)
		{
			Name = name;
			Category = category;
			Stock = stock;
			Price = price;
		}

	}
	public class Inventory : IInventory
	{
		private List<IProduct> products = new List<IProduct>();

		void AddProduct(IProduct product)
		{
			products.Add(product);
		}
		void RemoveProduct(IProduct product)
		{
			products.RemoveAll(p => p.Name == product.Name);	
		}
		int CalculateTotalValue();
		List<IProduct> GetProductsByCategory(string category);
		List<IProduct> SearchProductsByName(string name);
		List<(string, int)> GetProductsByCategoryWithCount();
		List<(string, List<IProduct>)> GetAllProductsByCategory();

	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}
	}
}
