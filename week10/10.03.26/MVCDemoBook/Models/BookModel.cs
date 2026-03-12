using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MVCDemoBook.Models
{
	[Table("tblBook")]
	public class BookModel
	{
		[Key]
		public int BookModelId { get; set; }
		public string BookName { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		
		public int Price { get; set; }
	}
}
