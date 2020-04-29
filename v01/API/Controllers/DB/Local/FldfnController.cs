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
    public class FldfnController : ControllerBase
    {
        private readonly LocalContext _context;

        public FldfnController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Fldfn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FldFn>>> GetFldfn()
        {
            return await _context.FldFn.ToListAsync();
        }

        // GET: api/Fldfn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FldFn>> GetFldfn(long id)
        {
            var fldfn = await _context.FldFn.FindAsync(id);

            if (fldfn == null)
            {
                return NotFound();
            }

            return fldfn;
        }

        // PUT: api/Fldfn/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFldfn(long id, FldFn fldfn)
        {
            if (id != fldfn.Fldfnid)
            {
                return BadRequest();
            }

            _context.Entry(fldfn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FldfnExists(id))
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

        // POST: api/Fldfn
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FldFn>> PostFldfn(FldFn fldfn)
        {
            _context.FldFn.Add(fldfn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFldfn", new { id = fldfn.Fldfnid }, fldfn);
        }

        // DELETE: api/Fldfn/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FldFn>> DeleteFldfn(long id)
        {
            var fldfn = await _context.FldFn.FindAsync(id);
            if (fldfn == null)
            {
                return NotFound();
            }

            _context.FldFn.Remove(fldfn);
            await _context.SaveChangesAsync();

            return fldfn;
        }

        private bool FldfnExists(long id)
        {
            return _context.FldFn.Any(e => e.Fldfnid == id);
        }
    }
}
