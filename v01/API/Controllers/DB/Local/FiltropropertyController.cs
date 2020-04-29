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
    public class FiltropropertyController : ControllerBase
    {
        private readonly LocalContext _context;

        public FiltropropertyController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Filtroproperty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FiltroProperty>>> GetFiltroproperty()
        {
            return await _context.FiltroProperty.ToListAsync();
        }

        // GET: api/Filtroproperty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FiltroProperty>> GetFiltroproperty(long id)
        {
            var filtroproperty = await _context.FiltroProperty.FindAsync(id);

            if (filtroproperty == null)
            {
                return NotFound();
            }

            return filtroproperty;
        }

        // PUT: api/Filtroproperty/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiltroproperty(long id, FiltroProperty filtroproperty)
        {
            if (id != filtroproperty.Filtropropertyid)
            {
                return BadRequest();
            }

            _context.Entry(filtroproperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiltropropertyExists(id))
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

        // POST: api/Filtroproperty
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FiltroProperty>> PostFiltroproperty(FiltroProperty filtroproperty)
        {
            _context.FiltroProperty.Add(filtroproperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFiltroproperty", new { id = filtroproperty.Filtropropertyid }, filtroproperty);
        }

        // DELETE: api/Filtroproperty/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FiltroProperty>> DeleteFiltroproperty(long id)
        {
            var filtroproperty = await _context.FiltroProperty.FindAsync(id);
            if (filtroproperty == null)
            {
                return NotFound();
            }

            _context.FiltroProperty.Remove(filtroproperty);
            await _context.SaveChangesAsync();

            return filtroproperty;
        }

        private bool FiltropropertyExists(long id)
        {
            return _context.FiltroProperty.Any(e => e.Filtropropertyid == id);
        }
    }
}
