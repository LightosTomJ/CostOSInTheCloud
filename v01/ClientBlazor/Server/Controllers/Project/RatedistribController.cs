using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;

namespace ClientBlazor.Server.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatedistribController : ControllerBase
    {
        private readonly projectContext _context;

        public RatedistribController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Ratedistrib
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ratedistrib>>> GetRatedistrib()
        {
            return await _context.Ratedistrib.ToListAsync();
        }

        // GET: api/Ratedistrib/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ratedistrib>> GetRatedistrib(long id)
        {
            var ratedistrib = await _context.Ratedistrib.FindAsync(id);

            if (ratedistrib == null)
            {
                return NotFound();
            }

            return ratedistrib;
        }

        // PUT: api/Ratedistrib/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatedistrib(long id, Ratedistrib ratedistrib)
        {
            if (id != ratedistrib.Id)
            {
                return BadRequest();
            }

            _context.Entry(ratedistrib).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatedistribExists(id))
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

        // POST: api/Ratedistrib
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Ratedistrib>> PostRatedistrib(Ratedistrib ratedistrib)
        {
            _context.Ratedistrib.Add(ratedistrib);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatedistrib", new { id = ratedistrib.Id }, ratedistrib);
        }

        // DELETE: api/Ratedistrib/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ratedistrib>> DeleteRatedistrib(long id)
        {
            var ratedistrib = await _context.Ratedistrib.FindAsync(id);
            if (ratedistrib == null)
            {
                return NotFound();
            }

            _context.Ratedistrib.Remove(ratedistrib);
            await _context.SaveChangesAsync();

            return ratedistrib;
        }

        private bool RatedistribExists(long id)
        {
            return _context.Ratedistrib.Any(e => e.Id == id);
        }
    }
}
