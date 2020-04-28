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
    public class AlcGroupsController : ControllerBase
    {
        private readonly LocalContext _context;

        public AlcGroupsController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/AlcGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlcGroups>>> GetAlcGroups()
        {
            return await _context.AlcGroups.ToListAsync();
        }

        // GET: api/AlcGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlcGroups>> GetAlcGroups(Guid id)
        {
            var alcGroups = await _context.AlcGroups.FindAsync(id);

            if (alcGroups == null)
            {
                return NotFound();
            }

            return alcGroups;
        }

        // PUT: api/AlcGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcGroups(Guid id, AlcGroups alcGroups)
        {
            if (id != alcGroups.Id)
            {
                return BadRequest();
            }

            _context.Entry(alcGroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcGroupsExists(id))
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

        // POST: api/AlcGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlcGroups>> PostAlcGroups(AlcGroups alcGroups)
        {
            _context.AlcGroups.Add(alcGroups);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlcGroupsExists(alcGroups.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlcGroups", new { id = alcGroups.Id }, alcGroups);
        }

        // DELETE: api/AlcGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlcGroups>> DeleteAlcGroups(Guid id)
        {
            var alcGroups = await _context.AlcGroups.FindAsync(id);
            if (alcGroups == null)
            {
                return NotFound();
            }

            _context.AlcGroups.Remove(alcGroups);
            await _context.SaveChangesAsync();

            return alcGroups;
        }

        private bool AlcGroupsExists(Guid id)
        {
            return _context.AlcGroups.Any(e => e.Id == id);
        }
    }
}
