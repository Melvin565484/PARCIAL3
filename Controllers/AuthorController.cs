using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webAPI.Data;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPIParcial3.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthorController:Controller
    {
        private DatabaseContext _context;

        public AuthorController(DatabaseContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthor()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorByID(int id)
        {
            var authors = await _context.Authors.FindAsync(id);
            if (authors==null)
            
            {
                return NotFound();

            }

            return authors;
        }
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction("AuthorByID", new{id=author.AuthorID}, author);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Author>> PutAuthors(int id, Author author)
        {
            if (id != author.AuthorID)
            {
                return BadRequest();
            }
            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
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
            return CreatedAtAction("GetAuthorByID", new{id=author.AuthorID}, author);
        }
        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(d=>d.AuthorID==id);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Author>> DeleteAuthors(int id)
        {
            var authors = await _context.Authors.FindAsync(id);
            if(authors==null)
            {
                return NotFound();
            }

            _context.Authors.Remove(authors);
            await _context.SaveChangesAsync();
            
            return authors;

        }

        private bool AuthorsExists(int id)
        {
            return _context.Authors.Any(d=>d.AuthorID==id);
        }
    }
}