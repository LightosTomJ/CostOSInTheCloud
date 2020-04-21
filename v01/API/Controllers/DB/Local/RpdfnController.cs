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
    public class RpdfnController : ControllerBase
    {
        private readonly localContext _context;

        public RpdfnController(localContext context)
        {
            _context = context;
        }

        // GET: api/Rpdfn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rpdfn>>> GetRpdfn()
        {
            return await _context.Rpdfn.ToListAsync();
        }

        // GET: api/Rpdfn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rpdfn>> GetRpdfn(long id)
        {
            var rpdfn = await _context.Rpdfn.FindAsync(id);

            if (rpdfn == null)
            {
                return NotFound();
            }

            return rpdfn;
        }

        // PUT: api/Rpdfn/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRpdfn(long id, Rpdfn rpdfn)
        {
            if (id != rpdfn.Rpdfnid)
            {
                return BadRequest();
            }

            _context.Entry(rpdfn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RpdfnExists(id))
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

        // POST: api/Rpdfn
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rpdfn>> PostRpdfn(Rpdfn rpdfn)
        {
            _context.Rpdfn.Add(rpdfn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRpdfn", new { id = rpdfn.Rpdfnid }, rpdfn);
        }

        // DELETE: api/Rpdfn/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rpdfn>> DeleteRpdfn(long id)
        {
            var rpdfn = await _context.Rpdfn.FindAsync(id);
            if (rpdfn == null)
            {
                return NotFound();
            }

            _context.Rpdfn.Remove(rpdfn);
            await _context.SaveChangesAsync();

            return rpdfn;
        }

        private bool RpdfnExists(long id)
        {
            return _context.Rpdfn.Any(e => e.Rpdfnid == id);
        }
    }
}
