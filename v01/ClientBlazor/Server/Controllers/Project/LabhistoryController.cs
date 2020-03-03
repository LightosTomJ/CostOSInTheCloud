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
    public class LabhistoryController : ControllerBase
    {
        private readonly projectContext _context;

        public LabhistoryController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Labhistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Labhistory>>> GetLabhistory()
        {
            return await _context.Labhistory.ToListAsync();
        }

        // GET: api/Labhistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Labhistory>> GetLabhistory(long id)
        {
            var labhistory = await _context.Labhistory.FindAsync(id);

            if (labhistory == null)
            {
                return NotFound();
            }

            return labhistory;
        }

        // PUT: api/Labhistory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabhistory(long id, Labhistory labhistory)
        {
            if (id != labhistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(labhistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabhistoryExists(id))
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

        // POST: api/Labhistory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Labhistory>> PostLabhistory(Labhistory labhistory)
        {
            _context.Labhistory.Add(labhistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabhistory", new { id = labhistory.Id }, labhistory);
        }

        // DELETE: api/Labhistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Labhistory>> DeleteLabhistory(long id)
        {
            var labhistory = await _context.Labhistory.FindAsync(id);
            if (labhistory == null)
            {
                return NotFound();
            }

            _context.Labhistory.Remove(labhistory);
            await _context.SaveChangesAsync();

            return labhistory;
        }

        private bool LabhistoryExists(long id)
        {
            return _context.Labhistory.Any(e => e.Id == id);
        }
    }
}
