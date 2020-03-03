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
    public class EquhistoryController : ControllerBase
    {
        private readonly projectContext _context;

        public EquhistoryController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Equhistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equhistory>>> GetEquhistory()
        {
            return await _context.Equhistory.ToListAsync();
        }

        // GET: api/Equhistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equhistory>> GetEquhistory(long id)
        {
            var equhistory = await _context.Equhistory.FindAsync(id);

            if (equhistory == null)
            {
                return NotFound();
            }

            return equhistory;
        }

        // PUT: api/Equhistory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquhistory(long id, Equhistory equhistory)
        {
            if (id != equhistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(equhistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquhistoryExists(id))
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

        // POST: api/Equhistory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Equhistory>> PostEquhistory(Equhistory equhistory)
        {
            _context.Equhistory.Add(equhistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquhistory", new { id = equhistory.Id }, equhistory);
        }

        // DELETE: api/Equhistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Equhistory>> DeleteEquhistory(long id)
        {
            var equhistory = await _context.Equhistory.FindAsync(id);
            if (equhistory == null)
            {
                return NotFound();
            }

            _context.Equhistory.Remove(equhistory);
            await _context.SaveChangesAsync();

            return equhistory;
        }

        private bool EquhistoryExists(long id)
        {
            return _context.Equhistory.Any(e => e.Id == id);
        }
    }
}
