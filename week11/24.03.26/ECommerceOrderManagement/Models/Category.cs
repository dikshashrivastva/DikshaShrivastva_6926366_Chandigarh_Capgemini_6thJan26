using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[StringLength(250)]
		public string Description { get; set; }

		public ICollection<Product> Products { get; set; } = new List<Product>();
	}
}