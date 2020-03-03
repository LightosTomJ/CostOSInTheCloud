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
    public class BcGrouppropController : ControllerBase
    {
        private readonly localContext _context;

        public BcGrouppropController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcGroupprop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcGroupprop>>> GetBcGroupprop()
        {
            return await _context.BcGroupprop.ToListAsync();
        }

        // GET: api/BcGroupprop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcGroupprop>> GetBcGroupprop(long id)
        {
            var bcGroupprop = await _context.BcGroupprop.FindAsync(id);

            if (bcGroupprop == null)
            {
                return NotFound();
            }

            return bcGroupprop;
        }

        // PUT: api/BcGroupprop/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcGroupprop(long id, BcGroupprop bcGroupprop)
        {
            if (id != bcGroupprop.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcGroupprop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcGrouppropExists(id))
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

        // POST: api/BcGroupprop
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcGroupprop>> PostBcGroupprop(BcGroupprop bcGroupprop)
        {
            _context.BcGroupprop.Add(bcGroupprop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcGroupprop", new { id = bcGroupprop.Id }, bcGroupprop);
        }

        // DELETE: api/BcGroupprop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcGroupprop>> DeleteBcGroupprop(long id)
        {
            var bcGroupprop = await _context.BcGroupprop.FindAsync(id);
            if (bcGroupprop == null)
            {
                return NotFound();
            }

            _context.BcGroupprop.Remove(bcGroupprop);
            await _context.SaveChangesAsync();

            return bcGroupprop;
        }

        private bool BcGrouppropExists(long id)
        {
            return _context.BcGroupprop.Any(e => e.Id == id);
        }
    }
}
