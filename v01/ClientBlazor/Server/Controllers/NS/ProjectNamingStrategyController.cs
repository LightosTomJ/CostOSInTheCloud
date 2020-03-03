using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.NS;

namespace ClientBlazor.Server.Controllers.NS
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectNamingStrategyController : ControllerBase
    {
        private readonly nsContext _context;

        public ProjectNamingStrategyController(nsContext context)
        {
            _context = context;
        }

        // GET: api/ProjectNamingStrategy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectNamingStrategy>>> GetProjectNamingStrategy()
        {
            return await _context.ProjectNamingStrategy.ToListAsync();
        }

        // GET: api/ProjectNamingStrategy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectNamingStrategy>> GetProjectNamingStrategy(int id)
        {
            var projectNamingStrategy = await _context.ProjectNamingStrategy.FindAsync(id);

            if (projectNamingStrategy == null)
            {
                return NotFound();
            }

            return projectNamingStrategy;
        }

        // PUT: api/ProjectNamingStrategy/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectNamingStrategy(int id, ProjectNamingStrategy projectNamingStrategy)
        {
            if (id != projectNamingStrategy.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectNamingStrategy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectNamingStrategyExists(id))
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

        // POST: api/ProjectNamingStrategy
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProjectNamingStrategy>> PostProjectNamingStrategy(ProjectNamingStrategy projectNamingStrategy)
        {
            _context.ProjectNamingStrategy.Add(projectNamingStrategy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectNamingStrategyExists(projectNamingStrategy.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectNamingStrategy", new { id = projectNamingStrategy.Id }, projectNamingStrategy);
        }

        // DELETE: api/ProjectNamingStrategy/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectNamingStrategy>> DeleteProjectNamingStrategy(int id)
        {
            var projectNamingStrategy = await _context.ProjectNamingStrategy.FindAsync(id);
            if (projectNamingStrategy == null)
            {
                return NotFound();
            }

            _context.ProjectNamingStrategy.Remove(projectNamingStrategy);
            await _context.SaveChangesAsync();

            return projectNamingStrategy;
        }

        private bool ProjectNamingStrategyExists(int id)
        {
            return _context.ProjectNamingStrategy.Any(e => e.Id == id);
        }
    }
}
