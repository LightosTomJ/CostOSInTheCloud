using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace ClientBlazor.Server.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserpropController : ControllerBase
    {
        private readonly localContext _context;

        public UserpropController(localContext context)
        {
            _context = context;
        }

        // GET: api/Userprop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userprop>>> GetUserprop()
        {
            return await _context.Userprop.ToListAsync();
        }

        // GET: api/Userprop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userprop>> GetUserprop(long id)
        {
            var userprop = await _context.Userprop.FindAsync(id);

            if (userprop == null)
            {
                return NotFound();
            }

            return userprop;
        }

        // PUT: api/Userprop/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserprop(long id, Userprop userprop)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Userprop>> PostUserprop(Userprop userprop)
        {
            _context.Userprop.Add(userprop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserprop", new { id = userprop.Id }, userprop);
        }

        // DELETE: api/Userprop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Userprop>> DeleteUserprop(long id)
        {
            var userprop = await _context.Userprop.FindAsync(id);
            if (userprop == null)
            {
                return NotFound();
            }

            _context.Userprop.Remove(userprop);
            await _context.SaveChangesAsync();

            return userprop;
        }

        private bool UserpropExists(long id)
        {
            return _context.Userprop.Any(e => e.Id == id);
        }
    }
}
