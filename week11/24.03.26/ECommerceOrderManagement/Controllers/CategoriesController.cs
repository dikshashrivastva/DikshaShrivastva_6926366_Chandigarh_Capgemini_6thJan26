using ECommerceOrderManagement.Data;
using ECommerceOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderManagement.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CategoriesController(ApplicationDbContext context) => _context = context;

		public async Task<IActionResult> Index()
			=> View(await _context.Categories.Include(c => c.Products).ToListAsync());

		public IActionResult Create() => View();

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Category category)
		{
			if (ModelState.IsValid)
			{
				_context.Add(category);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var cat = await _context.Categories.FindAsync(id);
			if (cat == null) return NotFound();
			return View(cat);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Category category)
		{
			if (id != category.CategoryId) return NotFound();
			if (ModelState.IsValid)
			{
				_context.Update(category);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var cat = await _context.Categories.FindAsync(id);
			if (cat == null) return NotFound();
			return View(cat);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var cat = await _context.Categories.FindAsync(id);
			_context.Categories.Remove(cat);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}