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
    public class AssemblyChildController : ControllerBase
    {
        private readonly localContext _context;

        public AssemblyChildController(localContext context)
        {
            _context = context;
        }

        // GET: api/AssemblyChild
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssemblyChild>>> GetAssemblyChild()
        {
            return await _context.AssemblyChild.ToListAsync();
        }

        // GET: api/AssemblyChild/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssemblyChild>> GetAssemblyChild(long id)
        {
            var assemblyChild = await _context.AssemblyChild.FindAsync(id);

            if (assemblyChild == null)
            {
                return NotFound();
            }

            return assemblyChild;
        }

        // PUT: api/AssemblyChild/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssemblyChild(long id, AssemblyChild assemblyChild)
        {
            if (id != assemblyChild.Assemblychildid)
            {
                return BadRequest();
            }

            _context.Entry(assemblyChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssemblyChildExists(id))
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

        // POST: api/AssemblyChild
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssemblyChild>> PostAssemblyChild(AssemblyChild assemblyChild)
        {
            _context.AssemblyChild.Add(assemblyChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssemblyChild", new { id = assemblyChild.Assemblychildid }, assemblyChild);
        }

        // DELETE: api/AssemblyChild/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssemblyChild>> DeleteAssemblyChild(long id)
        {
            var assemblyChild = await _context.AssemblyChild.FindAsync(id);
            if (assemblyChild == null)
            {
                return NotFound();
            }

            _context.AssemblyChild.Remove(assemblyChild);
            await _context.SaveChangesAsync();

            return assemblyChild;
        }

        private bool AssemblyChildExists(long id)
        {
            return _context.AssemblyChild.Any(e => e.Assemblychildid == id);
        }
    }
}
