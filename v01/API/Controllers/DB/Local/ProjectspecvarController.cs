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
    public class ProjectspecvarController : ControllerBase
    {
        private readonly LocalContext _context;

        public ProjectspecvarController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Projectspecvar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectSpecVar>>> GetProjectspecvar()
        {
            return await _context.ProjectSpecVar.ToListAsync();
        }

        // GET: api/Projectspecvar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectSpecVar>> GetProjectspecvar(long id)
        {
            var projectspecvar = await _context.ProjectSpecVar.FindAsync(id);

            if (projectspecvar == null)
            {
                return NotFound();
            }

            return projectspecvar;
        }

        // PUT: api/Projectspecvar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectspecvar(long id, ProjectSpecVar projectspecvar)
        {
            if (id != projectspecvar.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectspecvar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectspecvarExists(id))
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

        // POST: api/Projectspecvar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectSpecVar>> PostProjectspecvar(ProjectSpecVar projectspecvar)
        {
            _context.ProjectSpecVar.Add(projectspecvar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectspecvar", new { id = projectspecvar.Id }, projectspecvar);
        }

        // DELETE: api/Projectspecvar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectSpecVar>> DeleteProjectspecvar(long id)
        {
            var projectspecvar = await _context.ProjectSpecVar.FindAsync(id);
            if (projectspecvar == null)
            {
                return NotFound();
            }

            _context.ProjectSpecVar.Remove(projectspecvar);
            await _context.SaveChangesAsync();

            return projectspecvar;
        }

        private bool ProjectspecvarExists(long id)
        {
            return _context.ProjectSpecVar.Any(e => e.Id == id);
        }
    }
}
