﻿namespace LibraryAPI.Models
{
	public class BookDTO
	{

		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int AuthorId {  get; set; }

	}
}
