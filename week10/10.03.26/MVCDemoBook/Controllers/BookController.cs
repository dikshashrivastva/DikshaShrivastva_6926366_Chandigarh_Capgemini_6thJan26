using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemoBook.Models;

namespace MVCDemoBook.Controllers
{
	public class BookController : Controller
	{
		private readonly BookDBContext _context;

		public BookController(BookDBContext context)
		{
			_context = context;
		}

		// GET: BookController
		public IActionResult Index()
		{
			var books = _context.books.ToList();
			return View(books);
		}

		// GET: BookController/Details/5
		// GET: BookController/Details/5
		public IActionResult Details(int id)
		{
			var book = _context.books.Find(id);

			if (book == null)
			{
				return NotFound();
			}

			return View(book);
		}

		// GET: BookController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BookController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(BookModel book)
		{
			try
			{
				_context.books.Add(book);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
		// GET: BookController/Delete/5
		public IActionResult Delete(int id)
		{
			var book = _context.books.Find(id);
			return View(book);
		}

		// POST: BookController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var book = _context.books.Find(id);
			_context.books.Remove(book);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		// GET: BookController/Edit/5
		public IActionResult Edit(int id)
		{
			var book = _context.books.Find(id);   // fetch book from database

			if (book == null)
			{
				return NotFound();
			}

			return View(book);   // send book to Edit view
		}


		// POST: BookController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, BookModel book)
		{
			if (id != book.BookModelId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_context.Update(book);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}

			return View(book);
		}

	}
}