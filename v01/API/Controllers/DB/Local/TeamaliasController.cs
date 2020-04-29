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
        private readonly LocalContext _context;

        public TeamaliasController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Teamalias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamAlias>>> GetTeamalias()
        {
            return await _context.TeamAlias.ToListAsync();
        }

        // GET: api/Teamalias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamAlias>> GetTeamalias(long id)
        {
            var teamalias = await _context.TeamAlias.FindAsync(id);

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
        public async Task<IActionResult> PutTeamalias(long id, TeamAlias teamalias)
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
        public async Task<ActionResult<TeamAlias>> PostTeamalias(TeamAlias teamalias)
        {
            _context.TeamAlias.Add(teamalias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamalias", new { id = teamalias.Id }, teamalias);
        }

        // DELETE: api/Teamalias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeamAlias>> DeleteTeamalias(long id)
        {
            var teamalias = await _context.TeamAlias.FindAsync(id);
            if (teamalias == null)
            {
                return NotFound();
            }

            _context.TeamAlias.Remove(teamalias);
            await _context.SaveChangesAsync();

            return teamalias;
        }

        private bool TeamaliasExists(long id)
        {
            return _context.TeamAlias.Any(e => e.Id == id);
        }
    }
}
