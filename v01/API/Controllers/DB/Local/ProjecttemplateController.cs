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
    public class ProjecttemplateController : ControllerBase
    {
        private readonly localContext _context;

        public ProjecttemplateController(localContext context)
        {
            _context = context;
        }

        // GET: api/Projecttemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projecttemplate>>> GetProjecttemplate()
        {
            return await _context.Projecttemplate.ToListAsync();
        }

        // GET: api/Projecttemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projecttemplate>> GetProjecttemplate(long id)
        {
            var projecttemplate = await _context.Projecttemplate.FindAsync(id);

            if (projecttemplate == null)
            {
                return NotFound();
            }

            return projecttemplate;
        }

        // PUT: api/Projecttemplate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjecttemplate(long id, Projecttemplate projecttemplate)
        {
            if (id != projecttemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(projecttemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjecttemplateExists(id))
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

        // POST: api/Projecttemplate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Projecttemplate>> PostProjecttemplate(Projecttemplate projecttemplate)
        {
            _context.Projecttemplate.Add(projecttemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjecttemplate", new { id = projecttemplate.Id }, projecttemplate);
        }

        // DELETE: api/Projecttemplate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projecttemplate>> DeleteProjecttemplate(long id)
        {
            var projecttemplate = await _context.Projecttemplate.FindAsync(id);
            if (projecttemplate == null)
            {
                return NotFound();
            }

            _context.Projecttemplate.Remove(projecttemplate);
            await _context.SaveChangesAsync();

            return projecttemplate;
        }

        private bool ProjecttemplateExists(long id)
        {
            return _context.Projecttemplate.Any(e => e.Id == id);
        }
    }
}
