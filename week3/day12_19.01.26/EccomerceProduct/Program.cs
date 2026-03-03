namespace EccomerceProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Product p1 = new Electronics(1, "Laptop", 50000, 2);
			Product p2 = new Clothing(2, "T-Shirt", 800, 5);
			Product p3 = new Books(3, "C# Book", 600, 3);

			Customer c1 = new Customer("Diksha");
			Cart cart = new Cart();

			p1.Display();
			p2.Display();
			p3.Display();

			cart.AddProduct(p1);
			cart.AddProduct(p3);

			cart.ViewCart();

			Order order = new Order();
			order.PlaceOrder(c1);
		}
    }
}
