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
    public class PrjdbmsController : ControllerBase
    {
        private readonly LocalContext _context;

        public PrjdbmsController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Prjdbms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prjdbms>>> GetPrjdbms()
        {
            return await _context.Prjdbms.ToListAsync();
        }

        // GET: api/Prjdbms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prjdbms>> GetPrjdbms(long id)
        {
            var prjdbms = await _context.Prjdbms.FindAsync(id);

            if (prjdbms == null)
            {
                return NotFound();
            }

            return prjdbms;
        }

        // PUT: api/Prjdbms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrjdbms(long id, Prjdbms prjdbms)
        {
            if (id != prjdbms.Id)
            {
                return BadRequest();
            }

            _context.Entry(prjdbms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrjdbmsExists(id))
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

        // POST: api/Prjdbms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prjdbms>> PostPrjdbms(Prjdbms prjdbms)
        {
            _context.Prjdbms.Add(prjdbms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrjdbms", new { id = prjdbms.Id }, prjdbms);
        }

        // DELETE: api/Prjdbms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prjdbms>> DeletePrjdbms(long id)
        {
            var prjdbms = await _context.Prjdbms.FindAsync(id);
            if (prjdbms == null)
            {
                return NotFound();
            }

            _context.Prjdbms.Remove(prjdbms);
            await _context.SaveChangesAsync();

            return prjdbms;
        }

        private bool PrjdbmsExists(long id)
        {
            return _context.Prjdbms.Any(e => e.Id == id);
        }
    }
}
