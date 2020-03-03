using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Results;

namespace ClientBlazor.Server.Controllers.Results
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaborPartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public LaborPartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/LaborPartial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaborPartial>>> GetLaborPartial()
        {
            return await _context.LaborPartial.ToListAsync();
        }

        // GET: api/LaborPartial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaborPartial>> GetLaborPartial(int id)
        {
            var laborPartial = await _context.LaborPartial.FindAsync(id);

            if (laborPartial == null)
            {
                return NotFound();
            }

            return laborPartial;
        }

        // PUT: api/LaborPartial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaborPartial(int id, LaborPartial laborPartial)
        {
            if (id != laborPartial.Id)
            {
                return BadRequest();
            }

            _context.Entry(laborPartial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaborPartialExists(id))
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

        // POST: api/LaborPartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LaborPartial>> PostLaborPartial(LaborPartial laborPartial)
        {
            _context.LaborPartial.Add(laborPartial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LaborPartialExists(laborPartial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLaborPartial", new { id = laborPartial.Id }, laborPartial);
        }

        // DELETE: api/LaborPartial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LaborPartial>> DeleteLaborPartial(int id)
        {
            var laborPartial = await _context.LaborPartial.FindAsync(id);
            if (laborPartial == null)
            {
                return NotFound();
            }

            _context.LaborPartial.Remove(laborPartial);
            await _context.SaveChangesAsync();

            return laborPartial;
        }

        private bool LaborPartialExists(int id)
        {
            return _context.LaborPartial.Any(e => e.Id == id);
        }
    }
}
