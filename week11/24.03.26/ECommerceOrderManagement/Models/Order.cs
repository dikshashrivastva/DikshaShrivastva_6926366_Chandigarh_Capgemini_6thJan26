using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.Models
{
	public enum OrderStatus { Pending, Processing, Shipped, Delivered, Cancelled }

	public class Order
	{
		public int OrderId { get; set; }

		[Required]
		public DateTime OrderDate { get; set; } = DateTime.Now;

		public OrderStatus Status { get; set; } = OrderStatus.Pending;

		public decimal TotalAmount { get; set; }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
		public ShippingDetail ShippingDetail { get; set; }
	}
}