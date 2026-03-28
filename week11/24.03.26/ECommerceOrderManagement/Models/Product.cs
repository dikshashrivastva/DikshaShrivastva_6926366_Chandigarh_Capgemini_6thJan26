using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.Models
{
	public class Product
	{
		public int ProductId { get; set; }

		[Required]
		[StringLength(150)]
		public string Name { get; set; }

		[StringLength(500)]
		public string Description { get; set; }

		[Required]
		[Range(0.01, 99999.99)]
		public decimal Price { get; set; }

		[Range(0, int.MaxValue)]
		public int Stock { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}