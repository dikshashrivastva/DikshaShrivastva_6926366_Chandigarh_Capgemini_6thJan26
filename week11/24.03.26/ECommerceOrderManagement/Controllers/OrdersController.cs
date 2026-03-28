using ECommerceOrderManagement.Data;
using ECommerceOrderManagement.Models;
using ECommerceOrderManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderManagement.Controllers
{
	public class OrdersController : Controller
	{
		private readonly ApplicationDbContext _context;
		public OrdersController(ApplicationDbContext context) => _context = context;

		public async Task<IActionResult> Index()
		{
			var orders = await _context.Orders
				.Include(o => o.Customer)
				.Include(o => o.ShippingDetail)
				.ToListAsync();
			return View(orders);
		}

		public async Task<IActionResult> Details(int id)
		{
			var order = await _context.Orders
				.Include(o => o.Customer)
				.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
				.Include(o => o.ShippingDetail)
				.FirstOrDefaultAsync(o => o.OrderId == id);

			if (order == null) return NotFound();

			var vm = new OrderDetailsViewModel
			{
				Order = order,
				Customer = order.Customer,
				OrderItems = order.OrderItems.ToList(),
				ShippingDetail = order.ShippingDetail
			};
			return View(vm);
		}

		public IActionResult Create()
		{
			ViewBag.CustomerId = new SelectList(_context.Customers, "CustomerId", "FullName");
			ViewBag.Products = _context.Products.ToList();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(int CustomerId, int[] productIds, int[] quantities, string shippingAddress)
		{
			// ── Reload dropdowns helper ──────────────────────────────────────────
			void ReloadView()
			{
				ViewBag.CustomerId = new SelectList(_context.Customers, "CustomerId", "FullName");
				ViewBag.Products = _context.Products.ToList();
			}

			// ── Basic validation ─────────────────────────────────────────────────
			if (CustomerId == 0)
			{
				ModelState.AddModelError("", "Please select a customer.");
				ReloadView(); return View();
			}

			if (string.IsNullOrWhiteSpace(shippingAddress))
			{
				ModelState.AddModelError("", "Shipping address is required.");
				ReloadView(); return View();
			}

			if (productIds == null || productIds.Length == 0)
			{
				ModelState.AddModelError("", "No products were submitted.");
				ReloadView(); return View();
			}

			// ── Build order items (only qty > 0) ─────────────────────────────────
			var orderItems = new List<OrderItem>();
			decimal total = 0;

			for (int i = 0; i < productIds.Length; i++)
			{
				int qty = (quantities != null && i < quantities.Length) ? quantities[i] : 0;
				if (qty <= 0) continue;

				var product = await _context.Products.FindAsync(productIds[i]);
				if (product == null) continue;

				orderItems.Add(new OrderItem
				{
					ProductId = product.ProductId,
					Quantity = qty,
					UnitPrice = product.Price
				});

				total += product.Price * qty;
			}

			if (orderItems.Count == 0)
			{
				ModelState.AddModelError("", "Please enter a quantity of at least 1 for at least one product.");
				ReloadView(); return View();
			}

			// ── Save ─────────────────────────────────────────────────────────────
			try
			{
				var order = new Order
				{
					CustomerId = CustomerId,
					OrderDate = DateTime.Now,
					Status = OrderStatus.Pending,
					TotalAmount = total,
					OrderItems = orderItems,
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = shippingAddress.Trim(),
						ShippingStatus = "Pending"
					}
				};

				_context.Orders.Add(order);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Failed to save order: " + ex.InnerException?.Message ?? ex.Message);
				ReloadView(); return View();
			}
		}

		public async Task<IActionResult> Delete(int id)
		{
			var order = await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderId == id);
			if (order == null) return NotFound();
			return View(order);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var order = await _context.Orders.FindAsync(id);
			_context.Orders.Remove(order);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}