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
        private readonly LocalContext _context;

        public ProjecttemplateController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Projecttemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTemplate>>> GetProjecttemplate()
        {
            return await _context.ProjectTemplate.ToListAsync();
        }

        // GET: api/Projecttemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTemplate>> GetProjecttemplate(long id)
        {
            var projecttemplate = await _context.ProjectTemplate.FindAsync(id);

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
        public async Task<IActionResult> PutProjecttemplate(long id, ProjectTemplate projecttemplate)
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
        public async Task<ActionResult<ProjectTemplate>> PostProjecttemplate(ProjectTemplate projecttemplate)
        {
            _context.ProjectTemplate.Add(projecttemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjecttemplate", new { id = projecttemplate.Id }, projecttemplate);
        }

        // DELETE: api/Projecttemplate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectTemplate>> DeleteProjecttemplate(long id)
        {
            var projecttemplate = await _context.ProjectTemplate.FindAsync(id);
            if (projecttemplate == null)
            {
                return NotFound();
            }

            _context.ProjectTemplate.Remove(projecttemplate);
            await _context.SaveChangesAsync();

            return projecttemplate;
        }

        private bool ProjecttemplateExists(long id)
        {
            return _context.ProjectTemplate.Any(e => e.Id == id);
        }
    }
}
