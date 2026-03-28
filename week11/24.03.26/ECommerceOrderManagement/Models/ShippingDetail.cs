using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.Models
{
	public class ShippingDetail
	{
		public int ShippingDetailId { get; set; }

		[Required]
		[StringLength(250)]
		public string ShippingAddress { get; set; }

		public DateTime? ShippedDate { get; set; }
		public DateTime? DeliveryDate { get; set; }

		[StringLength(100)]
		public string TrackingNumber { get; set; } = string.Empty;

		[StringLength(50)]
		public string ShippingStatus { get; set; } = "Pending";

		public int OrderId { get; set; }
		public Order Order { get; set; }
	}
}