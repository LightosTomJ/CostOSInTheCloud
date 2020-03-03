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
    public class AssemblyMaterialController : ControllerBase
    {
        private readonly projectContext _context;

        public AssemblyMaterialController(projectContext context)
        {
            _context = context;
        }

        // GET: api/AssemblyMaterial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssemblyMaterial>>> GetAssemblyMaterial()
        {
            return await _context.AssemblyMaterial.ToListAsync();
        }

        // GET: api/AssemblyMaterial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssemblyMaterial>> GetAssemblyMaterial(long id)
        {
            var assemblyMaterial = await _context.AssemblyMaterial.FindAsync(id);

            if (assemblyMaterial == null)
            {
                return NotFound();
            }

            return assemblyMaterial;
        }

        // PUT: api/AssemblyMaterial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssemblyMaterial(long id, AssemblyMaterial assemblyMaterial)
        {
            if (id != assemblyMaterial.Assemblymaterialid)
            {
                return BadRequest();
            }

            _context.Entry(assemblyMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssemblyMaterialExists(id))
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

        // POST: api/AssemblyMaterial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AssemblyMaterial>> PostAssemblyMaterial(AssemblyMaterial assemblyMaterial)
        {
            _context.AssemblyMaterial.Add(assemblyMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssemblyMaterial", new { id = assemblyMaterial.Assemblymaterialid }, assemblyMaterial);
        }

        // DELETE: api/AssemblyMaterial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssemblyMaterial>> DeleteAssemblyMaterial(long id)
        {
            var assemblyMaterial = await _context.AssemblyMaterial.FindAsync(id);
            if (assemblyMaterial == null)
            {
                return NotFound();
            }

            _context.AssemblyMaterial.Remove(assemblyMaterial);
            await _context.SaveChangesAsync();

            return assemblyMaterial;
        }

        private bool AssemblyMaterialExists(long id)
        {
            return _context.AssemblyMaterial.Any(e => e.Assemblymaterialid == id);
        }
    }
}
