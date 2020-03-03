using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace ClientBlazor.Server.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectaccessController : ControllerBase
    {
        private readonly localContext _context;

        public ProjectaccessController(localContext context)
        {
            _context = context;
        }

        // GET: api/Projectaccess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projectaccess>>> GetProjectaccess()
        {
            return await _context.Projectaccess.ToListAsync();
        }

        // GET: api/Projectaccess/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projectaccess>> GetProjectaccess(long id)
        {
            var projectaccess = await _context.Projectaccess.FindAsync(id);

            if (projectaccess == null)
            {
                return NotFound();
            }

            return projectaccess;
        }

        // PUT: api/Projectaccess/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectaccess(long id, Projectaccess projectaccess)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Projectaccess>> PostProjectaccess(Projectaccess projectaccess)
        {
            _context.Projectaccess.Add(projectaccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectaccess", new { id = projectaccess.Paid }, projectaccess);
        }

        // DELETE: api/Projectaccess/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projectaccess>> DeleteProjectaccess(long id)
        {
            var projectaccess = await _context.Projectaccess.FindAsync(id);
            if (projectaccess == null)
            {
                return NotFound();
            }

            _context.Projectaccess.Remove(projectaccess);
            await _context.SaveChangesAsync();

            return projectaccess;
        }

        private bool ProjectaccessExists(long id)
        {
            return _context.Projectaccess.Any(e => e.Paid == id);
        }
    }
}
