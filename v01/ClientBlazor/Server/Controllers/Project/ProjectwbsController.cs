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
    public class ProjectwbsController : ControllerBase
    {
        private readonly projectContext _context;

        public ProjectwbsController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Projectwbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projectwbs>>> GetProjectwbs()
        {
            return await _context.Projectwbs.ToListAsync();
        }

        // GET: api/Projectwbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projectwbs>> GetProjectwbs(long id)
        {
            var projectwbs = await _context.Projectwbs.FindAsync(id);

            if (projectwbs == null)
            {
                return NotFound();
            }

            return projectwbs;
        }

        // PUT: api/Projectwbs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectwbs(long id, Projectwbs projectwbs)
        {
            if (id != projectwbs.Projectwbsid)
            {
                return BadRequest();
            }

            _context.Entry(projectwbs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectwbsExists(id))
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

        // POST: api/Projectwbs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Projectwbs>> PostProjectwbs(Projectwbs projectwbs)
        {
            _context.Projectwbs.Add(projectwbs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectwbs", new { id = projectwbs.Projectwbsid }, projectwbs);
        }

        // DELETE: api/Projectwbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projectwbs>> DeleteProjectwbs(long id)
        {
            var projectwbs = await _context.Projectwbs.FindAsync(id);
            if (projectwbs == null)
            {
                return NotFound();
            }

            _context.Projectwbs.Remove(projectwbs);
            await _context.SaveChangesAsync();

            return projectwbs;
        }

        private bool ProjectwbsExists(long id)
        {
            return _context.Projectwbs.Any(e => e.Projectwbsid == id);
        }
    }
}
