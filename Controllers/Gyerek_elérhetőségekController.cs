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
    public class Gyerek_elérhetőségekController : ControllerBase
    {
        private readonly LogopédiaContext _context;

        public Gyerek_elérhetőségekController(LogopédiaContext context)
        {
            _context = context;
        }

        // GET: api/Gyerek_elérhetőségek
        [HttpGet]
        [Route("api/Gyerek_elérhetőségek")]
        public async Task<ActionResult<IEnumerable<Gyerek_elérhetőségek>>> GetGyerek_Elérhetőségek()
        {
            return await _context.Gyerek_Elérhetőségek.ToListAsync();
        }

        // GET: api/Gyerek_elérhetőségek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gyerek_elérhetőségek>> GetGyerek_elérhetőségek(int id)
        {
            var gyerek_elérhetőségek = await _context.Gyerek_Elérhetőségek.FindAsync(id);

            if (gyerek_elérhetőségek == null)
            {
                return NotFound();
            }

            return gyerek_elérhetőségek;
        }

        // PUT: api/Gyerek_elérhetőségek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGyerek_elérhetőségek(int id, Gyerek_elérhetőségek gyerek_elérhetőségek)
        {
            if (id != gyerek_elérhetőségek.elerhetosegAZ)
            {
                return BadRequest();
            }

            _context.Entry(gyerek_elérhetőségek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Gyerek_elérhetőségekExists(id))
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

        // POST: api/Gyerek_elérhetőségek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gyerek_elérhetőségek>> PostGyerek_elérhetőségek(Gyerek_elérhetőségek gyerek_elérhetőségek)
        {
            _context.Gyerek_Elérhetőségek.Add(gyerek_elérhetőségek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGyerek_elérhetőségek", new { id = gyerek_elérhetőségek.elerhetosegAZ }, gyerek_elérhetőségek);
        }

        // DELETE: api/Gyerek_elérhetőségek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGyerek_elérhetőségek(int id)
        {
            var gyerek_elérhetőségek = await _context.Gyerek_Elérhetőségek.FindAsync(id);
            if (gyerek_elérhetőségek == null)
            {
                return NotFound();
            }

            _context.Gyerek_Elérhetőségek.Remove(gyerek_elérhetőségek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Gyerek_elérhetőségekExists(int id)
        {
            return _context.Gyerek_Elérhetőségek.Any(e => e.elerhetosegAZ == id);
        }
    }
}
