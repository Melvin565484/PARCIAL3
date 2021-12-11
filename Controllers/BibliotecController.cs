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
            return CreatedAtAction("GetBibliotecByID", new{id=bibliotec.ISBN}, bibliotec);
        }
    }
}