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
    public class TesztekController : ControllerBase
    {
        private readonly LogopédiaContext _context;

        public TesztekController(LogopédiaContext context)
        {
            _context = context;
        }

        // GET: api/Tesztek
        [HttpGet]
        [Route("api/Tesztek")]
        public async Task<ActionResult<IEnumerable<Tesztek>>> GetTesztek()
        {
            return await _context.Tesztek.ToListAsync();
        }

        // GET: api/Tesztek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tesztek>> GetTesztek(int id)
        {
            var tesztek = await _context.Tesztek.FindAsync(id);

            if (tesztek == null)
            {
                return NotFound();
            }

            return tesztek;
        }

        // PUT: api/Tesztek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTesztek(int id, Tesztek tesztek)
        {
            if (id != tesztek.tesztAZ)
            {
                return BadRequest();
            }

            _context.Entry(tesztek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TesztekExists(id))
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

        // POST: api/Tesztek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tesztek>> PostTesztek(Tesztek tesztek)
        {
            _context.Tesztek.Add(tesztek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTesztek", new { id = tesztek.tesztAZ }, tesztek);
        }

        // DELETE: api/Tesztek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTesztek(int id)
        {
            var tesztek = await _context.Tesztek.FindAsync(id);
            if (tesztek == null)
            {
                return NotFound();
            }

            _context.Tesztek.Remove(tesztek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TesztekExists(int id)
        {
            return _context.Tesztek.Any(e => e.tesztAZ == id);
        }
    }
}
