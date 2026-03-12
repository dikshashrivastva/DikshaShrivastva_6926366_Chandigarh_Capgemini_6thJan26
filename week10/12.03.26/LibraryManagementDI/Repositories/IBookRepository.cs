using LibraryManagementDI.Models;

namespace LibraryManagementDI.Repositories
{
	public interface IBookRepository
	{
		List<Book> GetAllBooks();

		Book GetBookById(int id);
	}
}
