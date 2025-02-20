﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BooksContext _context;

        public AuthorsController(BooksContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAuthorDto>>> GetAuthors()
        {
			if (_context.Authors == null)
			{
				return NotFound();
			}

			var authors = await _context.Authors.Select(t => new GetAuthorDto()
			{

				Id = t.Id,
				FirstName = t.FirstName,
                LastName = t.LastName,
                MainCategory = t.MainCategory,

			}
			).ToListAsync();

			return Ok(authors);
		}

        // GET: api/Authors/5
        [HttpGet("{id}")]
		public async Task<ActionResult<IEnumerable<GetAuthorAndBooks>>> GetAuthorsAndBooks()
		{
			if (_context.Authors == null)
			{
				return NotFound();
			}

			var authors = await _context.Authors.Include(a => a.Books).Select(a => new GetAuthorAndBooks()
			{

				Id = a.Id,
				FirstName = a.FirstName,
				LastName = a.LastName,
				Books = a.Books.Select(b => new BookDto
				{

					Id = b.Id,
					Title = b.title,
					Description = b.description,


				}
				).ToList()

			}
			).ToListAsync();

			return Ok(authors);
		}

		// PUT: api/Authors/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
