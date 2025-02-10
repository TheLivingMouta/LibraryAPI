using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
	public class Book
	{

		[Key] public int Id { get; set; }
		[MaxLength(200)] public string title { get; set; }
		[MaxLength(500)] public string description { get; set; }
		public int authorId { get; set; }
		public ICollection<Book> books { get; set;}

	}
}
