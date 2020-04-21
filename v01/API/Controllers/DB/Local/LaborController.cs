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
    public class LaborController : ControllerBase
    {
        private readonly localContext _context;

        public LaborController(localContext context)
        {
            _context = context;
        }

        // GET: api/Labor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Labor>>> GetLabor()
        {
            return await _context.Labor.ToListAsync();
        }

        // GET: api/Labor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Labor>> GetLabor(long id)
        {
            var labor = await _context.Labor.FindAsync(id);

            if (labor == null)
            {
                return NotFound();
            }

            return labor;
        }

        // PUT: api/Labor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabor(long id, Labor labor)
        {
            if (id != labor.Laborid)
            {
                return BadRequest();
            }

            _context.Entry(labor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaborExists(id))
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

        // POST: api/Labor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Labor>> PostLabor(Labor labor)
        {
            _context.Labor.Add(labor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabor", new { id = labor.Laborid }, labor);
        }

        // DELETE: api/Labor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Labor>> DeleteLabor(long id)
        {
            var labor = await _context.Labor.FindAsync(id);
            if (labor == null)
            {
                return NotFound();
            }

            _context.Labor.Remove(labor);
            await _context.SaveChangesAsync();

            return labor;
        }

        private bool LaborExists(long id)
        {
            return _context.Labor.Any(e => e.Laborid == id);
        }
    }
}
