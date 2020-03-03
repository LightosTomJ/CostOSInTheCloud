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
    public class Projectwbs2Controller : ControllerBase
    {
        private readonly projectContext _context;

        public Projectwbs2Controller(projectContext context)
        {
            _context = context;
        }

        // GET: api/Projectwbs2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projectwbs2>>> GetProjectwbs2()
        {
            return await _context.Projectwbs2.ToListAsync();
        }

        // GET: api/Projectwbs2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projectwbs2>> GetProjectwbs2(long id)
        {
            var projectwbs2 = await _context.Projectwbs2.FindAsync(id);

            if (projectwbs2 == null)
            {
                return NotFound();
            }

            return projectwbs2;
        }

        // PUT: api/Projectwbs2/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectwbs2(long id, Projectwbs2 projectwbs2)
        {
            if (id != projectwbs2.Projectwbsid)
            {
                return BadRequest();
            }

            _context.Entry(projectwbs2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Projectwbs2Exists(id))
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

        // POST: api/Projectwbs2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Projectwbs2>> PostProjectwbs2(Projectwbs2 projectwbs2)
        {
            _context.Projectwbs2.Add(projectwbs2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectwbs2", new { id = projectwbs2.Projectwbsid }, projectwbs2);
        }

        // DELETE: api/Projectwbs2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projectwbs2>> DeleteProjectwbs2(long id)
        {
            var projectwbs2 = await _context.Projectwbs2.FindAsync(id);
            if (projectwbs2 == null)
            {
                return NotFound();
            }

            _context.Projectwbs2.Remove(projectwbs2);
            await _context.SaveChangesAsync();

            return projectwbs2;
        }

        private bool Projectwbs2Exists(long id)
        {
            return _context.Projectwbs2.Any(e => e.Projectwbsid == id);
        }
    }
}
