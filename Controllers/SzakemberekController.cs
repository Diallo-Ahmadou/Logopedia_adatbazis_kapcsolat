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
    public class SzakemberekController : ControllerBase
    {
        private readonly LogopédiaContext _context;

        public SzakemberekController(LogopédiaContext context)
        {
            _context = context;
        }

        // GET: api/Szakemberek
        [HttpGet]
        [Route("api/Szakemberek")]
        public async Task<ActionResult<IEnumerable<Szakemberek>>> GetSzakemberek()
        {
            return await _context.Szakemberek.ToListAsync();
        }

        // GET: api/Szakemberek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Szakemberek>> GetSzakemberek(int id)
        {
            var szakemberek = await _context.Szakemberek.FindAsync(id);

            if (szakemberek == null)
            {
                return NotFound();
            }

            return szakemberek;
        }

        // PUT: api/Szakemberek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSzakemberek(int id, Szakemberek szakemberek)
        {
            if (id != szakemberek.ellato_szakemberID)
            {
                return BadRequest();
            }

            _context.Entry(szakemberek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SzakemberekExists(id))
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

        // POST: api/Szakemberek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Szakemberek>> PostSzakemberek(Szakemberek szakemberek)
        {
            _context.Szakemberek.Add(szakemberek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSzakemberek", new { id = szakemberek.ellato_szakemberID }, szakemberek);
        }

        // DELETE: api/Szakemberek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSzakemberek(int id)
        {
            var szakemberek = await _context.Szakemberek.FindAsync(id);
            if (szakemberek == null)
            {
                return NotFound();
            }

            _context.Szakemberek.Remove(szakemberek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SzakemberekExists(int id)
        {
            return _context.Szakemberek.Any(e => e.ellato_szakemberID == id);
        }
    }
}
