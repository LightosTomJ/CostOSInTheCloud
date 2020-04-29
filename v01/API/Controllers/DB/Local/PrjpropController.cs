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
    public class PrjpropController : ControllerBase
    {
        private readonly LocalContext _context;

        public PrjpropController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Prjprop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrjProp>>> GetPrjprop()
        {
            return await _context.PrjProp.ToListAsync();
        }

        // GET: api/Prjprop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrjProp>> GetPrjprop(long id)
        {
            var prjprop = await _context.PrjProp.FindAsync(id);

            if (prjprop == null)
            {
                return NotFound();
            }

            return prjprop;
        }

        // PUT: api/Prjprop/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrjprop(long id, PrjProp prjprop)
        {
            if (id != prjprop.Id)
            {
                return BadRequest();
            }

            _context.Entry(prjprop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrjpropExists(id))
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

        // POST: api/Prjprop
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrjProp>> PostPrjprop(PrjProp prjprop)
        {
            _context.PrjProp.Add(prjprop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrjprop", new { id = prjprop.Id }, prjprop);
        }

        // DELETE: api/Prjprop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrjProp>> DeletePrjprop(long id)
        {
            var prjprop = await _context.PrjProp.FindAsync(id);
            if (prjprop == null)
            {
                return NotFound();
            }

            _context.PrjProp.Remove(prjprop);
            await _context.SaveChangesAsync();

            return prjprop;
        }

        private bool PrjpropExists(long id)
        {
            return _context.PrjProp.Any(e => e.Id == id);
        }
    }
}
