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
    public class AssemblySubcontractorController : ControllerBase
    {
        private readonly localContext _context;

        public AssemblySubcontractorController(localContext context)
        {
            _context = context;
        }

        // GET: api/AssemblySubcontractor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssemblySubcontractor>>> GetAssemblySubcontractor()
        {
            return await _context.AssemblySubcontractor.ToListAsync();
        }

        // GET: api/AssemblySubcontractor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssemblySubcontractor>> GetAssemblySubcontractor(long id)
        {
            var assemblySubcontractor = await _context.AssemblySubcontractor.FindAsync(id);

            if (assemblySubcontractor == null)
            {
                return NotFound();
            }

            return assemblySubcontractor;
        }

        // PUT: api/AssemblySubcontractor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssemblySubcontractor(long id, AssemblySubcontractor assemblySubcontractor)
        {
            if (id != assemblySubcontractor.Assemblysubcontractorid)
            {
                return BadRequest();
            }

            _context.Entry(assemblySubcontractor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssemblySubcontractorExists(id))
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

        // POST: api/AssemblySubcontractor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AssemblySubcontractor>> PostAssemblySubcontractor(AssemblySubcontractor assemblySubcontractor)
        {
            _context.AssemblySubcontractor.Add(assemblySubcontractor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssemblySubcontractor", new { id = assemblySubcontractor.Assemblysubcontractorid }, assemblySubcontractor);
        }

        // DELETE: api/AssemblySubcontractor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssemblySubcontractor>> DeleteAssemblySubcontractor(long id)
        {
            var assemblySubcontractor = await _context.AssemblySubcontractor.FindAsync(id);
            if (assemblySubcontractor == null)
            {
                return NotFound();
            }

            _context.AssemblySubcontractor.Remove(assemblySubcontractor);
            await _context.SaveChangesAsync();

            return assemblySubcontractor;
        }

        private bool AssemblySubcontractorExists(long id)
        {
            return _context.AssemblySubcontractor.Any(e => e.Assemblysubcontractorid == id);
        }
    }
}
