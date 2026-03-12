using LibraryManagementDI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementDI.Controllers
{
	public class BooksController : Controller
	{
		private readonly IBookRepository _repository;

		public BooksController(IBookRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Details(int id)
		{
			var book = _repository.GetBookById(id);

			return View(book);
		}
	}
}
