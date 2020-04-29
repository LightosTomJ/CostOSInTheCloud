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
    public class ProjectepsController : ControllerBase
    {
        private readonly LocalContext _context;

        public ProjectepsController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Projecteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectEPS>>> GetProjecteps()
        {
            return await _context.ProjectEPS.ToListAsync();
        }

        // GET: api/Projecteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEPS>> GetProjecteps(long id)
        {
            var projecteps = await _context.ProjectEPS.FindAsync(id);

            if (projecteps == null)
            {
                return NotFound();
            }

            return projecteps;
        }

        // PUT: api/Projecteps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjecteps(long id, ProjectEPS projecteps)
        {
            if (id != projecteps.Projectepsid)
            {
                return BadRequest();
            }

            _context.Entry(projecteps).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectepsExists(id))
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

        // POST: api/Projecteps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectEPS>> PostProjecteps(ProjectEPS projecteps)
        {
            _context.ProjectEPS.Add(projecteps);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjecteps", new { id = projecteps.Projectepsid }, projecteps);
        }

        // DELETE: api/Projecteps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectEPS>> DeleteProjecteps(long id)
        {
            var projecteps = await _context.ProjectEPS.FindAsync(id);
            if (projecteps == null)
            {
                return NotFound();
            }

            _context.ProjectEPS.Remove(projecteps);
            await _context.SaveChangesAsync();

            return projecteps;
        }

        private bool ProjectepsExists(long id)
        {
            return _context.ProjectEPS.Any(e => e.Projectepsid == id);
        }
    }
}
