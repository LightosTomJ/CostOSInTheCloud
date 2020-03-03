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
    public class GlbpropController : ControllerBase
    {
        private readonly localContext _context;

        public GlbpropController(localContext context)
        {
            _context = context;
        }

        // GET: api/Glbprop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Glbprop>>> GetGlbprop()
        {
            return await _context.Glbprop.ToListAsync();
        }

        // GET: api/Glbprop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Glbprop>> GetGlbprop(long id)
        {
            var glbprop = await _context.Glbprop.FindAsync(id);

            if (glbprop == null)
            {
                return NotFound();
            }

            return glbprop;
        }

        // PUT: api/Glbprop/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlbprop(long id, Glbprop glbprop)
        {
            if (id != glbprop.Id)
            {
                return BadRequest();
            }

            _context.Entry(glbprop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlbpropExists(id))
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

        // POST: api/Glbprop
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Glbprop>> PostGlbprop(Glbprop glbprop)
        {
            _context.Glbprop.Add(glbprop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGlbprop", new { id = glbprop.Id }, glbprop);
        }

        // DELETE: api/Glbprop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Glbprop>> DeleteGlbprop(long id)
        {
            var glbprop = await _context.Glbprop.FindAsync(id);
            if (glbprop == null)
            {
                return NotFound();
            }

            _context.Glbprop.Remove(glbprop);
            await _context.SaveChangesAsync();

            return glbprop;
        }

        private bool GlbpropExists(long id)
        {
            return _context.Glbprop.Any(e => e.Id == id);
        }
    }
}