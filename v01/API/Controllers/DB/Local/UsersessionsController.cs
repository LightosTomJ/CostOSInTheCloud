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
    public class UsersessionsController : ControllerBase
    {
        private readonly LocalContext _context;

        public UsersessionsController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Usersessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usersessions>>> GetUsersessions()
        {
            return await _context.Usersessions.ToListAsync();
        }

        // GET: api/Usersessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usersessions>> GetUsersessions(long id)
        {
            var usersessions = await _context.Usersessions.FindAsync(id);

            if (usersessions == null)
            {
                return NotFound();
            }

            return usersessions;
        }

        // PUT: api/Usersessions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersessions(long id, Usersessions usersessions)
        {
            if (id != usersessions.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersessions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersessionsExists(id))
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

        // POST: api/Usersessions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usersessions>> PostUsersessions(Usersessions usersessions)
        {
            _context.Usersessions.Add(usersessions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersessions", new { id = usersessions.Id }, usersessions);
        }

        // DELETE: api/Usersessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usersessions>> DeleteUsersessions(long id)
        {
            var usersessions = await _context.Usersessions.FindAsync(id);
            if (usersessions == null)
            {
                return NotFound();
            }

            _context.Usersessions.Remove(usersessions);
            await _context.SaveChangesAsync();

            return usersessions;
        }

        private bool UsersessionsExists(long id)
        {
            return _context.Usersessions.Any(e => e.Id == id);
        }
    }
}
