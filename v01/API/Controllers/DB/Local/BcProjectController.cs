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
    public class BcProjectController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcProjectController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcProject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcProject>>> GetBcProject()
        {
            return await _context.BcProject.ToListAsync();
        }

        // GET: api/BcProject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcProject>> GetBcProject(long id)
        {
            var bcProject = await _context.BcProject.FindAsync(id);

            if (bcProject == null)
            {
                return NotFound();
            }

            return bcProject;
        }

        // PUT: api/BcProject/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcProject(long id, BcProject bcProject)
        {
            if (id != bcProject.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcProjectExists(id))
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

        // POST: api/BcProject
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcProject>> PostBcProject(BcProject bcProject)
        {
            _context.BcProject.Add(bcProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcProject", new { id = bcProject.Id }, bcProject);
        }

        // DELETE: api/BcProject/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcProject>> DeleteBcProject(long id)
        {
            var bcProject = await _context.BcProject.FindAsync(id);
            if (bcProject == null)
            {
                return NotFound();
            }

            _context.BcProject.Remove(bcProject);
            await _context.SaveChangesAsync();

            return bcProject;
        }

        private bool BcProjectExists(long id)
        {
            return _context.BcProject.Any(e => e.Id == id);
        }
    }
}
