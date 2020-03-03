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
    public class SubcontractorPartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public SubcontractorPartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/SubcontractorPartial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubcontractorPartial>>> GetSubcontractorPartial()
        {
            return await _context.SubcontractorPartial.ToListAsync();
        }

        // GET: api/SubcontractorPartial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubcontractorPartial>> GetSubcontractorPartial(int id)
        {
            var subcontractorPartial = await _context.SubcontractorPartial.FindAsync(id);

            if (subcontractorPartial == null)
            {
                return NotFound();
            }

            return subcontractorPartial;
        }

        // PUT: api/SubcontractorPartial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcontractorPartial(int id, SubcontractorPartial subcontractorPartial)
        {
            if (id != subcontractorPartial.Id)
            {
                return BadRequest();
            }

            _context.Entry(subcontractorPartial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcontractorPartialExists(id))
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

        // POST: api/SubcontractorPartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SubcontractorPartial>> PostSubcontractorPartial(SubcontractorPartial subcontractorPartial)
        {
            _context.SubcontractorPartial.Add(subcontractorPartial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubcontractorPartialExists(subcontractorPartial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubcontractorPartial", new { id = subcontractorPartial.Id }, subcontractorPartial);
        }

        // DELETE: api/SubcontractorPartial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubcontractorPartial>> DeleteSubcontractorPartial(int id)
        {
            var subcontractorPartial = await _context.SubcontractorPartial.FindAsync(id);
            if (subcontractorPartial == null)
            {
                return NotFound();
            }

            _context.SubcontractorPartial.Remove(subcontractorPartial);
            await _context.SaveChangesAsync();

            return subcontractorPartial;
        }

        private bool SubcontractorPartialExists(int id)
        {
            return _context.SubcontractorPartial.Any(e => e.Id == id);
        }
    }
}
