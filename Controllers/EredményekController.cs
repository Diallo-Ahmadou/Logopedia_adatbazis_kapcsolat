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
    public class EredményekController : ControllerBase
    {
        private readonly LogopédiaContext _context;

        public EredményekController(LogopédiaContext context)
        {
            _context = context;
        }

        // GET: api/Eredmények
        [HttpGet]
        [Route("api/Eredmények")]
        public async Task<ActionResult<IEnumerable<Eredmények>>> GetEredmények()
        {
            return await _context.Eredmények.ToListAsync();
        }

        // GET: api/Eredmények/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eredmények>> GetEredmények(int id)
        {
            var eredmények = await _context.Eredmények.FindAsync(id);

            if (eredmények == null)
            {
                return NotFound();
            }

            return eredmények;
        }

        // PUT: api/Eredmények/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEredmények(int id, Eredmények eredmények)
        {
            if (id != eredmények.tesztAZ)
            {
                return BadRequest();
            }

            _context.Entry(eredmények).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EredményekExists(id))
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

        // POST: api/Eredmények
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Eredmények>> PostEredmények(Eredmények eredmények)
        {
            _context.Eredmények.Add(eredmények);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEredmények", new { id = eredmények.tesztAZ }, eredmények);
        }

        // DELETE: api/Eredmények/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEredmények(int id)
        {
            var eredmények = await _context.Eredmények.FindAsync(id);
            if (eredmények == null)
            {
                return NotFound();
            }

            _context.Eredmények.Remove(eredmények);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EredményekExists(int id)
        {
            return _context.Eredmények.Any(e => e.tesztAZ == id);
        }
    }
}
