using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibraryAPI.Models
{
	public class BooksContext : DbContext
	{

		public string DBPath { get; set; }

		public BooksContext(DbContextOptions<BooksContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Book> Books { get; set; } = null;

		public DbSet<Author> Authors { get; set; } = null;
 
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 1,
				authorId = 1,
				title = "Ready Player One",
				description = "In 2045, people seek to escape from reality through the OASIS (Ontologically Anthropocentric Sensory Immersive Simulation), a virtual reality entertainment universe created by James Halliday and Ogden Morrow of Gregarious Games"
			}
			);

			modelBuilder.Entity<Author>().HasData(new Author
			{
				Id = 1,
				FirstName = "Ernest",
				LastName = "Cline",
				DOB = new DateTime(1972, 3, 29),
				MainCategory = "Science Fiction"
			}
			);

			base.OnModelCreating(modelBuilder);

		}
	}
}
 