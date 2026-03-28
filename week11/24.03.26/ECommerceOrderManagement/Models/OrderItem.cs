using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.Models
{
	public class OrderItem
	{
		public int OrderItemId { get; set; }

		[Range(1, 1000)]
		public int Quantity { get; set; }

		[Range(0.01, 99999.99)]
		public decimal UnitPrice { get; set; }

		public int OrderId { get; set; }
		public Order Order { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}