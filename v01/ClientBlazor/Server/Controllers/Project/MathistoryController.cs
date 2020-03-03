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
    public class MathistoryController : ControllerBase
    {
        private readonly projectContext _context;

        public MathistoryController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Mathistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mathistory>>> GetMathistory()
        {
            return await _context.Mathistory.ToListAsync();
        }

        // GET: api/Mathistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mathistory>> GetMathistory(long id)
        {
            var mathistory = await _context.Mathistory.FindAsync(id);

            if (mathistory == null)
            {
                return NotFound();
            }

            return mathistory;
        }

        // PUT: api/Mathistory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMathistory(long id, Mathistory mathistory)
        {
            if (id != mathistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(mathistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MathistoryExists(id))
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

        // POST: api/Mathistory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mathistory>> PostMathistory(Mathistory mathistory)
        {
            _context.Mathistory.Add(mathistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMathistory", new { id = mathistory.Id }, mathistory);
        }

        // DELETE: api/Mathistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mathistory>> DeleteMathistory(long id)
        {
            var mathistory = await _context.Mathistory.FindAsync(id);
            if (mathistory == null)
            {
                return NotFound();
            }

            _context.Mathistory.Remove(mathistory);
            await _context.SaveChangesAsync();

            return mathistory;
        }

        private bool MathistoryExists(long id)
        {
            return _context.Mathistory.Any(e => e.Id == id);
        }
    }
}
