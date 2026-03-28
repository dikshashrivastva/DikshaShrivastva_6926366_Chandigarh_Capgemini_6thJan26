using ECommerceOrderManagement.Data;
using ECommerceOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderManagement.Controllers
{
	public class CustomersController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CustomersController(ApplicationDbContext context) => _context = context;

		public async Task<IActionResult> Index()
			=> View(await _context.Customers.ToListAsync());

		public async Task<IActionResult> Details(int id)
		{
			var customer = await _context.Customers
				.Include(c => c.Orders)
					.ThenInclude(o => o.OrderItems)
						.ThenInclude(oi => oi.Product)
				.Include(c => c.Orders)
					.ThenInclude(o => o.ShippingDetail)
				.FirstOrDefaultAsync(c => c.CustomerId == id);

			if (customer == null) return NotFound();
			return View(customer);
		}

		public IActionResult Create() => View();

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Customer customer)
		{
			if (ModelState.IsValid)
			{
				_context.Add(customer);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(customer);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			if (customer == null) return NotFound();
			return View(customer);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Customer customer)
		{
			if (id != customer.CustomerId) return NotFound();
			if (ModelState.IsValid)
			{
				_context.Update(customer);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(customer);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			if (customer == null) return NotFound();
			return View(customer);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}