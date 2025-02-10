using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
	public class Author
	{

		[Key] public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DOB { get; set; }
		public string MainCategory { get; set; }

		public List<Book> Books { get; set; } = new List<Book>();

	}
}
