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
    public class AssemblyController : ControllerBase
    {
        private readonly LocalContext _context;

        public AssemblyController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Assembly
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assembly>>> GetAssembly()
        {
            return await _context.Assembly.ToListAsync();
        }

        // GET: api/Assembly/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assembly>> GetAssembly(long id)
        {
            var @assembly = await _context.Assembly.FindAsync(id);

            if (@assembly == null)
            {
                return NotFound();
            }

            return @assembly;
        }

        // PUT: api/Assembly/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssembly(long id, Assembly @assembly)
        {
            if (id != @assembly.Assemblyid)
            {
                return BadRequest();
            }

            _context.Entry(@assembly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssemblyExists(id))
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

        // POST: api/Assembly
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Assembly>> PostAssembly(Assembly @assembly)
        {
            _context.Assembly.Add(@assembly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssembly", new { id = @assembly.Assemblyid }, @assembly);
        }

        // DELETE: api/Assembly/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Assembly>> DeleteAssembly(long id)
        {
            var @assembly = await _context.Assembly.FindAsync(id);
            if (@assembly == null)
            {
                return NotFound();
            }

            _context.Assembly.Remove(@assembly);
            await _context.SaveChangesAsync();

            return @assembly;
        }

        private bool AssemblyExists(long id)
        {
            return _context.Assembly.Any(e => e.Assemblyid == id);
        }
    }
}
