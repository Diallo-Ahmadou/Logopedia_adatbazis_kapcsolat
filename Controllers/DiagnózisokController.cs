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
    public class DiagnózisokController : ControllerBase
    {
        private readonly LogopédiaContext _context;

        public DiagnózisokController(LogopédiaContext context)
        {
            _context = context;
        }

        // GET: api/Diagnózisok
        [HttpGet]
        [Route("api/Diagnózisok")]
        public async Task<ActionResult<IEnumerable<Diagnózisok>>> GetDiagnózisok()
        {
            return await _context.Diagnózisok.ToListAsync();
        }

        // GET: api/Diagnózisok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diagnózisok>> GetDiagnózisok(int id)
        {
            var diagnózisok = await _context.Diagnózisok.FindAsync(id);

            if (diagnózisok == null)
            {
                return NotFound();
            }

            return diagnózisok;
        }

        // PUT: api/Diagnózisok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnózisok(int id, Diagnózisok diagnózisok)
        {
            if (id != diagnózisok.diagnozisAZ)
            {
                return BadRequest();
            }

            _context.Entry(diagnózisok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnózisokExists(id))
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

        // POST: api/Diagnózisok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diagnózisok>> PostDiagnózisok(Diagnózisok diagnózisok)
        {
            _context.Diagnózisok.Add(diagnózisok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiagnózisok", new { id = diagnózisok.diagnozisAZ }, diagnózisok);
        }

        // DELETE: api/Diagnózisok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnózisok(int id)
        {
            var diagnózisok = await _context.Diagnózisok.FindAsync(id);
            if (diagnózisok == null)
            {
                return NotFound();
            }

            _context.Diagnózisok.Remove(diagnózisok);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiagnózisokExists(int id)
        {
            return _context.Diagnózisok.Any(e => e.diagnozisAZ == id);
        }
    }
}
