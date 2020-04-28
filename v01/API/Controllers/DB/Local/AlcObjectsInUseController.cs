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
    public class AlcObjectsInUseController : ControllerBase
    {
        private readonly LocalContext _context;

        public AlcObjectsInUseController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/AlcObjectsInUse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlcObjectsInUse>>> GetAlcObjectsInUse()
        {
            return await _context.AlcObjectsInUse.ToListAsync();
        }

        // GET: api/AlcObjectsInUse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlcObjectsInUse>> GetAlcObjectsInUse(string id)
        {
            var alcObjectsInUse = await _context.AlcObjectsInUse.FindAsync(id);

            if (alcObjectsInUse == null)
            {
                return NotFound();
            }

            return alcObjectsInUse;
        }

        // PUT: api/AlcObjectsInUse/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcObjectsInUse(string id, AlcObjectsInUse alcObjectsInUse)
        {
            if (id != alcObjectsInUse.ObjId)
            {
                return BadRequest();
            }

            _context.Entry(alcObjectsInUse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcObjectsInUseExists(id))
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

        // POST: api/AlcObjectsInUse
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlcObjectsInUse>> PostAlcObjectsInUse(AlcObjectsInUse alcObjectsInUse)
        {
            _context.AlcObjectsInUse.Add(alcObjectsInUse);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlcObjectsInUseExists(alcObjectsInUse.ObjId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlcObjectsInUse", new { id = alcObjectsInUse.ObjId }, alcObjectsInUse);
        }

        // DELETE: api/AlcObjectsInUse/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlcObjectsInUse>> DeleteAlcObjectsInUse(string id)
        {
            var alcObjectsInUse = await _context.AlcObjectsInUse.FindAsync(id);
            if (alcObjectsInUse == null)
            {
                return NotFound();
            }

            _context.AlcObjectsInUse.Remove(alcObjectsInUse);
            await _context.SaveChangesAsync();

            return alcObjectsInUse;
        }

        private bool AlcObjectsInUseExists(string id)
        {
            return _context.AlcObjectsInUse.Any(e => e.ObjId == id);
        }
    }
}
