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
    public class SubhistoryController : ControllerBase
    {
        private readonly projectContext _context;

        public SubhistoryController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Subhistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subhistory>>> GetSubhistory()
        {
            return await _context.Subhistory.ToListAsync();
        }

        // GET: api/Subhistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subhistory>> GetSubhistory(long id)
        {
            var subhistory = await _context.Subhistory.FindAsync(id);

            if (subhistory == null)
            {
                return NotFound();
            }

            return subhistory;
        }

        // PUT: api/Subhistory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubhistory(long id, Subhistory subhistory)
        {
            if (id != subhistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(subhistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubhistoryExists(id))
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

        // POST: api/Subhistory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Subhistory>> PostSubhistory(Subhistory subhistory)
        {
            _context.Subhistory.Add(subhistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubhistory", new { id = subhistory.Id }, subhistory);
        }

        // DELETE: api/Subhistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subhistory>> DeleteSubhistory(long id)
        {
            var subhistory = await _context.Subhistory.FindAsync(id);
            if (subhistory == null)
            {
                return NotFound();
            }

            _context.Subhistory.Remove(subhistory);
            await _context.SaveChangesAsync();

            return subhistory;
        }

        private bool SubhistoryExists(long id)
        {
            return _context.Subhistory.Any(e => e.Id == id);
        }
    }
}
