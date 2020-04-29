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
    public class AlcAmusersController : ControllerBase
    {
        private readonly LocalContext _context;

        public AlcAmusersController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/AlcAmusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlcAmUsers>>> GetAlcAmusers()
        {
            return await _context.AlcAmUsers.ToListAsync();
        }

        // GET: api/AlcAmusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlcAmUsers>> GetAlcAmusers(Guid id)
        {
            var alcAmusers = await _context.AlcAmUsers.FindAsync(id);

            if (alcAmusers == null)
            {
                return NotFound();
            }

            return alcAmusers;
        }

        // PUT: api/AlcAmusers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcAmusers(Guid id, AlcAmUsers alcAmusers)
        {
            if (id != alcAmusers.UserGid)
            {
                return BadRequest();
            }

            _context.Entry(alcAmusers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcAmusersExists(id))
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

        // POST: api/AlcAmusers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlcAmUsers>> PostAlcAmusers(AlcAmUsers alcAmusers)
        {
            _context.AlcAmUsers.Add(alcAmusers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlcAmusersExists(alcAmusers.UserGid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlcAmusers", new { id = alcAmusers.UserGid }, alcAmusers);
        }

        // DELETE: api/AlcAmusers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlcAmUsers>> DeleteAlcAmusers(Guid id)
        {
            var alcAmusers = await _context.AlcAmUsers.FindAsync(id);
            if (alcAmusers == null)
            {
                return NotFound();
            }

            _context.AlcAmUsers.Remove(alcAmusers);
            await _context.SaveChangesAsync();

            return alcAmusers;
        }

        private bool AlcAmusersExists(Guid id)
        {
            return _context.AlcAmUsers.Any(e => e.UserGid == id);
        }
    }
}
