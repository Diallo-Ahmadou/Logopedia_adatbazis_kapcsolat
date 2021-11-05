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
    public class TerápiákController : ControllerBase
    {
        private readonly LogopédiaContext _context;

        public TerápiákController(LogopédiaContext context)
        {
            _context = context;
        }

        // GET: api/Terápiák
        [HttpGet]
        [Route("api/Terápiák")]
        public async Task<ActionResult<IEnumerable<Terápiák>>> GetTerápiák()
        {
            return await _context.Terápiák.ToListAsync();
        }

        // GET: api/Terápiák/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Terápiák>> GetTerápiák(int id)
        {
            var terápiák = await _context.Terápiák.FindAsync(id);

            if (terápiák == null)
            {
                return NotFound();
            }

            return terápiák;
        }

        // PUT: api/Terápiák/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerápiák(int id, Terápiák terápiák)
        {
            if (id != terápiák.terapiaAZ)
            {
                return BadRequest();
            }

            _context.Entry(terápiák).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerápiákExists(id))
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

        // POST: api/Terápiák
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Terápiák>> PostTerápiák(Terápiák terápiák)
        {
            _context.Terápiák.Add(terápiák);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTerápiák", new { id = terápiák.terapiaAZ }, terápiák);
        }

        // DELETE: api/Terápiák/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerápiák(int id)
        {
            var terápiák = await _context.Terápiák.FindAsync(id);
            if (terápiák == null)
            {
                return NotFound();
            }

            _context.Terápiák.Remove(terápiák);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TerápiákExists(int id)
        {
            return _context.Terápiák.Any(e => e.terapiaAZ == id);
        }
    }
}
