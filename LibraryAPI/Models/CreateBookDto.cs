﻿namespace LibraryAPI.Models
{
	public class CreateBookDto
	{

		public int id {  get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public string authorId { get; set; }

	}
}
