using ECommerceOrderManagement.Models;

namespace ECommerceOrderManagement.ViewModels
{
	public class TopProductViewModel
	{
		public string ProductName { get; set; }
		public int TotalSold { get; set; }
	}

	public class CustomerOrderSummaryViewModel
	{
		public string CustomerName { get; set; }
		public string Email { get; set; }
		public int TotalOrders { get; set; }
		public decimal TotalSpent { get; set; }
	}

	public class DashboardViewModel
	{
		public List<TopProductViewModel> TopProducts { get; set; }
		public List<Order> PendingShipments { get; set; }
		public List<CustomerOrderSummaryViewModel> CustomerSummaries { get; set; }
	}
}