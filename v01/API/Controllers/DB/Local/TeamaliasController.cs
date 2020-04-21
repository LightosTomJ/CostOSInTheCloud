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
    public class TeamaliasController : ControllerBase
    {
        private readonly localContext _context;

        public TeamaliasController(localContext context)
        {
            _context = context;
        }

        // GET: api/Teamalias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teamalias>>> GetTeamalias()
        {
            return await _context.Teamalias.ToListAsync();
        }

        // GET: api/Teamalias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teamalias>> GetTeamalias(long id)
        {
            var teamalias = await _context.Teamalias.FindAsync(id);

            if (teamalias == null)
            {
                return NotFound();
            }

            return teamalias;
        }

        // PUT: api/Teamalias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamalias(long id, Teamalias teamalias)
        {
            if (id != teamalias.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamalias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamaliasExists(id))
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

        // POST: api/Teamalias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teamalias>> PostTeamalias(Teamalias teamalias)
        {
            _context.Teamalias.Add(teamalias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamalias", new { id = teamalias.Id }, teamalias);
        }

        // DELETE: api/Teamalias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teamalias>> DeleteTeamalias(long id)
        {
            var teamalias = await _context.Teamalias.FindAsync(id);
            if (teamalias == null)
            {
                return NotFound();
            }

            _context.Teamalias.Remove(teamalias);
            await _context.SaveChangesAsync();

            return teamalias;
        }

        private bool TeamaliasExists(long id)
        {
            return _context.Teamalias.Any(e => e.Id == id);
        }
    }
}
