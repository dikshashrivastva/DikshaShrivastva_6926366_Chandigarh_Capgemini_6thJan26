using ECommerceOrderManagement.Data;
using ECommerceOrderManagement.Models;
using ECommerceOrderManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderManagement.Controllers
{
	public class AdminController : Controller
	{
		private readonly ApplicationDbContext _context;
		public AdminController(ApplicationDbContext context) => _context = context;

		// Simple session-based admin check
		private bool IsAdmin() => HttpContext.Session.GetString("IsAdmin") == "true";

		public IActionResult Login() => View();

		[HttpPost]
		public IActionResult Login(string username, string password)
		{
			if (username == "admin" && password == "admin123")
			{
				HttpContext.Session.SetString("IsAdmin", "true");
				return RedirectToAction("Dashboard");
			}
			ViewBag.Error = "Invalid credentials.";
			return View();
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login");
		}

		public async Task<IActionResult> Dashboard()
		{
			if (!IsAdmin()) return RedirectToAction("Login");

			var topProducts = await _context.OrderItems
				.GroupBy(oi => oi.Product.Name)
				.Select(g => new TopProductViewModel
				{
					ProductName = g.Key,
					TotalSold = g.Sum(x => x.Quantity)
				})
				.OrderByDescending(x => x.TotalSold)
				.Take(5)
				.ToListAsync();

			var pending = await _context.Orders
				.Include(o => o.Customer)
				.Include(o => o.ShippingDetail)
				.Where(o => o.Status == OrderStatus.Pending)
				.ToListAsync();

			var customerSummaries = await _context.Customers
				.Select(c => new CustomerOrderSummaryViewModel
				{
					CustomerName = c.FullName,
					Email = c.Email,
					TotalOrders = c.Orders.Count,
					TotalSpent = c.Orders.Sum(o => o.TotalAmount)
				})
				.ToListAsync();

			var vm = new DashboardViewModel
			{
				TopProducts = topProducts,
				PendingShipments = pending,
				CustomerSummaries = customerSummaries
			};

			return View(vm);
		}

		public async Task<IActionResult> UpdateShipping(int id)
		{
			if (!IsAdmin()) return RedirectToAction("Login");
			var shipping = await _context.ShippingDetails.FindAsync(id);
			if (shipping == null) return NotFound();
			return View(shipping);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateShipping(ShippingDetail model)
		{
			if (!IsAdmin()) return RedirectToAction("Login");
			var shipping = await _context.ShippingDetails.FindAsync(model.ShippingDetailId);
			if (shipping == null) return NotFound();

			shipping.ShippingStatus = model.ShippingStatus;
			shipping.TrackingNumber = model.TrackingNumber;
			shipping.ShippedDate = model.ShippedDate;
			shipping.DeliveryDate = model.DeliveryDate;
			await _context.SaveChangesAsync();
			return RedirectToAction("Dashboard");
		}
	}
}