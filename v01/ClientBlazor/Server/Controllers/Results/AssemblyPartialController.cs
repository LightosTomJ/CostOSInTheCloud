using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Results;

namespace ClientBlazor.Server.Controllers.Results
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssemblyPartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public AssemblyPartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/AssemblyPartial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssemblyPartial>>> GetAssemblyPartial()
        {
            return await _context.AssemblyPartial.ToListAsync();
        }

        // GET: api/AssemblyPartial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssemblyPartial>> GetAssemblyPartial(int id)
        {
            var assemblyPartial = await _context.AssemblyPartial.FindAsync(id);

            if (assemblyPartial == null)
            {
                return NotFound();
            }

            return assemblyPartial;
        }

        // PUT: api/AssemblyPartial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssemblyPartial(int id, AssemblyPartial assemblyPartial)
        {
            if (id != assemblyPartial.Id)
            {
                return BadRequest();
            }

            _context.Entry(assemblyPartial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssemblyPartialExists(id))
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

        // POST: api/AssemblyPartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AssemblyPartial>> PostAssemblyPartial(AssemblyPartial assemblyPartial)
        {
            _context.AssemblyPartial.Add(assemblyPartial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssemblyPartialExists(assemblyPartial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssemblyPartial", new { id = assemblyPartial.Id }, assemblyPartial);
        }

        // DELETE: api/AssemblyPartial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssemblyPartial>> DeleteAssemblyPartial(int id)
        {
            var assemblyPartial = await _context.AssemblyPartial.FindAsync(id);
            if (assemblyPartial == null)
            {
                return NotFound();
            }

            _context.AssemblyPartial.Remove(assemblyPartial);
            await _context.SaveChangesAsync();

            return assemblyPartial;
        }

        private bool AssemblyPartialExists(int id)
        {
            return _context.AssemblyPartial.Any(e => e.Id == id);
        }
    }
}
