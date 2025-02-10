namespace LibraryAPI.Models
{
	public class GetAuthorAndBooks
	{

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<BookDto> Books { get; set; } = new List<BookDto>();

	}

	public class BookDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
