namespace Movie
{
	public interface IFilm
	{
		string Title { get; set; }
		string Director { get; set; }
		int Year { get; set; }
	}

	public interface IFilmLibrary
	{
		public void AddFilm(IFilm film);
		public void RemoveFilm(string title);
		public List<IFilm> GetFilms();
		public List<IFilm> SearchFilms(string query);
		public int GetTotalFilmCount();
	}

	//Film Class
	public class Film : IFilm
	{
		public string Title { get; set; }
		public string Director { get; set; }
		public int Year { get; set; }

		public Film(string title, string director, int year)
		{
			Title = title;
			Director = director;
			Year = year;
		}
	}

	//FilmLibrary Class
	public class FilmLibrary : IFilmLibrary
	{
		private List<IFilm> films = new List<IFilm>();
		//Add film
		public void AddFilm(IFilm film)
		{
			films.Add(film);

		}

		//Remove film by title
		public void RemoveFilm(string title)
		{
			films.RemoveAll(f => f.Title == title);
		}

		//return all films
		public List<IFilm> GetFilms()
		{
			return films;
		}
		//search films by title or director name
		public List<IFilm> SearchFilms(string query)
		{
			return films.Where(f => f.Title.Contains(query) ||
			f.Director.Contains(query)).ToList();
		}

		//return total number of films
		public int GetTotalFilmCount()
		{
			return films.Count;
		}
	}
		internal class Program
	    {
		static void Main(string[] args)
		{
			IFilmLibrary library = new FilmLibrary();

			library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
			library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
			library.AddFilm(new Film("Titanic", "James Cameron", 1997));

			Console.WriteLine("All Films:");
			foreach (var film in library.GetFilms())
			{
				Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
			}

			Console.WriteLine("\nSearch Results for 'Nolan':");
			var searchResults = library.SearchFilms("Nolan");

			foreach (var film in searchResults)
			{
				Console.WriteLine($"{film.Title} - {film.Director}");
			}

			Console.WriteLine("\nRemoving Titanic...");
			library.RemoveFilm("Titanic");

			Console.WriteLine("\nTotal Films in Library: " + library.GetTotalFilmCount());
		}
	}
}
