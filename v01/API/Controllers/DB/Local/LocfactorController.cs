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
    public class LocfactorController : ControllerBase
    {
        private readonly LocalContext _context;

        public LocfactorController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Locfactor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocFactor>>> GetLocfactor()
        {
            return await _context.LocFactor.ToListAsync();
        }

        // GET: api/Locfactor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocFactor>> GetLocfactor(long id)
        {
            var locfactor = await _context.LocFactor.FindAsync(id);

            if (locfactor == null)
            {
                return NotFound();
            }

            return locfactor;
        }

        // PUT: api/Locfactor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocfactor(long id, LocFactor locfactor)
        {
            if (id != locfactor.Lfid)
            {
                return BadRequest();
            }

            _context.Entry(locfactor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocfactorExists(id))
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

        // POST: api/Locfactor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LocFactor>> PostLocfactor(LocFactor locfactor)
        {
            _context.LocFactor.Add(locfactor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocfactor", new { id = locfactor.Lfid }, locfactor);
        }

        // DELETE: api/Locfactor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LocFactor>> DeleteLocfactor(long id)
        {
            var locfactor = await _context.LocFactor.FindAsync(id);
            if (locfactor == null)
            {
                return NotFound();
            }

            _context.LocFactor.Remove(locfactor);
            await _context.SaveChangesAsync();

            return locfactor;
        }

        private bool LocfactorExists(long id)
        {
            return _context.LocFactor.Any(e => e.Lfid == id);
        }
    }
}
