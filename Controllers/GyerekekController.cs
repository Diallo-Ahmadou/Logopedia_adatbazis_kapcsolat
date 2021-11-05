using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Logopédia_adatbázis_kapcsolat.Models;

namespace Logopédia_adatbázis_kapcsolat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GyerekekController : ControllerBase
    {
        private readonly LogopédiaContext _context;

        public GyerekekController(LogopédiaContext context)
        {
            _context = context;
        }

        // GET: api/Gyerekek
        [HttpGet]
        [Route("api/Gyerekek")]
        public async Task<ActionResult<IEnumerable<Gyerekek>>> GetGyerekek()
        {
            return await _context.Gyerekek.ToListAsync();
        }

        // GET: api/Gyerekek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gyerekek>> GetGyerekek(int id)
        {
            var gyerekek = await _context.Gyerekek.FindAsync(id);

            if (gyerekek == null)
            {
                return NotFound();
            }

            return gyerekek;
        }

        // PUT: api/Gyerekek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGyerekek(int id, Gyerekek gyerekek)
        {
            if (id != gyerekek.oktatasi_azonosito)
            {
                return BadRequest();
            }

            _context.Entry(gyerekek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GyerekekExists(id))
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

        // POST: api/Gyerekek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gyerekek>> PostGyerekek(Gyerekek gyerekek)
        {
            _context.Gyerekek.Add(gyerekek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGyerekek", new { id = gyerekek.oktatasi_azonosito }, gyerekek);
        }

        // DELETE: api/Gyerekek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGyerekek(int id)
        {
            var gyerekek = await _context.Gyerekek.FindAsync(id);
            if (gyerekek == null)
            {
                return NotFound();
            }

            _context.Gyerekek.Remove(gyerekek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GyerekekExists(int id)
        {
            return _context.Gyerekek.Any(e => e.oktatasi_azonosito == id);
        }
    }
}
