using ECommerceOrderManagement.Data;
using ECommerceOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderManagement.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _context;
		public ProductsController(ApplicationDbContext context) => _context = context;

		public async Task<IActionResult> Index(int? categoryId)
		{
			var categories = await _context.Categories.ToListAsync();
			ViewBag.Categories = new SelectList(categories, "CategoryId", "Name", categoryId);
			ViewBag.SelectedCategory = categoryId;

			var products = _context.Products.Include(p => p.Category).AsQueryable();
			if (categoryId.HasValue)
				products = products.Where(p => p.CategoryId == categoryId);

			return View(await products.ToListAsync());
		}

		public async Task<IActionResult> Details(int id)
		{
			var product = await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(p => p.ProductId == id);
			if (product == null) return NotFound();
			return View(product);
		}

		public IActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Product product)
		{
			if (ModelState.IsValid)
			{
				_context.Add(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
			return View(product);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null) return NotFound();
			ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
			return View(product);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Product product)
		{
			if (id != product.ProductId) return NotFound();
			if (ModelState.IsValid)
			{
				_context.Update(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
			return View(product);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
			if (product == null) return NotFound();
			return View(product);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = await _context.Products.FindAsync(id);
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}							