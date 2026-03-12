using LibraryManagementDI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementDI.Repositories
{
	public class BookRepository : IBookRepository
	{
		private List<Book> books = new List<Book>
		{
			new Book{Id=1, Title="Clean Code", Author="Robert Martin"},
			new Book{Id=2, Title="Design Patterns", Author="GoF"},
			new Book{Id=3, Title="C# in Depth", Author="Jon Skeet"}
		};

		public List<Book> GetAllBooks()
		{
			return books;
		}

		public Book GetBookById(int id)
		{
			return books.FirstOrDefault(b => b.Id == id);
		}
	}
}