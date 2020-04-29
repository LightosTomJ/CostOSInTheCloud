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
    public class UserpropController : ControllerBase
    {
        private readonly LocalContext _context;

        public UserpropController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Userprop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProp>>> GetUserprop()
        {
            return await _context.UserProp.ToListAsync();
        }

        // GET: api/Userprop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProp>> GetUserprop(long id)
        {
            var userprop = await _context.UserProp.FindAsync(id);

            if (userprop == null)
            {
                return NotFound();
            }

            return userprop;
        }

        // PUT: api/Userprop/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserprop(long id, UserProp userprop)
        {
            if (id != userprop.Id)
            {
                return BadRequest();
            }

            _context.Entry(userprop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserpropExists(id))
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

        // POST: api/Userprop
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserProp>> PostUserprop(UserProp userprop)
        {
            _context.UserProp.Add(userprop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserprop", new { id = userprop.Id }, userprop);
        }

        // DELETE: api/Userprop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserProp>> DeleteUserprop(long id)
        {
            var userprop = await _context.UserProp.FindAsync(id);
            if (userprop == null)
            {
                return NotFound();
            }

            _context.UserProp.Remove(userprop);
            await _context.SaveChangesAsync();

            return userprop;
        }

        private bool UserpropExists(long id)
        {
            return _context.UserProp.Any(e => e.Id == id);
        }
    }
}
