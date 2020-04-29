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
    public class ProjectusertemplateController : ControllerBase
    {
        private readonly LocalContext _context;

        public ProjectusertemplateController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Projectusertemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectUserTemplate>>> GetProjectusertemplate()
        {
            return await _context.ProjectUserTemplate.ToListAsync();
        }

        // GET: api/Projectusertemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectUserTemplate>> GetProjectusertemplate(long id)
        {
            var projectusertemplate = await _context.ProjectUserTemplate.FindAsync(id);

            if (projectusertemplate == null)
            {
                return NotFound();
            }

            return projectusertemplate;
        }

        // PUT: api/Projectusertemplate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectusertemplate(long id, ProjectUserTemplate projectusertemplate)
        {
            if (id != projectusertemplate.Templateid)
            {
                return BadRequest();
            }

            _context.Entry(projectusertemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectusertemplateExists(id))
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

        // POST: api/Projectusertemplate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectUserTemplate>> PostProjectusertemplate(ProjectUserTemplate projectusertemplate)
        {
            _context.ProjectUserTemplate.Add(projectusertemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectusertemplate", new { id = projectusertemplate.Templateid }, projectusertemplate);
        }

        // DELETE: api/Projectusertemplate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectUserTemplate>> DeleteProjectusertemplate(long id)
        {
            var projectusertemplate = await _context.ProjectUserTemplate.FindAsync(id);
            if (projectusertemplate == null)
            {
                return NotFound();
            }

            _context.ProjectUserTemplate.Remove(projectusertemplate);
            await _context.SaveChangesAsync();

            return projectusertemplate;
        }

        private bool ProjectusertemplateExists(long id)
        {
            return _context.ProjectUserTemplate.Any(e => e.Templateid == id);
        }
    }
}
