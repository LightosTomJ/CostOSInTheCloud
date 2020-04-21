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
    public class AssemblyConsumableController : ControllerBase
    {
        private readonly localContext _context;

        public AssemblyConsumableController(localContext context)
        {
            _context = context;
        }

        // GET: api/AssemblyConsumable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssemblyConsumable>>> GetAssemblyConsumable()
        {
            return await _context.AssemblyConsumable.ToListAsync();
        }

        // GET: api/AssemblyConsumable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssemblyConsumable>> GetAssemblyConsumable(long id)
        {
            var assemblyConsumable = await _context.AssemblyConsumable.FindAsync(id);

            if (assemblyConsumable == null)
            {
                return NotFound();
            }

            return assemblyConsumable;
        }

        // PUT: api/AssemblyConsumable/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssemblyConsumable(long id, AssemblyConsumable assemblyConsumable)
        {
            if (id != assemblyConsumable.Assemblyconsumableid)
            {
                return BadRequest();
            }

            _context.Entry(assemblyConsumable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssemblyConsumableExists(id))
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

        // POST: api/AssemblyConsumable
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssemblyConsumable>> PostAssemblyConsumable(AssemblyConsumable assemblyConsumable)
        {
            _context.AssemblyConsumable.Add(assemblyConsumable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssemblyConsumable", new { id = assemblyConsumable.Assemblyconsumableid }, assemblyConsumable);
        }

        // DELETE: api/AssemblyConsumable/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssemblyConsumable>> DeleteAssemblyConsumable(long id)
        {
            var assemblyConsumable = await _context.AssemblyConsumable.FindAsync(id);
            if (assemblyConsumable == null)
            {
                return NotFound();
            }

            _context.AssemblyConsumable.Remove(assemblyConsumable);
            await _context.SaveChangesAsync();

            return assemblyConsumable;
        }

        private bool AssemblyConsumableExists(long id)
        {
            return _context.AssemblyConsumable.Any(e => e.Assemblyconsumableid == id);
        }
    }
}
