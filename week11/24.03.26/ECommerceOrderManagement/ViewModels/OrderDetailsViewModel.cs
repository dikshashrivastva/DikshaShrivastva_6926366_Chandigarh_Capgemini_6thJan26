using ECommerceOrderManagement.Models;

namespace ECommerceOrderManagement.ViewModels
{
	public class OrderDetailsViewModel
	{
		public Order Order { get; set; }
		public List<OrderItem> OrderItems { get; set; }
		public ShippingDetail ShippingDetail { get; set; }
		public Customer Customer { get; set; }
	}
}