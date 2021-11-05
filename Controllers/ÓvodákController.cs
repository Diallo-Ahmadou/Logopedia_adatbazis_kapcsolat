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
    public class ÓvodákController : ControllerBase
    {
        private readonly LogopédiaContext _context;

        public ÓvodákController(LogopédiaContext context)
        {
            _context = context;
        }

        // GET: api/Óvodák
        [HttpGet]
        [Route("api/Óvodák")]
        public async Task<ActionResult<IEnumerable<Óvodák>>> GetÓvodák()
        {
            return await _context.Óvodák.ToListAsync();
        }

        // GET: api/Óvodák/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Óvodák>> GetÓvodák(int id)
        {
            var óvodák = await _context.Óvodák.FindAsync(id);

            if (óvodák == null)
            {
                return NotFound();
            }

            return óvodák;
        }

        // PUT: api/Óvodák/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutÓvodák(int id, Óvodák óvodák)
        {
            if (id != óvodák.ovodaAZ)
            {
                return BadRequest();
            }

            _context.Entry(óvodák).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ÓvodákExists(id))
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

        // POST: api/Óvodák
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Óvodák>> PostÓvodák(Óvodák óvodák)
        {
            _context.Óvodák.Add(óvodák);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetÓvodák", new { id = óvodák.ovodaAZ }, óvodák);
        }

        // DELETE: api/Óvodák/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteÓvodák(int id)
        {
            var óvodák = await _context.Óvodák.FindAsync(id);
            if (óvodák == null)
            {
                return NotFound();
            }

            _context.Óvodák.Remove(óvodák);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ÓvodákExists(int id)
        {
            return _context.Óvodák.Any(e => e.ovodaAZ == id);
        }
    }
}
