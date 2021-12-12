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

    public class BibliotecController:Controller
    {
        private DatabaseContext _context;

        public BibliotecController(DatabaseContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bibliotec>>> GetBibliotec()
        {
            var bibliotecs = await _context.Bibliotecs.ToListAsync();
            return bibliotecs;
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Bibliotec>> GetBibliotecByID(int id)
        {
            var bibliotecs = await _context.Bibliotecs.FindAsync(id);
            if (bibliotecs==null)
            
            {
                return NotFound();

            }

            return bibliotecs;
        }
        [HttpPost]
        public async Task<ActionResult<Bibliotec>> PostBibliotec(Bibliotec bibliotec)
        {
            _context.Bibliotecs.Add(bibliotec);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBibliotecByID", new{id=bibliotec.BibliotecID}, bibliotec);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Bibliotec>> PutBibliotecs(int id, Bibliotec bibliotec)
        {
            if (id != bibliotec.BibliotecID)
            {
                return BadRequest();
            }
            _context.Entry(bibliotec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!BibliotecExists(id))
                {
                
                return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return CreatedAtAction("GetBibliotecByID", new{id=bibliotec.BibliotecID}, bibliotec);
        }
        private bool BibliotecExists(int id)
        {
            return _context.Bibliotecs.Any(d=>d.BibliotecID==id);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Bibliotec>> DeleteBibliotecs(int id)
        {
            var bibliotecs = await _context.Bibliotecs.FindAsync(id);
            if(bibliotecs==null)
            {
                return NotFound();
            }

            _context.Bibliotecs.Remove(bibliotecs);
            await _context.SaveChangesAsync();
            
            return bibliotecs;

        }

        private bool BibliotecsExists(int id)
        {
            return _context.Bibliotecs.Any(d=>d.BibliotecID==id);
        }
    }
}