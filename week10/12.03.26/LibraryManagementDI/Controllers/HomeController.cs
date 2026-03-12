using Microsoft.AspNetCore.Mvc;
using LibraryManagementDI.Repositories;

namespace LibraryManagementDI.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBookRepository _repository;

		public HomeController(IBookRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var books = _repository.GetAllBooks();

			return View(books);
		}
	}
}