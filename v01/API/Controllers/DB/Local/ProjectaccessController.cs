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
    public class ProjectaccessController : ControllerBase
    {
        private readonly LocalContext _context;

        public ProjectaccessController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Projectaccess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectAccess>>> GetProjectaccess()
        {
            return await _context.ProjectAccess.ToListAsync();
        }

        // GET: api/Projectaccess/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectAccess>> GetProjectaccess(long id)
        {
            var projectaccess = await _context.ProjectAccess.FindAsync(id);

            if (projectaccess == null)
            {
                return NotFound();
            }

            return projectaccess;
        }

        // PUT: api/Projectaccess/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectaccess(long id, ProjectAccess projectaccess)
        {
            if (id != projectaccess.Paid)
            {
                return BadRequest();
            }

            _context.Entry(projectaccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectaccessExists(id))
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

        // POST: api/Projectaccess
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectAccess>> PostProjectaccess(ProjectAccess projectaccess)
        {
            _context.ProjectAccess.Add(projectaccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectaccess", new { id = projectaccess.Paid }, projectaccess);
        }

        // DELETE: api/Projectaccess/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectAccess>> DeleteProjectaccess(long id)
        {
            var projectaccess = await _context.ProjectAccess.FindAsync(id);
            if (projectaccess == null)
            {
                return NotFound();
            }

            _context.ProjectAccess.Remove(projectaccess);
            await _context.SaveChangesAsync();

            return projectaccess;
        }

        private bool ProjectaccessExists(long id)
        {
            return _context.ProjectAccess.Any(e => e.Paid == id);
        }
    }
}
