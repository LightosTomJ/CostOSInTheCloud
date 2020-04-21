using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace API.Controllers.DB.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlcUlController : ControllerBase
    {
        private readonly localContext _context;

        public AlcUlController(localContext context)
        {
            _context = context;
        }

        // GET: api/AlcUl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlcUl>>> GetAlcUl()
        {
            return await _context.AlcUl.ToListAsync();
        }

        // GET: api/AlcUl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlcUl>> GetAlcUl(Guid id)
        {
            var alcUl = await _context.AlcUl.FindAsync(id);

            if (alcUl == null)
            {
                return NotFound();
            }

            return alcUl;
        }

        // PUT: api/AlcUl/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcUl(Guid id, AlcUl alcUl)
        {
            if (id != alcUl.Ulgid)
            {
                return BadRequest();
            }

            _context.Entry(alcUl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcUlExists(id))
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

        // POST: api/AlcUl
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlcUl>> PostAlcUl(AlcUl alcUl)
        {
            _context.AlcUl.Add(alcUl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlcUlExists(alcUl.Ulgid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlcUl", new { id = alcUl.Ulgid }, alcUl);
        }

        // DELETE: api/AlcUl/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlcUl>> DeleteAlcUl(Guid id)
        {
            var alcUl = await _context.AlcUl.FindAsync(id);
            if (alcUl == null)
            {
                return NotFound();
            }

            _context.AlcUl.Remove(alcUl);
            await _context.SaveChangesAsync();

            return alcUl;
        }

        private bool AlcUlExists(Guid id)
        {
            return _context.AlcUl.Any(e => e.Ulgid == id);
        }
    }
}
