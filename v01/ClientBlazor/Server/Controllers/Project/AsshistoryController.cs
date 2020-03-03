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
    public class AsshistoryController : ControllerBase
    {
        private readonly projectContext _context;

        public AsshistoryController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Asshistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asshistory>>> GetAsshistory()
        {
            return await _context.Asshistory.ToListAsync();
        }

        // GET: api/Asshistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asshistory>> GetAsshistory(long id)
        {
            var asshistory = await _context.Asshistory.FindAsync(id);

            if (asshistory == null)
            {
                return NotFound();
            }

            return asshistory;
        }

        // PUT: api/Asshistory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsshistory(long id, Asshistory asshistory)
        {
            if (id != asshistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(asshistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsshistoryExists(id))
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

        // POST: api/Asshistory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Asshistory>> PostAsshistory(Asshistory asshistory)
        {
            _context.Asshistory.Add(asshistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsshistory", new { id = asshistory.Id }, asshistory);
        }

        // DELETE: api/Asshistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asshistory>> DeleteAsshistory(long id)
        {
            var asshistory = await _context.Asshistory.FindAsync(id);
            if (asshistory == null)
            {
                return NotFound();
            }

            _context.Asshistory.Remove(asshistory);
            await _context.SaveChangesAsync();

            return asshistory;
        }

        private bool AsshistoryExists(long id)
        {
            return _context.Asshistory.Any(e => e.Id == id);
        }
    }
}
