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
    public class AssemblyLaborController : ControllerBase
    {
        private readonly localContext _context;

        public AssemblyLaborController(localContext context)
        {
            _context = context;
        }

        // GET: api/AssemblyLabor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssemblyLabor>>> GetAssemblyLabor()
        {
            return await _context.AssemblyLabor.ToListAsync();
        }

        // GET: api/AssemblyLabor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssemblyLabor>> GetAssemblyLabor(long id)
        {
            var assemblyLabor = await _context.AssemblyLabor.FindAsync(id);

            if (assemblyLabor == null)
            {
                return NotFound();
            }

            return assemblyLabor;
        }

        // PUT: api/AssemblyLabor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssemblyLabor(long id, AssemblyLabor assemblyLabor)
        {
            if (id != assemblyLabor.Assemblylaborid)
            {
                return BadRequest();
            }

            _context.Entry(assemblyLabor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssemblyLaborExists(id))
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

        // POST: api/AssemblyLabor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssemblyLabor>> PostAssemblyLabor(AssemblyLabor assemblyLabor)
        {
            _context.AssemblyLabor.Add(assemblyLabor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssemblyLabor", new { id = assemblyLabor.Assemblylaborid }, assemblyLabor);
        }

        // DELETE: api/AssemblyLabor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssemblyLabor>> DeleteAssemblyLabor(long id)
        {
            var assemblyLabor = await _context.AssemblyLabor.FindAsync(id);
            if (assemblyLabor == null)
            {
                return NotFound();
            }

            _context.AssemblyLabor.Remove(assemblyLabor);
            await _context.SaveChangesAsync();

            return assemblyLabor;
        }

        private bool AssemblyLaborExists(long id)
        {
            return _context.AssemblyLabor.Any(e => e.Assemblylaborid == id);
        }
    }
}
