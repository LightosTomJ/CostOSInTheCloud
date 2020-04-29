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
    public class BcGrouppropController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcGrouppropController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcGroupprop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcGroupProp>>> GetBcGroupprop()
        {
            return await _context.BcGroupProp.ToListAsync();
        }

        // GET: api/BcGroupprop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcGroupProp>> GetBcGroupprop(long id)
        {
            var bcGroupprop = await _context.BcGroupProp.FindAsync(id);

            if (bcGroupprop == null)
            {
                return NotFound();
            }

            return bcGroupprop;
        }

        // PUT: api/BcGroupprop/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcGroupprop(long id, BcGroupProp bcGroupprop)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcGroupProp>> PostBcGroupprop(BcGroupProp bcGroupprop)
        {
            _context.BcGroupProp.Add(bcGroupprop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcGroupprop", new { id = bcGroupprop.Id }, bcGroupprop);
        }

        // DELETE: api/BcGroupprop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcGroupProp>> DeleteBcGroupprop(long id)
        {
            var bcGroupprop = await _context.BcGroupProp.FindAsync(id);
            if (bcGroupprop == null)
            {
                return NotFound();
            }

            _context.BcGroupProp.Remove(bcGroupprop);
            await _context.SaveChangesAsync();

            return bcGroupprop;
        }

        private bool BcGrouppropExists(long id)
        {
            return _context.BcGroupProp.Any(e => e.Id == id);
        }
    }
}
