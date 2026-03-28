using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }

		[Required]
		[StringLength(100)]
		public string FullName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Phone]
		public string Phone { get; set; }

		[StringLength(250)]
		public string Address { get; set; }

		public ICollection<Order> Orders { get; set; } = new List<Order>();
	}
}